using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using TestPlaza4Wcf.Model;

namespace TestPlaza4Wcf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            method1();
        }

        private void method1()
        {             
            string murl = string.Empty;
             
            murl = "http://128.0.14.30:10086/svr/Some";
            string rst = string.Empty;

            DataContractJsonSerializer seriallizer = new DataContractJsonSerializer(typeof(cyms_bt_dish_favourableParameters));
            cyms_bt_dish_favourableParameters model = new cyms_bt_dish_favourableParameters();
            model.ch_boothid = "02";
            string mjson = string.Empty;
            MemoryStream stream = new MemoryStream();

            seriallizer.WriteObject(stream, model);
            stream.Flush();
            byte[] byIn = stream.ToArray();

            try
            {                
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = System.Text.Encoding.UTF8;
                    wc.Headers.Add("Content-Type", "application/json;charset=utf-8");
                    byte[] byRst = wc.UploadData(murl, "POST", byIn);

                    MessageBox.Show("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                stream.Close();
            }
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {
            method2();
        }

        private void method2()
        {
            string murl = string.Empty;
            murl = "http://128.0.14.32:18911/PayServer/Test/";

            string rst = string.Empty;

            PayInfo pi = new PayInfo();
            pi.flow_no = "10086";
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(PayInfo));
            string sendStr = string.Empty;
            using (MemoryStream mst = new MemoryStream())
            {
                dcjs.WriteObject(mst, pi);
                mst.Flush();
                sendStr = Encoding.UTF8.GetString(mst.ToArray(), 0, (int)mst.Length);
                murl = murl + sendStr;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = System.Text.Encoding.UTF8;
                    wc.Headers.Add("Content-Type", "application/json;charset=utf-8");
                    rst = wc.UploadString(murl, "");

                    MessageBox.Show(rst);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
