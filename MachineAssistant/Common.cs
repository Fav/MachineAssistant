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
        public static Dictionary<string, IMACmd> g_CMDDir = new Dictionary<string, IMACmd>();
        public static void OutLog(string str)
        {
            System.Windows.Forms.MessageBox.Show(str);
        }
    }
}
