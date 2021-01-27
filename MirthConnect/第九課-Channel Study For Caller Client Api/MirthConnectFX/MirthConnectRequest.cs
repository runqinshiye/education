using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace MirthConnectFX
{
    public class MirthConnectRequest : IMirthConnectRequest
    {
        private readonly IHttpWebRequestFactory httpRequestFactory;
        private string url;
        private readonly IDictionary<string, string> postData;

        public string AuthSessionId { get; set; }
        public string ContentType { get; set; } = "application/x-www-form-urlencoded";
        public IDictionary<string, string> UrlParameters { get; set; }

        public MirthConnectRequest(IHttpWebRequestFactory httpRequestFactory, string url)
        {
            this.httpRequestFactory = httpRequestFactory;
            this.url = url;
            this.postData = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();
        }

        public virtual IMirthConnectRequest ForOperation(string operation)
        {
            this.url += "/" + operation;
            //AddPostData("op", operation);
            return this;
        }

        //public virtual IMirthConnectRequest ForUrlParam(string param, string paramVal)
        //{
        //    if (!this.url.Contains("?"))
        //        this.url += "?" + param + "=" + paramVal;
        //    else
        //        this.url += "&" + param + "=" + paramVal;

        //    return this;
        //}

        public IMirthConnectResponse Execute()
        {
            var data = PreparePostData();

            var httpRequest = httpRequestFactory.Create(new Uri(url));

            httpRequest.Method = "POST";
            httpRequest.ContentType = ContentType;
            httpRequest.ContentLength = data.Length;
            httpRequest.CookieContainer = new CookieContainer();

            IncludeAuthCookieIfAvailable(httpRequest);

            using (var dataStream = httpRequest.GetRequestStream())
            {
                dataStream.Write(data, 0, data.Length);
            }

            try
            {
                return new MirthConnectResponse(httpRequest.GetResponse());
            }
            catch (WebException ex)
            {
                const string message = "Mirth returned error processing request";
                var remoteError = string.Empty;
                
                if (ex.Response == null)
                    throw new MirthConnectException(message, remoteError, ex);

                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    remoteError = reader.ReadToEnd();
                }

                throw new MirthConnectException(message, remoteError, ex);
            }
        }

        public IMirthConnectResponse ExecuteJustBody()
        {
            var data = PreparePostBodyData();

            var httpRequest = httpRequestFactory.Create(new Uri(url));

            httpRequest.Method = "POST";
            httpRequest.ContentType = ContentType;
            httpRequest.ContentLength = data.Length;
            httpRequest.CookieContainer = new CookieContainer();

            IncludeAuthCookieIfAvailable(httpRequest);

            using (var dataStream = new StreamWriter(httpRequest.GetRequestStream()))
            {
                dataStream.Write(data);
            }

            try
            {
                return new MirthConnectResponse(httpRequest.GetResponse());
            }
            catch (WebException ex)
            {
                const string message = "Mirth returned error processing request";
                var remoteError = string.Empty;

                if (ex.Response == null)
                    throw new MirthConnectException(message, remoteError, ex);

                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    remoteError = reader.ReadToEnd();
                }

                throw new MirthConnectException(message, remoteError, ex);
            }
        }

        public IMirthConnectResponse ExecutePut()
        {
            var data = PreparePostBodyData();
            PrepareUrl();
            var httpRequest = httpRequestFactory.Create(new Uri(url));

            httpRequest.Method = "PUT";
            httpRequest.ContentType = ContentType;
            httpRequest.ContentLength = data.Length;
            httpRequest.CookieContainer = new CookieContainer();

            IncludeAuthCookieIfAvailable(httpRequest);

            using (var dataStream = new StreamWriter(httpRequest.GetRequestStream()))
            {
                dataStream.Write(data);
            }

            try
            {
                return new MirthConnectResponse(httpRequest.GetResponse());
            }
            catch (WebException ex)
            {
                const string message = "Mirth returned error processing request";
                var remoteError = string.Empty;

                if (ex.Response == null)
                    throw new MirthConnectException(message, remoteError, ex);

                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    remoteError = reader.ReadToEnd();
                }

                throw new MirthConnectException(message, remoteError, ex);
            }
        }

        public IMirthConnectResponse ExecuteGet()
        {
            var data = PreparePostData();
            PrepareUrl();
            var httpRequest = httpRequestFactory.Create(new Uri(Uri.EscapeUriString(url)));

            //httpRequest.Method = "POST";
            //httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.ContentLength = data.Length;
            httpRequest.CookieContainer = new CookieContainer();

            IncludeAuthCookieIfAvailable(httpRequest);


            try
            {
                var ret = new MirthConnectResponse(httpRequest.GetResponse());
                return ret;
            }
            catch (WebException ex)
            {
                const string message = "Mirth returned error processing request";
                var remoteError = string.Empty;

                if (ex.Response == null)
                    throw new MirthConnectException(message, remoteError, ex);

                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    remoteError = reader.ReadToEnd();
                }

                throw new MirthConnectException(message, remoteError, ex);
            }
        }

        public void AddPostData(string key, string value)
        {
            postData.Add(key, value);
        }

        public void AddUrlData(string key, string value)
        {
            UrlParameters.Add(key, value);
        }

        public IDictionary<string, string> GetPostData()
        {
            return postData;
        }

        private byte[] PreparePostData()
        {
            var sb = new StringBuilder();
            foreach (var postItem in postData)
                sb.AppendFormat("{0}={1}&", postItem.Key, UrlEncode(postItem.Value));

            return Encoding.UTF8.GetBytes(sb.ToString().TrimEnd('&'));
        }

        private string PreparePostBodyData()
        {
            var body = "";
            if(postData.ContainsKey("body"))
            {
                string value;
                var tryed = postData.TryGetValue("body", out value);

                if (tryed)
                    body = value;
            }

            return new StringContent(body, Encoding.UTF8, ContentType).ReadAsStringAsync().Result;
        }

        private void PrepareUrl()
        {
            if(UrlParameters.Count > 0)
            {
                url += "?";

                foreach (var item in UrlParameters)
                    url += $"{item.Key}={item.Value}&";

                url = url.Remove(url.Length - 1, 1);
            }
        }

        private static string UrlEncode(string value)
        {
            const int limit = 2000;
            var sb = new StringBuilder();
            var loops = value.Length / limit;

            for (var i = 0; i <= loops; i++)
            {
                sb.Append(i < loops
                    ? Uri.EscapeDataString(value.Substring(limit*i, limit))
                    : Uri.EscapeDataString(value.Substring(limit*i)));
            }

            return sb.ToString();
        }

        private void IncludeAuthCookieIfAvailable(IHttpWebRequest httpRequest)
        {
            if (!string.IsNullOrWhiteSpace(AuthSessionId))
                httpRequest.CookieContainer.Add(new Cookie("JSESSIONID", AuthSessionId, "/", httpRequest.RequestUri.Host));
        }
    }
}