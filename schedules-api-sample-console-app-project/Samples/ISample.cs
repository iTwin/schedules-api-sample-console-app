/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
namespace SchedulesApiSampleConsoleApp.Samples
{
    internal interface ISample
    {
        string _requestUri { get; }
        Task ExecuteAsync(string scheduleId);
    }
}
