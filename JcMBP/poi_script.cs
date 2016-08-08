using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class poi_script : Form
    {
        public poi_script()
        {
            InitializeComponent();
        }
        public poi_script(string s)
        {
            InitializeComponent();
            textBox1.Text = s;
        }
        public  string path_test = "";
        bool istrue = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                path_test = textBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\Jcoffset";
            openFileDialog1.Filter = "*.jointcom|*.jointcom";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                path_test = openFileDialog1.FileName;               
                istrue = true;
            }
        }

        private void poi_script_Load(object sender, EventArgs e)
        {

        }
    }
}
