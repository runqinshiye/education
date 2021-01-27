using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class ListenerConnectorProperties
    {
        [XmlElement("host")]
        public string Host { get; set; }
        [XmlElement("port")]
        public string Port { get; set; }
    }
}
