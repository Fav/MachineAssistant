using MAEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineAssistant
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            //读取所有dll
            string dllDir = Application.StartupPath + "/plugin";
            if (!Directory.Exists(dllDir))
            {
                Directory.CreateDirectory(dllDir);
            }
            var dllFiles =Directory.EnumerateFiles(dllDir,"*.dll", SearchOption.AllDirectories);
            foreach (var file in dllFiles)
            {
                Assembly a = Assembly.LoadFile(file);
                
                Type[] types = a.GetTypes();
                foreach (var type in types)
                {
                    Type[] theInterfaces = type.GetInterfaces();
                    foreach (var theInterface in theInterfaces)
                    {
                        if (theInterface.FullName.Equals("MAEngine.IMACmd"))
                        {
                            string dllDescrip = ((System.Reflection.AssemblyDescriptionAttribute)(((System.Attribute[])(a.GetCustomAttributes()))[8])).Description;
                            Common.g_CMDDir[type.FullName] = new CCMDTag() { MACmd = GetPluginObject(type), DllDescrip = dllDescrip };
                        }
                    }
                }
            }

            //xml文档,可供翻译






            Application.Run(new MainForm());
        }

        private static IMACmd GetPluginObject(Type type)
        {
            IMACmd macmd = null;
            try
            {
                //创建一个插件对象实例
                macmd = Activator.CreateInstance(type) as IMACmd;
            }
            catch
            {
                Common.OutLog(type.FullName + "反射生成对象时发生异常");
            }
            return macmd;
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}
