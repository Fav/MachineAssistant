using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAEngine
{
    public interface IMACmd
    {
        Dictionary<string, object> MAParams { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        bool Excute();
        void OutLog();
    }
}
