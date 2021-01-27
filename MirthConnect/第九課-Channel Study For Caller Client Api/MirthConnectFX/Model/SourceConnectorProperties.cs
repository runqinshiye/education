using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class SourceConnectorProperties
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
        /// <summary>
        /// If false, then queue enabled
        /// </summary>
        [XmlElement("respondAfterProcessing")]
        public bool RespondAfterProcessing { get; set; }
        [XmlElement("responseVariable")]
        public string ResponseVariable { get; set; }
        [XmlElement("processBatch")]
        public bool ProcessBatch { get; set; }
        [XmlElement("firstResponse")]
        public bool FirstResponse { get; set; }
        [XmlElement("processingThreads")]
        public int ProcessingThreads { get; set; }
        [XmlElement("queueBufferSize")]
        public int QueueBufferSize { get; set; }

        [XmlElement("resourceIds")]
        public HashMapData ResourceIds { get; set; }

    }
}
