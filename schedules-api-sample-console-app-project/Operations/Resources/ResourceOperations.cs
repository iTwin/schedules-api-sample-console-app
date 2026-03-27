/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Models.Http;
using SchedulesApiSampleConsoleApp.Models.Resources;

namespace SchedulesApiSampleConsoleApp.Operations.Resources
{
    internal class ResourceOperations
    {
        private readonly HttpClient _client;

        internal ResourceOperations(HttpClient client)
        {
            _client = client;
        }

        internal async Task<ResourceGet?> FetchResourceAsync(string schedule)
        {
            var get = new HttpGet($"schedules/{schedule}/resources", _client);
            return await get.GetJson<ResourceGet>();
        }

        internal async Task<ResourceGetItem?> FetchSingleResourceItemAsync(string schedule, string id)
        {
            var get = new HttpGet($"schedules/{schedule}/resources/{id}", _client);
            return await get.GetJson<ResourceGetItem>();
        }

        internal async Task<ResourceStatusHistoryGet?> FetchResourceStatusHistoryAsync(string schedule, string resourceId)
        {
            var get = new HttpGet($"schedules/{schedule}/resources/{resourceId}/status-history", _client);
            return await get.GetJson<ResourceStatusHistoryGet>();
        }

        internal async Task<ResourceStatusHistoryGetItem?> FetchSingleResourceStatusHistoryItemAsync(string schedule, string id)
        {
            var get = new HttpGet($"/schedules/{schedule}/resources/status-history/{id}", _client);
            return await get.GetJson<ResourceStatusHistoryGetItem>();
        }

        internal async Task<dynamic?> PostResourceStatusHistoryAsync(string schedule, ResourceStatusPostItem data)
        {
            var post = new HttpPost($"schedules/{schedule}/resources/status-history", _client);
            return await post.Post(data);
        }
    }
}
