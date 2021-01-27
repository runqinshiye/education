using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    [XmlRoot("channelGroup")]
    public class ChannelGroup
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("revision")]
        public int Revision { get; set; }

        [XmlElement("lastModified")]
        public MirthDateTime LastModified { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlArray("channels"), XmlArrayItem("channel")]
        public List<ChannelInfo> Channels { get; set; }
    }
}
