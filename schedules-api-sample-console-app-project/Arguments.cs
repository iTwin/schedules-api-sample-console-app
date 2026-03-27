/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp
{
    public record Arguments(string Schedule, bool GetSchedule, bool Post, bool Pagination, bool GetAll, bool GetSingle, string? ClientId, string? ClientSecret);
}
