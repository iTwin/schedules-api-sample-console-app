/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Models.Http;
using SchedulesApiSampleConsoleApp.Models.Schedules;

namespace SchedulesApiSampleConsoleApp.Operations.Schedules
{
    internal class ScheduleOperations
    {
        private readonly HttpClient _client;
        internal HttpResponseMessage? LastResponse { get; private set; }

        internal ScheduleOperations(HttpClient client)
        {
            _client = client;
        }

        internal async Task<ScheduleGet> FetchSchedulesAsync(string iTwinId)
        {
            var get = new HttpGet($"schedules/?iTwinId={iTwinId}", _client);
            var result = await get.GetJson<ScheduleGet>();
            LastResponse = get.LastResponse;
            return result;
        }

        internal async Task<ScheduleGetItem?> FetchSingleScheduleAsync(string schedule)
        {
            var get = new HttpGet($"schedules/{schedule}", _client);
            return await get.GetJson<ScheduleGetItem>();
        }
    }
}
