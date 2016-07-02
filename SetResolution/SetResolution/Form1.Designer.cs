namespace SetResolution
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbxOUR = new System.Windows.Forms.GroupBox();
            this.cbxSetOnStart = new System.Windows.Forms.CheckBox();
            this.cbxBitPer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudDisplayFrequency = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lblHeight = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSettedClose = new System.Windows.Forms.CheckBox();
            this.tmrClose = new System.Windows.Forms.Timer(this.components);
            this.btnCancelClose = new System.Windows.Forms.Button();
            this.gbxOUR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisplayFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxOUR
            // 
            this.gbxOUR.Controls.Add(this.btnCancelClose);
            this.gbxOUR.Controls.Add(this.chkSettedClose);
            this.gbxOUR.Controls.Add(this.cbxSetOnStart);
            this.gbxOUR.Controls.Add(this.cbxBitPer);
            this.gbxOUR.Controls.Add(this.label3);
            this.gbxOUR.Controls.Add(this.nudDisplayFrequency);
            this.gbxOUR.Controls.Add(this.label2);
            this.gbxOUR.Controls.Add(this.btnSet);
            this.gbxOUR.Controls.Add(this.nudHeight);
            this.gbxOUR.Controls.Add(this.nudWidth);
            this.gbxOUR.Controls.Add(this.lblHeight);
            this.gbxOUR.Controls.Add(this.label1);
            this.gbxOUR.Location = new System.Drawing.Point(12, 12);
            this.gbxOUR.Name = "gbxOUR";
            this.gbxOUR.Size = new System.Drawing.Size(346, 258);
            this.gbxOUR.TabIndex = 0;
            this.gbxOUR.TabStop = false;
            this.gbxOUR.Text = "OUR";
            // 
            // cbxSetOnStart
            // 
            this.cbxSetOnStart.AutoSize = true;
            this.cbxSetOnStart.Location = new System.Drawing.Point(18, 236);
            this.cbxSetOnStart.Name = "cbxSetOnStart";
            this.cbxSetOnStart.Size = new System.Drawing.Size(132, 16);
            this.cbxSetOnStart.TabIndex = 11;
            this.cbxSetOnStart.Text = "在启动程序时就设置";
            this.cbxSetOnStart.UseVisualStyleBackColor = true;
            // 
            // cbxBitPer
            // 
            this.cbxBitPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBitPer.FormattingEnabled = true;
            this.cbxBitPer.Items.AddRange(new object[] {
            "32",
            "16"});
            this.cbxBitPer.Location = new System.Drawing.Point(183, 171);
            this.cbxBitPer.Name = "cbxBitPer";
            this.cbxBitPer.Size = new System.Drawing.Size(121, 20);
            this.cbxBitPer.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "BitsPerPel";
            // 
            // nudDisplayFrequency
            // 
            this.nudDisplayFrequency.Location = new System.Drawing.Point(183, 138);
            this.nudDisplayFrequency.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudDisplayFrequency.Minimum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudDisplayFrequency.Name = "nudDisplayFrequency";
            this.nudDisplayFrequency.Size = new System.Drawing.Size(120, 21);
            this.nudDisplayFrequency.TabIndex = 2;
            this.nudDisplayFrequency.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "DisplayFrequency";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(183, 204);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "设置(&Set)";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(183, 102);
            this.nudHeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(120, 21);
            this.nudHeight.TabIndex = 1;
            this.nudHeight.Value = new decimal(new int[] {
            768,
            0,
            0,
            0});
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(183, 60);
            this.nudWidth.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(120, 21);
            this.nudWidth.TabIndex = 0;
            this.nudWidth.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(102, 104);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 12);
            this.lblHeight.TabIndex = 6;
            this.lblHeight.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Width";
            // 
            // chkSettedClose
            // 
            this.chkSettedClose.AutoSize = true;
            this.chkSettedClose.Location = new System.Drawing.Point(172, 236);
            this.chkSettedClose.Name = "chkSettedClose";
            this.chkSettedClose.Size = new System.Drawing.Size(108, 16);
            this.chkSettedClose.TabIndex = 12;
            this.chkSettedClose.Text = "设置完成后关闭";
            this.chkSettedClose.UseVisualStyleBackColor = true;
            // 
            // tmrClose
            // 
            this.tmrClose.Interval = 1000;
            this.tmrClose.Tick += new System.EventHandler(this.tmrClose_Tick);
            // 
            // btnCancelClose
            // 
            this.btnCancelClose.Location = new System.Drawing.Point(6, 20);
            this.btnCancelClose.Name = "btnCancelClose";
            this.btnCancelClose.Size = new System.Drawing.Size(90, 23);
            this.btnCancelClose.TabIndex = 13;
            this.btnCancelClose.Text = "取消关闭(&C)";
            this.btnCancelClose.UseVisualStyleBackColor = true;
            this.btnCancelClose.Visible = false;
            this.btnCancelClose.Click += new System.EventHandler(this.btnCancelClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 280);
            this.Controls.Add(this.gbxOUR);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置分辨率";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.gbxOUR.ResumeLayout(false);
            this.gbxOUR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisplayFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxOUR;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.NumericUpDown nudDisplayFrequency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxBitPer;
        private System.Windows.Forms.CheckBox cbxSetOnStart;
        private System.Windows.Forms.CheckBox chkSettedClose;
        private System.Windows.Forms.Timer tmrClose;
        private System.Windows.Forms.Button btnCancelClose;
    }
}

