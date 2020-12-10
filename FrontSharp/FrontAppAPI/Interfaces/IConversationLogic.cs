using FrontAppAPI.Models;
using FrontAppAPI.Requests;
using System.Collections.Generic;

namespace FrontAppAPI.Interfaces
{
    public interface IConversationLogic
    {
        ListResultResponseBody<Conversation> List(List<ConversationStatusFilter> statusFilter = null, int? limit = null);

        Conversation Get(string conversationId);

        void Update(string conversationId, UpdateConversationRequest updateConversation);

        ListResultResponseBody<Inbox> ListInboxes(string conversationId);

        ListResultResponseBody<Message> ListMessages(string conversationId, int? limit = null);
    }
}