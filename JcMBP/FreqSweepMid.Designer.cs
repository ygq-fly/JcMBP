namespace JcMBP
{
    partial class FreqSweepMid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreqSweepMid));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.eng_lbl_show_mode = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.eng_pB_title = new System.Windows.Forms.Label();
            this.freq_plot = new jcXY2dPlotEx.XY2dPlotEx();
            this.freq_dgvPim = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fluctuate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.time_tb_rxPass = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.time_tb_show_tx1 = new System.Windows.Forms.TextBox();
            this.time_tb_show_tx2 = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.time_tb_pim_now = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.time_tB_valMax = new System.Windows.Forms.TextBox();
            this.time_tB_valMin = new System.Windows.Forms.TextBox();
            this.time_tb_limit = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.time_tB_valMin_dbc = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.time_tB_valMax_dbc = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.time_lbl_limitResulte = new System.Windows.Forms.Label();
            this.time_tb_pim_now_dbc = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.脚本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.freq_Scrollbar = new Multi_Band_PIM_Analysis.CustomScrollbar();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freq_dgvPim)).BeginInit();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // eng_lbl_show_mode
            // 
            this.eng_lbl_show_mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(69)))), ((int)(((byte)(72)))));
            this.eng_lbl_show_mode.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.eng_lbl_show_mode.ForeColor = System.Drawing.Color.White;
            this.eng_lbl_show_mode.Location = new System.Drawing.Point(8, 17);
            this.eng_lbl_show_mode.Name = "eng_lbl_show_mode";
            this.eng_lbl_show_mode.Size = new System.Drawing.Size(559, 30);
            this.eng_lbl_show_mode.TabIndex = 124;
            this.eng_lbl_show_mode.Text = "频 域 模 式";
            this.eng_lbl_show_mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.eng_pB_title);
            this.groupBox2.Controls.Add(this.eng_lbl_show_mode);
            this.groupBox2.Controls.Add(this.freq_plot);
            this.groupBox2.Location = new System.Drawing.Point(229, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 335);
            this.groupBox2.TabIndex = 151;
            this.groupBox2.TabStop = false;
            // 
            // eng_pB_title
            // 
            this.eng_pB_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(69)))), ((int)(((byte)(72)))));
            this.eng_pB_title.Image = ((System.Drawing.Image)(resources.GetObject("eng_pB_title.Image")));
            this.eng_pB_title.Location = new System.Drawing.Point(442, 22);
            this.eng_pB_title.Name = "eng_pB_title";
            this.eng_pB_title.Size = new System.Drawing.Size(120, 20);
            this.eng_pB_title.TabIndex = 135;
            // 
            // freq_plot
            // 
            this.freq_plot.AixsLineColor = System.Drawing.Color.DarkTurquoise;
            this.freq_plot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.freq_plot.BorderLineColor = System.Drawing.Color.Blue;
            this.freq_plot.GridBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.freq_plot.GridLineBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.freq_plot.InnerMargin = 6;
            this.freq_plot.LineColor = System.Drawing.Color.DarkTurquoise;
            this.freq_plot.Location = new System.Drawing.Point(8, 55);
            this.freq_plot.MajorLineWidth = 2;
            this.freq_plot.Margin = new System.Windows.Forms.Padding(4);
            this.freq_plot.MinorLineWidth = 1;
            this.freq_plot.Name = "freq_plot";
            this.freq_plot.ShowTitle = false;
            this.freq_plot.Size = new System.Drawing.Size(559, 272);
            this.freq_plot.TabIndex = 134;
            this.freq_plot.Title = "Plot XY 2d Demo";
            this.freq_plot.TitleFont = new System.Drawing.Font("宋体", 9F);
            this.freq_plot.TitleLabelColor = System.Drawing.Color.White;
            this.freq_plot.XAxisTitle = "Frequency(MHz)";
            this.freq_plot.XLabelColor = System.Drawing.Color.White;
            this.freq_plot.XLabelFont = new System.Drawing.Font("宋体", 9F);
            this.freq_plot.XMajorCount = 5;
            this.freq_plot.XMajorLength = 5;
            this.freq_plot.XMinorCount = 2;
            this.freq_plot.XMinorLength = 3;
            this.freq_plot.XShowLabel = true;
            this.freq_plot.XShowMinor = true;
            this.freq_plot.XShowTitle = false;
            this.freq_plot.XTitleFont = new System.Drawing.Font("宋体", 12F);
            this.freq_plot.YAxisTitle = "(dBm)";
            this.freq_plot.YLabelColor = System.Drawing.Color.White;
            this.freq_plot.YLabelFont = new System.Drawing.Font("宋体", 9F);
            this.freq_plot.YMajorCount = 2;
            this.freq_plot.YMajorLength = 5;
            this.freq_plot.YMinorCount = 3;
            this.freq_plot.YMinorLength = 3;
            this.freq_plot.YShowLabel = true;
            this.freq_plot.YShowMinor = true;
            this.freq_plot.YShowTitle = false;
            this.freq_plot.YTitleFont = new System.Drawing.Font("宋体", 12F);
            // 
            // freq_dgvPim
            // 
            this.freq_dgvPim.AllowUserToAddRows = false;
            this.freq_dgvPim.AllowUserToDeleteRows = false;
            this.freq_dgvPim.AllowUserToResizeColumns = false;
            this.freq_dgvPim.AllowUserToResizeRows = false;
            this.freq_dgvPim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.freq_dgvPim.BackgroundColor = System.Drawing.Color.Black;
            this.freq_dgvPim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.freq_dgvPim.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.freq_dgvPim.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.freq_dgvPim.ColumnHeadersHeight = 31;
            this.freq_dgvPim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.freq_dgvPim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.Fluctuate,
            this.dataGridViewTextBoxColumn7});
            this.freq_dgvPim.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.freq_dgvPim.DefaultCellStyle = dataGridViewCellStyle2;
            this.freq_dgvPim.EnableHeadersVisualStyles = false;
            this.freq_dgvPim.GridColor = System.Drawing.Color.DarkTurquoise;
            this.freq_dgvPim.Location = new System.Drawing.Point(237, 349);
            this.freq_dgvPim.MultiSelect = false;
            this.freq_dgvPim.Name = "freq_dgvPim";
            this.freq_dgvPim.ReadOnly = true;
            this.freq_dgvPim.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.freq_dgvPim.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.freq_dgvPim.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freq_dgvPim.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.freq_dgvPim.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.freq_dgvPim.RowTemplate.Height = 21;
            this.freq_dgvPim.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.freq_dgvPim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.freq_dgvPim.ShowCellErrors = false;
            this.freq_dgvPim.ShowCellToolTips = false;
            this.freq_dgvPim.ShowEditingIcon = false;
            this.freq_dgvPim.ShowRowErrors = false;
            this.freq_dgvPim.Size = new System.Drawing.Size(525, 263);
            this.freq_dgvPim.TabIndex = 152;
            this.freq_dgvPim.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.freq_dgvPim_RowPrePaint);
            this.freq_dgvPim.Scroll += new System.Windows.Forms.ScrollEventHandler(this.freq_dgvPim_Scroll);
            this.freq_dgvPim.MouseClick += new System.Windows.Forms.MouseEventHandler(this.freq_dgvPim_MouseClick);
            this.freq_dgvPim.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.freq_dgvPim_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NO.";
            this.dataGridViewTextBoxColumn1.FillWeight = 44F;
            this.dataGridViewTextBoxColumn1.HeaderText = "N0.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Peak";
            this.dataGridViewTextBoxColumn6.FillWeight = 105F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Peak(dBm)";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Fluctuate
            // 
            this.Fluctuate.DataPropertyName = "Fluctuate";
            this.Fluctuate.HeaderText = "波动(dBm)";
            this.Fluctuate.Name = "Fluctuate";
            this.Fluctuate.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Result";
            this.dataGridViewTextBoxColumn7.FillWeight = 105F;
            this.dataGridViewTextBoxColumn7.HeaderText = "结果";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 631);
            this.panel1.TabIndex = 155;
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.Gainsboro;
            this.label59.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label59.ForeColor = System.Drawing.Color.Gray;
            this.label59.Location = new System.Drawing.Point(17, 159);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(186, 68);
            this.label59.TabIndex = 144;
            this.label59.Text = "紫光网络\r\nJointcom.com";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(69)))), ((int)(((byte)(72)))));
            this.label60.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label60.ForeColor = System.Drawing.Color.White;
            this.label60.Location = new System.Drawing.Point(6, 17);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(205, 30);
            this.label60.TabIndex = 125;
            this.label60.Text = "监 控 项";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_tb_rxPass
            // 
            this.time_tb_rxPass.BackColor = System.Drawing.Color.DimGray;
            this.time_tb_rxPass.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tb_rxPass.ForeColor = System.Drawing.Color.White;
            this.time_tb_rxPass.Location = new System.Drawing.Point(102, 122);
            this.time_tb_rxPass.Name = "time_tb_rxPass";
            this.time_tb_rxPass.Size = new System.Drawing.Size(86, 25);
            this.time_tb_rxPass.TabIndex = 143;
            this.time_tb_rxPass.Text = "----";
            this.time_tb_rxPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label62.Location = new System.Drawing.Point(10, 62);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(81, 17);
            this.label62.TabIndex = 138;
            this.label62.Text = "P1 (dBm):";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label63.Location = new System.Drawing.Point(18, 130);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(73, 17);
            this.label63.TabIndex = 142;
            this.label63.Text = "VCO 检测:";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time_tb_show_tx1
            // 
            this.time_tb_show_tx1.BackColor = System.Drawing.Color.DimGray;
            this.time_tb_show_tx1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tb_show_tx1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tb_show_tx1.ForeColor = System.Drawing.Color.White;
            this.time_tb_show_tx1.Location = new System.Drawing.Point(102, 60);
            this.time_tb_show_tx1.Name = "time_tb_show_tx1";
            this.time_tb_show_tx1.ReadOnly = true;
            this.time_tb_show_tx1.ShortcutsEnabled = false;
            this.time_tb_show_tx1.Size = new System.Drawing.Size(86, 18);
            this.time_tb_show_tx1.TabIndex = 139;
            this.time_tb_show_tx1.TabStop = false;
            this.time_tb_show_tx1.Text = "0";
            this.time_tb_show_tx1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // time_tb_show_tx2
            // 
            this.time_tb_show_tx2.BackColor = System.Drawing.Color.DimGray;
            this.time_tb_show_tx2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tb_show_tx2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tb_show_tx2.ForeColor = System.Drawing.Color.White;
            this.time_tb_show_tx2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.time_tb_show_tx2.Location = new System.Drawing.Point(102, 93);
            this.time_tb_show_tx2.Name = "time_tb_show_tx2";
            this.time_tb_show_tx2.ReadOnly = true;
            this.time_tb_show_tx2.ShortcutsEnabled = false;
            this.time_tb_show_tx2.Size = new System.Drawing.Size(86, 18);
            this.time_tb_show_tx2.TabIndex = 141;
            this.time_tb_show_tx2.TabStop = false;
            this.time_tb_show_tx2.Text = "0";
            this.time_tb_show_tx2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.Color.Transparent;
            this.label64.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label64.Location = new System.Drawing.Point(10, 95);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(81, 17);
            this.label64.TabIndex = 140;
            this.label64.Text = "P2 (dBm):";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.textBox1);
            this.groupBox17.Controls.Add(this.label2);
            this.groupBox17.Controls.Add(this.textBox2);
            this.groupBox17.Controls.Add(this.button1);
            this.groupBox17.Controls.Add(this.label1);
            this.groupBox17.Controls.Add(this.numericUpDown2);
            this.groupBox17.Controls.Add(this.time_tb_pim_now);
            this.groupBox17.Controls.Add(this.label21);
            this.groupBox17.Controls.Add(this.label65);
            this.groupBox17.Controls.Add(this.time_tB_valMax);
            this.groupBox17.Controls.Add(this.time_tB_valMin);
            this.groupBox17.Controls.Add(this.time_tb_limit);
            this.groupBox17.Controls.Add(this.label66);
            this.groupBox17.Controls.Add(this.time_tB_valMin_dbc);
            this.groupBox17.Controls.Add(this.label67);
            this.groupBox17.Controls.Add(this.time_tB_valMax_dbc);
            this.groupBox17.Controls.Add(this.label68);
            this.groupBox17.Controls.Add(this.time_lbl_limitResulte);
            this.groupBox17.Controls.Add(this.time_tb_pim_now_dbc);
            this.groupBox17.Location = new System.Drawing.Point(806, 1);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(217, 376);
            this.groupBox17.TabIndex = 161;
            this.groupBox17.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DimGray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox1.Location = new System.Drawing.Point(87, 164);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(109, 27);
            this.textBox1.TabIndex = 168;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "---";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label2.Location = new System.Drawing.Point(5, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 167;
            this.label2.Text = "波动(dBm):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DimGray;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox2.Location = new System.Drawing.Point(87, 164);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ShortcutsEnabled = false;
            this.textBox2.Size = new System.Drawing.Size(109, 27);
            this.textBox2.TabIndex = 169;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "---";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(87, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 166;
            this.button1.Text = "dBm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label1.Location = new System.Drawing.Point(3, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 163;
            this.label1.Text = "Unit:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.Color.Black;
            this.numericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown2.DecimalPlaces = 1;
            this.numericUpDown2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown2.ForeColor = System.Drawing.Color.White;
            this.numericUpDown2.Location = new System.Drawing.Point(88, 303);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.ReadOnly = true;
            this.numericUpDown2.Size = new System.Drawing.Size(85, 21);
            this.numericUpDown2.TabIndex = 162;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            this.numericUpDown2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numericUpDown2_MouseClick);
            // 
            // time_tb_pim_now
            // 
            this.time_tb_pim_now.BackColor = System.Drawing.Color.DimGray;
            this.time_tb_pim_now.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tb_pim_now.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tb_pim_now.ForeColor = System.Drawing.Color.White;
            this.time_tb_pim_now.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.time_tb_pim_now.Location = new System.Drawing.Point(87, 131);
            this.time_tb_pim_now.Name = "time_tb_pim_now";
            this.time_tb_pim_now.ReadOnly = true;
            this.time_tb_pim_now.ShortcutsEnabled = false;
            this.time_tb_pim_now.Size = new System.Drawing.Size(109, 27);
            this.time_tb_pim_now.TabIndex = 126;
            this.time_tb_pim_now.TabStop = false;
            this.time_tb_pim_now.Text = "---";
            this.time_tb_pim_now.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label21.Location = new System.Drawing.Point(6, 138);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 17);
            this.label21.TabIndex = 125;
            this.label21.Text = "平均(dBm):";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(69)))), ((int)(((byte)(72)))));
            this.label65.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label65.ForeColor = System.Drawing.Color.White;
            this.label65.Location = new System.Drawing.Point(6, 17);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(205, 30);
            this.label65.TabIndex = 124;
            this.label65.Text = "互 调 值";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_tB_valMax
            // 
            this.time_tB_valMax.BackColor = System.Drawing.Color.DimGray;
            this.time_tB_valMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tB_valMax.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tB_valMax.ForeColor = System.Drawing.Color.White;
            this.time_tB_valMax.Location = new System.Drawing.Point(88, 57);
            this.time_tB_valMax.Name = "time_tB_valMax";
            this.time_tB_valMax.ReadOnly = true;
            this.time_tB_valMax.ShortcutsEnabled = false;
            this.time_tB_valMax.Size = new System.Drawing.Size(109, 27);
            this.time_tB_valMax.TabIndex = 118;
            this.time_tB_valMax.TabStop = false;
            this.time_tB_valMax.Text = "---";
            this.time_tB_valMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // time_tB_valMin
            // 
            this.time_tB_valMin.BackColor = System.Drawing.Color.DimGray;
            this.time_tB_valMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tB_valMin.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tB_valMin.ForeColor = System.Drawing.Color.White;
            this.time_tB_valMin.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.time_tB_valMin.Location = new System.Drawing.Point(88, 94);
            this.time_tB_valMin.Name = "time_tB_valMin";
            this.time_tB_valMin.ReadOnly = true;
            this.time_tB_valMin.ShortcutsEnabled = false;
            this.time_tB_valMin.Size = new System.Drawing.Size(109, 27);
            this.time_tB_valMin.TabIndex = 119;
            this.time_tB_valMin.TabStop = false;
            this.time_tB_valMin.Text = "---";
            this.time_tB_valMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // time_tb_limit
            // 
            this.time_tb_limit.BackColor = System.Drawing.Color.Black;
            this.time_tb_limit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tb_limit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tb_limit.ForeColor = System.Drawing.Color.White;
            this.time_tb_limit.Location = new System.Drawing.Point(88, 303);
            this.time_tb_limit.Name = "time_tb_limit";
            this.time_tb_limit.Size = new System.Drawing.Size(72, 22);
            this.time_tb_limit.TabIndex = 110;
            this.time_tb_limit.Text = "-110.0";
            this.time_tb_limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time_tb_limit.Visible = false;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label66.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label66.Location = new System.Drawing.Point(9, 308);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(73, 16);
            this.label66.TabIndex = 117;
            this.label66.Text = "Limit(dBm):";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_tB_valMin_dbc
            // 
            this.time_tB_valMin_dbc.BackColor = System.Drawing.Color.DimGray;
            this.time_tB_valMin_dbc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tB_valMin_dbc.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tB_valMin_dbc.ForeColor = System.Drawing.Color.White;
            this.time_tB_valMin_dbc.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.time_tB_valMin_dbc.Location = new System.Drawing.Point(88, 94);
            this.time_tB_valMin_dbc.Name = "time_tB_valMin_dbc";
            this.time_tB_valMin_dbc.ReadOnly = true;
            this.time_tB_valMin_dbc.ShortcutsEnabled = false;
            this.time_tB_valMin_dbc.Size = new System.Drawing.Size(109, 27);
            this.time_tB_valMin_dbc.TabIndex = 116;
            this.time_tB_valMin_dbc.TabStop = false;
            this.time_tB_valMin_dbc.Text = "---";
            this.time_tB_valMin_dbc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time_tB_valMin_dbc.Visible = false;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Transparent;
            this.label67.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label67.Location = new System.Drawing.Point(6, 102);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(78, 17);
            this.label67.TabIndex = 115;
            this.label67.Text = "最小(dBm):";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time_tB_valMax_dbc
            // 
            this.time_tB_valMax_dbc.BackColor = System.Drawing.Color.DimGray;
            this.time_tB_valMax_dbc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tB_valMax_dbc.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tB_valMax_dbc.ForeColor = System.Drawing.Color.White;
            this.time_tB_valMax_dbc.Location = new System.Drawing.Point(88, 57);
            this.time_tB_valMax_dbc.Name = "time_tB_valMax_dbc";
            this.time_tB_valMax_dbc.ReadOnly = true;
            this.time_tB_valMax_dbc.ShortcutsEnabled = false;
            this.time_tB_valMax_dbc.Size = new System.Drawing.Size(109, 27);
            this.time_tB_valMax_dbc.TabIndex = 114;
            this.time_tB_valMax_dbc.TabStop = false;
            this.time_tB_valMax_dbc.Text = "---";
            this.time_tB_valMax_dbc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time_tB_valMax_dbc.Visible = false;
            // 
            // label68
            // 
            this.label68.BackColor = System.Drawing.Color.Transparent;
            this.label68.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label68.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label68.Location = new System.Drawing.Point(7, 64);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(78, 17);
            this.label68.TabIndex = 113;
            this.label68.Text = "最大(dBm):";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time_lbl_limitResulte
            // 
            this.time_lbl_limitResulte.BackColor = System.Drawing.Color.DimGray;
            this.time_lbl_limitResulte.Font = new System.Drawing.Font("微软雅黑", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_lbl_limitResulte.ForeColor = System.Drawing.Color.Lime;
            this.time_lbl_limitResulte.Location = new System.Drawing.Point(6, 201);
            this.time_lbl_limitResulte.Name = "time_lbl_limitResulte";
            this.time_lbl_limitResulte.Size = new System.Drawing.Size(196, 83);
            this.time_lbl_limitResulte.TabIndex = 112;
            this.time_lbl_limitResulte.Text = "PASS";
            this.time_lbl_limitResulte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_tb_pim_now_dbc
            // 
            this.time_tb_pim_now_dbc.BackColor = System.Drawing.Color.DimGray;
            this.time_tb_pim_now_dbc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tb_pim_now_dbc.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tb_pim_now_dbc.ForeColor = System.Drawing.Color.White;
            this.time_tb_pim_now_dbc.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.time_tb_pim_now_dbc.Location = new System.Drawing.Point(87, 131);
            this.time_tb_pim_now_dbc.Name = "time_tb_pim_now_dbc";
            this.time_tb_pim_now_dbc.ReadOnly = true;
            this.time_tb_pim_now_dbc.ShortcutsEnabled = false;
            this.time_tb_pim_now_dbc.Size = new System.Drawing.Size(109, 27);
            this.time_tb_pim_now_dbc.TabIndex = 165;
            this.time_tb_pim_now_dbc.TabStop = false;
            this.time_tb_pim_now_dbc.Text = "---";
            this.time_tb_pim_now_dbc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(235, 594);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Maximum = 200;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(561, 28);
            this.progressBar1.TabIndex = 163;
            this.progressBar1.Value = 100;
            this.progressBar1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeight = 31;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.脚本,
            this.Max,
            this.Min,
            this.result});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(235, 349);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(561, 245);
            this.dataGridView1.TabIndex = 162;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // 脚本
            // 
            this.脚本.DataPropertyName = "0";
            this.脚本.FillWeight = 81.21828F;
            this.脚本.HeaderText = "脚本(NO.)";
            this.脚本.Name = "脚本";
            this.脚本.ReadOnly = true;
            this.脚本.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Max
            // 
            this.Max.DataPropertyName = "1";
            this.Max.FillWeight = 106.2606F;
            this.Max.HeaderText = "Max(dBm)";
            this.Max.Name = "Max";
            this.Max.ReadOnly = true;
            this.Max.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Min
            // 
            this.Min.DataPropertyName = "2";
            this.Min.FillWeight = 106.2606F;
            this.Min.HeaderText = "Min(dBm)";
            this.Min.Name = "Min";
            this.Min.ReadOnly = true;
            this.Min.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // result
            // 
            this.result.DataPropertyName = "4";
            this.result.FillWeight = 106.2606F;
            this.result.HeaderText = "Result";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label59);
            this.groupBox1.Controls.Add(this.label60);
            this.groupBox1.Controls.Add(this.label63);
            this.groupBox1.Controls.Add(this.label64);
            this.groupBox1.Controls.Add(this.label62);
            this.groupBox1.Controls.Add(this.time_tb_rxPass);
            this.groupBox1.Controls.Add(this.time_tb_show_tx1);
            this.groupBox1.Controls.Add(this.time_tb_show_tx2);
            this.groupBox1.Location = new System.Drawing.Point(806, 383);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 234);
            this.groupBox1.TabIndex = 164;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // freq_Scrollbar
            // 
            this.freq_Scrollbar.ChannelColor = System.Drawing.Color.Black;
            this.freq_Scrollbar.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("freq_Scrollbar.DownArrowImage")));
            this.freq_Scrollbar.LargeChange = 10;
            this.freq_Scrollbar.Location = new System.Drawing.Point(768, 349);
            this.freq_Scrollbar.Maximum = 100;
            this.freq_Scrollbar.Minimum = 0;
            this.freq_Scrollbar.MinimumSize = new System.Drawing.Size(23, 106);
            this.freq_Scrollbar.Name = "freq_Scrollbar";
            this.freq_Scrollbar.Size = new System.Drawing.Size(28, 263);
            this.freq_Scrollbar.SmallChange = 1;
            this.freq_Scrollbar.TabIndex = 153;
            this.freq_Scrollbar.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("freq_Scrollbar.ThumbBottomImage")));
            this.freq_Scrollbar.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("freq_Scrollbar.ThumbBottomSpanImage")));
            this.freq_Scrollbar.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("freq_Scrollbar.ThumbMiddleImage")));
            this.freq_Scrollbar.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("freq_Scrollbar.ThumbTopImage")));
            this.freq_Scrollbar.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("freq_Scrollbar.ThumbTopSpanImage")));
            this.freq_Scrollbar.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("freq_Scrollbar.UpArrowImage")));
            this.freq_Scrollbar.Value = 0;
            this.freq_Scrollbar.Scroll += new System.EventHandler(this.freq_Scrollbar_Scroll);
            // 
            // FreqSweepMid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 635);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.freq_dgvPim);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.freq_Scrollbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FreqSweepMid";
            this.Text = "FreqSweepMid";
            this.Load += new System.EventHandler(this.FreqSweepMid_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.freq_dgvPim)).EndInit();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Multi_Band_PIM_Analysis.CustomScrollbar freq_Scrollbar;
        private System.Windows.Forms.Label eng_lbl_show_mode;
        private System.Windows.Forms.Label eng_pB_title;
        private System.Windows.Forms.GroupBox groupBox2;
        private jcXY2dPlotEx.XY2dPlotEx freq_plot;
        private System.Windows.Forms.DataGridView freq_dgvPim;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label time_tb_rxPass;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox time_tb_show_tx1;
        private System.Windows.Forms.TextBox time_tb_show_tx2;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox time_tb_pim_now;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox time_tB_valMax;
        private System.Windows.Forms.TextBox time_tB_valMin;
        private System.Windows.Forms.TextBox time_tb_limit;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox time_tB_valMin_dbc;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox time_tB_valMax_dbc;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label time_lbl_limitResulte;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 脚本;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max;
        private System.Windows.Forms.DataGridViewTextBoxColumn Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox time_tb_pim_now_dbc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fluctuate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;


    }
}