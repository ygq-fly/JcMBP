using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class DebugPoi : Form
    {
        ClsUpLoad cul;
         public DebugPoi(ClsUpLoad cul)
        {
            InitializeComponent();
            this.cul = cul;
        }

        private void btn_vco_Click(object sender, EventArgs e)
        {
            try
            {
                double vco = 0;
                int a = comboBox1.SelectedIndex;
                bool isVco = ClsJcPimDll.JcGetVcoDsp(ref vco, (byte)a);
                tb_log.AppendText("VCO Status: " + isVco.ToString() + " / " + vco.ToString("0.00") + "\r\n");
            }
            catch { }
        }

        private void btn_sen_Click(object sender, EventArgs e)
        {
            double val = 0;
            val = ClsJcPimDll.JcGetSen();

            tb_log.AppendText(val.ToString() + "\r\n");
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

        private void btn_sig_on_Click(object sender, EventArgs e)
        {
            ClsJcPimDll.fnSetTxOn(true, ClsJcPimDll.JC_CARRIER_TX1);
        }

        private void btn_sig_off_Click(object sender, EventArgs e)
        {
            ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1);
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

        private void btn_sig2_on_Click(object sender, EventArgs e)
        {
            ClsJcPimDll.fnSetTxOn(true, ClsJcPimDll.JC_CARRIER_TX2);
        }

        private void btn_sig2_off_Click(object sender, EventArgs e)
        {
            ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int t1 = this.comboBox1.SelectedIndex;
            int t2=this.comboBox2.SelectedIndex;
            int rx = comboBox3.SelectedIndex;
            int b = this.comboBox4.SelectedIndex;
            if (t1 < 0 || t2<0||rx<0||b < 0) return;
            //设置开关
            if (ClsJcPimDll.JcSetSwitch(t1, t2, rx, b))
            {
                tb_log.AppendText("switch: " + " tx1:" + t1.ToString() + " tx2:" + t2.ToString() + " rx:" + rx.ToString() + " succ\r\n");
            }
            else
            {
                byte[] bError = new byte[512];
                ClsJcPimDll.JcGetError(bError, 512);
                tb_log.AppendText(Encoding.ASCII.GetString(bError) + "\r\n");
            }
        }

        void IniBand()
        {
          
        }

        private void DebugPoi_Load(object sender, EventArgs e)
        {
            IniBand();
            comboBox1.SelectedIndex  =0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str_ = "";
            if (MessageBox.Show("确认是否 改变数据库！修改值: " + numericUpDown1.Value.ToString(), "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            if (comboBox8.SelectedIndex == 0)
            {
                if (ClsJcPimDll.JcSetOffsetTxIncremental((byte)comboBox6.SelectedIndex, (byte)(comboBox7.SelectedIndex), (byte)(comboBox5.SelectedIndex), 0, Convert.ToDouble(numericUpDown1.Value)) < -1000)
                {
                    str_ += " set orr\r\n";
                    MessageBox.Show("set err");

                }
                if (ClsJcPimDll.JcSetOffsetTxIncremental((byte)comboBox6.SelectedIndex, (byte)(comboBox7.SelectedIndex), (byte)(comboBox5.SelectedIndex), 1, Convert.ToDouble(numericUpDown1.Value)*(-1)) < -1000)
                {
                    str_ += " set orr\r\n";
                    MessageBox.Show("set err");
                }
            }
            else
            {
                if (ClsJcPimDll.JcSetOffsetTxIncremental((byte)comboBox6.SelectedIndex, (byte)(comboBox7.SelectedIndex), (byte)(comboBox5.SelectedIndex), 1, Convert.ToDouble(numericUpDown1.Value)) < -1000)
                {
                    str_ += " set orr\r\n";
                    MessageBox.Show("set err");
                }
            }
            str_ += comboBox6.SelectedItem.ToString() + "  " + comboBox5.SelectedItem.ToString() + "  " + comboBox7.SelectedItem.ToString() + "  " + comboBox8.SelectedItem.ToString() + "  SetOffset:" + numericUpDown1.Value.ToString() + "\r\n";
            tb_log.AppendText(str_);
        }

        private void DebugPoi_Load_1(object sender, EventArgs e)
        {
            OfftenMethod.LoadComboBox(comboBox1, cul.BandNames);
            OfftenMethod.LoadComboBox(comboBox2, cul.BandNames);
            OfftenMethod.LoadComboBox(comboBox3, cul.BandNames);
            OfftenMethod.LoadComboBox(comboBox6, cul.BandNames);

            comboBox6.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 8 || comboBox1.SelectedIndex == 11)
            {
                MessageBox.Show("poi模式当前频段无tx1");
                comboBox1.SelectedIndex = 0;
                return;
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 10)
            {
                MessageBox.Show("poi模式当前频段无tx2");
                comboBox2.SelectedIndex = 0;
                return;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 8 || comboBox3.SelectedIndex == 11)
            {
                MessageBox.Show("poi模式当前频段无rx");
                comboBox3.SelectedIndex = 0;
                return;
            }
        }
    }
}
