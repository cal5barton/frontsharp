using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace FrontAppAPI.Requests
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