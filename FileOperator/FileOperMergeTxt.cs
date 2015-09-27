using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperator
{
    public class FileOperMergeTxt : FileOper
    {
        public string[] StrSourcePaths { get; set; }
        public string[] StrTargetPath { get; set; }
        public FileOperMergeTxt()
        {
            setAttr();
            MAParams = new Dictionary<string, object>();
            MAParams["exePath"] = "";
            MAParams["param"] = string.Format("copy /y  {0} {1}",StrSourcePaths==null?"": string.Join("+", StrSourcePaths), StrTargetPath);
        }
        void setAttr()
        {
            Name = "合并文本文件";
            Description = "将多个文本文件合成一个文本文件";
        }
    }
}
