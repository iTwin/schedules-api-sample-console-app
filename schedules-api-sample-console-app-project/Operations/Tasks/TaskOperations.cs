/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Models.Http;
using SchedulesApiSampleConsoleApp.Models.Tasks;

namespace SchedulesApiSampleConsoleApp.Operations.Tasks
{
    internal class TaskOperations
    {
        private readonly HttpClient _client;

        internal TaskOperations(HttpClient client)
        {
            _client = client;
        }

        internal async Task<TaskGet?> FetchTaskAsync(string schedule, string top, string next)
        {
            var url = !string.IsNullOrEmpty(next)
                ? next
                : string.IsNullOrEmpty(top) ? $"schedules/{schedule}/tasks" : $"schedules/{schedule}/tasks?$top={top}";

            var get = new HttpGet(url, _client);
            return await get.GetJson<TaskGet>();
        }

        internal async Task<TaskGetItem?> FetchSingleTaskItemAsync(string schedule, string id)
        {
            var get = new HttpGet($"schedules/{schedule}/tasks/{id}", _client);
            return await get.GetJson<TaskGetItem>();
        }
    }
}
