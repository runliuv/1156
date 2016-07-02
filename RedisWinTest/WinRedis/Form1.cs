using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApplication1.Models;

namespace WinRedis
{
    public partial class Form1 : Form
    {
        string _url = "http://localhost:57127/api/values/";

        bool mStop = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _url = "http://localhost:57127/api/values/";
                gbxButton.Enabled = false;
                mStop = false;

                int threads = int.Parse(nudThreads.Value.ToString());
                int times = int.Parse(nudTimes.Value.ToString());
                for (int i = 1; i <= threads; i++)
                {
                    ParameterizedThreadStart ps = new ParameterizedThreadStart(threadDo);
                    Thread th = new Thread(ps);
                    th.Start(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void threadDo(object oid)
        {
            int threads = int.Parse(nudThreads.Value.ToString());
            int times = int.Parse(nudTimes.Value.ToString());
            string ii = "0";
            if (oid != null)
            {
                ii = oid.ToString();
            }
            for (int i = 1; i <= times; i++)
            {
                if (mStop)
                {
                    return;
                }

                string itemNo = txtItem_no.Text.Trim();
                string msg = string.Format("thread {0} times {1} ", ii, i);
                try
                {

                    string furl = _url + itemNo;
                    string rsp = MU.HttpReqG(furl, "");

                    Log.WLog(msg + " 正常：" + rsp);

                }
                catch (Exception ex)
                {

                    Log.WLog(msg + " 异常：" + ex.Message);
                }
                finally
                {
                    if (int.Parse(ii) >= threads - 1 && i >= times - 1)
                    {
                        if (gbxButton.InvokeRequired)
                        {
                            this.Invoke(new MethodInvoker(() => { gbxButton.Enabled = true; }));
                        }
                        else
                        {
                            gbxButton.Enabled = true;
                        }
                    }
                }
            }
        }

        private void bwTestRedis_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bwTestRedis_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("e.Error " + e.Error.Message);
                return;
            }
            MessageBox.Show("完成");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _url = "http://localhost:57127/api/conn/";
                gbxButton.Enabled = false;
                mStop = false;

                int threads = int.Parse(nudThreads.Value.ToString());
                int times = int.Parse(nudTimes.Value.ToString());
                for (int i = 0; i < threads; i++)
                {
                    ParameterizedThreadStart ps = new ParameterizedThreadStart(threadDo);
                    Thread th = new Thread(ps);
                    th.Start(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mStop = true;
            gbxButton.Enabled = true;
        }
    }
}
