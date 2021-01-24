using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CallMirthWinFromClient
{
  public class HttpCallerLib
    {
       
        public static string SendHttpMsg(string msgUrl, string msgContent)
        {
            string retStr = "";
            try
            {
                Program.FileLogIns.Info(msgContent);
                byte[] dataArray = Encoding.UTF8.GetBytes(msgContent);//设置编码规格
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(msgUrl);//创建Web请求
                req.Method = "POST";
                req.ContentType = "text/plain; charset=utf-8";
                req.ContentLength = dataArray.Length;
                //写入post参数
                Stream Writer = req.GetRequestStream();//获取用于写入请求数据的Stream对象
                Writer.Write(dataArray, 0, dataArray.Length);//把参数数据写入请求数据流
                Writer.Close();
                HttpWebResponse rep = (HttpWebResponse)req.GetResponse();//获得相应
                int status = Convert.ToInt32(rep.StatusCode);
                using (StreamReader reader = new StreamReader(rep.GetResponseStream(), Encoding.UTF8))
                {
                    retStr = reader.ReadToEnd();
                    Program.FileLogIns.Info(retStr);
                }
                rep.Close();
            }
            catch (Exception ex)
            {
                Program.FileLogIns.Error(ex.ToString());
                retStr = "";
            }
            return retStr;
        }

       
        public static int SendMsgForStatus(string Url, string methodName, Dictionary<string, string> Paras)
        {
            int status = 0;
            try
            {
                if (Paras.Count > 0)
                {

                    //请求参数
                    StringBuilder buffer = new StringBuilder();
                    int i = 0;
                    foreach (string key in Paras.Keys)
                    {
                        if (i > 0)
                        {
                            buffer.AppendFormat("&{0}={1}", key, Paras[key]);
                        }
                        else
                        {
                            buffer.AppendFormat("{0}={1}", key, Paras[key]);
                        }
                        i++;
                    }
                    string postData = buffer.ToString();
                    buffer.Clear();
                    buffer = null;
                    byte[] dataArray = Encoding.UTF8.GetBytes(postData);//设置编码规格
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url + "/" + methodName);//根据要POST的URL地址创建Web请求
                    req.Method = "Post";
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = dataArray.Length;
                    //写入post参数
                    Stream Writer = req.GetRequestStream();//获取用于写入请求数据的Stream对象
                    Writer.Write(dataArray, 0, dataArray.Length);//把参数数据写入请求数据流
                    Writer.Close();
                    //获取状态码
                    HttpWebResponse rep = (HttpWebResponse)req.GetResponse();//获得相应
                    status = Convert.ToInt32(rep.StatusCode);
                    rep.Close();
                }
            }
            catch
            {
                status = 0;
            }
            return status;
        }
    }
}
