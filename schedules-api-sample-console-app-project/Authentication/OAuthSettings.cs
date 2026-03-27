/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Authentication
{
    public record OAuthSettings(
        string ClientId,
        string ClientSecret,
        string RedirectUri,
        string TokenEndpoint,
        string AuthorizeEndpoint,
        string Scope);
}
