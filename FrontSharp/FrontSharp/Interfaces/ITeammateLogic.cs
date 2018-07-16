using FrontSharp.Models;
using FrontSharp.Requests;
using System.Collections.Generic;

namespace FrontSharp.Interfaces
{
    public interface ITeammateLogic
    {
        ListResultResponseBody<Teammate> List();

        Teammate Get(string teammateId);

        void Update(string teammateId, UpdateTeammateRequest updateTeammate);

        ListResultResponseBody<Conversation> ListConversations(string teammateId, List<ConversationStatusFilter> statusFilter = null, int? limit = null);

        ListResultResponseBody<Inbox> ListInboxes(string teammateId);
    }
}