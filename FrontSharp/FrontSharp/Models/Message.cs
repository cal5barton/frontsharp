using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class Message
    {
        public _Links _links { get; set; }
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
        public Metadata metadata { get; set; }
    }
}
