namespace FrontSharp.Models
{
    public class ImportMessageResponse : BaseResponseBody
    {
        public string conversation_reference { get; set; }
        public string message_uid { get; set; }
    }
}