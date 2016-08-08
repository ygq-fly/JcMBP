namespace JcMBP
{
    partial class TimeSweepMid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeSweepMid));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.time_tb_log = new System.Windows.Forms.TextBox();
            this.time_Scrollbar = new Multi_Band_PIM_Analysis.CustomScrollbar();
            this.time_dgvPim = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fluctuate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_plot = new CustomControls.PowerProgramBar();
            this.label71 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.label60 = new System.Windows.Forms.Label();
            this.time_tb_rxPass = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.time_tb_show_tx1 = new System.Windows.Forms.TextBox();
            this.time_tb_show_tx2 = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.time_tb_pim_now_dbc = new System.Windows.Forms.TextBox();
            this.time_lbl_limitResulte = new System.Windows.Forms.Label();
            this.time_tB_valMax_dbc = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.time_tB_valMin_dbc = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.time_tb_limit = new System.Windows.Forms.TextBox();
            this.time_tB_valMin = new System.Windows.Forms.TextBox();
            this.time_tB_valMax = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.time_tb_pim_now = new System.Windows.Forms.TextBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time_dgvPim)).BeginInit();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox17.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox18
            // 
            this.groupBox18.BackColor = System.Drawing.Color.Transparent;
            this.groupBox18.Controls.Add(this.time_tb_log);
            this.groupBox18.Controls.Add(this.time_Scrollbar);
            this.groupBox18.Controls.Add(this.time_dgvPim);
            this.groupBox18.Controls.Add(this.time_plot);
            this.groupBox18.Controls.Add(this.label71);
            this.groupBox18.Location = new System.Drawing.Point(227, 1);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox18.Size = new System.Drawing.Size(574, 615);
            this.groupBox18.TabIndex = 156;
            this.groupBox18.TabStop = false;
            // 
            // time_tb_log
            // 
            this.time_tb_log.BackColor = System.Drawing.Color.Silver;
            this.time_tb_log.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tb_log.Location = new System.Drawing.Point(8, 51);
            this.time_tb_log.Multiline = true;
            this.time_tb_log.Name = "time_tb_log";
            this.time_tb_log.ReadOnly = true;
            this.time_tb_log.Size = new System.Drawing.Size(342, 280);
            this.time_tb_log.TabIndex = 153;
            this.time_tb_log.Text = "<<请开始点频测试>>";
            // 
            // time_Scrollbar
            // 
            this.time_Scrollbar.ChannelColor = System.Drawing.Color.Black;
            this.time_Scrollbar.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("time_Scrollbar.DownArrowImage")));
            this.time_Scrollbar.LargeChange = 10;
            this.time_Scrollbar.Location = new System.Drawing.Point(537, 348);
            this.time_Scrollbar.Maximum = 100;
            this.time_Scrollbar.Minimum = 0;
            this.time_Scrollbar.MinimumSize = new System.Drawing.Size(23, 106);
            this.time_Scrollbar.Name = "time_Scrollbar";
            this.time_Scrollbar.Size = new System.Drawing.Size(28, 263);
            this.time_Scrollbar.SmallChange = 1;
            this.time_Scrollbar.TabIndex = 152;
            this.time_Scrollbar.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("time_Scrollbar.ThumbBottomImage")));
            this.time_Scrollbar.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("time_Scrollbar.ThumbBottomSpanImage")));
            this.time_Scrollbar.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("time_Scrollbar.ThumbMiddleImage")));
            this.time_Scrollbar.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("time_Scrollbar.ThumbTopImage")));
            this.time_Scrollbar.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("time_Scrollbar.ThumbTopSpanImage")));
            this.time_Scrollbar.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("time_Scrollbar.UpArrowImage")));
            this.time_Scrollbar.Value = 0;
            this.time_Scrollbar.Scroll += new System.EventHandler(this.time_Scrollbar_Scroll);
            // 
            // time_dgvPim
            // 
            this.time_dgvPim.AllowUserToAddRows = false;
            this.time_dgvPim.AllowUserToDeleteRows = false;
            this.time_dgvPim.AllowUserToResizeColumns = false;
            this.time_dgvPim.AllowUserToResizeRows = false;
            this.time_dgvPim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.time_dgvPim.BackgroundColor = System.Drawing.Color.Black;
            this.time_dgvPim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_dgvPim.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.time_dgvPim.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.time_dgvPim.ColumnHeadersHeight = 31;
            this.time_dgvPim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.time_dgvPim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn13,
            this.Fluctuate,
            this.dataGridViewTextBoxColumn14});
            this.time_dgvPim.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.time_dgvPim.DefaultCellStyle = dataGridViewCellStyle2;
            this.time_dgvPim.EnableHeadersVisualStyles = false;
            this.time_dgvPim.GridColor = System.Drawing.Color.DarkTurquoise;
            this.time_dgvPim.Location = new System.Drawing.Point(8, 349);
            this.time_dgvPim.MultiSelect = false;
            this.time_dgvPim.Name = "time_dgvPim";
            this.time_dgvPim.ReadOnly = true;
            this.time_dgvPim.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.time_dgvPim.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.time_dgvPim.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_dgvPim.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.time_dgvPim.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.time_dgvPim.RowTemplate.Height = 21;
            this.time_dgvPim.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.time_dgvPim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.time_dgvPim.ShowCellErrors = false;
            this.time_dgvPim.ShowCellToolTips = false;
            this.time_dgvPim.ShowEditingIcon = false;
            this.time_dgvPim.ShowRowErrors = false;
            this.time_dgvPim.Size = new System.Drawing.Size(525, 263);
            this.time_dgvPim.TabIndex = 151;
            this.time_dgvPim.Scroll += new System.Windows.Forms.ScrollEventHandler(this.time_dgvPim_Scroll);
            this.time_dgvPim.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.time_dgvPim_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NO.";
            this.dataGridViewTextBoxColumn8.FillWeight = 44F;
            this.dataGridViewTextBoxColumn8.HeaderText = "N0.";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Peak";
            this.dataGridViewTextBoxColumn13.FillWeight = 105F;
            this.dataGridViewTextBoxColumn13.HeaderText = "Peak(dBm)";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Fluctuate
            // 
            this.Fluctuate.DataPropertyName = "Fluctuate";
            this.Fluctuate.HeaderText = "波动(dBm)";
            this.Fluctuate.Name = "Fluctuate";
            this.Fluctuate.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Result";
            this.dataGridViewTextBoxColumn14.FillWeight = 105F;
            this.dataGridViewTextBoxColumn14.HeaderText = "结果";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // time_plot
            // 
            this.time_plot.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_plot.ForeColor = System.Drawing.Color.Black;
            this.time_plot.GraduationColor = System.Drawing.Color.Black;
            this.time_plot.GraduationNumber = 5;
            this.time_plot.GraduationTextColor = System.Drawing.Color.Black;
            this.time_plot.Location = new System.Drawing.Point(372, 51);
            this.time_plot.Margin = new System.Windows.Forms.Padding(1);
            this.time_plot.MaxValue = 0F;
            this.time_plot.MinValue = -180F;
            this.time_plot.Name = "time_plot";
            this.time_plot.RealValue = -40F;
            this.time_plot.Size = new System.Drawing.Size(193, 280);
            this.time_plot.TabIndex = 125;
            this.time_plot.Value = -100F;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(69)))), ((int)(((byte)(72)))));
            this.label71.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label71.ForeColor = System.Drawing.Color.White;
            this.label71.Location = new System.Drawing.Point(8, 17);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(559, 30);
            this.label71.TabIndex = 124;
            this.label71.Text = "时 域 模 式";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label71.Click += new System.EventHandler(this.label71_Click);
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.Gainsboro;
            this.label59.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label59.ForeColor = System.Drawing.Color.Gray;
            this.label59.Location = new System.Drawing.Point(17, 155);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(186, 68);
            this.label59.TabIndex = 144;
            this.label59.Text = "紫光网络\r\nJointcom.com";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.label59);
            this.groupBox16.Controls.Add(this.label60);
            this.groupBox16.Controls.Add(this.time_tb_rxPass);
            this.groupBox16.Controls.Add(this.label62);
            this.groupBox16.Controls.Add(this.label63);
            this.groupBox16.Controls.Add(this.time_tb_show_tx1);
            this.groupBox16.Controls.Add(this.time_tb_show_tx2);
            this.groupBox16.Controls.Add(this.label64);
            this.groupBox16.Location = new System.Drawing.Point(804, 384);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(217, 233);
            this.groupBox16.TabIndex = 159;
            this.groupBox16.TabStop = false;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(69)))), ((int)(((byte)(72)))));
            this.label60.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label60.ForeColor = System.Drawing.Color.White;
            this.label60.Location = new System.Drawing.Point(6, 13);
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
            this.time_tb_rxPass.Location = new System.Drawing.Point(102, 121);
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
            this.label62.Location = new System.Drawing.Point(10, 58);
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
            this.label63.Location = new System.Drawing.Point(18, 126);
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
            this.time_tb_show_tx1.Location = new System.Drawing.Point(102, 57);
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
            this.time_tb_show_tx2.Location = new System.Drawing.Point(102, 89);
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
            this.label64.Location = new System.Drawing.Point(10, 91);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(81, 17);
            this.label64.TabIndex = 140;
            this.label64.Text = "P2 (dBm):";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 628);
            this.panel1.TabIndex = 154;
            // 
            // time_tb_pim_now_dbc
            // 
            this.time_tb_pim_now_dbc.BackColor = System.Drawing.Color.DimGray;
            this.time_tb_pim_now_dbc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tb_pim_now_dbc.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tb_pim_now_dbc.ForeColor = System.Drawing.Color.White;
            this.time_tb_pim_now_dbc.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.time_tb_pim_now_dbc.Location = new System.Drawing.Point(88, 138);
            this.time_tb_pim_now_dbc.Name = "time_tb_pim_now_dbc";
            this.time_tb_pim_now_dbc.ReadOnly = true;
            this.time_tb_pim_now_dbc.ShortcutsEnabled = false;
            this.time_tb_pim_now_dbc.Size = new System.Drawing.Size(109, 27);
            this.time_tb_pim_now_dbc.TabIndex = 167;
            this.time_tb_pim_now_dbc.TabStop = false;
            this.time_tb_pim_now_dbc.Text = "---";
            this.time_tb_pim_now_dbc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // time_lbl_limitResulte
            // 
            this.time_lbl_limitResulte.BackColor = System.Drawing.Color.DimGray;
            this.time_lbl_limitResulte.Font = new System.Drawing.Font("微软雅黑", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_lbl_limitResulte.ForeColor = System.Drawing.Color.Lime;
            this.time_lbl_limitResulte.Location = new System.Drawing.Point(6, 208);
            this.time_lbl_limitResulte.Name = "time_lbl_limitResulte";
            this.time_lbl_limitResulte.Size = new System.Drawing.Size(196, 83);
            this.time_lbl_limitResulte.TabIndex = 112;
            this.time_lbl_limitResulte.Text = "PASS";
            this.time_lbl_limitResulte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Transparent;
            this.label67.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label67.Location = new System.Drawing.Point(6, 104);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(78, 17);
            this.label67.TabIndex = 115;
            this.label67.Text = "最小(dBm):";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time_tB_valMin_dbc
            // 
            this.time_tB_valMin_dbc.BackColor = System.Drawing.Color.DimGray;
            this.time_tB_valMin_dbc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tB_valMin_dbc.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tB_valMin_dbc.ForeColor = System.Drawing.Color.White;
            this.time_tB_valMin_dbc.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.time_tB_valMin_dbc.Location = new System.Drawing.Point(88, 96);
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
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label66.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label66.Location = new System.Drawing.Point(9, 315);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(73, 16);
            this.label66.TabIndex = 117;
            this.label66.Text = "Limit(dBm):";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_tb_limit
            // 
            this.time_tb_limit.BackColor = System.Drawing.Color.Black;
            this.time_tb_limit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tb_limit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tb_limit.ForeColor = System.Drawing.Color.White;
            this.time_tb_limit.Location = new System.Drawing.Point(89, 309);
            this.time_tb_limit.Name = "time_tb_limit";
            this.time_tb_limit.Size = new System.Drawing.Size(72, 22);
            this.time_tb_limit.TabIndex = 110;
            this.time_tb_limit.Text = "-110.0";
            this.time_tb_limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time_tb_limit.Visible = false;
            // 
            // time_tB_valMin
            // 
            this.time_tB_valMin.BackColor = System.Drawing.Color.DimGray;
            this.time_tB_valMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tB_valMin.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tB_valMin.ForeColor = System.Drawing.Color.White;
            this.time_tB_valMin.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.time_tB_valMin.Location = new System.Drawing.Point(88, 96);
            this.time_tB_valMin.Name = "time_tB_valMin";
            this.time_tB_valMin.ReadOnly = true;
            this.time_tB_valMin.ShortcutsEnabled = false;
            this.time_tB_valMin.Size = new System.Drawing.Size(109, 27);
            this.time_tB_valMin.TabIndex = 119;
            this.time_tB_valMin.TabStop = false;
            this.time_tB_valMin.Text = "---";
            this.time_tB_valMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label21.Location = new System.Drawing.Point(6, 145);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 17);
            this.label21.TabIndex = 125;
            this.label21.Text = "平均(dBm):";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time_tb_pim_now
            // 
            this.time_tb_pim_now.BackColor = System.Drawing.Color.DimGray;
            this.time_tb_pim_now.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_tb_pim_now.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_tb_pim_now.ForeColor = System.Drawing.Color.White;
            this.time_tb_pim_now.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.time_tb_pim_now.Location = new System.Drawing.Point(88, 138);
            this.time_tb_pim_now.Name = "time_tb_pim_now";
            this.time_tb_pim_now.ReadOnly = true;
            this.time_tb_pim_now.ShortcutsEnabled = false;
            this.time_tb_pim_now.Size = new System.Drawing.Size(109, 27);
            this.time_tb_pim_now.TabIndex = 126;
            this.time_tb_pim_now.TabStop = false;
            this.time_tb_pim_now.Text = "---";
            this.time_tb_pim_now.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.Color.Black;
            this.numericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown2.DecimalPlaces = 1;
            this.numericUpDown2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown2.ForeColor = System.Drawing.Color.White;
            this.numericUpDown2.Location = new System.Drawing.Point(88, 310);
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label1.Location = new System.Drawing.Point(3, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 165;
            this.label1.Text = "Unit:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(87, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 167;
            this.button1.Text = "dBm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox17
            // 
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
            this.groupBox17.Location = new System.Drawing.Point(804, 1);
            this.groupBox17.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox17.Size = new System.Drawing.Size(217, 380);
            this.groupBox17.TabIndex = 158;
            this.groupBox17.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DimGray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox1.Location = new System.Drawing.Point(89, 174);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(109, 27);
            this.textBox1.TabIndex = 169;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "---";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label2.Location = new System.Drawing.Point(5, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 168;
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
            this.textBox2.Location = new System.Drawing.Point(89, 174);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ShortcutsEnabled = false;
            this.textBox2.Size = new System.Drawing.Size(109, 27);
            this.textBox2.TabIndex = 170;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "---";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // TimeSweepMid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 635);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox16);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.groupBox18);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimeSweepMid";
            this.Text = "TimeSweepMid";
            this.Load += new System.EventHandler(this.TimeSweepMid_Load);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time_dgvPim)).EndInit();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox time_tb_log;
        private Multi_Band_PIM_Analysis.CustomScrollbar time_Scrollbar;
        private System.Windows.Forms.DataGridView time_dgvPim;
        private CustomControls.PowerProgramBar time_plot;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label time_tb_rxPass;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox time_tb_show_tx1;
        private System.Windows.Forms.TextBox time_tb_show_tx2;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox time_tb_pim_now_dbc;
        private System.Windows.Forms.Label time_lbl_limitResulte;
        private System.Windows.Forms.TextBox time_tB_valMax_dbc;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox time_tB_valMin_dbc;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox time_tb_limit;
        private System.Windows.Forms.TextBox time_tB_valMin;
        private System.Windows.Forms.TextBox time_tB_valMax;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox time_tb_pim_now;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fluctuate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
    }
}