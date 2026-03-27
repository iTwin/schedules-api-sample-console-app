/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Models.Resources
{
    public class ResourceStatusHistoryResponse
    {
        public Operation? Operation { get; set; }
        public StatusHistoryItem? StatusHistoryItem { get; set; }
        public OperationLocattion? _links { get; set; }
    }

    public class Operation
    {
        public string? Id { get; set; }
    }

    public class StatusHistoryItem
    {
        public string? Id { get; set; }
    }

    public class OperationLocattion
    {
        public LinkHref? OperationLocation { get; set; }
    }

    public class LinkHref
    {
        public string? Href { get; set; }
    }
}
