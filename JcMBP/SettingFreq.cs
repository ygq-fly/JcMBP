using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class SettingFreq : Form
    {
        public SettingFreq()
        {
            InitializeComponent();
        }

        public double f1 = 0;
        public double f2 = 0;
        int mode;
        public  SettingFreq(double  f1, double  f2,int mode)
        {
            InitializeComponent();
            this.f1 = f1;
            this.f2 = f2;
            this.mode = mode;
            numericUpDown1.Value = Convert.ToDecimal(f2);
            time_nud_f1.Value = Convert.ToDecimal(f1);
            if (mode == 1)
            {
                numericUpDown1.Enabled = false;
            }
        }
        public SettingFreq(double f1, double f2,float max,float min)
        {
            InitializeComponent();
            this.f1 = f1;
            this.f2 = f2;
            numericUpDown1.Value = Convert.ToDecimal(f2);
            time_nud_f1.Value = Convert.ToDecimal(f1);
            numericUpDown1.Maximum =Convert.ToDecimal(max);
            numericUpDown1.Minimum = Convert.ToDecimal(min);
            time_nud_f1.Maximum = Convert.ToDecimal(max);
            time_nud_f1.Minimum = Convert.ToDecimal(min);
        }

        private void ConfigFreq_Load(object sender, EventArgs e)
        {
            time_nud_f1.Value = (decimal)f1;
            numericUpDown1.Value = (decimal)f2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1 = Convert.ToDouble(time_nud_f1.Value);
            f2 = Convert.ToDouble(numericUpDown1.Value);
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void time_nud_f1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void numericUpDown1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void time_nud_f1_ValueChanged(object sender, EventArgs e)
        {
            if (mode == 1)
                numericUpDown1.Value = time_nud_f1.Value;
        }
    }
}
