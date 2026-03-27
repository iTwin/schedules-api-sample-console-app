/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Operations.Tasks;

namespace SchedulesApiSampleConsoleApp.Samples
{
    internal class GetAllSample : ISample
    {
        private readonly TaskOperations _taskOperations;
        public string _requestUri { get; }

        public GetAllSample(TaskOperations taskOperations, Configuration configuration)
        {
            _taskOperations = taskOperations;
            _requestUri = configuration.ServiceHost.ToString();
        }

        public async Task ExecuteAsync(string scheduleId)
        {
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine("SAMPLE: Get All Tasks");
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine();

            Console.WriteLine("This sample shows how to get a all Entities from an endpoint.");
            Console.WriteLine("For this example the 'Tasks' endpoint will be used.");
            Console.WriteLine("A GET request is to be sent to the following URL.\n");
            Console.WriteLine($"Sending GET request to {_requestUri}schedules/{scheduleId}/Tasks\n");
            var result = await _taskOperations.FetchTaskAsync(scheduleId, "", "");
            if (result == null || result.Tasks == null || result.Tasks.Count == 0)
            {
                Console.WriteLine("There were no items found for the GET request.\n");
            }
        }
    }
}
