/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Models.Schedules
{
    public class ScheduleGetItem
    {
        public string? Id { get; set; }
        public string? iModelId { get; set; }
        public string? iTwinId { get; set; }
        public bool? IsNextGen { get; set; }
        public string? Name { get; set; }
        public string? type { get; set; }
    }
}
