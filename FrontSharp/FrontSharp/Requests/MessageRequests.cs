using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Requests
{

    public class ImportMessageRequest
    {
        [JsonProperty("sender")]
        public Sender Sender { get; set; }
        [JsonProperty("to")]
        public List<string> To { get; set; }
        [JsonProperty("cc")]
        public List<string> Cc { get; set; }
        [JsonProperty("bcc")]
        public List<string> Bcc { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("body_format")]
        public BodyFormat BodyFormat { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public Type Type { get; set; }
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }
        [JsonProperty("created_at")]
        public double CreatedAt { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        [JsonProperty("attachments")]
        public object[] Attachments { get; set; }
        [JsonProperty("metadata")]
        public ImportMessageMetadata Metadata { get; set; }
    }

    public enum BodyFormat
    {
        markdown,
        html
    }

    public enum Type
    {
        email,
        sms
    }

    public class Sender
    {
        [JsonProperty("handle")]
        public string Handle { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("author_id")]
        public string AuthorId { get; set; }
    }

    public class ImportMessageMetadata
    {
        [JsonProperty("thread_ref")]
        public string ThreadRef { get; set; }
        [JsonProperty("is_inbound")]
        public bool IsInbound { get; set; }
        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }
        [JsonProperty("should_skip_rules")]
        public bool ShouldSkipRules { get; set; }
    }

}
