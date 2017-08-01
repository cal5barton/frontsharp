using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class Contact
    {
        public _Links _links { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string avatar_url { get; set; }
        public bool is_spammer { get; set; }
        public List<string> links { get; set; }
        public List<Handle> handles { get; set; }
        public List<Group> groups { get; set; }
    }
}