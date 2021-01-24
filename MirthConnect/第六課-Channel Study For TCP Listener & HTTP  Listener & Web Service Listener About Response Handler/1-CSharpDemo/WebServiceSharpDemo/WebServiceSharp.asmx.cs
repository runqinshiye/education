using System.Data;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Web.Services;

namespace WebServiceSharpDemo
{
    /// <summary>
    /// 潤沁實業C#版本Webservice接口服务系统
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/", Description = "<center><strong>潤沁實業开放给Mirth Connect的C#版本接口服务</strong></center>")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class WebServiceSharp : System.Web.Services.WebService
    {
        //创建日志记录组件实例
        public static log4net.ILog FileLogIns = log4net.LogManager.GetLogger("FileLog.Logging");
        public WebServiceSharp()
        {
            //修改日期格式
            Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN");
            Thread.CurrentThread.CurrentCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator = "-";
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortTimePattern = "HH:mm:ss";
        }
        [WebMethod(Description = "测试本Webservice服务是否搭建OK", EnableSession = false)]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "数据库连接测试", EnableSession = false)]
        public string DBConnTest()
        {
            int i= DBProcess.DbConnTest();
            string tipInfo = i == 1 ? "连接成功." : "连接失败!";
            return tipInfo;
        }
        /// <summary>
        /// 取得患者信息
        /// </summary>
        /// <param name="pid">病案号</param>
        [WebMethod(Description = "取得患者信息", EnableSession = false)]
        public string acceptMessage(string pid)
        {
            string retXmlStr = "";
            if (!pid.Equals(""))
            {
                string sqlstr = $"select * from patient where pid={pid}";
                FileLogIns.Info($"sql：{sqlstr}");
                DBProcess ins = new DBProcess();
                DataTable dt = ins.GetDt(sqlstr);
                if (dt != null)
                {
                    retXmlStr = GetPatInfo(dt);
                }
                else
                {
                    retXmlStr = GetNullPatInfo(pid);
                }
            }
            FileLogIns.Info($"GetPatientInfo响应为：{retXmlStr}");
            return retXmlStr;
        }
        private string GetPatInfo(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<patient>");
            sb.Append("<reason></reason>");
            sb.Append("<info>");
            sb.Append($"<pid>{dt.Rows[0]["pid"].ToString()}</pid>");
            sb.Append($"<name>{dt.Rows[0]["name"].ToString()}</name>");
            sb.Append($"<sex>{dt.Rows[0]["sex"].ToString()}</sex>");
            sb.Append($"<dob>{dt.Rows[0]["dob"].ToString()}</dob>");
            //Xml特殊字符的处理:在C#中，直接调用C#提供的方法，保存之后就会自动将xml几个特殊字符转为对应实体
            //string s =System.Security.SecurityElement.Escape(s);
            //例：臺灣'<&>"台中 ➱➱➱ 臺灣&apos;&lt;&amp;&gt;&quot;台中
            sb.Append($"<addr>{System.Security.SecurityElement.Escape(dt.Rows[0]["addr"].ToString())}</addr>");
            sb.Append($"<ssn>{dt.Rows[0]["ssn"].ToString()}</ssn>");
            sb.Append($"<status>{dt.Rows[0]["status"].ToString()}</status>");
            sb.Append("</info>");
            sb.Append("</patient>");
            return sb.ToString();
        }
        private string GetNullPatInfo(string pid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<patient>");
            sb.Append($"<reason>pid:{pid}未查询到患者信息.</reason>");
            sb.Append("<info>");
            sb.Append($"<pid></pid>");
            sb.Append($"<name></name>");
            sb.Append($"<sex></sex>");
            sb.Append($"<dob></dob>");
            sb.Append($"<addr></addr>");
            sb.Append($"<ssn></ssn>");
            sb.Append($"<status></status>");
            sb.Append("</info>");
            sb.Append("</patient>");
            return sb.ToString();
        }
    }
}
