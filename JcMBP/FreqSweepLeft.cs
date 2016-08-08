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

        TestData testdata;
        ClsUpLoad cul;
        //DataSweep ds;
        FreqSweepMid fsm;
        float _rxs;
        float _rxe;
        float set_rxs;
        float set_rxe;
        int count = 1;
        public static string bandname = "";
        public static double st_pow = 43;
        public FreqSweepLeft(ClsUpLoad cul,FreqSweepMid fsm)
        {
            InitializeComponent();
            this.cul = cul;
            this.fsm=fsm;
            if (ClsUpLoad._type == 1)
            {
                time_btn_start_a.Text = "REV";
                time_btn_start_b.Text = "FWD";
            }
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
            testdata = new TestData(ClsUpLoad.qiaoji_times);
            for (int i = 0; i < ClsUpLoad.qiaoji_times; i++)
            {
                st_pow = Convert.ToSingle(freq_nud_pow1.Value);
                testdata.tx1Date[i].fs = Convert.ToSingle(freq_nud_fstart1.Value);
                testdata.tx1Date[i].fe = Convert.ToSingle(freq_nud_fstop1.Value);
                testdata.tx2Date[i].fs = Convert.ToSingle(freq_nud_fstart2.Value);
                testdata.tx2Date[i].fe = Convert.ToSingle(freq_nud_fstop2.Value);
                testdata.tx1Date[i].pow = Convert.ToSingle(freq_nud_pow1.Value);
                testdata.tx2Date[i].pow = Convert.ToSingle(freq_nud_pow2.Value);
                testdata.tx1Date[i].step = Convert.ToSingle(freq_cb_step.Text.Replace('m', ' '));
                testdata.tx2Date[i].step = Convert.ToSingle(freq_cb_step.Text.Replace('m', ' '));
                testdata.tx1Date[i].band = cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)];
                testdata.tx2Date[i].band = cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)];
                testdata.rxDate[i].band = cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)];
                testdata.pimDate[i].order = byte.Parse(freq_cb_im.Text.Substring(2));
                if (freq_check_off1.Checked)
                {
                    testdata.tx1Date[i].off= Convert.ToDouble(freq_nud_off1.Value);
                    testdata.tx2Date[i].off = Convert.ToDouble(freq_nud_off1.Value);
                }
                else
                {
                    testdata.tx1Date[i].off = 0;
                    testdata.tx2Date[i].off = 0;
                }
                 testdata.rxDate[i].currentRxe = set_rxe;
                 testdata.rxDate[i].currentRxs = set_rxs;
                 testdata.rxDate[i].port = port;
                 testdata.tx1Date[i].port = port;
                 testdata.tx2Date[i].port = port;
                testdata.rxDate[i].bandName = freq_cb_band.Text.ToLower();
                testdata.tx1Date[i].bandName = freq_cb_band.Text.ToLower();
                testdata.tx2Date[i].bandName = freq_cb_band.Text.ToLower();
                testdata.pimDate[i].imCo1 = (int.Parse(freq_cb_im.Text.Substring(2)) + 1) / 2;
                testdata.pimDate[i].imCo2 = (int.Parse(freq_cb_im.Text.Substring(2)) - 1) / 2;
                testdata.pimDate[i].imLess = 0;
                testdata.pimDate[i].imLow = 0;
            }

            //OfftenMethod.ToAddColumns(ds.dtm);
            //OfftenMethod.ToAddColumns(ds.dtm_c);
           
            //fsm.Clone(ds);//传递扫描数据类
            Thread th = new Thread(start);
            th.IsBackground = true;
            th.Start();
            fsm.isThreadStart = true;
        }

        /// <summary>
        /// 开始扫频
        /// </summary>
        void start()
        {
            fsm.DataINIT();
            for (int i = 0; i < ClsUpLoad.qiaoji_times; i++)
            {
                if (i >= 1)
                {
                    Message m = new Message();
                    this.Invoke(new ThreadStart(delegate()
                   {                      
                       m.ShowDialog();
                   }));
                    if (m.DialogResult != DialogResult.OK)
                        break;
                   
                }
                Sweep s = new SweepFreq(testdata, ClsUpLoad._type.ToString(), i);
                fsm.Start(s,testdata,i);
                if (FreqSweepMid.jb_err || time_btn_start_a.Enabled) break;
                fsm.isThreadStart = false;
            }
                this.Invoke(new ThreadStart(delegate()
                {
                    fsm.LastINIT();
                    time_btn_start_a.Enabled = true;
                    time_btn_start_a.BackColor = Color.White;
                    time_btn_start_b.Enabled = true;
                    time_btn_start_b.BackColor = Color.White;
                    groupBox1.Enabled = true;
                    time_check_vco.Enabled = true;
                }));
                fsm.isThreadStart = false;
        }


        void SaveFreq()
        { 
        
        }

        /// <summary>
        /// 扫频按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_btn_start_a_Click(object sender, EventArgs e)
        {
            if (!fsm.isThreadStart)
            {
                time_btn_start_a.Enabled = false;
                time_btn_start_a.BackColor = Color.Green;
                time_btn_start_b.Enabled = false;
                groupBox1.Enabled = false;
                time_check_vco.Enabled = false;

                //if (!fsm.isThreadStart)
                Ini(0);
            }
            //else
            //    fsm.Stop();
        }

        private void FreqSweepLeft_Load(object sender, EventArgs e)
        {
            ControlIni();
            //ds = new DataSweep();
           
            FrmMain.CBHandle += new ChangeBand(ChangeBand_handle);
            FrmMain.CVHandle += new ChangeVco_enable(ChangeVco_handle);
            set_rxe = _rxe;
            set_rxs = _rxs;
            button9.Text = set_rxs.ToString("0") + "-" + set_rxe.ToString("0");
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        void ControlIni()
        {
            OfftenMethod.LoadComboBox(freq_cb_band, cul.BandNames,0);
            freq_cb_band.SelectedIndex = 0;
            freq_cb_im.SelectedIndex = 0;
            freq_cb_step.SelectedIndex = 1;
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
                                             (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].TxS, (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].TxE);
            OfftenMethod.NudValue(freq_nud_fstart2, freq_nud_fstop2,
                                     (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].TxS, (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].TxE);
            switch (freq_cb_im.SelectedIndex)
            {
                case 0:
                    freq_nud_fstart1.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_F1UpS);
                    freq_nud_fstart2.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_F2DnS);
                    freq_nud_fstop1.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_F1UpE);
                    freq_nud_fstop2.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_F2DnE);
                    _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_imS;
                    _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_imE;
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
                       _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord5_imS;
                         _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord5_imE;
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
                    _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord7_imS;
                    _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord7_imE;
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
                       _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord9_imS;
                         _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord9_imE;
                    // OfftenMethod.NudValue(freq_nud_fstart1, freq_nud_fstop1,
                    //                         (decimal)cul.ld[freq_cb_band.SelectedIndex].ord9_F1UpS, (decimal)cul.ld[freq_cb_band.SelectedIndex].ord9_F1UpE);
                    //OfftenMethod.NudValue(freq_nud_fstart2, freq_nud_fstop2,
                    //                         (decimal)cul.ld[freq_cb_band.SelectedIndex].ord9_F2DnS, (decimal)cul.ld[freq_cb_band.SelectedIndex].ord9_F2DnE);  
                
                    break;
                case 4: break;
            }
            _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_imS;
            _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(freq_cb_band.Text)]].ord3_imE;
            set_rxe = _rxe;
            set_rxs = _rxs;
            button9.Text = _rxs.ToString("0") + "-" + _rxe.ToString("0") + "MHz";
        }

        private void time_btn_start_b_Click(object sender, EventArgs e)
        {
          
           

            time_btn_start_b.Enabled = false;
            time_btn_start_b.BackColor = Color.Green;
            time_btn_start_a.Enabled = false;
            groupBox1.Enabled = false;
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

            //Thread.Sleep(500);
            //fsm.Stop();
            //this.Invoke(new ThreadStart(delegate()
            //{
            //    time_btn_start_a.Enabled = true;
            //    time_btn_start_a.BackColor = Color.White;
            //    time_btn_start_b.Enabled = true;
            //    time_btn_start_b.BackColor = Color.White;
            //    groupBox1.Enabled = true;
            //}));
            if (fsm.isThreadStart)
            {
                fsm.Stop();

                time_btn_start_a.Enabled = true;
                time_btn_start_a.BackColor = Color.White;
                time_btn_start_b.Enabled = true;
                time_btn_start_b.BackColor = Color.White;
                groupBox1.Enabled = true;
            }
            Thread.Sleep(500);

            //fsm.Stop();
            //time_btn_start_a.Enabled = true;
            //time_btn_start_a.BackColor = Color.White;
            //time_btn_start_b.Enabled = true;
            //time_btn_start_b.BackColor = Color.White;
            //groupBox1.Enabled = true;
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

        private void button9_Click(object sender, EventArgs e)
        {
            RxRange rr = new RxRange(set_rxs, set_rxe, _rxe, _rxs);
            rr.ShowDialog();
            if (rr.DialogResult == DialogResult.OK)
            {
                set_rxs = rr._rxs;
                set_rxe = rr._rxe;
                button9.Text = set_rxs.ToString("0") + "-" + set_rxe.ToString("0");
            }
        }
    }
}
