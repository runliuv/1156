using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 按字符分割文本
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            txtOut.Text = string.Empty;

            string[] spli = txtIn.Text.Split(new string[] { txtSp.Text }, StringSplitOptions.None);
            foreach (string ite in spli)
            {
                txtOut.Text += (ite)+System.Environment.NewLine;
            }
        }
    }
}
