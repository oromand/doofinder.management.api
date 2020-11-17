using doofinder.management.api.Models;
using doofinder.management.api.Models.ProcessingTasks;
using RestSharp;

namespace doofinder.management.api
{
    public class ManagementRequester
    {
        private readonly string apiKey;
        private readonly string baseUrl;
        private readonly RestClient _client;

        public ManagementRequester(string apiKey, string baseUrl = "https://eu1-api.doofinder.com/v1")
        {
            this.apiKey = apiKey;
            this.baseUrl = baseUrl;

            this._client = new RestClient(baseUrl);
            _client.AddDefaultHeader("Authorization", $"Token {apiKey}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        public System.Threading.Tasks.Task<Models.ManagementApiResponse<Models.ProcessingTasks.ProcessDataFeedResponse>> ProcessDataFeed(string hashId, bool force = false)
        {
            ManagementApiResponse<ProcessDataFeedResponse> result = new ManagementApiResponse<ProcessDataFeedResponse>();

            string requestUri = $"{hashId}/tasks/process?force={force.ToString().ToLowerInvariant()}";
            RestRequest request = new RestRequest(requestUri, Method.POST);

            var response = _client.Execute(request);
            result.HttpResponse = response;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Data = Newtonsoft.Json.JsonConvert.DeserializeObject<ProcessDataFeedResponse>(response.Content);
            }


            return System.Threading.Tasks.Task.FromResult(result);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public System.Threading.Tasks.Task<Models.ManagementApiResponse<Models.ProcessingTasks.ProcessDataFeedResponse>> GetTaskDetails(string hashId, string taskId)
        {
            ManagementApiResponse<ProcessDataFeedResponse> result = new ManagementApiResponse<ProcessDataFeedResponse>();

            string requestUri = $"{hashId}/tasks/{taskId}";
            RestRequest request = new RestRequest(requestUri, Method.GET);

            var response = _client.Execute(request);
            result.HttpResponse = response;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Data = Newtonsoft.Json.JsonConvert.DeserializeObject<ProcessDataFeedResponse>(response.Content);
            }

            return System.Threading.Tasks.Task.FromResult(result);
        }
    }
}
