using MAEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperator
{
    public class FileOperMergeTxt : FileOper
    {
        public CMAGetUserFilePath SourcePaths { get; set; }
        public CMAGetUserDirPath TargetDir { get; set; }
        public FileOperMergeTxt()
        {
            MAParams = new Dictionary<string, object>();
            Name = "合并文本文件";
            Description = "将多个文本文件合成一个文本文件";
            SourcePaths = new CMAGetUserFilePath();
            TargetDir = new CMAGetUserDirPath();
        }
        protected override bool DoBeforeExcute()
        {
            var StrSourcePaths=SourcePaths.FilePaths;
            var StrTargetDir = TargetDir.FilePath;
            if (StrSourcePaths == null || StrSourcePaths.Length==0)
            {
                return false;
            }
            MAParams["exePath"] = "";
            MAParams["param"] = string.Format("copy /y  {0} {1}", string.Join("+", StrSourcePaths), StrTargetDir + "\\merge.txt");
            return base.DoBeforeExcute();
        }
    }
}
