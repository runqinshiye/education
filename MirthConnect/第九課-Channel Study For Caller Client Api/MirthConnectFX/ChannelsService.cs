using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using MirthConnectFX.Model;
using MirthConnectFX.Utility;

namespace MirthConnectFX
{
    public class ChannelsService : ServiceBase, IChannelsService
    {
        public ChannelsService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session)
            : base(mirthConnectRequestFactory, session, "channels")
        {
        }
        
        public IEnumerable<ChannelSummary> GetChannelSummary()
        {
            var request = CreateRequest().ForOperation(Operations.Channels.GetChannelSummary);
            request.AddPostData("cachedChannels", "<map/>");

            var response = request.Execute();
            var summary = response.Content.ToObject<ChannelList>();

            return summary.ChannelSummaries;
        }

        public bool Update(Channel channel)
        {
            var channelXml = channel.ToXml().Replace("'", "&apos;");

            var request = CreateRequest().ForOperation(channel.Id);

            request.AddPostData("body", channelXml);
            request.AddUrlData("override", "true");
            request.ContentType = "application/xml";

            var response = request.ExecutePut();
            return Boolean.Parse(XElement.Parse(response.Content).Value);
        }

        public bool Create(Channel channel)
        {
            var newChannel = channel.CreateNew();
            channel.Id = Guid.NewGuid().ToString();
            var channelXml = newChannel.ToXml().Replace("'", "&apos;");

            var request = CreateRequest();
            request.AddPostData("body", channelXml);
            request.ContentType = "application/xml";

            var response = request.ExecuteJustBody();
            return Boolean.Parse(XElement.Parse(response.Content).Value);
        }

        public Channel GetChannel(string channelId)
        {
            //if (Session.IsMirthVersion(MirthBaseVersion.V3x))
            //    return GetChannels(new[] {channelId}).FirstOrDefault();
            
            var channel = new Channel {Id = channelId}.ToXml();
            var request = CreateRequest().ForOperation(channelId);
            //request.AddPostData("channel", channel);

            var response = request.ExecuteGet();
            var channelList = response.Content.ToObject<Channel>();

            return channelList;
        }

        public string GetRawChannelXML(string channelId)
        {
            //if (Session.IsMirthVersion(MirthBaseVersion.V3x))
            //    return GetChannels(new[] {channelId}).FirstOrDefault();

            var channel = new Channel { Id = channelId }.ToXml();
            var request = CreateRequest().ForOperation(channelId);
            //request.AddPostData("channel", channel);

            var response = request.ExecuteGet();
            return response.Content;
        }

        public GlobalScripts GetChannelIdsAndNames()
        {
            var request = CreateRequest().ForOperation(Operations.Channels.GetIdsAndName);

            var response = request.ExecuteGet();
            return response.Content.ToObject<GlobalScripts>();
        }

        public IEnumerable<Channel> GetChannels(IEnumerable<string> channelIds)
        {
            if (Session.IsMirthVersion(MirthBaseVersion.V2x))
                return channelIds.Select(GetChannel).ToList();

            var request = CreateRequest();

            if(channelIds == null || channelIds.Count() > 0)
            {
                request.ForOperation(Operations.Channels.GetChannel);
                request.AddPostData("channelIds", channelIds.ToXmlCollection("set"));
            }

            var response = request.ExecuteGet();
            return response.Content.ToObject<ChannelList>().Channels;
        }

        public void EnableChannel(string channelId)
        {
            var channel = GetChannel(channelId);
            channel.SourceConnector.Enabled = true;

            Update(channel);
        }

        public void DisableChannel(string channelId)
        {
            var channel = GetChannel(channelId);
            channel.SourceConnector.Enabled = false;

            Update(channel);
        }
    }
}