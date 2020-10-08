using Newtonsoft.Json;

namespace doofinder.management.api.Models.ProcessingTasks
{
    public class ProcessDataFeedResponse
    {
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("task_name")]
        public string TaskName { get; set; }
        [JsonProperty("detail")]
        public string Detail { get; set; }
    }

}
