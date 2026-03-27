/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using System.CommandLine;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using SchedulesApiSampleConsoleApp.Validation;
using SchedulesApiSampleConsoleApp.Authentication;

namespace SchedulesApiSampleConsoleApp
{
    public delegate Task RunAppAsync(Arguments arguments, Configuration configuration);

    public static class ConsoleApp
    {
        public static async Task<int> RunAsync(string[] args, RunAppAsync runAsync)
        {
            var scheduleOption = new Option<string>("--schedule") { Description = "Schedule ID to query from", Required = false };
            var paginationOption = new Option<bool>("--pagination") { Description = "Queries an endpoint using the pagination tokens to return Tasks", Required = false };
            var getScheduleOption = new Option<bool>("--getschedule") { Description = "Queries an endpoint to return a single Schedule Entity - /schedules/{schedule_id}", Required = false };
            var postOption = new Option<bool>("--post") { Description = "Send a POST request to the Resource Status History endpoint", Required = false };
            var GetAllOption = new Option<bool>("--getall") { Description = "Queries an endpoint to return all Task Entities - /schedules/{schedule_id}/tasks", Required = false };
            var GetSingleOption = new Option<bool>("--getsingle") { Description = "Queries an endpoint to return a single Task Entity - /schedules/{schedule_id}/tasks/{taskId}", Required = false };
            var clientIdOption = new Option<string>("--clientid") { Description = "OAuth Client ID (overrides appsettings.json)", Required = false };
            var clientSecretOption = new Option<string>("--clientsecret") { Description = "OAuth Client Secret (overrides appsettings.json)", Required = false };

            var rootCommand = new RootCommand
            {
                scheduleOption,
                getScheduleOption,
                postOption,
                paginationOption,
                GetAllOption,
                GetSingleOption,
                clientIdOption,
                clientSecretOption
            };
            rootCommand.Description = "External Schedule API Sample App";

            var parseResult = rootCommand.Parse(args);

            var schedule = parseResult.GetValue(scheduleOption);
            var getSchedule = parseResult.GetValue(getScheduleOption);
            var post = parseResult.GetValue(postOption);
            var pagination = parseResult.GetValue(paginationOption);
            var getAll = parseResult.GetValue(GetAllOption);
            var getSingle = parseResult.GetValue(GetSingleOption);
            var clientId = parseResult.GetValue(clientIdOption);
            var clientSecret = parseResult.GetValue(clientSecretOption);

            var validator = new ArgumentValidator();
            var validationResult = validator.ValidateAll(schedule, getSchedule, post, pagination, getAll, getSingle);

            if (!validationResult.IsValid)
            {
                Log(validationResult.ErrorMessage!);
                return 1;
            }

            var arguments = new Arguments(schedule!, getSchedule, post, pagination, getAll, getSingle, clientId, clientSecret);
            await runAsync(arguments, ReadConfiguration(arguments));
            return 0;
        }

        public static Configuration ReadConfiguration(Arguments arguments)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appsettings.json")
                .Build();

            var oauthSettings = new OAuthSettings(
                ClientId: arguments.ClientId ?? configuration["OAuth:ClientId"]!,
                ClientSecret: arguments.ClientSecret ?? configuration["OAuth:ClientSecret"]!,
                RedirectUri: configuration["OAuth:RedirectUri"]!,
                TokenEndpoint: configuration["OAuth:TokenEndpoint"]!,
                AuthorizeEndpoint: configuration["OAuth:AuthorizeEndpoint"]!,
                Scope: configuration["OAuth:Scope"]!
            );

            return new Configuration(
                ServiceHost: new Uri(configuration[nameof(Configuration.ServiceHost)]!),
                OAuth: oauthSettings);
        }

        public static void Log(string message, params object?[] args)
        {
            Console.WriteLine("{0}: {1}", DateTime.Now, string.Format(message, args));
        }
    }
}
