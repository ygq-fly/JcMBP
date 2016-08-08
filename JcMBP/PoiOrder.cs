using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class PoiOrder : Form
    {
       public  byte imCo1 = 2;
       public  byte imCo2 = 1;
       public  byte imLow = 0;
       public  byte imLess = 0;
       public string val = "";
        public PoiOrder()
        {
            InitializeComponent();
        }
        public PoiOrder(byte imCo1,byte imCo2,byte imLow,byte imLess)
        {
            InitializeComponent();
            this.imCo1 = imCo1;
            this.imCo2 = imCo2;
            
            if (imCo2 == 0 || imCo1 == 0)
                checkBox3.Checked = true; 
            numericUpDown2.Value = (decimal)imCo1;
            numericUpDown1.Value = (decimal)imCo2;           
            if (imLow == 1)
            {
                checkBox1.Checked = true;
                //numericUpDown2.Value = (decimal)imCo2;
                //numericUpDown1.Value = (decimal)imCo1;
            }          
            if (imLess == 1)
                checkBox2.Checked = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                imLow = 1;
                label1.Text = "F2";
                label3.Text = "F1";
            }
            else
            {
                imLow = 0;
                label1.Text = "F1";
                label3.Text = "F2";
            }
            
           label2.Text= OfftenMethod.PimFormula(imCo1, imCo2, imLow, imLess);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                imLess = 1;
            else
                imLess = 0;
          label2.Text=  OfftenMethod.PimFormula(imCo1, imCo2, imLow, imLess);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                numericUpDown2.Value = 2;
                numericUpDown1.Value = 0;
                numericUpDown2.Enabled = false;
                numericUpDown1.Enabled = false;
            }
            else
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            val = label2.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            imCo1 = (byte)numericUpDown2.Value;
            label2.Text = OfftenMethod.PimFormula(imCo1, imCo2, imLow, imLess);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            imCo2 = (byte)numericUpDown1.Value;
            label2.Text = OfftenMethod.PimFormula(imCo1, imCo2, imLow, imLess);
        }
    }
}
