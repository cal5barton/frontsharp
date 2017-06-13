using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Requests
{
    public class CreateCommentRequest
    {
        [JsonProperty("author_Id")]
        public string AuthorId { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
