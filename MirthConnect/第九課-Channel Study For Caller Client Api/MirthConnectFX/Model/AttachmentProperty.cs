using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class AttachmentProperty
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("properties")]
        public string Properties { get; set; }
    }
}
