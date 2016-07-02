using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoBakIEfav
{
    public partial class frmShowDelFileForSync : Form
    {
        public List<string> LstDataSource { get; set; }

        public frmShowDelFileForSync()
        {
            InitializeComponent();
        }

        private void frmShowDelFileForSync_Load(object sender, EventArgs e)
        {
            if (LstDataSource != null)
            {
                listBox1.DataSource = LstDataSource;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
