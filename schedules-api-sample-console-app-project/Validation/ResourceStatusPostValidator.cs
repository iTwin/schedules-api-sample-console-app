/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Models.Resources;

namespace SchedulesApiSampleConsoleApp.Validation
{
    public class ResourceStatusPostValidator
    {

        public ValidationResult Validate(ResourceStatusPostItem item, string firstResourceId, string firstStatusitemId)
        {
            var resourceId = firstResourceId;
            var statusItemId = firstStatusitemId;

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

            if (!IsValidGuid(item.ResourceId))
            {
                return ValidationResult.Failure("ResourceId should be a valid GUID.");
            }

            if (!IsValidGuid(item.StatusItemId))
            {
                return ValidationResult.Failure("StatusItemId should be a valid GUID.");
            }

            if (!string.Equals(item.StatusItemId, statusItemId, StringComparison.OrdinalIgnoreCase))
            {
                return ValidationResult.Failure($"StatusItemId should be '{statusItemId}'.");
            }
            if (!string.Equals(item.ResourceId, resourceId, StringComparison.OrdinalIgnoreCase))
            {
                return ValidationResult.Failure($"ResourceId should be '{resourceId}'.");
            }

            return ValidationResult.Success();
        }

        private bool IsValidGuid(string value)
        {
            return Guid.TryParse(value, out _);
        }
    }
}
