using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class SaveMess : Form
    {
       public  List<string> val=new List<string>();
        public SaveMess()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty) val.Add("[Enter Instrument]");
            else val.Add(textBox1.Text);

            if (textBox2.Text == string.Empty) val.Add("[Enter Test Description]");
            else val.Add(textBox2.Text);

            if (textBox3.Text == string.Empty) val.Add("[Enter Model Number]");
            else val.Add(textBox3.Text);

            if (textBox4.Text == string.Empty) val.Add("[Enter Operator]");
            else val.Add(textBox4.Text);

            if (textBox5.Text == string.Empty) val.Add("[Enter Description]");
            else val.Add(textBox5.Text);

            this.DialogResult = DialogResult.OK;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
