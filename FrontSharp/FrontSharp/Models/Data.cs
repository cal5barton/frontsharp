using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class Data : BaseResponseBody
    {
        public string address { get; set; }
        public string send_as { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public bool is_inbound { get; set; }
        public float created_at { get; set; }
        public string blurb { get; set; }
        public string body { get; set; }
        public string text { get; set; }
        public SourceTargetMetadata metadata { get; set; }
        public Author author { get; set; }
        public Recipient[] recipients { get; set; }
        public Attachment[] attachments { get; set; }
    }
}
