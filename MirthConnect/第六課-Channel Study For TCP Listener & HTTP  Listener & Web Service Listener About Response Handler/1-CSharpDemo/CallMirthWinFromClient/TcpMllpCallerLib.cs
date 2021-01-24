using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace CallMirthWinFromClient
{
    public class TcpMllpCallerLib
    {
        private IPAddress _HostAddress = IPAddress.Parse("127.0.0.1");
        private int _Port = 4200;
        private string _LLPHeader = LLP.GetLLPString("[0x0B]");
        private string _LLPTrailer = LLP.GetLLPString("[0x1C][0x0D]");
        private bool _WaitForAck = true;
        private bool _SendAck = true;
        /// <summary>
        /// The Host Address of this TCP/IP Object
        /// </summary>
        public IPAddress HostAddress
        {
            get { return _HostAddress; }
            set { _HostAddress = value; }
        }
        /// <summary>
        /// The Port of this TCP/IP Object
        /// </summary>
        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }
        public bool WaitForAck
        {
            get { return _WaitForAck; }
            set { _WaitForAck = value; }
        }
        /// <summary>
        /// The Send Ack option for this TCP/IP Object, used to determine if an ack should be sent for each received message.
        /// </summary>
        public bool SendAck
        {
            get { return _SendAck; }
            set { _SendAck = value; }
        }
        public string SendMllpMsg(string msgContent,bool mllpFlag)
        {
            string ackStr = "";
            try
            {
                Program.FileLogIns.Info(msgContent);
                int BufferSize = 4096;
                TcpClient client = new TcpClient();
                IPEndPoint server = new IPEndPoint(HostAddress, Port);
                client.Connect(server);
                NetworkStream stream = client.GetStream();
                byte[] msgLLP;
                if (mllpFlag)
                {
                    msgLLP = Encoding.UTF8.GetBytes(String.Format("{0}{1}{2}", _LLPHeader, msgContent, _LLPTrailer));
                }
                else
                {
                    msgLLP = Encoding.UTF8.GetBytes(msgContent);
                }
                lock (stream)
                {
                    stream.Write(msgLLP, 0, msgLLP.Length);
                }
                
                if (WaitForAck)
                {
                    
                        byte[] ackLLP = new byte[BufferSize];
                        lock (stream)
                        {
                            stream.Read(ackLLP, 0, BufferSize);
                        }
                        //去除响应的首尾
                        ackStr = Encoding.UTF8.GetString(ackLLP).Replace(_LLPHeader,"").Replace(_LLPTrailer,"").Replace("\0", "").Trim();
                    
                }
                stream.Close();
                client.Close();
            }
            catch (SocketException se)
            {
                Program.FileLogIns.Error(se.Message);
            }
            catch (Exception ex)
            {
                Program.FileLogIns.Error(ex.Message);
            }
            return ackStr;
        }
    }
    public class LLP
    {
        /// <summary>
        /// The Char Value to use in the LLP Wrapper
        /// </summary>
        public char CharValue { get; set; }
        /// <summary>
        /// The Hex Value of the Char Code
        /// </summary>
        public string Hex { get; set; }
        /// <summary>
        /// The Hex Code Description
        /// </summary>
        public string Description { get; set; }

        public LLP() { }

        public LLP(char _CharValue, string _Hex, string _Desc)
        {
            CharValue = _CharValue;
            Hex = _Hex;
            Description = _Desc;
        }

        public static LLP LoadLLP(string _Hex)
        {
            LLP llp = LoadLLPList().Find(delegate (LLP l) { return l.Hex == _Hex; });
            return llp;
        }

        public static string GetLLPString(string s)
        {
            StringBuilder sb = new StringBuilder();
            Regex reg = new Regex("\\[0x[A-Za-z0-9]+\\]");
            MatchCollection matches = reg.Matches(s);
            foreach (Match match in matches)
            {
                LLP l = LoadLLP(match.Value);
                sb.Append(l.CharValue);
            }
            return sb.ToString();
        }

        public static List<LLP> LoadLLPList()
        {
            List<LLP> LLPList = new List<LLP>();
            LLPList.Add(new LLP((char)0, "[0x0]", "Null char"));
            LLPList.Add(new LLP((char)1, "[0x1]", "Start of Heading"));
            LLPList.Add(new LLP((char)2, "[0x2]", "Start of Text"));
            LLPList.Add(new LLP((char)3, "[0x3]", "End of Text"));
            LLPList.Add(new LLP((char)4, "[0x4]", "End of Transmission"));
            LLPList.Add(new LLP((char)5, "[0x5]", "Inquiry"));
            LLPList.Add(new LLP((char)6, "[0x6]", "Acknowledgment"));
            LLPList.Add(new LLP((char)7, "[0x7]", "Bell"));
            LLPList.Add(new LLP((char)8, "[0x8]", "Back Space"));
            LLPList.Add(new LLP((char)9, "[0x9]", "Horizontal Tab"));
            LLPList.Add(new LLP((char)10, "[0x0A]", "Line Feed"));
            LLPList.Add(new LLP((char)11, "[0x0B]", "Vertical Tab"));
            LLPList.Add(new LLP((char)12, "[0x0C]", "Form Feed"));
            LLPList.Add(new LLP((char)13, "[0x0D]", "Carriage Return"));
            LLPList.Add(new LLP((char)14, "[0x0E]", "Shift Out / X-On"));
            LLPList.Add(new LLP((char)15, "[0x0F]", "Shift In / X-Off"));
            LLPList.Add(new LLP((char)16, "[0x10]", "Data Line Escape"));
            LLPList.Add(new LLP((char)17, "[0x11]", "Device Control 1 (oft. XON)"));
            LLPList.Add(new LLP((char)18, "[0x12]", "Device Control 2"));
            LLPList.Add(new LLP((char)19, "[0x13]", "Device Control 3 (oft. XOFF)"));
            LLPList.Add(new LLP((char)20, "[0x14]", "Device Control 4"));
            LLPList.Add(new LLP((char)21, "[0x15]", "Negative Acknowledgment"));
            LLPList.Add(new LLP((char)22, "[0x16]", "Synchronous Idle"));
            LLPList.Add(new LLP((char)23, "[0x17]", "End of Transmit Block"));
            LLPList.Add(new LLP((char)24, "[0x18]", "Cancel"));
            LLPList.Add(new LLP((char)25, "[0x19]", "End of Medium"));
            LLPList.Add(new LLP((char)26, "[0x1A]", "Substitute"));
            LLPList.Add(new LLP((char)27, "[0x1B]", "Escape"));
            LLPList.Add(new LLP((char)28, "[0x1C]", "File Separator"));
            LLPList.Add(new LLP((char)29, "[0x1D]", "Group Separator"));
            LLPList.Add(new LLP((char)30, "[0x1E]", "Record Separator"));
            LLPList.Add(new LLP((char)31, "[0x1F]", "Unit Separator"));
            return LLPList;
        }
    }
}
