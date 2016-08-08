using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class FileName : Form
    {
        public FileName()
        {
            InitializeComponent();
        }

        public string fileName = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            fileName = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void FileName_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
