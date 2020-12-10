using System;
using System.Collections.Generic;

namespace FrontAppAPI.Requests
{
    public class EventSearchParameters
    {
        public List<EventTypeFilter> EventTypes { get; set; }
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
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