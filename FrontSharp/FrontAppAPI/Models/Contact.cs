using System.Collections.Generic;

namespace FrontAppAPI.Models
{
    public class Contact : BaseResponseBody
    {
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