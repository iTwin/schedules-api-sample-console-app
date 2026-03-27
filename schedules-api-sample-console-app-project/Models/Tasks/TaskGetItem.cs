/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Models.Tasks
{
    public class TaskGetItem
    {
        public string? Id { get; set; }
        public int? actualDuration { get; set; }
        public DateTime? actualFinish { get; set; }
        public double? actualPhysicalQuantity { get; set; }
        public DateTime? actualStart { get; set; }
        public string? calendarId { get; set; }
        public string? comment { get; set; }
        public DateTime? constraintEarlyDate { get; set; }
        public DateTime? constraintLateDate { get; set; }
        public string? constraintType { get; set; }
        public bool? deleted { get; set; }
        public string? durationType { get; set; }
        public double? estimatedRate { get; set; }
        public DateTime? expectedFinish { get; set; }
        public bool? isWbs { get; set; }
        public string? name { get; set; }
        public string? parentId { get; set; }
        public int? percentComplete { get; set; }
        public double? physicalQuantity { get; set; }
        public string? physicalQuantityUnit { get; set; }
        public int? plannedDuration { get; set; }
        public DateTime? plannedFinish { get; set; }
        public double? plannedPhysicalQuantity { get; set; }
        public DateTime? plannedStart { get; set; }
        public string? progressType { get; set; }
        public int? remainingDuration { get; set; }
        public double? remainingPhysicalQuantity { get; set; }
        public string? ruleId { get; set; }
        public string? status { get; set; }
        public string? statusId { get; set; }
        public string? type { get; set; }
        public string? url { get; set; }
        public string? userDefinedId { get; set; }
    }
}