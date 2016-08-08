using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class SleepTime : Form
    {
        public SleepTime(decimal times)
        {

            InitializeComponent();
            numericUpDown1.Value = times;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void SleepTime_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = ClsUpLoad._sleepTime;
        }

        private void numericUpDown1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClsUpLoad._sleepTime = numericUpDown1.Value;
            IniFile.SetFileName(Application.StartupPath + "\\JcConfig.ini");
            IniFile.SetString("Settings", "poi_sleep_time", numericUpDown1.Value.ToString());
            this.DialogResult = DialogResult.OK;
        }
    }
}
