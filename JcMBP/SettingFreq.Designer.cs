namespace JcMBP
{
    partial class SettingFreq
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.time_nud_f1 = new System.Windows.Forms.NumericUpDown();
            this.label51 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_nud_f1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 132;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 131;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.Black;
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.White;
            this.numericUpDown1.Location = new System.Drawing.Point(128, 39);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(85, 21);
            this.numericUpDown1.TabIndex = 129;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1820,
            0,
            0,
            0});
            this.numericUpDown1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numericUpDown1_MouseClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 19);
            this.label1.TabIndex = 130;
            this.label1.Text = "结束频率 (MHz)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // time_nud_f1
            // 
            this.time_nud_f1.BackColor = System.Drawing.Color.Black;
            this.time_nud_f1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_nud_f1.DecimalPlaces = 2;
            this.time_nud_f1.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_nud_f1.ForeColor = System.Drawing.Color.White;
            this.time_nud_f1.Location = new System.Drawing.Point(128, 8);
            this.time_nud_f1.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.time_nud_f1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.time_nud_f1.Name = "time_nud_f1";
            this.time_nud_f1.ReadOnly = true;
            this.time_nud_f1.Size = new System.Drawing.Size(85, 21);
            this.time_nud_f1.TabIndex = 127;
            this.time_nud_f1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time_nud_f1.Value = new decimal(new int[] {
            1820,
            0,
            0,
            0});
            this.time_nud_f1.ValueChanged += new System.EventHandler(this.time_nud_f1_ValueChanged);
            this.time_nud_f1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.time_nud_f1_MouseClick);
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.Transparent;
            this.label51.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label51.Location = new System.Drawing.Point(9, 9);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(113, 19);
            this.label51.TabIndex = 128;
            this.label51.Text = "起始频率 (MHz)";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingFreq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 99);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.time_nud_f1);
            this.Controls.Add(this.label51);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "SettingFreq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingFreq";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_nud_f1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown time_nud_f1;
        private System.Windows.Forms.Label label51;
    }
}