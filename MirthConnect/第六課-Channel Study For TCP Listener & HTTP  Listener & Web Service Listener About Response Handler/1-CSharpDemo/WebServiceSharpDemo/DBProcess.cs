using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;

namespace WebServiceSharpDemo
{
    public class DBProcess
    {
       
        //定义数据库操作对象
        public static Database _db = EnterpriseLibraryContainer.Current.GetInstance<Database>("MariaDB");
        //创建日志记录组件实例
        public static log4net.ILog FileLog = log4net.LogManager.GetLogger("FileLog.Logging");
        //数据库连接测试
        public static int DbConnTest()
        {
            try
            {
                Database _dbTest = EnterpriseLibraryContainer.Current.GetInstance<Database>("MariaDB");
                System.Data.Common.DbConnection dbconn = _dbTest.CreateConnection();
                dbconn.Open();
                if (dbconn.State == ConnectionState.Open)
                {
                    dbconn.Close();
                }
                _dbTest = null;
                return 1;
            }
            catch (Exception ex)
            {
                ShowException(ex, "数据库连接测试失败");
                return 0;
            }
        }
        public static void disposeDb()
        {
            _db = null;
        }
        public static string GetUidStrUUID()
        {
            return Guid.NewGuid().ToString("N");
        }

        #region 数据库错误日志
        public static void ShowException(Exception ex, string infos)
        {
            string exMessage = ex.Message;
            string exSource = ex.Source;
            string exStackTrace = ex.StackTrace;
            string exInnerMessage = string.Empty;
            string exInnerSource = string.Empty;
            string exInnerStackTrace = string.Empty;

            if (ex.InnerException != null)
            {
                exInnerMessage = ex.InnerException.Message;
                exInnerSource = ex.InnerException.Source;
                exInnerStackTrace = ex.InnerException.StackTrace;
            }
            string exInfoStr = "=======ex异常=======" + Environment.NewLine +
                            exMessage + Environment.NewLine +
                            exSource + Environment.NewLine +
                            exStackTrace + Environment.NewLine +
                            "=======exInner异常=======" + Environment.NewLine +
                            exInnerMessage + Environment.NewLine +
                            exInnerSource + Environment.NewLine +
                            exInnerStackTrace + Environment.NewLine +
                            "=======附加信息=======" + Environment.NewLine +
                            infos;
            //写日志
            System.Console.WriteLine("错误信息：" + exInfoStr);
            FileLog.Error(exInfoStr);
        }
        #endregion
        
        #region 通用数据库操作
        public DataSet GetDs(string sqlstr)
        {
            DataSet ds = null;
            try
            {
                DbCommand cmd = _db.GetSqlStringCommand(sqlstr);
                ds = _db.ExecuteDataSet(cmd);
            }
            catch (Exception ex)
            {
                FileLog.ErrorFormat("{0}调用GetDs异常：{1}", sqlstr, ex.ToString());
                ds = null;
            }
            return ds;
        }

        public DataTable GetDt(string sqlstr)
        {
            DataTable dt = null;
            try
            {
                DbCommand cmd = _db.GetSqlStringCommand(sqlstr);
                DataSet ds = _db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                FileLog.ErrorFormat("{0}调用GetDt异常：{1}", sqlstr, ex.ToString());
                dt = null;
            }
            return dt;
        }


        public IDataReader GetReader(string sqlstr)
        {
            IDataReader dataReader = null;
            try
            {
                DbCommand cmd = _db.GetSqlStringCommand(sqlstr);
                dataReader = _db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                FileLog.ErrorFormat("{0}调用GetReader异常：{1}", sqlstr, ex.ToString());
                dataReader = null;
            }
            return dataReader;
        }
        //获取服务器时间
        public static string GetServerDt()
        {
            string retStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sqlstr = "select  date_format(now(),'%Y-%m-%d %H:%i:%s') as dt";
            try
            {
                DbCommand cmd = _db.GetSqlStringCommand(sqlstr);
                retStr = _db.ExecuteScalar(cmd).ToString();
            }
            catch (Exception ex)
            {
                FileLog.ErrorFormat("GetServerDt异常：{0}", ex.ToString());
                retStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            return retStr;
        }
        //获取Mariadb自10.3开始支持的自定义序号发生器tuid_seq的值
        public Int64 GetOneSeqValue()
        {
            string sqlstr = "SELECT NEXT VALUE FOR tuid_seq";
            try
            {
                DbCommand cmd = _db.GetSqlStringCommand(sqlstr);
                Int64 value = Convert.ToInt64(_db.ExecuteScalar(cmd));
                return value;
            }
            catch (Exception ex)
            {
                ShowException(ex, "GetOneSeqValue 执行语句,序号发生器tuid_seq错误：" + sqlstr);
            }
            return -1;
        }
        #endregion
    }
}