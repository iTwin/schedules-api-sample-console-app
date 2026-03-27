/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp;
using SchedulesApiSampleConsoleApp.Authentication;
using SchedulesApiSampleConsoleApp.Operations.Schedules;
using SchedulesApiSampleConsoleApp.Operations.Resources;
using SchedulesApiSampleConsoleApp.Operations.Tasks;
using System.Net.Http.Headers;
using SchedulesApiSampleConsoleApp.Operations.Operation;

await ConsoleApp.RunAsync(args, async (arguments, configuration) =>
{
    var authenticator = new OAuthAuthenticator(configuration.OAuth);
    var tokenResponse = await authenticator.AuthenticateAsync();

    var client = new HttpClient
    {
        BaseAddress = configuration.ServiceHost,
    };
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

    var scheduleOperations = new ScheduleOperations(client);
    var resourceOperations = new ResourceOperations(client);
    var taskOperations = new TaskOperations(client);
    var operationOperations = new OperationOperations(client);

    var app = new ScheduleServiceApp(scheduleOperations, resourceOperations, taskOperations, operationOperations);

    await app.RunAsync(arguments, configuration);
});