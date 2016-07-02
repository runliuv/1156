using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;
using ClassLibrary1.mod;

namespace ClassLibrary1
{
    [ServiceContract]
    public interface ILike
    {
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "*", RequestFormat = WebMessageFormat.Json)]
        Stream Some(Stream inputStream);

        [OperationContract]
        Stream GetZM9JF(Stream inp);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "*", RequestFormat = WebMessageFormat.Json)]
        rzm9 Test(zm9 inp);
    }
}
