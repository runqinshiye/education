using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class PollConnectorProperties
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

		[XmlElement("pollingType")]
		public string PollingType { get; set; }

		[XmlElement("pollOnStart")]
        public bool PollOnStart { get; set; }

		[XmlElement("pollingFrequency")]
		public int PollingFrequency { get; set; }

		[XmlElement("pollingHour")]
		public int PollingHour { get; set; }

		[XmlElement("pollingMinute")]
		public int PollingMinute { get; set; }

		[XmlElement("pollConnectorPropertiesAdvanced")]
		public PollConnectorPropertiesAdvanced PollConnectorPropertiesAdvanced { get; set; }

		[XmlElement("cronJobs")]
		public string CronJobs { get; set; }//public CronJobs CronJobs { get; set; }
	}
}
