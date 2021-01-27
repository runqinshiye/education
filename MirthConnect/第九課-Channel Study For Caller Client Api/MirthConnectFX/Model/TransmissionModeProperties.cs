using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class TransmissionModeProperties
    {
        [XmlAttribute("class")]
        public string Class { get; set; }
        [XmlElement("pluginPointName")]
        public string PluginPointName { get; set; }
        [XmlElement("startOfMessageBytes")]
        public string StartOfMessageBytes { get; set; }
        [XmlElement("endOfMessageBytes")]
        public string EndOfMessageBytes { get; set; }
        [XmlElement("useMLLPv2")]
        public bool UseMLLPv2 { get; set; }
        [XmlElement("ackBytes")]
        public string AckBytes { get; set; }
        [XmlElement("nackBytes")]
        public int NackBytes { get; set; }
        [XmlElement("maxRetries")]
        public int MaxRetries { get; set; }
    }
}
