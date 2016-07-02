using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 切克闹
{
    public partial class Form1 : Form
    {
        private DataTable dtTask = new DataTable("nock");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 设计
            dtTask.Columns.Add("time");
            dtTask.Columns.Add("content");
            dtTask.Columns.Add("sound");

            txtContent.Text = "水开了？";

            cbxUnit.SelectedIndex = 0;

            tmrNO.Interval = 1000;
            tmrNO.Tick += new EventHandler(tmrNO_Tick);
            tmrNO.Start();
            #endregion
        }

        void tmrNO_Tick(object sender, EventArgs e)
        {
            for (int i = dtTask.Rows.Count - 1; i >= 0; i--)
            {
                string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (dtTask.Rows[i]["time"].ToString() == strNow)
                {
                    nfiNO.BalloonTipText = MakeTip(dtTask.Rows[i]["content"].ToString());
                    nfiNO.ShowBalloonTip(9000);

                    dtTask.Rows.RemoveAt(i);
                }
            }
             
        }

        /// <summary>
        /// 生成BalloonTipText
        /// </summary>
        /// <param name="strPu"></param>
        /// <returns></returns>
        string MakeTip(string strPu)
        {
            if (string.IsNullOrEmpty(strPu))
                strPu = DateTime.Now.ToString();

            string tmp = "------ ------ ------ ------ ------ ------ ------ ------ ------" + System.Environment.NewLine +
                strPu
                + System.Environment.NewLine + "------ ------ ------ ------ ------ ------ ------ ------ ------";

            return tmp;
        }

        private void btnNO1_Click(object sender, EventArgs e)
        {
            DateTime dteNo = DateTime.Now;
            if (cbxUnit.SelectedItem.ToString() == "分钟")
                dteNo = DateTime.Now.AddMinutes(double.Parse(nudSec.Value.ToString()));
            else if (cbxUnit.SelectedItem.ToString() == "秒")
                dteNo = DateTime.Now.AddSeconds(double.Parse(nudSec.Value.ToString()));
            else if (cbxUnit.SelectedItem.ToString() == "小时")
                dteNo = DateTime.Now.AddHours(double.Parse(nudSec.Value.ToString()));

            dtTask.Rows.Add(dteNo.ToString("yyyy-MM-dd HH:mm:ss"),
                txtContent.Text, txtSound.Text);

            dgvTask.DataSource = dtTask;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void nfiNO_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiShow_Click(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
