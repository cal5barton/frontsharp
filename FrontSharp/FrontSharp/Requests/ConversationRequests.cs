using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("status")]
        public ConversationStatus Status { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }

    public enum ConversationStatus
    {
        open,
        archived,
        deleted,
        spam
    }

}
