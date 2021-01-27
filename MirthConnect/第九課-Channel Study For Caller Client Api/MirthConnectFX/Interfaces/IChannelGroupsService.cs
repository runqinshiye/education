using MirthConnectFX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirthConnectFX.Interfaces
{
    public interface IChannelGroupsService
    {
        IEnumerable<ChannelGroup> GetChannelGroups(IEnumerable<string> groupIds = null);
    }
}
