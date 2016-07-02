using System;
using System.Windows.Forms;
using System.IO;
using UsualLib;

namespace GameArchiveBak
{
    public partial class FrmAdd : Form
    {
        public EnumClass.FormAcessMode FormAcessMode { get; set; }

        public string DocDescr { get; set; }

        public string SourcePath { get; set; }

        public string TargetPath { get; set; }

        public FrmAdd()
        {
            InitializeComponent();
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            if (FormAcessMode == EnumClass.FormAcessMode.Add)
            {
                txtDocDescr.Text = "MyGame1";
                //默认我的文档的第一个文件夹。
                string myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string[] firstInMyDoc = Directory.GetDirectories(myDocPath);
                if (firstInMyDoc != null && firstInMyDoc.Length > 0)
                    txtSource.Text = firstInMyDoc[0];
                else
                    txtSource.Text = myDocPath;

            }
            else if (FormAcessMode == EnumClass.FormAcessMode.Edit)
            {
                txtDocDescr.Text = DocDescr;
                txtSource.Text = SourcePath;

            }
        }

        private void btnBrow_Click(object sender, EventArgs e)
        {
            NewFolderBrowDia fdSource = new NewFolderBrowDia();
            if (fdSource.DisplayDialog() == DialogResult.OK)
            {
                txtSource.Text = fdSource.Path;
            }
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            string sDocDescr = txtDocDescr.Text.Trim();
            if (string.IsNullOrEmpty(sDocDescr))
            {
                MessageBox.Show("描述不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //检查源目录是否存在            
            string sourcePath = txtSource.Text.Trim();
            if (string.IsNullOrEmpty(sourcePath))
            {
                MessageBox.Show("存档位置不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Directory.Exists(sourcePath))
            {
                MessageBox.Show("存档位置不存在！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //属性
            DocDescr = sDocDescr;
            SourcePath = sourcePath;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #region 按ESC 提示是否要退出
        //按ESC 提示是否要退出  
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData) //激活回车键  
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        if (MessageBox.Show("确定要退出么？", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            this.Close();//csc关闭窗体  
                        }
                        break;
                    case Keys.Enter:
                        btnOK_Click(null, null);
                        break;
                }

            }
            return false;
        }
        #endregion

    }
}
