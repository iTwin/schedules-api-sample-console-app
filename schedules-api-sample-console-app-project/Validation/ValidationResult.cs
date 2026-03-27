/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Validation
{
    public class ValidationResult
    {
        public bool IsValid { get; }
        public string? ErrorMessage { get; }

        private ValidationResult(bool isValid, string? errorMessage = null)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public static ValidationResult Success() => new(true);
        public static ValidationResult Failure(string errorMessage) => new(false, errorMessage);
    }
}
