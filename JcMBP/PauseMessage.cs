using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class PauseMessage : Form
    {
        public string message = "";
        public PauseMessage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            message=textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
