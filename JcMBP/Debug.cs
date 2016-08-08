using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class Debug : Form
    {
        ClsUpLoad cul;
        public Debug(ClsUpLoad cul)
        {
            InitializeComponent();
            this.cul=cul;
            OfftenMethod.LoadComboBox_d(cb_switchband, cul.AllBandNames);
            OfftenMethod.LoadComboBox_d(comboBox1, cul.BandNames);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        private void btn_sen_Click(object sender, EventArgs e)
        {
            double val = 0;
            val = ClsJcPimDll.JcGetSen();
            tb_log.AppendText(val.ToString() + "\r\n");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ClsJcPimDll.Callback_Get_RX_Offset_Point mycallback = new ClsJcPimDll.Callback_Get_RX_Offset_Point(mycb);
            ClsJcPimDll.testcb(mycallback);
        }

        void mycb(double a, double b)
        {
            this.Invoke(new ThreadStart(delegate()
            {
                tb_log.AppendText("get: " + a.ToString() + " , " + b.ToString() + "\r\n");
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int a = this.cb_switchband.SelectedIndex;
            int b = this.cb_coup.SelectedIndex;
            //string st = cb_switchband.Text.Substring(0, cb_switchband.Text.Length - 2);
            //int count = cul.BandNames.IndexOf(st);
            //a = cul.BandCount[count]*2;
            //if(cb_switchband.Text.Contains("_2"))
            //    a++;
           
            if (a < 0 || b < 0) return;
            //设置开关
            if(ClsJcPimDll.JcSetSwitch(a, a, a, b))
            {
                tb_log.AppendText("switch: "+a.ToString() + " succ\r\n");
            }
            else
            {
                byte[] bError = new byte[512];
                ClsJcPimDll.JcGetError(bError, 512);
                tb_log.AppendText(Encoding.ASCII.GetString(bError) + "\r\n");
            }
        }

        private void btn_ana_Click(object sender, EventArgs e)
        {
            double freq_mhz = 930;
            try
            {
                freq_mhz = double.Parse(tb_ana_freq.Text);
            }
            catch { return; }

            ClsJcPimDll.JcSetAna_RefLevelOffset(0);
            double val = ClsJcPimDll.JcGetAna(freq_mhz * 1000, false);
            tb_log.AppendText("Analyzer: " + val.ToString() + "\r\n");

        }

        private void btn_sig1_Click(object sender, EventArgs e)
        {
            double f1_mhz, p1;
            try
            {
                f1_mhz = double.Parse(tb_f1.Text);
                p1 = double.Parse(tb_p1.Text);
            }
            catch { return; }

            ClsJcPimDll.JcSetSig(ClsJcPimDll.JC_CARRIER_TX1, f1_mhz * 1000, p1);
            tb_log.AppendText("Set Sig1 freq: " + f1_mhz.ToString() + "\r\n");
            tb_log.AppendText("Set Sig1 pow: " + p1.ToString() + "\r\n");
        }

        private void btn_sig2_Click(object sender, EventArgs e)
        {
            double f2_mhz, p2;
            try
            {
                f2_mhz = double.Parse(tb_f2.Text);
                p2 = double.Parse(tb_p2.Text);
            }
            catch { return; }

            ClsJcPimDll.JcSetSig(ClsJcPimDll.JC_CARRIER_TX2, f2_mhz * 1000, p2);

            tb_log.AppendText("Set Sig2 freq: " + f2_mhz.ToString() + "\r\n");
            tb_log.AppendText("Set Sig2 pow: " + p2.ToString() + "\r\n");
        }

        private void btn_vco_Click(object sender, EventArgs e)
        {
            try
            {
                double vco = 0;
                int a = cb_switchband.SelectedIndex;
                bool isVco = ClsJcPimDll.JcGetVcoDsp(ref vco, (byte)a);
                tb_log.AppendText("VCO Status: " + isVco.ToString() + " / " + vco.ToString("0.00") + "\r\n");
            }
            catch { }
        }

        private void btn_sig_on_Click(object sender, EventArgs e)
        {
            ClsJcPimDll.fnSetTxOn(true, ClsJcPimDll.JC_CARRIER_TX1);
        }

        private void btn_sig_off_Click(object sender, EventArgs e)
        {
            ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1);
        }

        private void btn_sig2_on_Click(object sender, EventArgs e)
        {
            ClsJcPimDll.fnSetTxOn(true, ClsJcPimDll.JC_CARRIER_TX2);
        }

        private void btn_sig2_off_Click(object sender, EventArgs e)
        {
            ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX2);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        private void button1_Click_3(object sender, EventArgs e)
        {
            string str_ = "";
            if (MessageBox.Show("确认是否 改变数据库！修改值: " + numericUpDown1.Value.ToString(), "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            if (comboBox4.SelectedIndex == 0)
            {
                if (ClsJcPimDll.JcSetOffsetTxIncremental((byte)comboBox1.SelectedIndex, (byte)(comboBox3.SelectedIndex), (byte)(comboBox2.SelectedIndex), 0, Convert.ToDouble(numericUpDown1.Value)) <= -10000)
                {
                    str_ += " set orr\r\n";
                    MessageBox.Show("set err");
                }
                if (ClsJcPimDll.JcSetOffsetTxIncremental((byte)comboBox1.SelectedIndex, (byte)(comboBox3.SelectedIndex), (byte)(comboBox2.SelectedIndex), 1, Convert.ToDouble(numericUpDown1.Value) * (-1)) <= -10000)
                {
                    str_ += "set orr\r\n";
                    MessageBox.Show("set err");
                }
            }
            else
            {
                if (ClsJcPimDll.JcSetOffsetTxIncremental((byte)comboBox1.SelectedIndex, (byte)(comboBox3.SelectedIndex), (byte)(comboBox2.SelectedIndex), 1, Convert.ToDouble(numericUpDown1.Value)) <= -10000)
                {
                    str_ += "set orr\r\n";
                    MessageBox.Show("set err");
                }
            }
            
             str_=comboBox1.SelectedItem.ToString()+"  "+comboBox2.SelectedItem.ToString()+"  "+comboBox3.SelectedItem.ToString()+"  "+comboBox4.SelectedItem.ToString()+"  SetOffset:"+numericUpDown1.Value.ToString()+"\r\n";
            tb_log.AppendText(str_);
            //FrmMain.test_setoff += str_;
        }

        private void cb_switchband_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
