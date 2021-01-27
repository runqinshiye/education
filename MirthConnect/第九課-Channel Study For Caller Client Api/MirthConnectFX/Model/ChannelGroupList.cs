using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("list")]
    public class ChannelGroupList
    {
        public ChannelGroupList()
        {
            ChannelGroups = new List<ChannelGroup>();
        }

        [XmlElement("channelGroup")]
        public List<ChannelGroup> ChannelGroups { get; set; }
    }
}
