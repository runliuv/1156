using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 重命名桌面快捷方式
{
    public partial class FrmRename : Form
    {
        public string SourceFileName { get; set; }

        public string NewFileName { get; set; }

        public FrmRename()
        {
            InitializeComponent();
        }

        public FrmRename(string sourceFileName)
            : this()
        {
            SourceFileName = sourceFileName;
        }

        private void FrmRename_Load(object sender, EventArgs e)
        {
            lblSrc.Text = SourceFileName;
            FileInfo fi = new FileInfo(SourceFileName);
            txtNewName.Text = fi.Name;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            NewFileName = txtNewName.Text.Trim();
            this.DialogResult = DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
