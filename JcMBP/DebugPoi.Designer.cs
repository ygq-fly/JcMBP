namespace JcMBP
{
    partial class DebugPoi
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
            this.btn_sig_on = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_ana_freq = new System.Windows.Forms.TextBox();
            this.btn_ana = new System.Windows.Forms.Button();
            this.btn_sig_off = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_vco = new System.Windows.Forms.Button();
            this.btn_sen = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_sig2_off = new System.Windows.Forms.Button();
            this.btn_sig2_on = new System.Windows.Forms.Button();
            this.tb_p2 = new System.Windows.Forms.TextBox();
            this.tb_f2 = new System.Windows.Forms.TextBox();
            this.btn_sig2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_f1 = new System.Windows.Forms.TextBox();
            this.btn_sig1 = new System.Windows.Forms.Button();
            this.tb_p1 = new System.Windows.Forms.TextBox();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_sig_on
            // 
            this.btn_sig_on.Location = new System.Drawing.Point(12, 81);
            this.btn_sig_on.Name = "btn_sig_on";
            this.btn_sig_on.Size = new System.Drawing.Size(79, 28);
            this.btn_sig_on.TabIndex = 134;
            this.btn_sig_on.Text = "TX_ON";
            this.btn_sig_on.UseVisualStyleBackColor = true;
            this.btn_sig_on.Click += new System.EventHandler(this.btn_sig_on_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(49, 142);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 21);
            this.numericUpDown1.TabIndex = 145;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_ana_freq);
            this.groupBox2.Controls.Add(this.btn_ana);
            this.groupBox2.Location = new System.Drawing.Point(10, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 92);
            this.groupBox2.TabIndex = 146;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "频谱";
            // 
            // tb_ana_freq
            // 
            this.tb_ana_freq.Location = new System.Drawing.Point(12, 21);
            this.tb_ana_freq.Name = "tb_ana_freq";
            this.tb_ana_freq.Size = new System.Drawing.Size(170, 21);
            this.tb_ana_freq.TabIndex = 129;
            this.tb_ana_freq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_ana
            // 
            this.btn_ana.Location = new System.Drawing.Point(12, 48);
            this.btn_ana.Name = "btn_ana";
            this.btn_ana.Size = new System.Drawing.Size(172, 28);
            this.btn_ana.TabIndex = 130;
            this.btn_ana.Text = "Analyzer";
            this.btn_ana.UseVisualStyleBackColor = true;
            this.btn_ana.Click += new System.EventHandler(this.btn_ana_Click);
            // 
            // btn_sig_off
            // 
            this.btn_sig_off.Location = new System.Drawing.Point(103, 81);
            this.btn_sig_off.Name = "btn_sig_off";
            this.btn_sig_off.Size = new System.Drawing.Size(79, 28);
            this.btn_sig_off.TabIndex = 135;
            this.btn_sig_off.Text = "TX_OFF";
            this.btn_sig_off.UseVisualStyleBackColor = true;
            this.btn_sig_off.Click += new System.EventHandler(this.btn_sig_off_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.comboBox8);
            this.groupBox7.Controls.Add(this.comboBox5);
            this.groupBox7.Controls.Add(this.button3);
            this.groupBox7.Controls.Add(this.comboBox6);
            this.groupBox7.Controls.Add(this.numericUpDown1);
            this.groupBox7.Controls.Add(this.comboBox7);
            this.groupBox7.Location = new System.Drawing.Point(218, 256);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(194, 198);
            this.groupBox7.TabIndex = 157;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Incemental";
            // 
            // comboBox8
            // 
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Items.AddRange(new object[] {
            "实际功率",
            "显示功率"});
            this.comboBox8.Location = new System.Drawing.Point(49, 114);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(100, 24);
            this.comboBox8.TabIndex = 147;
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "TX1",
            "TX2"});
            this.comboBox5.Location = new System.Drawing.Point(49, 50);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(100, 24);
            this.comboBox5.TabIndex = 143;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(107, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 23);
            this.button3.TabIndex = 146;
            this.button3.Text = "SET";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "1移动GSM900",
            "2电信CMDA800",
            "3电信FDD1.8G",
            "4联通FDD1.8G",
            "5电信FDD2.1G",
            "6联通WCDMA",
            "7移动DCS1800",
            "8移动TD(F频段)",
            "9移动TD(A频段)",
            "10移动TD(E频段)",
            "11电信TD2.3G",
            "12联通TD2.3G"});
            this.comboBox6.Location = new System.Drawing.Point(49, 20);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(137, 24);
            this.comboBox6.TabIndex = 142;
            // 
            // comboBox7
            // 
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "PORT1",
            "PORT2"});
            this.comboBox7.Location = new System.Drawing.Point(49, 84);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(100, 24);
            this.comboBox7.TabIndex = 144;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_vco);
            this.groupBox6.Controls.Add(this.btn_sen);
            this.groupBox6.Controls.Add(this.groupBox2);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Controls.Add(this.groupBox3);
            this.groupBox6.Location = new System.Drawing.Point(3, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(211, 442);
            this.groupBox6.TabIndex = 156;
            this.groupBox6.TabStop = false;
            // 
            // btn_vco
            // 
            this.btn_vco.Location = new System.Drawing.Point(10, 20);
            this.btn_vco.Name = "btn_vco";
            this.btn_vco.Size = new System.Drawing.Size(194, 28);
            this.btn_vco.TabIndex = 149;
            this.btn_vco.Text = "VCO";
            this.btn_vco.UseVisualStyleBackColor = true;
            this.btn_vco.Click += new System.EventHandler(this.btn_vco_Click);
            // 
            // btn_sen
            // 
            this.btn_sen.Location = new System.Drawing.Point(10, 54);
            this.btn_sen.Name = "btn_sen";
            this.btn_sen.Size = new System.Drawing.Size(194, 28);
            this.btn_sen.TabIndex = 144;
            this.btn_sen.Text = "Sensor";
            this.btn_sen.UseVisualStyleBackColor = true;
            this.btn_sen.Click += new System.EventHandler(this.btn_sen_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_sig2_off);
            this.groupBox4.Controls.Add(this.btn_sig2_on);
            this.groupBox4.Controls.Add(this.tb_p2);
            this.groupBox4.Controls.Add(this.tb_f2);
            this.groupBox4.Controls.Add(this.btn_sig2);
            this.groupBox4.Location = new System.Drawing.Point(10, 311);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(194, 114);
            this.groupBox4.TabIndex = 148;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SIG2";
            // 
            // btn_sig2_off
            // 
            this.btn_sig2_off.Location = new System.Drawing.Point(103, 81);
            this.btn_sig2_off.Name = "btn_sig2_off";
            this.btn_sig2_off.Size = new System.Drawing.Size(79, 28);
            this.btn_sig2_off.TabIndex = 137;
            this.btn_sig2_off.Text = "TX_OFF";
            this.btn_sig2_off.UseVisualStyleBackColor = true;
            this.btn_sig2_off.Click += new System.EventHandler(this.btn_sig2_off_Click);
            // 
            // btn_sig2_on
            // 
            this.btn_sig2_on.Location = new System.Drawing.Point(12, 81);
            this.btn_sig2_on.Name = "btn_sig2_on";
            this.btn_sig2_on.Size = new System.Drawing.Size(79, 28);
            this.btn_sig2_on.TabIndex = 136;
            this.btn_sig2_on.Text = "TX_ON";
            this.btn_sig2_on.UseVisualStyleBackColor = true;
            this.btn_sig2_on.Click += new System.EventHandler(this.btn_sig2_on_Click);
            // 
            // tb_p2
            // 
            this.tb_p2.Location = new System.Drawing.Point(117, 20);
            this.tb_p2.Name = "tb_p2";
            this.tb_p2.Size = new System.Drawing.Size(65, 21);
            this.tb_p2.TabIndex = 136;
            this.tb_p2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_f2
            // 
            this.tb_f2.Location = new System.Drawing.Point(12, 20);
            this.tb_f2.Name = "tb_f2";
            this.tb_f2.Size = new System.Drawing.Size(65, 21);
            this.tb_f2.TabIndex = 134;
            this.tb_f2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_sig2
            // 
            this.btn_sig2.Location = new System.Drawing.Point(12, 47);
            this.btn_sig2.Name = "btn_sig2";
            this.btn_sig2.Size = new System.Drawing.Size(170, 28);
            this.btn_sig2.TabIndex = 135;
            this.btn_sig2.Text = "Signal_2";
            this.btn_sig2.UseVisualStyleBackColor = true;
            this.btn_sig2.Click += new System.EventHandler(this.btn_sig2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_sig_off);
            this.groupBox3.Controls.Add(this.btn_sig_on);
            this.groupBox3.Controls.Add(this.tb_f1);
            this.groupBox3.Controls.Add(this.btn_sig1);
            this.groupBox3.Controls.Add(this.tb_p1);
            this.groupBox3.Location = new System.Drawing.Point(10, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 119);
            this.groupBox3.TabIndex = 147;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SIG1";
            // 
            // tb_f1
            // 
            this.tb_f1.Location = new System.Drawing.Point(12, 20);
            this.tb_f1.Name = "tb_f1";
            this.tb_f1.Size = new System.Drawing.Size(65, 21);
            this.tb_f1.TabIndex = 131;
            this.tb_f1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_sig1
            // 
            this.btn_sig1.Location = new System.Drawing.Point(12, 47);
            this.btn_sig1.Name = "btn_sig1";
            this.btn_sig1.Size = new System.Drawing.Size(170, 28);
            this.btn_sig1.TabIndex = 132;
            this.btn_sig1.Text = "Signal_1";
            this.btn_sig1.UseVisualStyleBackColor = true;
            this.btn_sig1.Click += new System.EventHandler(this.btn_sig1_Click);
            // 
            // tb_p1
            // 
            this.tb_p1.Location = new System.Drawing.Point(117, 20);
            this.tb_p1.Name = "tb_p1";
            this.tb_p1.Size = new System.Drawing.Size(65, 21);
            this.tb_p1.TabIndex = 133;
            this.tb_p1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(416, 9);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ReadOnly = true;
            this.tb_log.Size = new System.Drawing.Size(391, 445);
            this.tb_log.TabIndex = 153;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.comboBox4);
            this.groupBox5.Controls.Add(this.comboBox3);
            this.groupBox5.Controls.Add(this.comboBox2);
            this.groupBox5.Controls.Add(this.comboBox1);
            this.groupBox5.Location = new System.Drawing.Point(218, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(193, 239);
            this.groupBox5.TabIndex = 155;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "POI开关";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 132;
            this.label3.Text = "RX:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 131;
            this.label2.Text = "TX2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 130;
            this.label1.Text = "TX1:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 29);
            this.button1.TabIndex = 129;
            this.button1.Text = "switch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "D1",
            "D2"});
            this.comboBox4.Location = new System.Drawing.Point(101, 156);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(69, 24);
            this.comboBox4.TabIndex = 129;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1移动GSM900",
            "2电信CMDA800",
            "3电信FDD1.8G",
            "4联通FDD1.8G",
            "5电信FDD2.1G",
            "6联通WCDMA",
            "7移动DCS1800",
            "8移动TD(F频段)",
            "9移动TD(A频段)",
            "10移动TD(E频段)",
            "11电信TD2.3G",
            "12联通TD2.3G"});
            this.comboBox3.Location = new System.Drawing.Point(49, 105);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(137, 24);
            this.comboBox3.TabIndex = 129;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1移动GSM900",
            "2电信CMDA800",
            "3电信FDD1.8G",
            "4联通FDD1.8G",
            "5电信FDD2.1G",
            "6联通WCDMA",
            "7移动DCS1800",
            "8移动TD(F频段)",
            "9移动TD(A频段)",
            "10移动TD(E频段)",
            "11电信TD2.3G",
            "12联通TD2.3G"});
            this.comboBox2.Location = new System.Drawing.Point(49, 60);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(137, 24);
            this.comboBox2.TabIndex = 128;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged_1);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1移动GSM900",
            "2电信CMDA800",
            "3电信FDD1.8G",
            "4联通FDD1.8G",
            "5电信FDD2.1G",
            "6联通WCDMA",
            "7移动DCS1800",
            "8移动TD(F频段)",
            "9移动TD(A频段)",
            "10移动TD(E频段)",
            "11电信TD2.3G",
            "12联通TD2.3G"});
            this.comboBox1.Location = new System.Drawing.Point(49, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 24);
            this.comboBox1.TabIndex = 127;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DebugPoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 463);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DebugPoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DebugPoi";
            this.Load += new System.EventHandler(this.DebugPoi_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_sig_on;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_ana_freq;
        private System.Windows.Forms.Button btn_ana;
        private System.Windows.Forms.Button btn_sig_off;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_vco;
        private System.Windows.Forms.Button btn_sen;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_sig2_off;
        private System.Windows.Forms.Button btn_sig2_on;
        private System.Windows.Forms.TextBox tb_p2;
        private System.Windows.Forms.TextBox tb_f2;
        private System.Windows.Forms.Button btn_sig2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_f1;
        private System.Windows.Forms.Button btn_sig1;
        private System.Windows.Forms.TextBox tb_p1;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}