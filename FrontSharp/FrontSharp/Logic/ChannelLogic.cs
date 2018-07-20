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

        public Channel Get(string channelAddress)
        {
            var request = base.BuildRequest();
            request.Resource += "/alt:address:{channelAddress}";
            request.AddParameter("channelAddress", channelAddress, ParameterType.UrlSegment);

            return _client.Execute<Channel>(request);
        }
    }
}