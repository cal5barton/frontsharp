using System.Collections.Generic;

namespace FrontSharp.Models
{
    public class Conversation : BaseResponseBody
    {
        public string id { get; set; }
        public string subject { get; set; }
        public string status { get; set; }
        public Teammate assignee { get; set; }
        public Recipient recipient { get; set; }
        public List<Tag> tags { get; set; }
        public Message last_message { get; set; }
        public float created_at { get; set; }
    }

    public enum ConversationStatusFilter
    {
        Archived,
        Assigned,
        Deleted,
        Open,
        Spam,
        Unassigned
    }
}