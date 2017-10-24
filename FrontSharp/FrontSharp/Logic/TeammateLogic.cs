using FrontSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontSharp.Models;
using FrontSharp.Requests;
using RestSharp;

namespace FrontSharp.Logic
{
    public class TeammateLogic : BaseLogic, ITeammateLogic
    {

        public TeammateLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "teammates";
        }

        public Teammate Get(string teammateId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{teammateId}";
            request.AddParameter("teammateId", teammateId, ParameterType.UrlSegment);

            return _client.Execute<Teammate>(request);
        }

        public ListResultResponseBody<Teammate> List()
        {
            var request = base.BuildRequest();
            return _client.Execute<ListResultResponseBody<Teammate>>(request);
        }

        public ListResultResponseBody<Conversation> ListConversations(string teammateId, List<ConversationStatusFilter> statusFilter = null,  int? limit = null)
        {
            var request = base.BuildRequest();
            request.Resource += "/{teammateId}/conversations";
            request.AddParameter("teammateId", teammateId, ParameterType.UrlSegment);

            if (statusFilter != null && statusFilter.Count() > 0)
            {
                foreach (var filter in statusFilter)
                {
                    request.AddParameter("q[statuses][]", filter.ToString().ToLower(), ParameterType.QueryString);
                }
            }

            if (limit != null) request.AddParameter("limit", limit > 100 ? 100 : limit, ParameterType.QueryString);

            return _client.Execute<ListResultResponseBody<Conversation>>(request);
        }

        public ListResultResponseBody<Inbox> ListInboxes(string teammateId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{teammateId}/inboxes";
            request.AddParameter("teammateId", teammateId, ParameterType.UrlSegment);

            return _client.Execute<ListResultResponseBody<Inbox>>(request);
        }

        public void Update(string teammateId, UpdateTeammateRequest updateTeammate)
        {
            var request = base.BuildRequest(Method.PATCH);
            request.Resource += "/{teammateId}";
            request.AddParameter("teammateId", teammateId, ParameterType.UrlSegment);

            _client.Execute<Teammate>(request, updateTeammate);
        }
    }
}
