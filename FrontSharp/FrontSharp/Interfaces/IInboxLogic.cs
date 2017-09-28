using FrontSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Interfaces
{
    public interface IInboxLogic
    {
        ListResultResponseBody<Inbox> List();
        Inbox Get(string inboxId);
        ListResultResponseBody<Conversation> ListConversations(string inboxId, List<ConversationStatusFilter> statusFilter = null, int? page_token = null, int? limit = null);
    }
}
