
namespace CallMirthWinFromClient
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnWsInit = new System.Windows.Forms.Button();
            this.btnWsSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WsTxtFunName = new System.Windows.Forms.TextBox();
            this.WsTxtUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.outTxt = new System.Windows.Forms.TextBox();
            this.InRtbTxt = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHttpInit = new System.Windows.Forms.Button();
            this.btnHttpSender = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.httpTxtPort = new System.Windows.Forms.TextBox();
            this.httpTxtIP = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkMLLP = new System.Windows.Forms.CheckBox();
            this.btnTcpInit = new System.Windows.Forms.Button();
            this.btnTcpSender = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TcpTxtPort = new System.Windows.Forms.TextBox();
            this.TcpTxtIP = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnWsInit);
            this.groupBox1.Controls.Add(this.btnWsSend);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.WsTxtFunName);
            this.groupBox1.Controls.Add(this.WsTxtUrl);
            this.groupBox1.Location = new System.Drawing.Point(81, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(906, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Web  Service Sender";
            // 
            // btnWsInit
            // 
            this.btnWsInit.Location = new System.Drawing.Point(708, 20);
            this.btnWsInit.Name = "btnWsInit";
            this.btnWsInit.Size = new System.Drawing.Size(94, 26);
            this.btnWsInit.TabIndex = 12;
            this.btnWsInit.Text = "初始化传入值";
            this.btnWsInit.UseVisualStyleBackColor = true;
            this.btnWsInit.Click += new System.EventHandler(this.btnWsInit_Click);
            // 
            // btnWsSend
            // 
            this.btnWsSend.Location = new System.Drawing.Point(818, 10);
            this.btnWsSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnWsSend.Name = "btnWsSend";
            this.btnWsSend.Size = new System.Drawing.Size(82, 21);
            this.btnWsSend.TabIndex = 11;
            this.btnWsSend.Text = "A.发送消息";
            this.btnWsSend.UseVisualStyleBackColor = true;
            this.btnWsSend.Click += new System.EventHandler(this.btnWsSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "函 数 名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "WSDL地址：";
            // 
            // WsTxtFunName
            // 
            this.WsTxtFunName.Location = new System.Drawing.Point(471, 24);
            this.WsTxtFunName.Margin = new System.Windows.Forms.Padding(2);
            this.WsTxtFunName.Name = "WsTxtFunName";
            this.WsTxtFunName.Size = new System.Drawing.Size(221, 21);
            this.WsTxtFunName.TabIndex = 8;
            this.WsTxtFunName.Text = "acceptMessage";
            // 
            // WsTxtUrl
            // 
            this.WsTxtUrl.Location = new System.Drawing.Point(70, 25);
            this.WsTxtUrl.Margin = new System.Windows.Forms.Padding(2);
            this.WsTxtUrl.Name = "WsTxtUrl";
            this.WsTxtUrl.Size = new System.Drawing.Size(332, 21);
            this.WsTxtUrl.TabIndex = 7;
            this.WsTxtUrl.Text = "http://localhost:8004/services/Mirth?wsdl";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 411);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "返回值：";
            // 
            // outTxt
            // 
            this.outTxt.Location = new System.Drawing.Point(19, 426);
            this.outTxt.Margin = new System.Windows.Forms.Padding(2);
            this.outTxt.Multiline = true;
            this.outTxt.Name = "outTxt";
            this.outTxt.Size = new System.Drawing.Size(1022, 108);
            this.outTxt.TabIndex = 12;
            // 
            // InRtbTxt
            // 
            this.InRtbTxt.Location = new System.Drawing.Point(19, 250);
            this.InRtbTxt.Name = "InRtbTxt";
            this.InRtbTxt.Size = new System.Drawing.Size(1022, 158);
            this.InRtbTxt.TabIndex = 15;
            this.InRtbTxt.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 234);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "传入值：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHttpInit);
            this.groupBox2.Controls.Add(this.btnHttpSender);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.httpTxtPort);
            this.groupBox2.Controls.Add(this.httpTxtIP);
            this.groupBox2.Location = new System.Drawing.Point(81, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(906, 59);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HTTP Sender";
            // 
            // btnHttpInit
            // 
            this.btnHttpInit.Location = new System.Drawing.Point(708, 20);
            this.btnHttpInit.Name = "btnHttpInit";
            this.btnHttpInit.Size = new System.Drawing.Size(94, 26);
            this.btnHttpInit.TabIndex = 12;
            this.btnHttpInit.Text = "初始化传入值";
            this.btnHttpInit.UseVisualStyleBackColor = true;
            this.btnHttpInit.Click += new System.EventHandler(this.btnHttpInit_Click);
            // 
            // btnHttpSender
            // 
            this.btnHttpSender.Location = new System.Drawing.Point(818, 19);
            this.btnHttpSender.Margin = new System.Windows.Forms.Padding(2);
            this.btnHttpSender.Name = "btnHttpSender";
            this.btnHttpSender.Size = new System.Drawing.Size(82, 27);
            this.btnHttpSender.TabIndex = 11;
            this.btnHttpSender.Text = "发送消息";
            this.btnHttpSender.UseVisualStyleBackColor = true;
            this.btnHttpSender.Click += new System.EventHandler(this.btnHttpSender_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(426, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "端口：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "IP地址：";
            // 
            // httpTxtPort
            // 
            this.httpTxtPort.Location = new System.Drawing.Point(471, 24);
            this.httpTxtPort.Margin = new System.Windows.Forms.Padding(2);
            this.httpTxtPort.Name = "httpTxtPort";
            this.httpTxtPort.Size = new System.Drawing.Size(221, 21);
            this.httpTxtPort.TabIndex = 8;
            this.httpTxtPort.Text = "8005";
            // 
            // httpTxtIP
            // 
            this.httpTxtIP.Location = new System.Drawing.Point(70, 25);
            this.httpTxtIP.Margin = new System.Windows.Forms.Padding(2);
            this.httpTxtIP.Name = "httpTxtIP";
            this.httpTxtIP.Size = new System.Drawing.Size(332, 21);
            this.httpTxtIP.TabIndex = 7;
            this.httpTxtIP.Text = "127.0.0.1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkMLLP);
            this.groupBox3.Controls.Add(this.btnTcpInit);
            this.groupBox3.Controls.Add(this.btnTcpSender);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.TcpTxtPort);
            this.groupBox3.Controls.Add(this.TcpTxtIP);
            this.groupBox3.Location = new System.Drawing.Point(81, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(906, 59);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TCP Sender";
            // 
            // chkMLLP
            // 
            this.chkMLLP.AutoSize = true;
            this.chkMLLP.Checked = true;
            this.chkMLLP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMLLP.Location = new System.Drawing.Point(624, 26);
            this.chkMLLP.Name = "chkMLLP";
            this.chkMLLP.Size = new System.Drawing.Size(48, 16);
            this.chkMLLP.TabIndex = 13;
            this.chkMLLP.Text = "MLLP";
            this.chkMLLP.UseVisualStyleBackColor = true;
            // 
            // btnTcpInit
            // 
            this.btnTcpInit.Location = new System.Drawing.Point(708, 19);
            this.btnTcpInit.Name = "btnTcpInit";
            this.btnTcpInit.Size = new System.Drawing.Size(94, 26);
            this.btnTcpInit.TabIndex = 12;
            this.btnTcpInit.Text = "初始化传入值";
            this.btnTcpInit.UseVisualStyleBackColor = true;
            this.btnTcpInit.Click += new System.EventHandler(this.btnTcpInit_Click);
            // 
            // btnTcpSender
            // 
            this.btnTcpSender.Location = new System.Drawing.Point(818, 19);
            this.btnTcpSender.Margin = new System.Windows.Forms.Padding(2);
            this.btnTcpSender.Name = "btnTcpSender";
            this.btnTcpSender.Size = new System.Drawing.Size(82, 27);
            this.btnTcpSender.TabIndex = 11;
            this.btnTcpSender.Text = "发送消息";
            this.btnTcpSender.UseVisualStyleBackColor = true;
            this.btnTcpSender.Click += new System.EventHandler(this.btnTcpSender_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(426, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "端口：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "IP地址：";
            // 
            // TcpTxtPort
            // 
            this.TcpTxtPort.Location = new System.Drawing.Point(471, 24);
            this.TcpTxtPort.Margin = new System.Windows.Forms.Padding(2);
            this.TcpTxtPort.Name = "TcpTxtPort";
            this.TcpTxtPort.Size = new System.Drawing.Size(147, 21);
            this.TcpTxtPort.TabIndex = 8;
            this.TcpTxtPort.Text = "8006";
            // 
            // TcpTxtIP
            // 
            this.TcpTxtIP.Location = new System.Drawing.Point(70, 25);
            this.TcpTxtIP.Margin = new System.Windows.Forms.Padding(2);
            this.TcpTxtIP.Name = "TcpTxtIP";
            this.TcpTxtIP.Size = new System.Drawing.Size(332, 21);
            this.TcpTxtIP.TabIndex = 7;
            this.TcpTxtIP.Text = "127.0.0.1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(818, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "B.发送消息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 539);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.InRtbTxt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.outTxt);
            this.Name = "FrmMain";
            this.Text = "发送消息到Mirth[测试客户端]";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnWsSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WsTxtFunName;
        private System.Windows.Forms.TextBox WsTxtUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox outTxt;
        private System.Windows.Forms.RichTextBox InRtbTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHttpSender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox httpTxtPort;
        private System.Windows.Forms.TextBox httpTxtIP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTcpSender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TcpTxtPort;
        private System.Windows.Forms.TextBox TcpTxtIP;
        private System.Windows.Forms.Button btnHttpInit;
        private System.Windows.Forms.Button btnWsInit;
        private System.Windows.Forms.Button btnTcpInit;
        private System.Windows.Forms.CheckBox chkMLLP;
        private System.Windows.Forms.Button button1;
    }
}

