/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Authentication
{
    public record TokenResponse(
        string AccessToken,
        string TokenType,
        int ExpiresIn,
        string? RefreshToken = null,
        string? Scope = null);
}
