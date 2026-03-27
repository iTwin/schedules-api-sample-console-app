/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Models.Http;
using SchedulesApiSampleConsoleApp.Models.Operations;

namespace SchedulesApiSampleConsoleApp.Operations.Operation
{
    internal class OperationOperations
    {
        private readonly HttpClient _client;

        internal OperationOperations(HttpClient client)
        {
            _client = client;
        }

        internal async Task<OperationGet?> FetchOperationAsync(string schedule, string top, string next)
        {
            var url = !string.IsNullOrEmpty(next)
                ? next
                : string.IsNullOrEmpty(top) ? $"schedules/{schedule}/tasks" : $"schedules/{schedule}/tasks?$top={top}";

            var get = new HttpGet(url, _client);
            return await get.GetJson<OperationGet>();
        }

        internal async Task<OperationGet?> FetchSingleOperationItemAsync(string schedule, string id)
        {
            var get = new HttpGet($"schedules/{schedule}/operations/{id}", _client);
            return await get.GetJson<OperationGet>();
        }
    }
}
