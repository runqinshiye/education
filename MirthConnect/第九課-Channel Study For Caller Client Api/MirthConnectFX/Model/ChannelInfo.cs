using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class ChannelInfo
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("revision")]
        public int Revision { get; set; }
    }
}
