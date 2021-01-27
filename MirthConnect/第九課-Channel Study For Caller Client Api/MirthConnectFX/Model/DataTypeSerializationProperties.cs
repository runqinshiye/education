using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class DataTypeSerializationProperties
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlAttribute("class")]
        public string Class { get;set; }

        [XmlElement("handleRepetitions")]
        public bool? HandleRepetitions { get; set; }
        [XmlElement("handleSubcomponents")]
        public bool? HandleSubcomponents { get; set; }
        [XmlElement("useStrictParser")]
        public bool? UseStrictParser { get; set; }
        [XmlElement("useStrictValidation")]
        public bool? UseStrictValidation { get; set; }
        [XmlElement("stripNamespaces")]
        public bool? StripNamespaces { get; set; }
        [XmlElement("segmentDelimiter")]
        public string SegmentDelimiter { get; set; }
        [XmlElement("convertLineBreaks")]
        public bool? ConvertLineBreaks { get; set; }

        public bool ShouldSerializeHandleRepetitions() => HandleRepetitions.HasValue;
        public bool ShouldSerializeHandleSubcomponents() => HandleSubcomponents.HasValue;
        public bool ShouldSerializeUseStrictParser() => UseStrictParser.HasValue;
        public bool ShouldSerializeUseStrictValidation() => UseStrictValidation.HasValue;
        public bool ShouldSerializeStripNamespaces() => StripNamespaces.HasValue;
        public bool ShouldSerializeConvertLineBreaks() => ConvertLineBreaks.HasValue;
        public bool ShouldSerializeSegmentDelimiter() => SegmentDelimiter != null;
    }
}


