using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class Author
    {
        public _Links _links { get; set; }
        public string id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool is_admin { get; set; }
        public bool is_available { get; set; }
    }
}
