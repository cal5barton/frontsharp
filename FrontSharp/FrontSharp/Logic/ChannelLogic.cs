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
    public class ChannelLogic : BaseLogic, IChannelLogic
    {
        public ChannelLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "channels";
        }

        public ListResultResponseBody<Channel> List(int? limit = null)
        {
            var request = base.BuildRequest();
            if (limit != null) request.AddParameter("limit", limit > 100 ? 100 : limit, ParameterType.QueryString);

            return _client.Execute<ListResultResponseBody<Channel>>(request);
        }

        public Channel GetByAddress(string channelAddress)
        {
            var request = BuildRequest();
            request.Resource += "/alt:address:{channelAddress}";
            request.AddParameter("channelAddress", channelAddress, ParameterType.UrlSegment);

            return _client.Execute<Channel>(request);
        }

        public Channel GetById(string id)
        {
            var request = BuildRequest();
            request.Resource += "/{id}";
            request.AddParameter("id", id, ParameterType.UrlSegment);

            return _client.Execute<Channel>(request);
        }
    }
}