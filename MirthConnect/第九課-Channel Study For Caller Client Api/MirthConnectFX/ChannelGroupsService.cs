using MirthConnectFX.Interfaces;
using MirthConnectFX.Model;
using MirthConnectFX.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirthConnectFX
{
    public class ChannelGroupsService : ServiceBase, IChannelGroupsService
    {
        public ChannelGroupsService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session)
            : base(mirthConnectRequestFactory, session, "channelgroups")
        {
        }

        public IEnumerable<ChannelGroup> GetChannelGroups(IEnumerable<string> groupIds = null)
        {
            var request = CreateRequest();

            if (groupIds != null)
            {
                foreach(var groupId in groupIds)
                {
                    request.AddUrlData("channelGroupId", groupId);
                }
            }

            var response = request.ExecuteGet();
            return response.Content.ToObject<ChannelGroupList>().ChannelGroups;
        }
    }
}
