using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrontSharp.Models
{
    public class Contact : BaseResponseBody
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("is_spammer")]
        public bool IsSpammer { get; set; }

        [JsonProperty("links")]
        public List<string> Links { get; set; }

        [JsonProperty("handles")]
        public List<ContactHandle> Handles { get; set; }

        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
    }
}