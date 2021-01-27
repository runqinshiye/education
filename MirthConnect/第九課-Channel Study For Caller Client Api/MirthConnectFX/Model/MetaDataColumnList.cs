using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [XmlRoot("metaDataColumns")]
    public class MetaDataColumnList
    {
        [XmlElement("metaDataColumn")]
        public List<MetaDataColumn> Items { get; set; }
    }
}
