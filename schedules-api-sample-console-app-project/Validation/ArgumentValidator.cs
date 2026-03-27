/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Validation
{
    public class ArgumentValidator
    {
        public ValidationResult ValidateSchedule(string? schedule)
        {
            if (string.IsNullOrWhiteSpace(schedule) || schedule == "<Add schedule ID here>")
            {
                return ValidationResult.Failure("--schedule argument must be set.");
            }

            return ValidationResult.Success();
        }

        public ValidationResult ValidateMutualExclusivity(bool getSchedule, bool post, bool pagination, bool getAll, bool getSingle)
        {
            int argumentCount = 0;
            if (getSchedule) argumentCount++;
            if (post) argumentCount++;
            if (pagination) argumentCount++;
            if (getAll) argumentCount++;
            if (getSingle) argumentCount++;

            if (argumentCount > 1)
            {
                return ValidationResult.Failure("Cannot set multiple functionality arguments (post, getschedule, getsingle, getall, pagination) at once. Select only one of these options.");
            }

            return ValidationResult.Success();
        }

        public ValidationResult ValidateAll(string? schedule, bool getSchedule, bool post, bool pagination, bool getAll, bool getSingle)
        {
            var scheduleValidation = ValidateSchedule(schedule);
            if (!scheduleValidation.IsValid)
                return scheduleValidation;

            var mutualExclusivityValidation = ValidateMutualExclusivity(getSchedule, post, pagination, getAll, getSingle);
            if (!mutualExclusivityValidation.IsValid)
                return mutualExclusivityValidation;



            return ValidationResult.Success();
        }
    }
}
