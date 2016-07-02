using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeOut
{
    public partial class FrmShowTip : Form
    {
        public FrmShowTip()
        {
            InitializeComponent();
        }

        private void FrmShowTip_Shown(object sender, EventArgs e)
        {
            Rectangle r = Screen.GetWorkingArea(this);

            //this.Location = new Point(r.Right - this.Width, r.Bottom - this.Height); //右下

            this.Location = new Point(0, r.Bottom - this.Height); //左下

            //this.Location = new Point(0, 0); //左上

            //this.Location = new Point(r.Right - this.Width, 0); //右上

        }
    }
}
