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
        ListResult<Inbox> List();
        Inbox Get(string inboxId);
        ListResult<Conversation> ListConversations(string inboxId, List<ConversationStatus> statusFilter = null, int? page = null, int? limit = null);
    }
}
