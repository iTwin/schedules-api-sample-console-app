/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Operations.Operation;
using SchedulesApiSampleConsoleApp.Operations.Resources;
using SchedulesApiSampleConsoleApp.Operations.Tasks;
using SchedulesApiSampleConsoleApp.Validation;

namespace SchedulesApiSampleConsoleApp.Samples
{
    internal class DefaultSample : ISample
    {
        private readonly GetAllSample _getAllSample;
        private readonly GetSingleSample _getSingleSample;
        public string _requestUri { get; }

        public DefaultSample(ResourceOperations resourceOperations, TaskOperations taskOperations, OperationOperations operationOperations, Configuration configuration)
        {
            var validator = new ResourceStatusPostValidator();
            _getAllSample = new GetAllSample(taskOperations, configuration);
            _getSingleSample = new GetSingleSample(taskOperations, configuration);
            _requestUri = configuration.ServiceHost.ToString();
        }

        public async Task ExecuteAsync(string scheduleId)
        {
            await _getSingleSample.ExecuteAsync(scheduleId);
            await _getAllSample.ExecuteAsync(scheduleId);
        }
    }
}
