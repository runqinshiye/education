using System;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class Filter
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlArray("rules"), XmlArrayItem("rule")]
        public Rule[] Rules { get; set; }
    }
}