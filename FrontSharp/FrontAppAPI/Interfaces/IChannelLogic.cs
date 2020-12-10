using FrontAppAPI.Models;

namespace FrontAppAPI.Interfaces
{
    public interface IChannelLogic
    {
        Channel GetByAddress(string channelAddress);
    }
}