namespace FrontSharp.Models
{
    public class Tag : BaseResponseBody
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool is_private { get; set; }
    }
}