/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Models.Resources
{
    public class ResourceGet
    {
        public List<ResourceGetItem>? Resources { get; set; }

        public string? NextPageToken { get; set; }
    }
}
