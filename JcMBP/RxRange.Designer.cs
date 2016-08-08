namespace JcMBP
{
    partial class RxRange
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
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.time_btn_start_b = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.SystemColors.InfoText;
            this.numericUpDown2.ForeColor = System.Drawing.SystemColors.Info;
            this.numericUpDown2.Location = new System.Drawing.Point(142, 45);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(85, 21);
            this.numericUpDown2.TabIndex = 182;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numericUpDown2_MouseClick);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.SystemColors.InfoText;
            this.numericUpDown1.ForeColor = System.Drawing.SystemColors.Info;
            this.numericUpDown1.Location = new System.Drawing.Point(142, 7);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(85, 21);
            this.numericUpDown1.TabIndex = 181;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numericUpDown1_MouseClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label1.Location = new System.Drawing.Point(15, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 180;
            this.label1.Text = "接收结束频率:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.Color.Transparent;
            this.label76.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label76.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label76.Location = new System.Drawing.Point(13, 6);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(101, 22);
            this.label76.TabIndex = 179;
            this.label76.Text = "接收起始频率:";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(142, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 29);
            this.button1.TabIndex = 178;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // time_btn_start_b
            // 
            this.time_btn_start_b.BackColor = System.Drawing.Color.White;
            this.time_btn_start_b.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_btn_start_b.Location = new System.Drawing.Point(16, 80);
            this.time_btn_start_b.Name = "time_btn_start_b";
            this.time_btn_start_b.Size = new System.Drawing.Size(72, 29);
            this.time_btn_start_b.TabIndex = 177;
            this.time_btn_start_b.Text = "OK";
            this.time_btn_start_b.UseVisualStyleBackColor = false;
            this.time_btn_start_b.Click += new System.EventHandler(this.time_btn_start_b_Click);
            // 
            // RxRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 125);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label76);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.time_btn_start_b);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RxRange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RxRange";
            this.Load += new System.EventHandler(this.RxRange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button time_btn_start_b;
    }
}