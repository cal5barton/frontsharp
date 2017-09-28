using FrontSharp.Interfaces;
using FrontSharp.Models;
using FrontSharp.Requests;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Logic
{
    public class ConversationLogic : BaseLogic, IConversationLogic
    {

        public ConversationLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "conversations";
        }
        
        public Conversation Get(string conversationId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{conversationId}";
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);

            return _client.Execute<Conversation>(request);
        }

        public void Update(string conversationId, UpdateConversationRequest updateConversation)
        {
            var request = base.BuildRequest(Method.PATCH);
            request.Resource += "/{conversationId}";
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);

            _client.Execute<Conversation>(request, updateConversation);
        }


        public ListResultResponseBody<Message> ListMessages(string conversationId, int? page_token = null, int? limit = null)
        {
            var request = base.BuildRequest();
            request.Resource += "/{conversationId}/messages";
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);

            if (page_token != null) request.AddParameter("page_token", page_token, ParameterType.QueryString);
            if (limit != null) request.AddParameter("limit", limit > 100 ? 100 : limit, ParameterType.QueryString);

            return _client.Execute<ListResultResponseBody<Message>>(request);
        }

        public ListResultResponseBody<Conversation> List(List<ConversationStatusFilter> statusFilter = null, int? page_token = null, int? limit = null)
        {
            var request = base.BuildRequest();
            if(statusFilter != null && statusFilter.Count() > 0)
            {
                foreach(var filter in statusFilter)
                {
                    request.AddParameter("q[statuses][]", filter.ToString().ToLower(), ParameterType.QueryString);
                }
            }

            if (page_token != null) request.AddParameter("page_token", page_token, ParameterType.QueryString);
            if (limit != null) request.AddParameter("limit", limit > 100 ? 100 : limit, ParameterType.QueryString);

            return _client.Execute<ListResultResponseBody<Conversation>>(request);
        }


        public ListResultResponseBody<Inbox> ListInboxes(string conversationId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{conversationId}/inboxes";
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);

            return _client.Execute<ListResultResponseBody<Inbox>>(request);
        }
    }
}
