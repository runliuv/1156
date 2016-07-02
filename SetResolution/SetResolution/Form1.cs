using System;
using System.Windows.Forms;

namespace SetResolution
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 关闭计时
        /// </summary>
        int CloseCount = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxBitPer.SelectedIndex = 0;

            UsualLib.RemForm.ReadRememberForm(this, null);

            if (cbxSetOnStart.Checked)
                UsualLib.SetResolution.ChangeRes(int.Parse(nudWidth.Value.ToString()), int.Parse(nudHeight.Value.ToString()),
                int.Parse(nudDisplayFrequency.Value.ToString()), int.Parse(cbxBitPer.SelectedItem.ToString()));

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UsualLib.RemForm.RememberForm(this, null);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            UsualLib.SetResolution.ChangeRes(int.Parse(nudWidth.Value.ToString()), int.Parse(nudHeight.Value.ToString()),
                int.Parse(nudDisplayFrequency.Value.ToString()), int.Parse(cbxBitPer.SelectedItem.ToString()));
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (cbxSetOnStart.Checked && chkSettedClose.Checked)
            {
                tmrClose.Start();
                btnCancelClose.Visible = true;
            }
        }


        /// <summary>
        /// 设置完成后关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrClose_Tick(object sender, EventArgs e)
        {
            gbxOUR.Text = string.Format("还有{0}秒关闭", CloseCount);

            CloseCount -= 1;

            if (CloseCount < 0)
            {
                tmrClose.Stop();

                this.Close();
            }
        }

        /// <summary>
        /// 取消关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelClose_Click(object sender, EventArgs e)
        {
            btnCancelClose.Visible = false;
            gbxOUR.Text = "Our";
            tmrClose.Stop();
        }
    }
}
