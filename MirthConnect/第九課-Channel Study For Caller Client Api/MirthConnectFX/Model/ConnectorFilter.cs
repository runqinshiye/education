using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class ConnectorFilter
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlArray("elements")]
        [XmlArrayItem(Type = typeof(JavaScriptRule), ElementName = "com.mirth.connect.plugins.javascriptrule.JavaScriptRule", IsNullable = true)]
        public List<object> Elements { get; set; }

        [XmlIgnore]
        public IEnumerable<JavaScriptRule> JavaScriptRules { get { return (Elements ?? Enumerable.Empty<object>()).OfType<JavaScriptRule>(); } }

    }
}
