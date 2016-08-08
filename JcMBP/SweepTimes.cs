using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class SweepTimes : Form
    {
        public SweepTimes()
        {
            InitializeComponent();
            numericUpDown1.Value = ClsUpLoad.qiaoji_times;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            ClsUpLoad.qiaoji_times = Convert.ToInt32(numericUpDown1.Value);
            IniFile.SetFileName(Application.StartupPath + "\\JcConfig.ini");
            IniFile.SetString("Settings", "qiaoji_times", numericUpDown1.Value.ToString());
            this.DialogResult = DialogResult.OK;
        }

        private void numericUpDown1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
          
        }
    }
}
