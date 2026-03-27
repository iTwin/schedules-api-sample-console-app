/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace SchedulesApiSampleConsoleApp.Authentication
{
    /// <summary>
    /// Implements OAuth 2.0 authorization code flow for authentication.
    /// Opens a browser for user login, listens on a local HTTP server for the callback,
    /// and exchanges the authorization code for an access token.
    /// This will use the settings provided in the Configuration file to determine the endpoints and client information for the OAuth flow.
    /// </summary>
    public class OAuthAuthenticator : IAuthenticator
    {
        private readonly OAuthSettings _settings;

        public OAuthAuthenticator(OAuthSettings settings)
        {
            _settings = settings;
        }

        public async Task<TokenResponse> AuthenticateAsync()
        {
            string? authCode = null;

            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add(_settings.RedirectUri);
                listener.Start();

                var authUrl = $"{_settings.AuthorizeEndpoint}?" +
                    $"response_type=code&" +
                    $"client_id={Uri.EscapeDataString(_settings.ClientId)}&" +
                    $"redirect_uri={Uri.EscapeDataString(_settings.RedirectUri)}&" +
                    $"scope={Uri.EscapeDataString(_settings.Scope)}";

                Process.Start(new ProcessStartInfo
                {
                    FileName = authUrl,
                    UseShellExecute = true
                });

                var context = await listener.GetContextAsync();
                authCode = context.Request.QueryString["code"];

                var responseString = "<html><body>You may now close this window.</body></html>";
                var buffer = Encoding.UTF8.GetBytes(responseString);
                context.Response.ContentLength64 = buffer.Length;
                await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();

                if (string.IsNullOrEmpty(authCode))
                {
                    throw new InvalidOperationException("Authorization code not found.");
                }
            }

            return await ExchangeCodeForTokenAsync(authCode);
        }

        private async Task<TokenResponse> ExchangeCodeForTokenAsync(string code)
        {
            using var httpClient = new HttpClient();
            
            var requestBody = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", code },
                { "redirect_uri", _settings.RedirectUri },
                { "client_id", _settings.ClientId },
                { "client_secret", _settings.ClientSecret }
            };

            var response = await httpClient.PostAsync(
                _settings.TokenEndpoint,
                new FormUrlEncodedContent(requestBody)
            );

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Failed to get token: {response.StatusCode}. {errorContent}");
            }

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            
            return new TokenResponse(
                AccessToken: json.GetProperty("access_token").GetString() ?? throw new InvalidOperationException("Access token not found in response"),
                TokenType: json.GetProperty("token_type").GetString() ?? "Bearer",
                ExpiresIn: json.GetProperty("expires_in").GetInt32(),
                RefreshToken: json.TryGetProperty("refresh_token", out var refreshToken) ? refreshToken.GetString() : null,
                Scope: json.TryGetProperty("scope", out var scope) ? scope.GetString() : null
            );
        }
    }
}
