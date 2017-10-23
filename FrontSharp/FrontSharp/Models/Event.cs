using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class Event : BaseResponseBody
    {
        public string id { get; set; }
        public string type { get; set; }
        public float emitted_at { get; set; }
        public Conversation conversation { get; set; }
        public Source source { get; set; }
        public Target target { get; set; }
    }

    public class EventSearchParameters
    {
        public List<EventTypeFilter> EventTypes { get; set; }
        public DateTime Before { get; set; }
        public DateTime After { get; set; }
    }

    public enum EventTypeFilter
    {
        Archive,
        Assign,
        Comment,
        Conversations_Merged,
        Forward,
        Inbound,
        Mention,
        Move,
        Out_Reply,
        Outbound,
        Reminder,
        Reopen,
        Restore,
        Sending_Error,
        Tag,
        Trash,
        Unassign,
        Untag
    }
}
