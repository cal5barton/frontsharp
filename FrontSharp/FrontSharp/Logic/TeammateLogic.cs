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

        /// <summary>
        /// Gets the information of a teammate
        /// </summary>
        /// <param name="teammateId">The id of the requested teammate</param>
        /// <returns>Teammate details</returns>
        public Teammate Get(string teammateId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{teammateId}";
            request.AddParameter("teammateId", teammateId, ParameterType.UrlSegment);

            return _client.Execute<Teammate>(request);
        }

        /// <summary>
        /// Lists all teammates
        /// </summary>
        /// <returns>A list response of the resulting teammates</returns>
        public ListResultResponseBody<Teammate> List()
        {
            var request = base.BuildRequest();
            return _client.Execute<ListResultResponseBody<Teammate>>(request);
        }

        /// <summary>
        /// Lists the conversations assigned to a teammate in reverse chronological order (newest first)
        /// </summary>
        /// <param name="teammateId">The id of the requested teammate</param>
        /// <param name="statusFilter">Limits results to only the statuses given or all results if no filters are provided</param>
        /// <param name="limit">The number of results to be retrieved (50 is the default, 100 is the max)</param>
        /// <returns>A list response of the resulting conversations according to the given teammate</returns>
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

        /// <summary>
        /// Lists the inboxes a teammate has access to
        /// </summary>
        /// <param name="teammateId">The id of the requested teammate</param>
        /// <returns>A list response of the resulting inboxes according to the given teammate</returns>
        public ListResultResponseBody<Inbox> ListInboxes(string teammateId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{teammateId}/inboxes";
            request.AddParameter("teammateId", teammateId, ParameterType.UrlSegment);

            return _client.Execute<ListResultResponseBody<Inbox>>(request);
        }

        /// <summary>
        /// Updates the information of a teammate
        /// </summary>
        /// <param name="teammateId">The id of the requested teammate</param>
        /// <param name="updateTeammate">Any details for the teammate to be updated</param>
        public void Update(string teammateId, UpdateTeammateRequest updateTeammate)
        {
            var request = base.BuildRequest(Method.PATCH);
            request.Resource += "/{teammateId}";
            request.AddParameter("teammateId", teammateId, ParameterType.UrlSegment);

            _client.Execute<Teammate>(request, updateTeammate);
        }
    }
}
