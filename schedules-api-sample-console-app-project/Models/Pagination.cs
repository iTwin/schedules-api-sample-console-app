/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Models
{
    public class Pagination
    {
        public Link? self { get; set; }
        public Link? next { get; set; }
    }

    public class Link
    {
        public string? href { get; set; }
    }
}
