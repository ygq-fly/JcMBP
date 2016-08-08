namespace JcMBP
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.rxoffset_btn_save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableSwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configSwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.jcConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加测试脚本数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试时间间隔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.老化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dBcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试次数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解锁校准配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存校准结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(5, 105);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 619);
            this.panel1.TabIndex = 1;
            this.panel1.TabStop = true;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.White;
            this.btn_close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.Location = new System.Drawing.Point(152, 28);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(138, 39);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "断开连接";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_open
            // 
            this.btn_open.BackColor = System.Drawing.Color.White;
            this.btn_open.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_open.Location = new System.Drawing.Point(8, 28);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(138, 39);
            this.btn_open.TabIndex = 4;
            this.btn_open.Text = "连接仪表";
            this.btn_open.UseVisualStyleBackColor = false;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(762, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 39);
            this.button4.TabIndex = 189;
            this.button4.Text = "保存图像";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // rxoffset_btn_save
            // 
            this.rxoffset_btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rxoffset_btn_save.BackColor = System.Drawing.Color.White;
            this.rxoffset_btn_save.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rxoffset_btn_save.Location = new System.Drawing.Point(903, 28);
            this.rxoffset_btn_save.Name = "rxoffset_btn_save";
            this.rxoffset_btn_save.Size = new System.Drawing.Size(126, 39);
            this.rxoffset_btn_save.TabIndex = 187;
            this.rxoffset_btn_save.Text = "保存数据";
            this.rxoffset_btn_save.UseVisualStyleBackColor = false;
            this.rxoffset_btn_save.Click += new System.EventHandler(this.rxoffset_btn_save_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(8, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 31);
            this.button1.TabIndex = 191;
            this.button1.Text = "时域模式";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(271, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(248, 31);
            this.button2.TabIndex = 192;
            this.button2.Text = "频域模式";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(525, 73);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(253, 31);
            this.button3.TabIndex = 193;
            this.button3.Text = "RX校准";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(784, 73);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(245, 31);
            this.button5.TabIndex = 194;
            this.button5.Text = "TX校准";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label1.Location = new System.Drawing.Point(471, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 195;
            this.label1.Text = "label1";
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem,
            this.enableSwitchToolStripMenuItem,
            this.configSwitchToolStripMenuItem,
            this.toolStripMenuItem1});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(46, 21);
            this.otherToolStripMenuItem.Text = "Tool";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // enableSwitchToolStripMenuItem
            // 
            this.enableSwitchToolStripMenuItem.Name = "enableSwitchToolStripMenuItem";
            this.enableSwitchToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.enableSwitchToolStripMenuItem.Text = "Enable Switch";
            // 
            // configSwitchToolStripMenuItem
            // 
            this.configSwitchToolStripMenuItem.Enabled = false;
            this.configSwitchToolStripMenuItem.Name = "configSwitchToolStripMenuItem";
            this.configSwitchToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.configSwitchToolStripMenuItem.Text = "Config Switch";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem1.Text = "校准值";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Checked = true;
            this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "Lock";
            this.toolStripMenuItem2.CheckedChanged += new System.EventHandler(this.toolStripMenuItem2_CheckedChanged);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem3.Text = "Deblock";
            // 
            // jcConfigToolStripMenuItem
            // 
            this.jcConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加测试脚本数据ToolStripMenuItem,
            this.测试时间间隔ToolStripMenuItem,
            this.老化ToolStripMenuItem,
            this.dBmToolStripMenuItem,
            this.测试次数ToolStripMenuItem,
            this.解锁校准配置ToolStripMenuItem});
            this.jcConfigToolStripMenuItem.Name = "jcConfigToolStripMenuItem";
            this.jcConfigToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.jcConfigToolStripMenuItem.Text = "Config";
            // 
            // 添加测试脚本数据ToolStripMenuItem
            // 
            this.添加测试脚本数据ToolStripMenuItem.Name = "添加测试脚本数据ToolStripMenuItem";
            this.添加测试脚本数据ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.添加测试脚本数据ToolStripMenuItem.Text = "添加测试脚本数据";
            this.添加测试脚本数据ToolStripMenuItem.Click += new System.EventHandler(this.添加测试脚本数据ToolStripMenuItem_Click);
            // 
            // 测试时间间隔ToolStripMenuItem
            // 
            this.测试时间间隔ToolStripMenuItem.Name = "测试时间间隔ToolStripMenuItem";
            this.测试时间间隔ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.测试时间间隔ToolStripMenuItem.Text = "测试时间间隔";
            this.测试时间间隔ToolStripMenuItem.Click += new System.EventHandler(this.测试时间间隔ToolStripMenuItem_Click);
            // 
            // 老化ToolStripMenuItem
            // 
            this.老化ToolStripMenuItem.Name = "老化ToolStripMenuItem";
            this.老化ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.老化ToolStripMenuItem.Text = "老化";
            // 
            // dBmToolStripMenuItem
            // 
            this.dBmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dBmToolStripMenuItem1,
            this.dBcToolStripMenuItem});
            this.dBmToolStripMenuItem.Enabled = false;
            this.dBmToolStripMenuItem.Name = "dBmToolStripMenuItem";
            this.dBmToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.dBmToolStripMenuItem.Text = "单位";
            // 
            // dBmToolStripMenuItem1
            // 
            this.dBmToolStripMenuItem1.Checked = true;
            this.dBmToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dBmToolStripMenuItem1.Name = "dBmToolStripMenuItem1";
            this.dBmToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.dBmToolStripMenuItem1.Text = "dBm";
            // 
            // dBcToolStripMenuItem
            // 
            this.dBcToolStripMenuItem.Name = "dBcToolStripMenuItem";
            this.dBcToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.dBcToolStripMenuItem.Text = "dBc";
            // 
            // 测试次数ToolStripMenuItem
            // 
            this.测试次数ToolStripMenuItem.Name = "测试次数ToolStripMenuItem";
            this.测试次数ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.测试次数ToolStripMenuItem.Text = "测试次数";
            this.测试次数ToolStripMenuItem.Visible = false;
            this.测试次数ToolStripMenuItem.Click += new System.EventHandler(this.测试次数ToolStripMenuItem_Click);
            // 
            // 解锁校准配置ToolStripMenuItem
            // 
            this.解锁校准配置ToolStripMenuItem.Name = "解锁校准配置ToolStripMenuItem";
            this.解锁校准配置ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.解锁校准配置ToolStripMenuItem.Text = "解锁校准配置";
            this.解锁校准配置ToolStripMenuItem.Click += new System.EventHandler(this.解锁校准配置ToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存校准结果ToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // 保存校准结果ToolStripMenuItem
            // 
            this.保存校准结果ToolStripMenuItem.Enabled = false;
            this.保存校准结果ToolStripMenuItem.Name = "保存校准结果ToolStripMenuItem";
            this.保存校准结果ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.保存校准结果ToolStripMenuItem.Text = "保存校准结果";
            this.保存校准结果ToolStripMenuItem.Click += new System.EventHandler(this.保存校准结果ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otherToolStripMenuItem,
            this.jcConfigToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 25);
            this.menuStrip1.TabIndex = 190;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 724);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.rxoffset_btn_save);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "0";
            this.Text = "FrmMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmMain_KeyPress);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button rxoffset_btn_save;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableSwitchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configSwitchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem jcConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加测试脚本数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试时间间隔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 老化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dBcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试次数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存校准结果ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem 解锁校准配置ToolStripMenuItem;


    }
}