using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1.mod
{
    [DataContract]
    public class rzm9
    {
        [DataMember]
        public int code { get; set; }
        [DataMember]
        public string msg { get; set; }

    }
}
