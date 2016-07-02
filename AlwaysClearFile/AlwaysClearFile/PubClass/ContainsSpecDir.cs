using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsualLib
{
    public class SpecDirOp
    {
        /// <summary>
        /// 判断是否包含特殊目录。inputPath 要判断的目录。bIsSpec 是否包含特殊目录。specDirName 特殊目录名称。outputPath 去除特殊目录的部分。
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="bIsSpec"></param>
        /// <param name="specDirName"></param>
        /// <param name="outputPath"></param>
        public  void ContainSpecDir(string inputPath, out bool bIsSpec, out string specDirName, out string outputPath)
        {

            bIsSpec = false;
            specDirName = string.Empty;
            outputPath = inputPath;
            IList<string> lstsf = Enum.GetNames(typeof(Environment.SpecialFolder));
            foreach (string sf in lstsf)
            {
                Environment.SpecialFolder sfType = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), sf);
                string specDir = Environment.GetFolderPath(sfType);
                if (string.IsNullOrEmpty(specDir))
                {
                    continue;
                }
                if (inputPath.ToLower().Contains(specDir.ToLower()))
                {
                    bIsSpec = true;
                    specDirName = sf;
                    outputPath = inputPath.ToLower().Replace(specDir.ToLower(), "");
                    break;
                }
            }
        }

        /// <summary>
        /// 按名字获取特殊目录的路径。
        /// </summary>
        /// <param name="specDirName"></param>
        /// <returns></returns>
        public string GetSpecDirValue(string specDirName)
        {
            string tmp = "";

            Environment.SpecialFolder sfType = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), specDirName);
            tmp = Environment.GetFolderPath(sfType);

            return tmp;
        }
    }
}
