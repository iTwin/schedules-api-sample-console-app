/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Models.Operations
{
    public class OperationGetItem
    {
        public string? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Status { get; set; }
        public string? SubStatus { get; set; }
        public string? FailureDescription { get; set; }
        public double? PercentComplete { get; set; }
        public bool? IsSynced { get; set; }

    }
}