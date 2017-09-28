using FrontSharp.Models;
using FrontSharp.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Interfaces
{
    public interface IConversationLogic
    {
        ListResultResponseBody<Conversation> List(List<ConversationStatusFilter> statusFilter = null, int? page_token = null, int? limit = null);
        Conversation Get(string conversationId);
        void Update(string conversationId, UpdateConversationRequest updateConversation);
        ListResultResponseBody<Inbox> ListInboxes(string conversationId);
        ListResultResponseBody<Message> ListMessages(string conversationId, int? page_token = null, int? limit = null);
    }
}
