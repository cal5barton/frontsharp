using FrontSharp.Interfaces;
using FrontSharp.Models;
using FrontSharp.Requests;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace FrontSharp.Logic
{
    public class ConversationLogic : BaseLogic, IConversationLogic
    {
        public ConversationLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "conversations";
        }

        /// <summary>
        /// Retrieves the full conversation details for a given conversation id
        /// </summary>
        /// <param name="conversationId">Id of the requested conversation</param>
        /// <returns>Full conversation details</returns>
        public Conversation Get(string conversationId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{conversationId}";
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);

            return _client.Execute<Conversation>(request);
        }

        /// <summary>
        /// Lists all the conversations in your company in reverse chronological order (latest updated first)
        /// </summary>
        /// <param name="statusFilter">Limits results to only the statuses given or all results if no filters are provided</param>
        /// <param name="limit">The number of results to be retrieved (50 is the default, 100 is the max)</param>
        /// <returns>A list response of the resulting conversations</returns>
        public ListResultResponseBody<Conversation> List(List<ConversationStatusFilter> statusFilter = null, int? limit = null)
        {
            var request = base.BuildRequest();
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

        /// <summary>
        /// Lists the inboxes in which a conversation appears
        /// </summary>
        /// <param name="conversationId">Id of the requested conversation</param>
        /// <returns>A list response of the related inboxes</returns>
        public ListResultResponseBody<Inbox> ListInboxes(string conversationId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{conversationId}/inboxes";
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);

            return _client.Execute<ListResultResponseBody<Inbox>>(request);
        }

        /// <summary>
        /// Lists all the messages sent or received in a conversation in reverse chronological order (newest first)
        /// </summary>
        /// <param name="conversationId">Id of the requested conversation</param>
        /// <param name="limit">The number of results to be retrieved (50 is the default, 100 is the max)</param>
        /// <returns>A list response of the related messages</returns>
        public ListResultResponseBody<Message> ListMessages(string conversationId, int? limit = null)
        {
            var request = base.BuildRequest();
            request.Resource += "/{conversationId}/messages";
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);

            if (limit != null) request.AddParameter("limit", limit > 100 ? 100 : limit, ParameterType.QueryString);

            return _client.Execute<ListResultResponseBody<Message>>(request);
        }

        /// <summary>
        /// Updates a conversation by changing the assignee id, the inbox, any tags, and/or altering the status
        /// Currently defaults to archiving conversations if no status is passed via the API
        /// </summary>
        /// <param name="conversationId">Id of the requested conversation</param>
        /// <param name="updateConversation">The details to be updated including the assignee id, the inbox, any tags, and/or the status</param>
        public void Update(string conversationId, UpdateConversationRequest updateConversation)
        {
            var request = base.BuildRequest(Method.PATCH);
            request.Resource += "/{conversationId}";
            request.AddParameter("conversationId", conversationId, ParameterType.UrlSegment);

            _client.Execute<Conversation>(request, updateConversation);
        }
    }
}