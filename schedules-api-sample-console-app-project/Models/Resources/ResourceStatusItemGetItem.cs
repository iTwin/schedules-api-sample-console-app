/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Models.Resources
{
    public class ResourceStatusItemGetItem
    {
        public string? Id { get; set; }
        public string? Color { get; set; }
        public bool? Deleted { get; set; }
        public bool? IsVisible { get; set; }
        public string? Name { get; set; }
        public string? StatusSetId { get; set; }
        public int? Transparency { get; set; }
        public bool? UseOriginalTransparency { get; set; }
    }
}
