/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Operations.Tasks;

namespace SchedulesApiSampleConsoleApp.Samples
{
    internal class GetSingleSample : ISample
    {
        private readonly TaskOperations _taskOperations;
        public string _requestUri { get; }

        public GetSingleSample(TaskOperations taskOperations, Configuration configuration)
        {
            _taskOperations = taskOperations;
            _requestUri = configuration.ServiceHost.ToString();
        }

        public async Task ExecuteAsync(string scheduleId)
        {
            var taskId = "4b523e61-8de5-44de-ba64-0cfc81aade46";

            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine("SAMPLE: Get Single Task");
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine();
            
            Console.WriteLine("This sample shows how to get a single Entity from an endpoint.");
            Console.WriteLine($"For this example the 'Tasks' endpoint will be used with a provided a Task ID: {taskId}.");
            Console.WriteLine("A GET request it so be send to the following URL.\n");
            Console.WriteLine($"Sending GET request to '{_requestUri}schedules/{scheduleId}/Tasks/4b523e61-8de5-44de-ba64-0cfc81aade46'.\n");
            var result = await _taskOperations.FetchSingleTaskItemAsync(scheduleId, "4b523e61-8de5-44de-ba64-0cfc81aade46");
            if (result == null)
            {
                Console.WriteLine("There were no items found for the GET request.\n");
            }
        }
    }
}
