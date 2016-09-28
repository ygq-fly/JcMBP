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
    public partial class FreqSweepLeft : Form
    {
        ClsUpLoad cul;
        DataSweep ds;
        FreqSweepMid fsm;
        double _rxs;
        double _rxe;
        int count = 1;
        public static string bandname = "";
        public FreqSweepLeft(ClsUpLoad cul,FreqSweepMid fsm)
        {
            InitializeComponent();
            this.cul = cul;
            this.fsm=fsm;
        }


        public void Cband(int tx1, int tx2, int rx)
        {
            freq_cb_band.SelectedIndex = rx;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="port"></param>
        void Ini(byte port)
        {
            ds.freq1s = Convert.ToDouble(freq_nud_fstart1.Value);
            ds.freq1e = Convert.ToDouble(freq_nud_fstop1.Value);
            ds.freq2s = Convert.ToDouble(freq_nud_fstart2.Value);
            ds.freq2e = Convert.ToDouble(freq_nud_fstop2.Value);
            ds.pow1 = Convert.ToSingle(freq_nud_pow1.Value);
            ds.pow2 = Convert.ToSingle(freq_nud_pow2.Value);
            ds.step1 = ds.step2 = Convert.ToSingle(freq_cb_step.Text.Replace('m', ' '));
            //ds.tx1 = ds.tx2 = ds.rx = (byte)(cul.d_BandNum[freq_cb_band.Text]);
            ds.tx1 = ds.tx2 = ds.rx = (byte)(cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]);
            ds.order = byte.Parse(freq_cb_im.Text.Substring(2));
            ds.imCo1 = (byte)(Convert.ToInt32(ds.order) / 2 + 1);
            ds.imCo2 = (byte)(Convert.ToInt32(ds.imCo1) - 1);
            if (freq_check_off1.Checked)
                ds.rx_off= ds.off1 = ds.off2 =ds.freq_off2= ds.freq_off1 = Convert.ToDouble(freq_nud_off1.Value);
            else
                ds.rx_off= ds.off1 = ds.off2 = ds.freq_off1 = ds.freq_off2 = 0;
            ds.MaxRx = _rxe;
            ds.MinRx = _rxs;
            ds.port = port;
            bandname = freq_cb_band.Text.ToLower();
            //count = Convert.ToInt32(numericUpDown1.Value);
            OfftenMethod.ToAddColumns(ds.dtm);
            OfftenMethod.ToAddColumns(ds.dtm_c);
           
            fsm.Clone(ds);//传递扫描数据类
            Thread th = new Thread(start);
            th.IsBackground = true;
            th.Start();
        }

        /// <summary>
        /// 开始扫频
        /// </summary>
        void start()
        {
            Sweep s = new SweepFreq(ds, ClsUpLoad._type.ToString());
            for (int i = 0; i < FrmMain.count; i++)
            {
              
                fsm.Start(s);
                if (i >= 1)
                {
                    MessageBox.Show("请敲击");
                }
            }
            this.Invoke(new ThreadStart(delegate()
            {
                time_btn_start_a.Enabled = true;
                time_btn_start_a.BackColor = Color.White;
                time_btn_start_b.Enabled = true;
                time_btn_start_b.BackColor = Color.White;
                groupBox1.Enabled = true;
                time_check_vco.Enabled = true;
              
            }));
        }

        /// <summary>
        /// 扫频按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        
        private void time_btn_start_a_Click(object sender, EventArgs e)
        {
           
            time_btn_start_a.Enabled = false;
            time_btn_start_a.BackColor = Color.Green;
            time_btn_start_b.Enabled = false;
            groupBox1.Enabled = false;
            time_check_vco.Enabled = false;
            //if (!fsm.isThreadStart)
                Ini(0);
            
            //else
            //    fsm.Stop();
        }

        private void FreqSweepLeft_Load(object sender, EventArgs e)
        {
            ControlIni();
            ds = new DataSweep();
            FrmMain.CBHandle += new ChangeBand(ChangeBand_handle);
            FrmMain.CVHandle += new ChangeVco_enable(ChangeVco_handle);
        
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        void ControlIni()
        {
            OfftenMethod.LoadComboBox(freq_cb_band, cul.BandNames,0);
            freq_cb_band.SelectedIndex = 0;
            freq_cb_im.SelectedIndex = 0;
            //freq_cb_step.SelectedIndex = 1;
        }

        /// <summary>
        /// 根据阶数改变数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void freq_cb_im_SelectedIndexChanged(object sender, EventArgs e)
        {
            FrmMain.Band = freq_cb_band.SelectedIndex;
            OfftenMethod.NudValue(freq_nud_fstart1, freq_nud_fstop1,
                                             (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].F1Min, (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].F1Max);
            OfftenMethod.NudValue(freq_nud_fstart2, freq_nud_fstop2,
                                     (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].F2Min, (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].F2Max);
            switch (freq_cb_im.SelectedIndex)
            {
                case 0:
                    freq_nud_fstart1.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_F1UpS);
                    freq_nud_fstart2.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_F2DnS);
                    freq_nud_fstop1.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_F1UpE);
                    freq_nud_fstop2.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_F2DnE);
                    //OfftenMethod.NudValue(freq_nud_fstart1, freq_nud_fstop1,
                    //                         (decimal)cul.ld[freq_cb_band.SelectedIndex].ord3_F1UpS, (decimal)cul.ld[freq_cb_band.SelectedIndex].ord3_F1UpE);
                    //OfftenMethod.NudValue(freq_nud_fstart2, freq_nud_fstop2,
                    //                         (decimal)cul.ld[freq_cb_band.SelectedIndex].ord3_F2DnS, (decimal)cul.ld[freq_cb_band.SelectedIndex].ord3_F2DnE);
                   
                    break;
                case 1:
                    freq_nud_fstart1.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord5_F1UpS);
                    freq_nud_fstart2.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord5_F2DnS);
                    freq_nud_fstop1.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord5_F1UpE);
                    freq_nud_fstop2.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord5_F2DnE);
                    // OfftenMethod.NudValue(freq_nud_fstart1, freq_nud_fstop1,
                    //                         (decimal)cul.ld[freq_cb_band.SelectedIndex].ord5_F1UpS, (decimal)cul.ld[freq_cb_band.SelectedIndex].ord5_F1UpE);
                    //OfftenMethod.NudValue(freq_nud_fstart2, freq_nud_fstop2,
                    //                         (decimal)cul.ld[freq_cb_band.SelectedIndex].ord5_F2DnS, (decimal)cul.ld[freq_cb_band.SelectedIndex].ord5_F2DnE);      
                    
                    break;
                case 2:
                    freq_nud_fstart1.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord7_F1UpS);
                    freq_nud_fstart2.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord7_F2DnS);
                    freq_nud_fstop1.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord7_F1UpE);
                    freq_nud_fstop2.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord7_F2DnE);
                    // OfftenMethod.NudValue(freq_nud_fstart1, freq_nud_fstop1,
                    //                         (decimal)cul.ld[freq_cb_band.SelectedIndex].ord7_F1UpS, (decimal)cul.ld[freq_cb_band.SelectedIndex].ord7_F1UpE);
                    //OfftenMethod.NudValue(freq_nud_fstart2, freq_nud_fstop2,
                    //                         (decimal)cul.ld[freq_cb_band.SelectedIndex].ord7_F2DnS, (decimal)cul.ld[freq_cb_band.SelectedIndex].ord7_F2DnE);     
                  
                    break;
                case 3:
                    freq_nud_fstart1.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord9_F1UpS);
                    freq_nud_fstart2.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord9_F2DnS);
                    freq_nud_fstop1.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord9_F1UpE);
                    freq_nud_fstop2.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord9_F2DnE);
                    // OfftenMethod.NudValue(freq_nud_fstart1, freq_nud_fstop1,
                    //                         (decimal)cul.ld[freq_cb_band.SelectedIndex].ord9_F1UpS, (decimal)cul.ld[freq_cb_band.SelectedIndex].ord9_F1UpE);
                    //OfftenMethod.NudValue(freq_nud_fstart2, freq_nud_fstop2,
                    //                         (decimal)cul.ld[freq_cb_band.SelectedIndex].ord9_F2DnS, (decimal)cul.ld[freq_cb_band.SelectedIndex].ord9_F2DnE);  
                
                    break;
                case 4: break;
            }
            _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_imS;
            _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_imE;

            switch ((int)cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_F1Step)
            { 
                case 1:
                    freq_cb_step.SelectedIndex = 0;
                    break;
                case 2:
                    freq_cb_step.SelectedIndex = 1;
                    break;
                case 3:
                    freq_cb_step.SelectedIndex = 2;
                    break;
                case 5:
                    freq_cb_step.SelectedIndex = 3;
                     break;
                case 10:
                    freq_cb_step.SelectedIndex = 4;
                    break;
                default :
                    freq_cb_step.SelectedIndex = 0;
                    break;
                
            }
        
        }

        private void time_btn_start_b_Click(object sender, EventArgs e)
        {

            time_btn_start_b.Enabled = false;
            time_btn_start_b.BackColor = Color.Green;
            time_btn_start_a.Enabled = false;
            groupBox1.Enabled = false;
            time_check_vco.Enabled = false;
            //if (!fsm.isThreadStart)
                Ini(1);
            //else
            //    fsm.Stop();
        }

        #region Numericupdown控件事件
        private void freq_nud_fstart1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void freq_nud_fstop1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void freq_nud_pow1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void freq_nud_fstart2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void freq_nud_fstop2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void freq_nud_pow2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void freq_nud_off1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        #endregion

        private void time_btn_stop_Click(object sender, EventArgs e)
        {
            fsm.Stop();
           
        }

        void ChangeBand_handle()
        {
            freq_cb_band.SelectedIndex = FrmMain.Band;
        }
        void ChangeVco_handle()
        {
            time_check_vco.Checked = FrmMain.Vco;
        }

      

        private void time_check_vco_CheckedChanged(object sender, EventArgs e)
        {
            if (time_check_vco.Checked)
                ClsUpLoad._vco = true;
            else
                ClsUpLoad._vco = false;
            FrmMain.Vco = time_check_vco.Checked;
        }

        private void FreqSweepLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                time_btn_start_a_Click(null,null);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
