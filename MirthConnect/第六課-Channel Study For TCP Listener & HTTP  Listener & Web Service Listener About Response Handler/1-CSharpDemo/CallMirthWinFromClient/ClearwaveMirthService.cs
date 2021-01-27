using System;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CallMirthWinFromClient
{
    public partial class ClearwaveMirthService : IDisposable
    {
        public string Url { get; set; }

        public string acceptMessage(string arg0)
        {
            // Example Request:
            // <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ws="http://ws.connectors.connect.mirth.com/">
            //    <soapenv:Header/>
            //    <soapenv:Body>
            //       <ws:acceptMessage>
            //          <arg0>gero et</arg0>
            //       </ws:acceptMessage>
            //    </soapenv:Body>
            // </soapenv:Envelope>
            var request = (HttpWebRequest)HttpWebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8";
            request.UserAgent = "ClearwaveMirthServiceClient";
            request.Headers.Add("SOAPAction", "");
            var postDataBuffer = Encoding.UTF8.GetBytes(SOAPEnvelopStart + XMLEncode(arg0) + SOAPEnvelopEnd);
            request.ContentLength = postDataBuffer.Length;
            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(postDataBuffer, 0, postDataBuffer.Length);
            }
            // Example Response:
            // <S:Envelope xmlns:S="http://schemas.xmlsoap.org/soap/envelope/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/">
            //    <SOAP-ENV:Header/>
            //    <S:Body>
            //       <ns2:acceptMessageResponse xmlns:ns2="http://ws.connectors.connect.mirth.com/">
            //          <return>ACK</return>
            //       </ns2:acceptMessageResponse>
            //    </S:Body>
            // </S:Envelope>
            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString() + " " + ReadContentFromResult(response));
            }
            return ReadContentFromResult(response);
        }

        private static string XMLEncode(string text)
        {
            return new XElement("arg0", text).ToString();
        }

        private static string ReadContentFromResult(HttpWebResponse response)
        {
            using (var reader = new XmlTextReader(response.GetResponseStream()))
            {
                while (reader.Read())
                {
                    if (reader.Name.ToLower() == "return")
                    {
                        return reader.ReadInnerXml();
                    }
                }
            }
            return "";
        }

        public void Dispose()
        {
            // no op
        }

        private const string SOAPEnvelopStart = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://ws.connectors.connect.mirth.com/""><soapenv:Header/><soapenv:Body><ws:acceptMessage>";
        private const string SOAPEnvelopEnd = @"</ws:acceptMessage></soapenv:Body></soapenv:Envelope>";
    }
}
