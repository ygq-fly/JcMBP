using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class OffsetPass : Form
    {
        public OffsetPass()
        {
            InitializeComponent();
            
        }
        string pass = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入密码");
                return;
            }
            pass = OfftenMethod.Mid5Lock(textBox1.Text.Trim());
            if (pass == ClsUpLoad.offset_pass)
                this.DialogResult = DialogResult.OK;
            else MessageBox.Show("密码错误,请重新输入！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePass cp = new ChangePass();
            cp.ShowDialog();
            if (cp.DialogResult == DialogResult.OK)
            {
                IniFile.SetString("Settings", "offsetpassword", cp.newpass, Application.StartupPath + "\\JcConfig.ini");
                ClsUpLoad.offset_pass = cp.newpass;
            }
        }
    }
}
