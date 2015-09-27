using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperator
{
    public class FileOperCreateTxt : FileOper
    {
        public string OutFilePath { get; set; }
        public string Content { get; set; }
        public FileOperCreateTxt()
        {
            setAttr();
            MAParams = new Dictionary<string, object>();
            MAParams["exePath"] = "";
            MAParams["param"] =string.Format( "echo {0}>{1}" ,Content,OutFilePath);
        }
        void setAttr() 
        {
            Name = "创建文本文件";
            Description = "根据文件名创建一个空文本文档,或者根据文件内容和文件名创建文本文档";
        }
    }
}
