/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Models.Schedules
{
    public class ScheduleGet
    {
        public List<ScheduleGetItem>? Schedules { get; set; }

        public string? NextPageToken { get; set; }
    }
}
