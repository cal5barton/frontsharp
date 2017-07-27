using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Requests
{
    public class UpdateConversationRequest
    {
        [JsonProperty("assignee_id")]
        public string AssigneeId { get; set; }

        [JsonProperty("inbox_id")]
        public string InboxId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }

}
