using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
	[Serializable]
	[XmlRoot("com.mirth.connect.plugins.ssl.model.SSLConnectorPluginProperties")]
	public class SslConnectorPluginProperties
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
		[XmlElement("enabled")]
		public bool? Enabled { get; set; }
		[XmlElement("clientAuthentication")]
		public string ClientAuthentication { get; set; }
		[XmlElement("hostnameVerificationEnabled")]
		public bool? HostnameVerificationEnabled { get; set; }
		[XmlElement("trustAllCertificates")]
		public bool? TrustAllCertificates { get; set; }

		[XmlElement("trustedCertificates")]
		public TrustedCertificates TrustedCertificates { get; set; }
		[XmlElement("localCertificateAlias")]
		public string LocalCertificateAlias { get; set; }
		[XmlElement("ocspEnabled")]
		public bool? OcspEnabled { get; set; }
		[XmlElement("ocspURI")]
		public string OcspURI { get; set; }
		[XmlElement("ocspHardFail")]
		public bool? OcspHardFail { get; set; }
		[XmlElement("crlEnabled")]
		public bool? CrlEnabled { get; set; }
		[XmlElement("crlURI")]
		public string CrlURI { get; set; }
		[XmlElement("crlHardFail")]
		public bool? CrlHardFail { get; set; }
		[XmlElement("subjectDNValidationEnabled")]
		public bool? SubjectDNValidationEnabled { get; set; }

		[XmlElement("trustedSubjectDNs")]
		public HashMapData TrustedSubjectDNs { get; set; }
		[XmlElement("hideIssuerDNs")]
		public bool? HideIssuerDNs { get; set; }
		[XmlElement("allowExpiredCertificates")]
		public bool? AllowExpiredCertificates { get; set; }
		[XmlElement("implicitFTPS")]
		public bool? ImplicitFTPS { get; set; }
		[XmlElement("useSTARTTLS")]
		public bool? UseStartTLS { get; set; }

		public bool ShouldSerializeLocalCertificateAlias() => LocalCertificateAlias != null;
		public bool ShouldSerializeClientAuthentication() => ClientAuthentication != null;
		public bool ShouldSerializeOcspURI() => OcspURI != null;
		public bool ShouldSerializeCrlURI() => CrlURI != null;


		public bool ShouldSerializeEnabled() => Enabled.HasValue;
		public bool ShouldSerializeHostnameVerificationEnabled() => HostnameVerificationEnabled.HasValue;
		public bool ShouldSerializeTrustAllCertificates() => TrustAllCertificates.HasValue;
		public bool ShouldSerializeOcspEnabled() => OcspEnabled.HasValue;
		public bool ShouldSerializeOcspHardFail() => OcspHardFail.HasValue;
		public bool ShouldSerializeCrlEnabled() => CrlEnabled.HasValue;
		public bool ShouldSerializeCrlHardFail() => CrlHardFail.HasValue;
		public bool ShouldSerializeSubjectDNValidationEnabled() => SubjectDNValidationEnabled.HasValue;
		public bool ShouldSerializeHideIssuerDNs() => HideIssuerDNs.HasValue;
		public bool ShouldSerializeAllowExpiredCertificates() => AllowExpiredCertificates.HasValue;
		public bool ShouldSerializeImplicitFTPS() => ImplicitFTPS.HasValue;
		public bool ShouldSerializeUseStartTLS() => UseStartTLS.HasValue;


	}
}



