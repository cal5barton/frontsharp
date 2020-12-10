using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrontAppAPI.Models
{
    public class Error
    {
        [JsonProperty("status")]
        public int HttpStatusCode { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("details")]
        public List<string> Details { get; set; }
    }
}