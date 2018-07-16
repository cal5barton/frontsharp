namespace FrontSharp.Models
{
    public class Attachment
    {
        public string filename { get; set; }
        public string url { get; set; }
        public string content_type { get; set; }
        public int size { get; set; }
        public AttachmentMetadata metadata { get; set; }
    }
}