using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class DestinationConnectorProperties
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("queueEnabled")]
        public bool QueueEnabled { get; set; }
        [XmlElement("sendFirst")]
        public bool SendFirst { get; set; }
        [XmlElement("retryIntervalMillis")]
        public int RetryIntervalMillis { get; set; }
        [XmlElement("regenerateTemplate")]
        public bool RegenerateTemplate { get; set; }
        [XmlElement("retryCount")]
        public int RetryCount { get; set; }
        [XmlElement("rotate")]
        public bool Rotate { get; set; }
        [XmlElement("threadCount")]
        public int ThreadCount { get; set; }
        [XmlElement("validateResponse")]
        public bool ValidateResponse { get; set; }
        [XmlElement("includeFilterTransformer")]
        public bool IncludeFilterTransformer { get; set; }
        [XmlElement("threadAssignmentVariable")]
        public string ThreadAssignmentVariable { get; set; }
        [XmlElement("resourceIds")]
        public HashMapData ResourceIds { get; set; }
        [XmlElement("queueBufferSize")]
        public int QueueBufferSize { get; set; }
        [XmlElement("reattachAttachments")]
        public bool ReattachAttachments { get; set; }
    }
}
