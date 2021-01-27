using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    public class InboundProperties
    {
        [XmlAttribute("class")]
        public string Class { get; set; }
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("serializationProperties")]
        public DataTypeSerializationProperties SerializationProperties { get; set; }

        [XmlElement("batchProperties")]
        public BatchProperties BatchProperties { get; set; }
        [XmlElement("deserializationProperties")]
        public DataTypeDeserializationProperties DeserializationProperties { get; set; }
        [XmlElement("responseGenerationProperties")]
        public DataTypeResponseGenerationProperties ResponseGenerationProperties { get; set; }
        [XmlElement("responseValidationProperties")]
        public DataTypeResponseValidationProperties ResponseValidationProperties { get; set; }
    }
}
