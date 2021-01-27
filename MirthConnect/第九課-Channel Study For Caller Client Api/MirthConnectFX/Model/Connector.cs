using System;
using System.Xml;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class Connector
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("metaDataId")]
        public string MetaDataId { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
    
        [XmlElement("properties")]
        public ConnectorProperties Properties { get; set; }
        [XmlElement("transformer")]
        public ConnectorTransformer Transformer { get; set; }
        [XmlElement("filter")]
        public ConnectorFilter Filter { get; set; }

        [XmlElement("responseTransformer")]
        public ConnectorTransformer ResponseTransformer { get; set; }

        [XmlElement("transportName")]
        public string TransportName { get; set; }
        [XmlElement("mode")]
        public string Mode { get; set; }
        [XmlElement("enabled")]
        public bool Enabled { get; set; }
        [XmlElement("waitForPrevious")]
        public bool WaitForPrevious { get; set; }
    }
}