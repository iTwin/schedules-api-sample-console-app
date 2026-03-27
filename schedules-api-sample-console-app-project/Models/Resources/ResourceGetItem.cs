/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Models.Resources
{
    public class ResourceGetItem
    {
        public string? Id { get; set; }
        public string? calendarId { get; set; }
        public bool? deleted { get; set; }
        public string? description { get; set; }
        public string? email { get; set; }
        public int? leadTime { get; set; }
        public string? name { get; set; }
        public string? parentId { get; set; }
        public bool? renewable { get; set; }
        public string? ruleId { get; set; }
        public string? type { get; set; }
        public string? unitType { get; set; }
        public string? url { get; set; }
        public string? userDefinedId { get; set; }
        public bool? wholeUnits { get; set; }
    }
}
