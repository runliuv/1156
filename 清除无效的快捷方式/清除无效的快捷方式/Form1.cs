using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using IWshRuntimeLibrary;
namespace 清除无效的快捷方式
{
    public partial class Form1 : Form
    {
        private DataTable dtNot;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtNot = new DataTable();
            dtNot.Columns.Add("FileFullName");
            dtNot.Columns.Add("RefFileOrDir");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dgvNot.Rows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dgvNot.Rows)
                {
                    try
                    {
                        System.IO.File.Delete(dgvr.Cells["colFileFullName"].Value.ToString());
                    }
                    catch { }
                }

                dtNot.Rows.Clear();

                MessageBox.Show("完成" + DateTime.Now.ToString());
            }
            else
            {
                MessageBox.Show("没有任何项。" );
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dtNot.Rows.Clear();

            //获取桌面位置
            string specDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string[] files = Directory.GetFiles(specDir);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.Extension.ToLower() == ".lnk")
                {

                    WshShell shell = new WshShell();
                    IWshShortcut currShort = (IWshShortcut)shell.CreateShortcut(fi.FullName);
                    string pp = currShort.TargetPath;


                    if (!(System.IO.File.Exists(pp) || Directory.Exists(pp)))
                    {
                        dtNot.Rows.Add(fi.FullName, pp);
                    }

                }
                else
                {
                    continue;
                }
            }
            if (dtNot.Rows.Count > 0)
            {


                dgvNot.DataSource = dtNot;
                MessageBox.Show("有无效的快捷方式清除！");
            }
        }


    }
}
