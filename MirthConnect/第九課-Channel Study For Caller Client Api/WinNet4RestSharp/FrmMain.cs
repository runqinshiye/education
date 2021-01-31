using Common.RestSharpNet4;
using Common.RestSharpNet4.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WinNet4RestSharp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback += (senderIns, certificate, chain, errors) => true;
            ServicePointManager.Expect100Continue = true;
            //.Net 4.5以上版本可以直接使用
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //.Net 4.0版本使用下面代码
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            
            var clientR = new RestClient("https://localhost:8443/api");
            //获取用户列表
            clientR.Authenticator = new HttpBasicAuthenticator("admin", "admin");
            var request = new RestRequest("users", Method.GET);
            IRestResponse response = clientR.Execute(request);
            var status = response.StatusCode;
            //登录
            request = new RestRequest("users/_login", Method.POST);
            request.Timeout = 10000;
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("username", "admin");
            request.AddParameter("password", "admin");
            
            response = clientR.Execute(request);
            if (response.StatusCode.ToString().Equals("OK"))
            {
              var  content = response.Content;
            }
        }
    }
}
