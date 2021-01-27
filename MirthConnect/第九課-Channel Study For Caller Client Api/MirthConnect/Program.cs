using MirthConnectFX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MirthConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = MirthConnectClient.Create("Default");   //Replace with setting in app.config

            var session = client.Login("admin", "admin", "0.0.0");

            Console.WriteLine("Session Id: {0}, Version: {1}", session.SessionID, session.Version);


            // Get Channel Groups and List Channels
            var groups = client.ChannelGroups.GetChannelGroups();
            foreach (var group in groups)
            {
                Console.WriteLine($"Group Name: {group.Name}");

                foreach (var channel in group.Channels)
                {
                    Console.WriteLine($"\tChannel Id: {channel.Id}");
                }
            }


            Console.WriteLine();
            //DisplayAllChannelStatus(client);

            //var oldchannel = client.Channels.GetChannel(channelId);
            //oldchannel.Name = "ChannelCreatedFromTemplate2";


            //client.Channels.Update(channel);
            //client.Channels.Create(oldchannel);


            //var channel = client.Channels.GetChannel(channelId);
            //Console.WriteLine("{0} - {1} (Enabled: {2})", channel.Id, channel.Name, channel.SourceConnector.Enabled);

            /*client.Channels.EnableChannel(channelId);

            channel = client.Channels.GetChannel(channelId);
            Console.WriteLine("{0} - {1} (Enabled: {2})", channel.Id, channel.Name, channel.SourceConnector.Enabled);

            client.Engine.DeployChannels(new[] { channelId });
            DisplayChannelStatus(client, channelId);

            client.ChannelStatus.StopChannel(channelId);
            DisplayChannelStatus(client, channelId);

            client.ChannelStatus.StartChannel(channelId);
            DisplayChannelStatus(client, channelId);

            client.Engine.UndeployChannels(new[] { channelId });

            var config = client.Configuration.GetServerConfiguation();
            Console.WriteLine("Channels: {0}, Global Scripts: {1}, Code Templates: {2}", config.Channels.Count, config.GlobalScripts.Count, config.CodeTemplates.Count);

            var codeTemplatesList = new CodeTemplateList();
            foreach (var codeTemplate in config.CodeTemplates)
                codeTemplatesList.CodeTemplates.Add(codeTemplate);

            client.CodeTemplates.UpdateCodeTemplates(codeTemplatesList);

            client.Messages.ClearMessages(channelId);

            var filter = new MessageObjectFilter
            {
                ChannelId = channelId,
                StartDate = DateTime.Now.AddDays(-1).ToMirthDateTime("Europe/London"),
                EndDate = DateTime.Now.AddDays(1).ToMirthDateTime("Europe/London")
            };

            client.Messages.RemoveFilterTable("temp");
            client.Messages.CreateTempTable("temp", filter);

            var messages = client.Messages.GetMessagesByPage("temp", 0, 20, 20);
            Console.WriteLine("{0} messages", messages.Count());

            client.Messages.RemoveFilterTable("temp");

            client.Events.RemoveAllEvents();
            */

            Console.Read();
        }

        private static void DisplayAllChannelStatus(IMirthConnectClient client)
        {
            var status = client.ChannelStatus.GetChannelStatus();
            foreach (var channelStatus in status)
                Console.Write("{0}\r\n ({1}) {2}\r\n\r\n", channelStatus.Name, channelStatus.ChannelId, channelStatus.State);
        }

        private static void DisplayChannelStatus(IMirthConnectClient client, string channelId)
        {
            var status = client.ChannelStatus.GetChannelStatus();
            var channel = status.Single(x => x.ChannelId == channelId);

            Console.Write("{0}\r\n ({1}) {2}\r\n\r\n", channel.Name, channel.ChannelId, channel.State);
        }
    }
}
