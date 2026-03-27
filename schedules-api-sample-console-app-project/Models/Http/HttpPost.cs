/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using SchedulesApiSampleConsoleApp.Models.Resources;

namespace SchedulesApiSampleConsoleApp.Models.Http
{
    public class HttpPost : HttpRequest
    {

        public HttpPost(string requestUri, HttpClient client) : base(requestUri, client) { }

        public async Task<ResourceStatusHistoryResponse> Post(ResourceStatusPostItem data)
        {
            var jsonPost = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonPost, Encoding.UTF8, "application/json");

            Console.WriteLine("POST request contains the following:");
            Console.WriteLine($"POST request :{RequestUri}");
            Console.WriteLine($"{{\n    \"date\": \"{data.Date:O}\",\n    \"id\": \"{data.Id}\",\n    \"resourceId\": \"{data.ResourceId}\",\n    \"statusCategoryId\": \"{data.StatusCategoryId}\",\n    \"statusItemId\": \"{data.StatusItemId}\"\n}}");
            Console.WriteLine();

            var response = await Client.PostAsync(RequestUri, content);
            var jsonResp = await response.Content.ReadFromJsonAsync<ResourceStatusHistoryResponse>();
            Console.WriteLine($"Response: {await response.Content.ReadAsStringAsync()}");
            Console.WriteLine();
            return jsonResp!;
        }
    }
}
