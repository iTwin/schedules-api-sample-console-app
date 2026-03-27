/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Models.Resources;

namespace SchedulesApiSampleConsoleApp.Validation
{
    public class ResourceStatusPostValidator
    {
        private const string statusCategoryId = "2bf087ec-d6cf-4f63-b1a2-70da8d9d9364";
        private const string statusItemId = "c8b6cb23-6e15-4d0f-8b85-93fac81ebdf8";

        public ValidationResult Validate(ResourceStatusPostItem item)
        {
            if (item == null)
            {
                return ValidationResult.Failure("ResourceStatusPostItem cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(item.ResourceId))
            {
                return ValidationResult.Failure("ResourceId is required.");
            }

            if (string.IsNullOrWhiteSpace(item.StatusCategoryId))
            {
                return ValidationResult.Failure("StatusCategoryId is required.");
            }

            if (string.IsNullOrWhiteSpace(item.StatusItemId))
            {
                return ValidationResult.Failure("StatusItemId is required.");
            }

            if (!IsValidGuid(item.ResourceId))
            {
                return ValidationResult.Failure("ResourceId should be a valid GUID.");
            }

            if (!IsValidGuid(item.StatusCategoryId))
            {
                return ValidationResult.Failure("StatusCategoryId should be a valid GUID.");
            }

            if (!IsValidGuid(item.StatusItemId))
            {
                return ValidationResult.Failure("StatusItemId should be a valid GUID.");
            }

            if (!string.Equals(item.StatusCategoryId, statusCategoryId, StringComparison.OrdinalIgnoreCase))
            {
                return ValidationResult.Failure($"StatusCategoryId should be '{statusCategoryId}'.");
            }

            if (!string.Equals(item.StatusItemId, statusItemId, StringComparison.OrdinalIgnoreCase))
            {
                return ValidationResult.Failure($"StatusItemId should be '{statusItemId}'.");
            }

            return ValidationResult.Success();
        }

        private bool IsValidGuid(string value)
        {
            return Guid.TryParse(value, out _);
        }
    }
}
