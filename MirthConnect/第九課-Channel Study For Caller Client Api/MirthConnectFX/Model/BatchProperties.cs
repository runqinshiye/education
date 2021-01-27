using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class BatchProperties
    {
        [XmlAttribute("class")]
        public string Class { get; set; }
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("splitType")]
        public string SplitType { get; set; }
        [XmlElement("elementName")]
        public string ElementName { get; set; }
        [XmlElement("level")]
        public int? Level { get; set; }
        [XmlElement("query")]
        public string Query { get; set; }
        [XmlElement("batchScript")]
        public string BatchScript { get; set; }

        public bool ShouldSerializeLevel() => Level.HasValue;    
        public bool ShouldSerializeSplitType() => SplitType != null;
        public bool ShouldSerializeElementName() => ElementName != null;
        public bool ShouldSerializeQuery() => Query != null;
        public bool ShouldSerializeBatchScript() => BatchScript != null;
    }
}

