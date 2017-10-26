using FrontSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontSharp.Models;
using RestSharp;
using FrontSharp.Helpers;
using FrontSharp.Requests;

namespace FrontSharp.Logic
{
    public class EventLogic : BaseLogic, IEventLogic
    {
        public EventLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "events";
        }

        /// <summary>
        /// Gets the full details of an event via the given event id
        /// </summary>
        /// <param name="eventId">The id of the requested event</param>
        /// <returns>Event details</returns>
        public Event Get(string eventId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{eventId}";
            request.AddParameter("eventId", eventId, ParameterType.UrlSegment);

            return _client.Execute<Event>(request);
        }

        /// <summary>
        /// Lists all the detailed events which occured in the inboxes of your company ordered in reverse chronological order (newest first)
        /// </summary>
        /// <param name="filter">Filterable options to limit the results</param>
        /// <param name="limit">The number of results to be retrieved (50 is the default, 100 is the max)</param>
        /// <returns>A list response of the event results</returns>
        public ListResultResponseBody<Event> List(EventSearchParameters filter = null,  int? limit = null)
        {
            var request = base.BuildRequest();

            if(filter != null)
            {
                if(filter.EventTypes != null && filter.EventTypes.Count() > 0)
                {
                    foreach(var typeFilter in filter.EventTypes)
                    {
                        request.AddParameter("q[types][]", typeFilter.ToString().ToLower(), ParameterType.QueryString);
                    }
                }

                if(filter.Before != null)
                {
                    request.AddParameter("q[before][]", filter.Before.Value.ToTimestamp(), ParameterType.QueryString);
                }

                if(filter.After != null)
                {
                    request.AddParameter("q[after][]", filter.After.Value.ToTimestamp(), ParameterType.QueryString);
                }
            }

            if (limit != null) request.AddParameter("limit", limit > 100 ? 100 : limit, ParameterType.QueryString);

            return _client.Execute<ListResultResponseBody<Event>>(request);
        }
    }
}
