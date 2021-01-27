using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class ConnectorTransformer
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlArray("elements"), XmlArrayItem("com.mirth.connect.plugins.javascriptstep.JavaScriptStep")]
        public List<JavaScriptStep> Steps { get; set; }

        [XmlElement("inboundTemplate")]
        public Template InboundTemplateBase64 { get; set; }
        [XmlElement("inboundDataType")]
        public string InboundDataType { get; set; }

        [XmlElement("outboundTemplate")]
        public Template OutboundTemplateBase64 { get; set; }
        [XmlElement("outboundDataType")]
        public string OutboundDataType { get; set; }

        [XmlElement("inboundProperties")]
        public InboundProperties InboundProperties { get; set; }

        [XmlElement("outboundProperties")]
        public OutboundProperties OutboundProperties { get; set; }
    }
}
