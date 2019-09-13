using FrontSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Interfaces
{
    public interface IChannelLogic
    {
        ListResultResponseBody<Channel> List(int? limit = null);

        Channel GetByAddress(string channelAddress);
    }
}