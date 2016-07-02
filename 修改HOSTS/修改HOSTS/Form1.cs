using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace 修改HOSTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string abc = Environment.GetEnvironmentVariable("systemroot");
            string path = Path.Combine(abc, @"System32\drivers\etc\hosts");
            txtPath.Text = path;

            if (File.Exists(path))
            {
                fileLoad(path);
            }
        }

        void fileLoad(string path)
        {
            if (File.Exists(path))
            {
                lbxMain.Items.Clear();
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        while (sr.Peek() >= 0)
                        {
                            string tmp = sr.ReadLine();
                            if (string.IsNullOrEmpty(tmp) || tmp.StartsWith("#"))
                                continue;
                            lbxMain.Items.Add(tmp);
                        }
                    }
                }
            }
        }

        private void btnBrow_Click(object sender, EventArgs e)
        {
            string abc = Environment.GetEnvironmentVariable("systemroot");
            string path = Path.Combine(abc, @"System32\drivers\etc");
            ofdHosts.InitialDirectory = path;
            if (ofdHosts.ShowDialog() == DialogResult.OK)
            {
                if (ofdHosts.FileName.ToLower().EndsWith("hosts"))
                {
                    txtPath.Text = ofdHosts.FileName;
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Trim().ToLower().EndsWith("hosts") && File.Exists(txtPath.Text.Trim()))
            {
                fileLoad(txtPath.Text.Trim());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text.Trim()))
            {
                MessageBox.Show("地址不能为空");
                return;
            }
            if (!txtPath.Text.Trim().ToLower().EndsWith("hosts"))
            {
                MessageBox.Show("不是hosts文件");
                return;
            }
            if (string.IsNullOrEmpty(txtNew.Text.Trim()))
            {
                MessageBox.Show("内容不能为空");
                return;
            }

            try
            {
                //检查是否已存在
                foreach (object ob in lbxMain.Items)
                {
                    if (ob.ToString().ToLower().Trim() == txtNew.Text.Trim().ToLower())
                    {
                        MessageBox.Show("已存在");
                        return;
                    }
                }

                FileInfo ff = new FileInfo(txtPath.Text.Trim());
                if (ff.Attributes != FileAttributes.Normal)
                {
                    File.SetAttributes(txtPath.Text.Trim(), FileAttributes.Normal);
                }

                //修改
                using (FileStream fs = new FileStream(txtPath.Text.Trim(), FileMode.Append, FileAccess.Write))
                {

                    using (StreamWriter sr = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sr.WriteLine(txtNew.Text.Trim());
                    }
                }

                //load
                fileLoad(txtPath.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改时出错" + ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text.Trim()))
            {
                MessageBox.Show("地址不能为空");
                return;
            }
            if (!txtPath.Text.Trim().ToLower().EndsWith("hosts"))
            {
                MessageBox.Show("不是hosts文件");
                return;
            }
             

            if (lbxMain.SelectedItem == null)
            {
                MessageBox.Show("没有选择任何项");
                return;
            }

            if (DialogResult.No == MessageBox.Show("确定要删除吗？", "确定", MessageBoxButtons.YesNo))
            {
                return;
            }

            string selectedCon = lbxMain.SelectedItem.ToString();

            try
            {


                FileInfo ff = new FileInfo(txtPath.Text.Trim());
                if (ff.Attributes != FileAttributes.Normal)
                {
                    File.SetAttributes(txtPath.Text.Trim(), FileAttributes.Normal);
                }
                string hosCon = string.Empty;
                //修改
                using (FileStream fs = new FileStream(txtPath.Text.Trim(), FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        hosCon = sr.ReadToEnd();
                    }
                 hosCon=   hosCon.Replace(selectedCon, "");
                }
                //写
                using (FileStream fs = new FileStream(txtPath.Text.Trim(), FileMode.Truncate, FileAccess.Write))
                {
                    using (StreamWriter sr = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sr.Write(hosCon);
                    }
                }

                //load
                fileLoad(txtPath.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改时出错" + ex.Message);
            }
        }
    }
}
