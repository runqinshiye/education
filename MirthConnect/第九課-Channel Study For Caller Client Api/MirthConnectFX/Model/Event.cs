using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    //[XmlRoot("event")]
    public class Event
    {
        [XmlElement("dateTime")]
        public string DateTime { get; set; }

        [XmlElement("nanoTime")]
        public string NanoTime { get; set; }

        [XmlElement("id")]
        public string Id { get; set; }

        //[XmlElement("eventTime")]
        //public string EventTime { get; set; }

        [XmlElement("level")]
        public string Level { get; set; }

        [XmlElement("name")]
        public string EventName { get; set; }

        [XmlElement("attributes")]
        public HashMapData Attributes { get; set; }

        [XmlElement("outcome")]
        public string Outcome { get; set; }

        [XmlElement("userId")]
        public string UserId { get; set; }

        [XmlElement("ipAddress")]
        public string IpAddress { get; set; }

        [XmlElement("serverId")]
        public string ServerId { get; set; }
    }
}
