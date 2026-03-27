/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Operations.Schedules;

namespace SchedulesApiSampleConsoleApp.Samples
{
    internal class GetSingleScheduleSample : ISample
    {
        private readonly ScheduleOperations _scheduleOperations;
        public string _requestUri { get; }

        public GetSingleScheduleSample(ScheduleOperations scheduleOperations, Configuration configuration)
        {
            _scheduleOperations = scheduleOperations;
            _requestUri = configuration.ServiceHost.ToString();
        }

        public async Task ExecuteAsync(string scheduleId)
        {
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine("SAMPLE: Get Single Schedule");
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine();

            Console.WriteLine("This sample shows how to get a single Entity from the Schedule Endpoint.");
            Console.WriteLine("For this example the 'Schedule' endpoint will be used with a Schedule ID.");
            Console.WriteLine("A GET request it so be send to the following URL.\n");
            Console.WriteLine($"Sending GET request to {_requestUri}/schedules/{scheduleId}");
            var result = await _scheduleOperations.FetchSingleScheduleAsync(scheduleId);
            if (result == null)
            {
                Console.WriteLine("There were no items found for the GET request.\n");
            }
        }
    }
}
