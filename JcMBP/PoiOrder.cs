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
       public bool poi_order = true; 
        public PoiOrder()
        {
            InitializeComponent();
        }
        public PoiOrder(byte imCo1,byte imCo2,byte imLow,byte imLess,bool orderMode)
        {
            InitializeComponent();
            this.imCo1 = imCo1;
            this.imCo2 = imCo2;
            this.imLow = imLow;
            this.imLess = imLess;
            this.poi_order = orderMode;
            if (orderMode)
            radioButton2.Checked = true;
            else
            radioButton1.Checked = true;
            //if (imCo2 == 0 || imCo1 == 0)
            //    checkBox3.Checked = true; 
            //numericUpDown2.Value = (decimal)imCo1;
            //numericUpDown1.Value = (decimal)imCo2;           
            //if (imLow == 1)
            //{
            //    checkBox1.Checked = true;
            //    //numericUpDown2.Value = (decimal)imCo2;
            //    //numericUpDown1.Value = (decimal)imCo1;
            //}          
            //if (imLess == 1)
            //    checkBox2.Checked = true;
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
            poi_order = radioButton2.Checked;
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                poi_order = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                if (imCo2 == 0 || imCo1 == 0)
                    checkBox3.Checked = true;
                numericUpDown2.Value = (decimal)imCo1;
                numericUpDown1.Value = (decimal)imCo2;
                if (imLow == 1)
                    checkBox1.Checked = true;
                else checkBox1.Checked = false;

                if (imLess == 1)
                    checkBox2.Checked = true;
                else checkBox2.Checked = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                poi_order = false;
                imLow = 0;
                imLess = 0;
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                int order=(int)(imCo1+imCo2);
                switch (order)
                { 
                    case 3:
                        comboBox1.SelectedIndex = 0;
                        break;
                    case 5:
                        comboBox1.SelectedIndex = 1;
                        break;
                    case 7:
                        comboBox1.SelectedIndex = 2;
                        break;
                    case 9:
                        comboBox1.SelectedIndex = 3;
                        break;
                    default:
                        comboBox1.SelectedIndex = 0;
                        break;
                }

                int m = comboBox1.SelectedIndex;
                switch (m)
                {
                    case 0:
                        imCo1 = 2;
                        imCo2 = 1;
                        break;
                    case 1:
                        imCo1 = 3;
                        imCo2 = 2;
                        break;
                    case 2:
                        imCo1 = 4;
                        imCo2 = 3;
                        break;
                    case 3:
                        imCo1 = 5;
                        imCo2 = 4;
                        break;
                    default:
                        imCo1 = 2;
                        imCo2 = 1;
                        break;
                }
                label2.Text = imCo1.ToString() + "F1 - " + imCo2.ToString() + "F2";

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int m = comboBox1.SelectedIndex;
            switch (m)
            {
                case 0:
                    imCo1 = 2;
                    imCo2 = 1;
                    break;
                case 1:
                    imCo1 = 3;
                    imCo2 = 2;
                    break;
                case 2:
                    imCo1 = 4;
                    imCo2 = 3;
                    break;
                case 3:
                    imCo1 = 5;
                    imCo2 = 4;
                    break;
                default:
                    imCo1 = 2;
                    imCo2 = 1;
                    break;
            }
            label2.Text = imCo1.ToString() + "F1 - " + imCo2.ToString() + "F2";

        }
    }
}
