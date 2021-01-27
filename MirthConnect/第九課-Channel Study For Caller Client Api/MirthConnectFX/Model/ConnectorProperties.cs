using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable]
    public class ConnectorProperties
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("pluginProperties")]
        public PluginProperties PluginProperties { get; set; }
        [XmlElement("pollConnectorProperties")]
        public PollConnectorProperties PollConnectorProperties { get; set; }

        [XmlElement("listenerConnectorProperties")]
        public ListenerConnectorProperties ListenerConnectorProperties { get; set; }
        [XmlElement("sourceConnectorProperties")]
        public SourceConnectorProperties SourceConnectorProperties { get; set; }
        [XmlElement("destinationConnectorProperties")]
        public DestinationConnectorProperties DestinationConnectorProperties { get; set; }
        [XmlElement("transmissionModeProperties")]
        public TransmissionModeProperties TransmissionModeProperties { get; set; }


        [XmlAttribute("class")]
        public string Class { get; set; }

        // START "Web Service Listener" Properties
        /// <summary>
        /// Applicable for Web Service Listener
        /// </summary>
        [XmlElement("serviceName")]
        public string ServiceName { get; set; }
        /// <summary>
        /// Applicable for Web Service Listener
        /// </summary>
        [XmlElement("className")]
        public string ClassName { get; set; }
        // END "Web Service Listener" Properties

        // START "TCP Listener" Properties
        /// <summary>
        /// Applicable for TCP Listener
        /// </summary>
        [XmlElement("receiveTimeout")]
        public int? ReceiveTimeout { get; set; }
        /// <summary>
        /// Applicable for TCP Listener
        /// </summary>
        [XmlElement("bufferSize")]
        public string BufferSize { get; set; }
        [XmlElement("keepConnectionOpen")]
        public bool? KeepConnectionOpen { get; set; }
        [XmlElement("maxConnections")]
        public int? MaxConnections { get; set; }
        // END "TCP Listener" Properties

        [XmlElement("wsdlUrl")]
        public string SOAPWSDLUrl { get; set; }
        [XmlElement("service")]
        public string SOAPService { get; set; }
        [XmlElement("port")]
        public string SOAPPort { get; set; }
        [XmlElement("locationURI")]
        public string SOAPLocationURI { get; set; }
        [XmlElement("socketTimeout")]
        public string SOAPSocketTimeout { get; set; }
        [XmlElement("oneWay")]
        public bool? SOAPIsOneWayInvocation { get; set; }
        [XmlElement("operation")]
        public string SOAPOperation { get; set; }
        [XmlElement("soapAction")]
        public string SOAPAction { get; set; }
        [XmlElement("envelope")]
        public string SOAPEnvelope { get; set; }


        [XmlElement("remoteAddress")]
        public string RemoteAddress { get; set; }
        [XmlElement("remotePort")]
        public string RemotePort { get; set; }
        [XmlElement("sendTimeout")]
        public string SendTimeout { get; set; }

        [XmlElement("checkRemoteHost")]
        public bool? CheckRemoteHost { get; set; }
        [XmlElement("responseTimeout")]
        public string ResponseTimeout { get; set; }
        [XmlElement("ignoreResponse")]
        public bool? IgnoreResponse { get; set; }
        [XmlElement("queueOnResponseTimeout")]
        public bool? QueueOnResponseTimeout { get; set; }
        [XmlElement("dataTypeBinary")]
        public bool? DataTypeBinary { get; set; }
        [XmlElement("charsetEncoding")]
        public string CharsetEncoding { get; set; }
        [XmlElement("template")]
        public string Template { get; set; }

        [XmlElement("scheme")]
        public string Scheme { get; set; }
        [XmlElement("host")]
        public string Host { get; set; }
        [XmlElement("outputPattern")]
        public string OutputPattern { get; set; }
        [XmlElement("username")]
        public string Username { get; set; }
        [XmlElement("password")]
        public string Password { get; set; }
        [XmlElement("timeout")]
        public string Timeout { get; set; }
        [XmlElement("secure")]
        public bool? Secure { get; set; }
        [XmlElement("passive")]
        public bool? Passive { get; set; }
        [XmlElement("binary")]
        public bool? Binary { get; set; }
        [XmlElement("script")]
        public string Script { get; set; }
        [XmlElement("overrideLocalBinding")]
        public bool? OverrideLocalBinding { get; set; }
        [XmlElement("localAddress")]
        public string LocalAddress { get; set; }
        [XmlElement("localPort")]
        public int? LocalPort { get; set; }

        [XmlElement("mapVariables")]
        public string MapVariables { get; set; }
        [XmlElement("channelId")]
        public string ChannelId { get; set; }
        [XmlElement("channelTemplate")]
        public string ChannelTemplate { get; set; }

        #region Serialize Methods
        public bool ShouldSerializeChannelId() => ChannelId != null;
        public bool ShouldSerializeChannelTemplate() => ChannelTemplate != null;
        public bool ShouldSerializeMapVariables() => MapVariables != null;
        public bool ShouldSerializeOverrideLocalBinding() => OverrideLocalBinding.HasValue;
        public bool ShouldSerializeLocalAddress() => LocalAddress != null;
        public bool ShouldSerializeLocalPort() => LocalPort.HasValue;
        public bool ShouldSerializeServiceName() => ServiceName != null;
        public bool ShouldSerializeClassName() => ClassName != null;
        public bool ShouldSerializeBufferSize() => BufferSize != null;
        public bool ShouldSerializeSOAPWSDLUrl() => SOAPWSDLUrl != null;
        public bool ShouldSerializeSOAPService() => SOAPService != null;
        public bool ShouldSerializeSOAPPort() => SOAPPort != null;
        public bool ShouldSerializeSOAPLocationURI() => SOAPLocationURI != null;
        public bool ShouldSerializeSOAPSocketTimeout() => SOAPSocketTimeout != null;
        public bool ShouldSerializeSOAPOperation() => SOAPOperation != null;
        public bool ShouldSerializeSOAPAction() => SOAPAction != null;
        public bool ShouldSerializeSOAPEnvelope() => SOAPEnvelope != null;
        public bool ShouldSerializeRemoteAddress() => RemoteAddress != null;
        public bool ShouldSerializeRemotePort() => RemotePort != null;
        public bool ShouldSerializeSendTimeout() => SendTimeout != null;
        public bool ShouldSerializeResponseTimeout() => ResponseTimeout != null;
        public bool ShouldSerializeCharsetEncoding() => CharsetEncoding != null;
        public bool ShouldSerializeTemplate() => Template != null;
        public bool ShouldSerializeScheme() => Scheme != null;
        public bool ShouldSerializeHost() => Host != null;
        public bool ShouldSerializeOutputPattern() => OutputPattern != null;
        public bool ShouldSerializeUsername() => Username != null;
        public bool ShouldSerializePassword() => Password != null;
        public bool ShouldSerializeTimeout() => Timeout != null;
        //public bool ShouldSerializeScript() => Script);


        public bool ShouldSerializeReceiveTimeout() => ReceiveTimeout.HasValue;
        public bool ShouldSerializeMaxConnections() => MaxConnections.HasValue;

        public bool ShouldSerializeSOAPIsOneWayInvocation() => SOAPIsOneWayInvocation.HasValue;
        public bool ShouldSerializeKeepConnectionOpen() => KeepConnectionOpen.HasValue;
        public bool ShouldSerializeCheckRemoteHost() => CheckRemoteHost.HasValue;
        public bool ShouldSerializeIgnoreResponse() => IgnoreResponse.HasValue;
        public bool ShouldSerializeQueueOnResponseTimeout() => QueueOnResponseTimeout.HasValue;
        public bool ShouldSerializeDataTypeBinary() => DataTypeBinary.HasValue;
        public bool ShouldSerializeSecure() => Secure.HasValue;
        public bool ShouldSerializePassive() => Passive.HasValue;
        public bool ShouldSerializeBinary() => Binary.HasValue;

        #endregion

    }
}
