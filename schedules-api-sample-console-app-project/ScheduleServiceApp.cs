/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp;
using SchedulesApiSampleConsoleApp.Samples;
using SchedulesApiSampleConsoleApp.Operations.Resources;
using SchedulesApiSampleConsoleApp.Operations.Schedules;
using SchedulesApiSampleConsoleApp.Operations.Tasks;
using System.Net;
using SchedulesApiSampleConsoleApp.Operations.Operation;

internal class ScheduleServiceApp
{
    private readonly ScheduleOperations _scheduleOperations;
    private readonly CreateSample _createSample;

    internal ScheduleServiceApp(
        ScheduleOperations scheduleOperations,
        ResourceOperations resourceOperations,
        TaskOperations taskOperations,
        OperationOperations operationOperations)
    {
        _scheduleOperations = scheduleOperations;
        _createSample = new CreateSample(scheduleOperations, resourceOperations, taskOperations, operationOperations);
    }

    internal async Task RunAsync(Arguments arguments, Configuration configuration)
    {
        var scheduleId = arguments.Schedule;

        if (!await AuthenticateAsync(scheduleId))
        {
            return;
        }

        var sample = _createSample.RunSample(arguments, configuration);
        await sample.ExecuteAsync(scheduleId);
    }

    private async Task<bool> AuthenticateAsync(string scheduleId)
    {
        Console.WriteLine("Initial query to test authorization. Fetching schedules for a given project - Queries all schedules in the specified Project.");
        var url = $"https://api.bentley.com/schedules/{scheduleId}";
        Console.WriteLine($"Sending GET request to {url}");
        var responseString = await _scheduleOperations.FetchSchedulesAsync(scheduleId);
        Console.WriteLine($"Response: {responseString}\n");

        if (_scheduleOperations.LastResponse is not { IsSuccessStatusCode: true })
        {
            Console.WriteLine("Fetching schedules for given project failed with status code: {0}.", _scheduleOperations.LastResponse?.StatusCode);

            if (_scheduleOperations.LastResponse?.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden &&
                _scheduleOperations.LastResponse.Headers.TryGetValues("WWW-Authenticate", out var reasonHeader))
            {
                Console.WriteLine("Authentication failure reason: {0}", string.Join(";", reasonHeader));
            }
            return false;
        }

        Console.WriteLine("Authentication successful");
        Console.WriteLine();

        if (responseString.Schedules == null || responseString.Schedules.Count == 0)
        {
            Console.WriteLine("No items for single schedule.");
            return false;
        }

        return true;
    }
}