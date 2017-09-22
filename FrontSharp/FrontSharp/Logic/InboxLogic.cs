using FrontSharp.Interfaces;
using FrontSharp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Logic
{
    public class InboxLogic : BaseLogic, IInboxLogic
    {
        public InboxLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "inboxes";
        }

        public ListResultResponseBody<Inbox> List()
        {
            var request = base.BuildRequest();
            return _client.Execute<ListResultResponseBody<Inbox>>(request);
        }

        public Inbox Get(string inboxId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{inbox_id}";
            request.AddParameter("inbox_id", inboxId, ParameterType.UrlSegment);

            return _client.Execute<Inbox>(request);
        }

        public ListResultResponseBody<Conversation> ListConversations(string inboxId, List<ConversationStatusFilter> statusFilter = null, int? page = null, int? limit = null)
        {
            var request = base.BuildRequest();
            request.Resource += "/{inbox_id}/conversations";
            request.AddParameter("inbox_id", inboxId, ParameterType.UrlSegment);
            if (statusFilter != null && statusFilter.Count() > 0)
            {
                foreach (var filter in statusFilter)
                {
                    request.AddParameter("q[statuses][]", filter.ToString().ToLower(), ParameterType.QueryString);
                }
            }

            if (page != null) request.AddParameter("page", page, ParameterType.QueryString);
            if (limit != null) request.AddParameter("limit", limit > 100 ? 100 : limit, ParameterType.QueryString);

            return _client.Execute<ListResultResponseBody<Conversation>>(request);
        }
    }
}
