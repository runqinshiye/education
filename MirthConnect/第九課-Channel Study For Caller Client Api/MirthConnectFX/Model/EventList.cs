using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("list")]
    public class EventList
    {
        public EventList()
        {
            Events = new List<Event>();
        }

        [XmlElement("event")]
        public List<Event> Events { get; set; }
    }
}
