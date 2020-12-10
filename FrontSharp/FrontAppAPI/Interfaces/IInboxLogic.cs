using FrontAppAPI.Models;
using System.Collections.Generic;

namespace FrontAppAPI.Interfaces
{
    public interface IInboxLogic
    {
        ListResultResponseBody<Inbox> List();

        Inbox Get(string inboxId);

        ListResultResponseBody<Conversation> ListConversations(string inboxId, List<ConversationStatusFilter> statusFilter = null, int? limit = null);
    }
}