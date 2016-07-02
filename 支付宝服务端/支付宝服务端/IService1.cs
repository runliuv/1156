using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.IO;
using 支付宝服务端.Common;

namespace 支付宝服务端
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService
    {
        // TODO: 在此添加您的服务操作
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "*", RequestFormat = WebMessageFormat.Json, UriTemplate = "PayQuery/{payinfo}")]
        ReturnQueryInfo PayQuery(string payinfo);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "*", RequestFormat = WebMessageFormat.Json, UriTemplate = "CreatAndPay/{payinfo}")]
        ReturnPayInfo CreatAndPay(string payinfo);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "*", RequestFormat = WebMessageFormat.Json, UriTemplate = "test")]
        Stream test(Stream payinfo);



        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "*", RequestFormat = WebMessageFormat.Json, UriTemplate = "Cancel/{payinfo}")]
        ReturnCancelInfo Cancel(string payinfo);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "*", RequestFormat = WebMessageFormat.Json, UriTemplate = "Refund/{payinfo}")]
        ReturnRefundInfo Refund(string payinfo);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "*", RequestFormat = WebMessageFormat.Json, UriTemplate = "Test/{StringValue}")]
        string Test(string StringValue);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "*", RequestFormat = WebMessageFormat.Json)]
        string Fetch(string id);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "*", RequestFormat = WebMessageFormat.Json)]
        Stream SomeOne(Stream inputStream);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "*", RequestFormat = WebMessageFormat.Json)]
        Stream SomeOnes(byte[] inputStream);

        #region MyRegion
        //2015年1月9日
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", RequestFormat = WebMessageFormat.Json)]
        ReturnPayInfo CreatAndPay1(PayInfo payinfo);

        //2015年1月9日
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", RequestFormat = WebMessageFormat.Json)]
        ReturnRefundInfo Refund1(PayInfo payinfo);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", RequestFormat = WebMessageFormat.Json)]
        ReturnQueryInfo PayQuery1(PayInfo payinfo);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", RequestFormat = WebMessageFormat.Json)]
        ReturnCancelInfo Cancel1(PayInfo payinfo);

        #endregion
    }


    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    [DataContract]
    public class Pay
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }


    }
}
