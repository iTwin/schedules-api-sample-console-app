/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Operations.Tasks;

namespace SchedulesApiSampleConsoleApp.Samples
{
    internal class PaginationSample : ISample
    {
        private readonly TaskOperations _taskOperations; 
        public string _requestUri { get; }

        public PaginationSample(TaskOperations taskOperations, Configuration configuration)
        {
			_taskOperations = taskOperations;
            _requestUri = configuration.ServiceHost.ToString();
        }

        public async Task ExecuteAsync(string scheduleId)
        {
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine("SAMPLE: Get All With Pagination");
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine();

            Console.WriteLine("This sample shows how to get Entities using the pagination tokens.");
            Console.WriteLine("For this example the 'Tasks' endpoint will be used.\n");

            Console.WriteLine("[ Getting the first page ]");
            Console.WriteLine("First the 'Tasks' endpoint is requested, with a top value entered.");
            Console.WriteLine("This example will use a 'Top.' value of '1' to get the first Entity.\n");

            Console.WriteLine("The GET request it so be send to the following URL.\n");
            Console.WriteLine($"Sending GET request to {_requestUri}schedules/{scheduleId}/Tasks\n");
            var allTasks = await _taskOperations.FetchTaskAsync(scheduleId, "1", "");
			Console.WriteLine();

			if (allTasks?.Tasks?.Count > 0)
			{
				var nextHref = allTasks._links?.next?.href;
				if (!string.IsNullOrEmpty(nextHref))
				{
                    Console.WriteLine("[ Getting the second page ]");
                    Console.WriteLine("To get the next Task Entity the 'next:' URL found in the response can be used.");
                    Console.WriteLine("This will get the second 'Top 1' Task Entity.\n");

                    Console.WriteLine($"Sending GET request to {allTasks._links?.next?.href}\n");
                    await _taskOperations.FetchTaskAsync(scheduleId, "1", nextHref);

                    Console.WriteLine();
                    Console.WriteLine("[ Getting further pages ]");
                    Console.WriteLine("The new 'next:' URL will return the third 'Top 1' Task Entity.");
                    Console.WriteLine("This process can be repeated until it has returned all the Tasks Entities.\n");
                }
                else
                {
                    Console.WriteLine("There were no entites found for the next pagination item.\n");
                }
			}
            else
            {
                Console.WriteLine("There were no items found for the GET request.\n");
            }
        }
    }
}
