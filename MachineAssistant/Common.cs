using MAEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineAssistant
{
    public static class Common
    {
        public static Dictionary<string, CCMDTag> g_CMDDir = new Dictionary<string, CCMDTag>();
        public static void OutLog(string str)
        {
            System.Windows.Forms.MessageBox.Show(str);
        }
    }
    public class CCMDTag
    {
        public IMACmd MACmd { get; set; }
        public string DllDescrip { get; set; }
    }
}
