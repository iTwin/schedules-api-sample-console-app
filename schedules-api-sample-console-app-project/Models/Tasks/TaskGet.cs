/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Models.Tasks
{
    public class TaskGet
    {
        public List<TaskGetItem>? Tasks { get; set; }

        public Pagination? _links { get; set; }
    }
}
