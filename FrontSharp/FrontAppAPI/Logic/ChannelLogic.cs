using FrontAppAPI.Interfaces;
using FrontAppAPI.Models;
using RestSharp;

namespace FrontAppAPI.Logic
{
    public class ChannelLogic : BaseLogic, IChannelLogic
    {
        public ChannelLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "channels";
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