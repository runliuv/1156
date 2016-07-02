using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace 延时启动程序
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 保存列表
        /// </summary>
        string ConfigList = Path.Combine(Application.StartupPath, "configList.txt");
        /// <summary>
        /// 保存配置
        /// </summary>
        string ConfigTxt = Path.Combine(Application.StartupPath, "config.txt");

        int timeCnt = 0;//主计数：秒
        decimal dCnt = 1M;//要达到的值：秒

        bool closeWhenStartFinish = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                //LIST
                if (File.Exists(ConfigList))
                {
                    using (FileStream fs = new FileStream(ConfigList, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            while (sr.Peek() >= 0)
                            {
                                string app = sr.ReadLine();
                                if (!string.IsNullOrEmpty(app))
                                    lbxApps.Items.Add(app);
                            }
                        }
                    }
                }
                //cfg
                if (File.Exists(ConfigTxt))
                {
                    using (FileStream fs = new FileStream(ConfigTxt, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            string app = sr.ReadLine();
                            if (!string.IsNullOrEmpty(app))
                            {
                                decimal dOut = 10M;
                                decimal.TryParse(app, out dOut);
                                nudTime.Value = dOut;
                            }
                        }
                    }
                }
                //TIMER
                dCnt = nudTime.Value;
                tmrCnt.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string pat = txtPath.Text.Trim();
            if (string.IsNullOrEmpty(pat))
            {
                MessageBox.Show("路径不能为空！");
                return;
            }
            pat = pat.TrimStart('\"');
            pat = pat.TrimEnd('\"');
            if (!File.Exists(pat))
            {
                MessageBox.Show("文件不存在！");
                return;
            }
            foreach (object ob in lbxApps.Items)
            {
                if (ob.ToString().ToLower() == pat.ToLower())
                    return;
            }
            lbxApps.Items.Add(pat);
            WriteTxt();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            lbxApps.Items.RemoveAt(lbxApps.SelectedIndex);
            WriteTxt();
        }

        void WriteTxt()
        {
            //写入文件
            try
            {
                using (FileStream fs = new FileStream(ConfigList, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (object ob in lbxApps.Items)
                        {
                            sw.WriteLine(ob.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(ConfigTxt, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {

                        sw.WriteLine(nudTime.Value.ToString());

                    }
                }
                MessageBox.Show("保存成功！");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tmrCnt_Tick(object sender, EventArgs e)
        {
            timeCnt += 1;
            if (timeCnt >= dCnt)
            {
                tmrCnt.Stop();
                foreach (object ob in lbxApps.Items)
                {
                    try
                    {
                        string app = ob.ToString();
                        if (File.Exists(app))
                        {
                            Process.Start(app);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        
                    }
                }

                //clo
                if (closeWhenStartFinish)
                    this.Close();
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelClose_Click(object sender, EventArgs e)
        {
            closeWhenStartFinish = false;
        }
    }
}
