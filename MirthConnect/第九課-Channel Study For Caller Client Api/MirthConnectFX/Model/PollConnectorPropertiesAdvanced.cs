using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class PollConnectorPropertiesAdvanced
    {
		[XmlElement("weekly")]
        public bool Weekly { get; set; }
		[XmlArray("inactiveDays"), XmlArrayItem("boolean")]
		public List<bool> InactiveDays { get; set; }
		[XmlElement("dayOfMonth")]
		public int DayOfMonth { get; set; }
		[XmlElement("allDay")]
		public bool AllDay { get; set; }
		[XmlElement("startingHour")]
		public int StartingHour { get; set; }
		[XmlElement("startingMinute")]
		public int StartingMinute { get; set; }
		[XmlElement("endingHour")]
		public int EndingHour { get; set; }
		[XmlElement("endingMinute")]
		public int EndingMinute { get; set; }
    }
}
