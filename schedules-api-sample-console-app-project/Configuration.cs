/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Authentication;

namespace SchedulesApiSampleConsoleApp
{
    public record Configuration(Uri ServiceHost, OAuthSettings OAuth);
}