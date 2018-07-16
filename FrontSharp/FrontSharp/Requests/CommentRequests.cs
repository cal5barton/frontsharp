using Newtonsoft.Json;

namespace FrontSharp.Requests
{
    public class CreateCommentRequest
    {
        [JsonProperty("author_id")]
        public string AuthorId { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}