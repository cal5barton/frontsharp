using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class Event : BaseResponseBody
    {
        public string id { get; set; }
        public string type { get; set; }
        public float emitted_at { get; set; }
        public Conversation conversation { get; set; }
        public Source source { get; set; }
        public Target target { get; set; }
    }

   
}
