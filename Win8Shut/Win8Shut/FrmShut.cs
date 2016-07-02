using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Win8Shut
{
    public partial class FrmShut : Form
    {
        public FrmShut()
        {
            InitializeComponent();
        }

        private void btnShut_Click(object sender, EventArgs e)
        {            
            Process.Start("shutdown", " /s /f /t 0");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", " /r /f /t 0");
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", " /l");
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", " /h");
        }
    }
}
