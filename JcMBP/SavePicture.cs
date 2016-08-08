using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class Save : Form
    {
        public string pictureName = "";
        public Save()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            pictureName = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void SavePicture_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        }
    }
}
