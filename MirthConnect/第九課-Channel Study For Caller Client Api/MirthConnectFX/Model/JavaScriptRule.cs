using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class JavaScriptRule
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("sequenceNumber")]
        public int SequenceNumber { get; set; }
        [XmlElement("enabled")]
        public bool Enabled { get; set; }
        [XmlElement("operator")]
        public string Operator { get; set; }
        [XmlElement("script")]
        public string Script { get; set; }

    }
}
