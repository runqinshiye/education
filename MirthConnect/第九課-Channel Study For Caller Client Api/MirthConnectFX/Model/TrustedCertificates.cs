using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class TrustedCertificates
    {
        [XmlElement("trustedCertificateAliases")]
        public string TrustedCerficateAliases { get; set; }
        [XmlElement("trustCACerts")]
        public bool TrustCACerts { get; set; }
    }
}
