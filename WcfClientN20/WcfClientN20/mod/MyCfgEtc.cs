using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1.pab
{
    public class MyCfgEtc
    {
        public static string xmlCfgName = "MyCfg.xml";

        public static string xmlCfgFullName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) 
            + "\\MyCfg.xml";
    }
}
