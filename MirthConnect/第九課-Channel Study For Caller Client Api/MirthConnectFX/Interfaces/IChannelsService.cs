using System.Collections.Generic;
using MirthConnectFX.Model;

namespace MirthConnectFX
{
    public interface IChannelsService
    {
        IEnumerable<ChannelSummary> GetChannelSummary();
        bool Create(Channel channel);
        bool Update(Channel channel);
        Channel GetChannel(string channelId);
        IEnumerable<Channel> GetChannels(IEnumerable<string> channelIds);
        void EnableChannel(string channelId);
        void DisableChannel(string channelId);
        GlobalScripts GetChannelIdsAndNames();

        string GetRawChannelXML(string channelId);
    }
}