using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SimpleCopy
{
    public partial class Form1 : Form
    {
        private delegate void JumpBoard_DLG(bool copyOrJump, string fileFullName, int copyCount);
        private JumpBoard_DLG JumpBoard_INS;

        private delegate void CopyStauts_DLG(bool copyIng, string fileFullName);
        private CopyStauts_DLG CopyStauts_INS;

        System.Threading.Thread thdCopy = null;

        private int CopyCount = 0;
        private int SkipCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            JumpBoard_INS = new JumpBoard_DLG(JumpBoard);
            CopyStauts_INS = new CopyStauts_DLG(CopyStauts);

            cbxJump.Checked = true;

            txtDirA.Text = @"f:\Music";
            txtDirB.Text = @"d:\Music";
        }

        /// <summary>
        /// copyIng 正在复制为TRUE。完成为FALSE
        /// </summary>
        /// <param name="copyIng"></param>
        /// <param name="fileFullName"></param>
        private void CopyStauts(bool copyIng, string fileFullName)
        {
            if (copyIng)
                lblStatus.Text = "正在复制：" + fileFullName;
            else
            {
                groupBox1.Enabled = true;
                lblStatus.Text = "复制完成。";
            }
        }

        /// <summary>
        /// copyOrJump true 为copy,false为 jump
        /// </summary>
        /// <param name="copyOrJump"></param>
        /// <param name="fileFullName"></param>
        private void JumpBoard(bool copyOrJump, string fileFullName, int copyCount)
        {
            if (copyOrJump)
            {
                lblCount.Text = "数量：" + copyCount.ToString();
                lbxCopy.Items.Insert(0, fileFullName);
            }
            else
            {
                lblSkipCount.Text = "数量：" + copyCount.ToString();
                lbxJump.Items.Insert(0, fileFullName);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDirA.Text.Trim()))
            {
                MessageBox.Show("A文件夹不能为空。");
                return;
            }
            if (string.IsNullOrEmpty(txtDirB.Text.Trim()))
            {
                MessageBox.Show("B文件夹不能为空。");
                return;
            }

            if (!Directory.Exists(txtDirA.Text.Trim()))
            {
                MessageBox.Show("A文件夹不存在。");
                return;
            }
            if (!Directory.Exists(txtDirB.Text.Trim()))
            {
                MessageBox.Show("B文件夹不存在。");
                return;
            }

            lbxCopy.Items.Clear();
            lbxJump.Items.Clear();
            CopyCount = 0;
            SkipCount = 0;
            lblCount.Text = "数量：0";
            lblSkipCount.Text = "数量：0";
            groupBox1.Enabled = false;

            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(ThdDirCopy);
            thdCopy = new System.Threading.Thread(ts);
            thdCopy.Start();

        }
        private void ThdDirCopy()
        {
            DirCopy(txtDirA.Text.Trim(), txtDirB.Text.Trim(), cbxJump.Checked);
        }

        private void DirCopy(string dirA, string dirB, bool bJump)
        {
            DirectoryInfo diB = new DirectoryInfo(dirB);
            string[] dirAFiles = Directory.GetFiles(dirA);
            foreach (string aFile in dirAFiles)
            {
                FileInfo fiA = new FileInfo(aFile);
                string fileB = diB + @"\" + fiA.Name;
                if (File.Exists(fileB) && bJump)
                {
                    SkipCount += 1;
                    this.BeginInvoke(JumpBoard_INS, false, aFile, SkipCount);
                    continue;
                }

                this.BeginInvoke(CopyStauts_INS, true, aFile);

                File.Copy(aFile, fileB, true);
                CopyCount += 1;
                this.BeginInvoke(JumpBoard_INS, true, fileB, CopyCount);
            }

            //复制完
            this.BeginInvoke(CopyStauts_INS, false, "");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            if (thdCopy != null)
            {
                thdCopy.Abort();
            }
            lblStatus.Text = string.Empty;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thdCopy != null)
            {
                thdCopy.Abort();
            }
        }
    }
}
