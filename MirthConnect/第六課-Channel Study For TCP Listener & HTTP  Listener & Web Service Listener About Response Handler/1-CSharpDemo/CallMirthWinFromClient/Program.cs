using System;
using System.Windows.Forms;

namespace CallMirthWinFromClient
{
    static class Program
    {
        //创建日志记录组件实例
        public static log4net.ILog FileLogIns = log4net.LogManager.GetLogger("FileLog.Logging");

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
