/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Models.Resources;

namespace SchedulesApiSampleConsoleApp.Validation
{
    public class ResourceStatusPostValidator
    {

        public ValidationResult Validate(ResourceStatusPostItem item)
        {;

            if (item == null)
            {
                return ValidationResult.Failure("ResourceStatusPostItem cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(item.ResourceId))
            {
                return ValidationResult.Failure("ResourceId is required.");
            }

            if (string.IsNullOrWhiteSpace(item.StatusItemId))
            {
                return ValidationResult.Failure("StatusItemId is required.");
            }

            return ValidationResult.Success();
        }
    }
}
