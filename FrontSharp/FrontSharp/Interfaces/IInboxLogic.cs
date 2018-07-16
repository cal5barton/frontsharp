using FrontSharp.Models;
using System.Collections.Generic;

namespace FrontSharp.Interfaces
{
    public interface IInboxLogic
    {
        ListResultResponseBody<Inbox> List();

        Inbox Get(string inboxId);

        ListResultResponseBody<Conversation> ListConversations(string inboxId, List<ConversationStatusFilter> statusFilter = null, int? limit = null);
    }
}