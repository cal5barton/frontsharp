namespace FrontSharp.Models
{
    public class AttachmentMetadata
    {
        public bool is_inline { get; set; }
        public string cid { get; set; }
    }

    public class MessageMetadata
    {
    }

    public class SourceTargetMetadata
    {
        public string type { get; set; }
    }
}