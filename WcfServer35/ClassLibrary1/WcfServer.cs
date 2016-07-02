using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ClassLibrary1
{
  public  class WcfServer
    {
      WebServiceHost host = null;
        private string serverPort = "18009";
        public WcfServer(string port)
        {
            serverPort = port;
            Uri baseURI = new Uri("http://localhost:" + port.ToString() + "/svr");
            host = new WebServiceHost(typeof(Like), baseURI); //类

            WebHttpBinding binding = new WebHttpBinding();
            // 这里不需要安全验证
            binding.Security.Mode = WebHttpSecurityMode.None;
            host.AddServiceEndpoint(typeof(ILike), binding, ""); //接口
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
                MaxConcurrentInstances = 260,
                MaxConcurrentSessions = 100
            };


            host.Description.Behaviors.Add(mdBehavior);

            ServiceMetadataBehavior behavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            {
                if (behavior == null)
                {
                    behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    host.Description.Behaviors.Add(behavior);
                }
                else
                {
                    behavior.HttpGetEnabled = true;
                }
            }

        }

        public void Start()
        {
            try
            {
                host.Open();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Close()
        {
            try
            {
                if (host != null)
                {
                    host.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
