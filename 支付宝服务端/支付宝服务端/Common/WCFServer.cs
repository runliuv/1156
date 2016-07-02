using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace 支付宝服务端.Common
{
    public class WCFServer
    {
        public WebServiceHost host = null;
        private string serverPort = "8000";
        //public Action<string> ServerRuned;
        public WCFServer(string port)
        {
            serverPort = port;
            Uri baseURI = new Uri("http://localhost:" + port.ToString() + "/PayServer");
            host = new WebServiceHost(typeof(PayServer), baseURI);

            WebHttpBinding binding = new WebHttpBinding();
            // 这里不需要安全验证
            binding.Security.Mode = WebHttpSecurityMode.None;
            host.AddServiceEndpoint(typeof(IService), binding, "");
            binding.MaxReceivedMessageSize = 2147483647;
            binding.MaxBufferSize = 2147483647;
            binding.MaxBufferPoolSize = 2147483647;

            binding.OpenTimeout = new TimeSpan(0, 10, 0);
            binding.CloseTimeout = new TimeSpan(0, 10, 0);
            binding.SendTimeout = new TimeSpan(0, 10, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 10, 0);

            //项目需要引用System.Runtime.Serialization.dll
            binding.ReaderQuotas.MaxDepth = 2147483647;
            binding.ReaderQuotas.MaxStringContentLength = 2147483647;
            binding.ReaderQuotas.MaxArrayLength = 2147483647;
            binding.ReaderQuotas.MaxBytesPerRead = 2147483647;
            binding.ReaderQuotas.MaxNameTableCharCount = 2147483647;

            ServiceThrottlingBehavior mdBehavior = new ServiceThrottlingBehavior()
            {
                MaxConcurrentCalls = 160,
                MaxConcurrentInstances = 260,//
                MaxConcurrentSessions = 100
            };
            host.Description.Behaviors.Add(mdBehavior);
            //int index = 0;
            //foreach (ServiceEndpoint endpoint in host.Description.Endpoints)
            //{
            //    System.Diagnostics.Debug.WriteLine("Endpoint {0}" + (index += 1).ToString());

            //    System.Diagnostics.Debug.WriteLine(string.Format("\tAddress: {0}\n\tBinding: {1}\n\tContract: {2}",

            //     endpoint.Address, endpoint.Binding, endpoint.Contract.Name));

            //}
        }

        public void Start()
        {
            //host.Opened += (sender, e) =>
            //{
            //    if (ServerRuned != null)
            //    {
            //        ServerRuned("");
            //    }
            //};

            try
            {
                host.Open();
            }
            catch (Exception ex)
            {
                // ServerRuned(ex.Message ?? "");
                //MessageBox.Show("服务启动失败。原因："+ex.Message);
                throw ex;
            }
        }

        public void Close()
        {
            if (host != null)
            {
                host.Close();
            }
        }
    }
}
