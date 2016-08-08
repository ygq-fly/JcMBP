using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }
        public  string newpass = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("请输入完整!");
                return;
            }
            if (OfftenMethod.Mid5Lock(textBox1.Text.Trim()) == ClsUpLoad.offset_pass)
            {
              
                if (textBox3.Text != textBox2.Text)
                {
                    MessageBox.Show("密码输入不一致,请重新输入");
                    return;
                }
                else
                {
                    newpass = OfftenMethod.Mid5Lock(textBox2.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                }

            }
            else
            {
                MessageBox.Show("密码错误，请重新输入");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
