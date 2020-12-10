using System.Collections.Generic;

namespace FrontAppAPI.Models
{
    public class Message : BaseResponseBody
    {
        public string id { get; set; }
        public string type { get; set; }
        public bool is_inbound { get; set; }
        public float created_at { get; set; }
        public string blurb { get; set; }
        public Author author { get; set; }
        public List<Recipient> recipients { get; set; }
        public string body { get; set; }
        public string text { get; set; }
        public List<Attachment> attachments { get; set; }
        public MessageMetadata metadata { get; set; }
    }
}