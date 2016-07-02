using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TestPlaza4Wcf.Model
{
    [Serializable]
    [DataContract]
    public class cyms_bt_dish_favourableParameters
    {
        [DataMember]
        public string ch_boothid { get; set; }
    }
}
