using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class Inbox
    {
        public _Links _links { get; set; }
        public string id { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string send_as { get; set; }
    }
}
