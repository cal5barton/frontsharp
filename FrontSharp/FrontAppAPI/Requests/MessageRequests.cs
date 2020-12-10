using FrontAppAPI.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Linq;

namespace FrontAppAPI.Requests
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

        [JsonIgnore]
        public List<AttachmentInfo> Attachments { get; set; }

        [JsonProperty("metadata")]
        public ImportMessageMetadata Metadata { get; set; }

        public bool HasAttachments()
        {
            return this.Attachments != null && this.Attachments.Count() > 0;
        }
    }

    [JsonConverter(typeof(MultipartRequestConverter))]
    public class ImportMessageMultipartFormRequest : ImportMessageRequest
    {
    }

    [JsonConverter(typeof(MultipartRequestConverter))]
    public class SendReplyMultipartFormRequest : SendReplyRequest
    { }

    public class SendReplyRequest
    {
        [JsonProperty("author_id")]
        public string AuthorId { get; set; }

        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonIgnore]
        public List<AttachmentInfo> Attachments { get; set; }

        public bool HasAttachments()
        {
            return this.Attachments != null && this.Attachments.Count() > 0;
        }

        [JsonProperty("options")]
        public Options Options { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("to")]
        public List<string> To { get; set; }

        [JsonProperty("cc")]
        public List<string> Cc { get; set; }

        [JsonProperty("bcc")]
        public List<string> Bcc { get; set; }
    }

    public class Options
    {
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("archive")]
        public bool Archive { get; set; }
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

    public class AttachmentInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }

        public AttachmentInfo(string name, string path)
        {
            this.Name = name;
            this.Path = path;
        }
    }
}