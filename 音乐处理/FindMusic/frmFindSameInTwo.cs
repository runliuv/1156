using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace FindMusic
{
    public partial class frmFindSameInTwo : Form
    {
        #region
        Thread thMain = null;
        private delegate void ThrowToDG_DLG(FileInfo fiA, FileInfo fiB);
        private ThrowToDG_DLG ThrowToDG_INS;
        #endregion

        public frmFindSameInTwo()
        {
            InitializeComponent();
        }

        private void frmFindSameInTwo_Load(object sender, EventArgs e)
        {
            ThrowToDG_INS = new ThrowToDG_DLG(ThrowToDG);

            txtDirA.Text = @"e:\MusicOne\";

            lbxDirB.Items.Add(@"d:\Music\");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtDirA.Text.Trim()))
            {
                MessageBox.Show("目录A不能为空。");
                return;
            }
            if (lbxDirB.Items.Count == 0)
            {
                MessageBox.Show("目录B数量不能为空。");
                return;
            }

            dgvA.Rows.Clear();
            dgvB.Rows.Clear();

            ThreadStart ts = new ThreadStart(Find);
            thMain = new Thread(ts);
            thMain.Start();

        }

        private void Find()
        {
            string[] aDirFiles = Directory.GetFiles(txtDirA.Text.Trim());
            foreach (string aFile in aDirFiles)
            {
                FileInfo fiAFile = new FileInfo(aFile);
                foreach (object ob in lbxDirB.Items)
                {
                    string dirB = (string)ob;
                    if (Directory.Exists(dirB))
                    {
                        if (!dirB.EndsWith(@"\"))
                            dirB += @"\";
                        string fileB = dirB + fiAFile.Name;
                        if (File.Exists(fileB))
                        {
                            FileInfo fiB = new FileInfo(fileB);

                            this.Invoke(ThrowToDG_INS, fiAFile, fiB);
                        }
                    }
                }
            }
        }

        private void ThrowToDG(FileInfo fiA, FileInfo fiB)
        {
            lblStatus.Text = "正在比对:" + fiA.Name;

            dgvA.Rows.Add(fiA.Name, (fiA.Length / 1024 / 1024).ToString() + " MB", fiA.FullName);

            dgvB.Rows.Add(fiB.Name, (fiB.Length / 1024 / 1024).ToString() + " MB", fiB.FullName);
        }

        /// <summary>
        /// 添加到DirB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newItem = txtDirB.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(newItem))
            {
                MessageBox.Show("不能为空！");
                return;
            }
            if (!lbxDirB.Items.Contains(newItem))
            {
                lbxDirB.Items.Add(newItem);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lbxDirB.SelectedIndex > -1)
            {
                lbxDirB.Items.RemoveAt(lbxDirB.SelectedIndex);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (thMain != null)
            {
                thMain.Abort();
            }
        }

        private void btnDelSel_Click(object sender, EventArgs e)
        {
            if (dgvB.Rows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dgvB.Rows)
                {
                    File.Delete(dgvr.Cells[2].Value.ToString());
                }

                dgvB.Rows.Clear();
            }
        }
    }
}
