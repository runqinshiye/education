using System;
using System.Net;
using System.Windows.Forms;

namespace CallMirthWinFromClient
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
 
        private void btnWsSend_Click(object sender, EventArgs e)
        {
            WebServiceProxyCallerLib wsd = new WebServiceProxyCallerLib(WsTxtUrl.Text.Trim(), WsTxtFunName.Text.Trim());
            outTxt.Text = Convert.ToString(wsd.ExecuteQuery(WsTxtFunName.Text.Trim(), InRtbTxt.Text.Trim()));
            wsd.Dispose();
        }

        private void btnHttpSender_Click(object sender, EventArgs e)
        {
            outTxt.Text= HttpCallerLib.SendHttpMsg(string.Format("http://{0}:{1}/", httpTxtIP.Text.Trim(), httpTxtPort.Text.Trim()),InRtbTxt.Text.Trim());
        }

        private void btnTcpSender_Click(object sender, EventArgs e)
        {
            TcpMllpCallerLib tcpIns = new TcpMllpCallerLib();
            tcpIns.HostAddress= IPAddress.Parse(TcpTxtIP.Text.Trim());
            tcpIns.Port = int.Parse(TcpTxtPort.Text.Trim());
            outTxt.Text = tcpIns.SendMllpMsg(InRtbTxt.Text.Trim(),chkMLLP.Checked);
        }
        private void btnWsInit_Click(object sender, EventArgs e)
        {
            InRtbTxt.Text = "<patient><pid>103</pid><ret>0</ret></patient>";
            outTxt.Text = "";
        }

        private void btnHttpInit_Click(object sender, EventArgs e)
        {
            InRtbTxt.Text = InXmlParas;
            outTxt.Text = "";
        }

        private void btnTcpInit_Click(object sender, EventArgs e)
        {
            InRtbTxt.Text = InHl7v2Paras.ToString();
            outTxt.Text = "";
        }
        System.Text.StringBuilder InHl7v2Paras = new System.Text.StringBuilder();
        string InXmlParas = "<patient><pid>110</pid><name>撰獲濟</name><sex>M</sex><dob>19650108</dob><addr>臺灣大學</addr><ssn>33661489</ssn><status>0</status></patient>";
        private void FrmMain_Load(object sender, EventArgs e)
        {
            InHl7v2Paras.AppendLine(@"MSH|^~\&|SMS|IAH|CERNER|PATHNT|200201291848||ADT^A01|CHPFADIT|P|2.3|||AL|NE|");
            InHl7v2Paras.AppendLine("EVN|A01|200201291848|||REJKB1");
            InHl7v2Paras.AppendLine("PID||53820452|00664524|220675537|AHMED^AYALNE^^^^||19781218|M||E|5718 SEMINARY RD #B5^^FALLS CHURCH^VA^22041||(703)379-8374|||||0053820452|220675537||");
            InHl7v2Paras.AppendLine("PV1||I|2324^2302^-B ||||1111111^PINA|||MED|||||||1111111^PINA|S||S|P||||||||||||||||||IAH|||||200201291848|");
            InHl7v2Paras.Append("PV2|||^SEIZURE, FEVER, RLQ PAIN");
        }
    }
}
