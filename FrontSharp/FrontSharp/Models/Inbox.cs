namespace FrontSharp.Models
{
    public class Inbox : BaseResponseBody
    {
        public string id { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string send_as { get; set; }
    }
}