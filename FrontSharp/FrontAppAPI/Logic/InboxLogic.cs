using FrontAppAPI.Interfaces;
using FrontAppAPI.Models;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace FrontAppAPI.Logic
{
    public class InboxLogic : BaseLogic, IInboxLogic
    {
        public InboxLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "inboxes";
        }

        /// <summary>
        /// Gets the details of an inbox via the given inbox id
        /// </summary>
        /// <param name="inboxId">The id of the requested inbox</param>
        /// <returns>Inbox details</returns>
        public Inbox Get(string inboxId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{inbox_id}";
            request.AddParameter("inbox_id", inboxId, ParameterType.UrlSegment);

            return _client.Execute<Inbox>(request);
        }

        /// <summary>
        /// Gets a list of all inboxes
        /// </summary>
        /// <returns>A list response of the resulting inboxes</returns>
        public ListResultResponseBody<Inbox> List()
        {
            var request = base.BuildRequest();
            return _client.Execute<ListResultResponseBody<Inbox>>(request);
        }

        /// <summary>
        /// Lists the conversations which appear in the inbox via the given inbox id
        /// </summary>
        /// <param name="inboxId">The id of the requested inbox</param>
        /// <param name="statusFilter">Filterable statuses to limit the results, defaults to all if no status is given</param>
        /// <param name="limit">The number of results to be retrieved (50 is the default, 100 is the max)</param>
        /// <returns></returns>
        public ListResultResponseBody<Conversation> ListConversations(string inboxId, List<ConversationStatusFilter> statusFilter = null, int? limit = null)
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

            if (limit != null) request.AddParameter("limit", limit > 100 ? 100 : limit, ParameterType.QueryString);

            return _client.Execute<ListResultResponseBody<Conversation>>(request);
        }
    }
}