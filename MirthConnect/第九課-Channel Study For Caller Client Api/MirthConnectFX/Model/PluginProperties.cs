using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class PluginProperties
    {
        [XmlElement("version")]
        public string Version { get; set; }
        [XmlElement("com.mirth.connect.plugins.ssl.model.SSLConnectorPluginProperties")]
        public SslConnectorPluginProperties SslConnector { get; set; }
    }
}
