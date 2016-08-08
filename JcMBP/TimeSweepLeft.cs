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
    public partial class TimeSweepLeft : Form
    {
        //DataSweep ds;
        TestData testdata;
        TimeSweepMid tsm;
        ClsUpLoad cul;
        int time = 1;
        float _rxs = 0;
        float _rxe = 0;
        float set_rxs = 0;
        float set_rxe = 0;
        public static double st_pow = 43;
        public TimeSweepLeft(ClsUpLoad cul,TimeSweepMid tsm)
        {
            InitializeComponent();
            this.cul = cul;
            this.tsm = tsm;
            if (ClsUpLoad._type == 1)
            {
                time_btn_start_a.Text = "REV";
                time_btn_start_b.Text = "FWD";
            }
        }
        public void Cband(int tx1, int tx2, int rx)
        {
            time_cb_band.SelectedIndex = rx;
        }

        void Ini(byte port)
        {

            testdata = new TestData(ClsUpLoad.qiaoji_times);
            for (int i = 0; i < ClsUpLoad.qiaoji_times; i++)
            {
                st_pow = Convert.ToSingle(time_nud_p1.Value);
                testdata.tx1Date[i].fs = Convert.ToSingle(time_nud_f1.Value);
                testdata.tx1Date[i].fe = Convert.ToSingle(time_nud_f1.Value);
                testdata.tx2Date[i].fs = Convert.ToSingle(time_nud_f2.Value);
                testdata.tx2Date[i].fe = Convert.ToSingle(time_nud_f2.Value);
                testdata.tx1Date[i].pow = Convert.ToSingle(time_nud_p1.Value);
                testdata.tx2Date[i].pow = Convert.ToSingle(time_nud_p2.Value);
                testdata.tx1Date[i].sweeptime = Convert.ToInt32(numericUpDown1.Value);
                testdata.tx2Date[i].sweeptime = Convert.ToInt32(numericUpDown1.Value);
                testdata.tx1Date[i].band = cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)];
                testdata.tx2Date[i].band = cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)];
                testdata.rxDate[i].band = cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)];
                testdata.pimDate[i].order = byte.Parse(time_cb_im.Text.Substring(2));
                if (time_check_off1.Checked)
                {
                    testdata.tx1Date[i].off = Convert.ToDouble(time_nud_off1.Value);
                    testdata.tx2Date[i].off = Convert.ToDouble(time_nud_off1.Value);
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
                testdata.rxDate[i].bandName = time_cb_band.Text.ToLower();
                testdata.tx1Date[i].bandName = time_cb_band.Text.ToLower();
                testdata.tx2Date[i].bandName = time_cb_band.Text.ToLower();
                testdata.pimDate[i].imCo1 = (int.Parse(time_cb_im.Text.Substring(2)) + 1) / 2;
                testdata.pimDate[i].imCo2 = (int.Parse(time_cb_im.Text.Substring(2)) - 1) / 2;
                testdata.pimDate[i].imLess = 0;
                testdata.pimDate[i].imLow = 0;
              
            }
            Thread th = new Thread(start);
            th.IsBackground = true;
            th.Start();

            //tsm.isThreadStart = true;
        }

        void start()
        {
            tsm.DataINIT();
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
                Sweep s = new SweepTime(testdata, ClsUpLoad._type.ToString(), i);
                tsm.Start(s, testdata, i);
                if (TimeSweepMid.jb_err||time_btn_start_a.Enabled)
                    break;
                
            }
            this.Invoke(new ThreadStart(delegate()
            {
                tsm.LastINIT();
                time_btn_start_a.Enabled = true;
                time_btn_start_a.BackColor = Color.White;
                time_btn_start_b.Enabled = true;
                time_btn_start_b.BackColor = Color.White;
                groupBox14.Enabled = true;
                time_check_vco.Enabled = true;
            }));
            tsm.isThreadStart = false;
            
        }

        void SaveFreq()
        {
            //IniFile.SetFileName(Application.StartupPath + "\\Band\\band" + cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)].ToString() + "_Specifics.ini");
            //IniFile.SetString("Specifics", "rx_band", val.ToString());//保存offset
            //cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord3_F1UpS=Convert.ToSingle(time_nud_f1.Value);
            //cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord3_F2DnE = Convert.ToSingle(time_nud_f2.Value);
        }
        private void  time_btn_start_a_Click(object sender, EventArgs e)
        {
            //if (!tsm.isThreadStart)
            //{
            try
            {
                time_btn_start_a.Enabled = false;
                time_btn_start_a.BackColor = Color.Green;
                time_btn_start_b.Enabled = false;
                groupBox14.Enabled = false;
                time_check_vco.Enabled = false;
                //SaveFreq();
                Ini(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //}
            //else
            //{
            //    tsm.Stop();
            //}
        }

        private void TimeSweepLeft_Load(object sender, EventArgs e)
        {
            OfftenMethod.LoadComboBox(time_cb_band, cul.BandNames,0);
            //ds = new DataSweep();
           FrmMain.CBHandle += new ChangeBand(ChangeBand_handle);
           FrmMain.CVHandle += new ChangeVco_enable(ChangeVco_handle);
            time_cb_band.SelectedIndex = 0;
            time_cb_im.SelectedIndex = 0;
            numericUpDown1.Value = ClsUpLoad.sweep_index;
            set_rxe = _rxe;
            set_rxs = _rxs;
            button9.Text = set_rxs.ToString("0") + "-" + set_rxe.ToString("0");
        }

        private void time_cb_im_SelectedIndexChanged(object sender, EventArgs e)
        {
            FrmMain.Band = time_cb_band.SelectedIndex;
            OfftenMethod.NudValue(time_nud_f1, time_nud_f2,
                   (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].TxS, (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].TxE);               
            switch (time_cb_im.SelectedIndex)
            {
                case 0:
                    time_nud_f1.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord3_F1UpS);
                    time_nud_f2.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord3_F2DnE);
                    _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord3_imS;
                    _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord3_imE;

                    //OfftenMethod.NudValue(time_nud_f1, time_nud_f2,
                    // (decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F1UpS, (decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F2DnE);               
                    break;
                case 1:
                    time_nud_f1.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord5_F1UpS);
                    time_nud_f2.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord5_F2DnE);
                     _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord5_imS;
                    _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord5_imE;
                    //OfftenMethod.NudValue(time_nud_f1, time_nud_f2,
                    //(decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F1UpS, (decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F2DnE);
                    break;
                case 2:
                    time_nud_f1.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord7_F1UpS);
                    time_nud_f2.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord7_F2DnE);
                     _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord7_imS;
                    _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord7_imE;
                    //OfftenMethod.NudValue(time_nud_f1, time_nud_f2,
                    //(decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F1UpS, (decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F2DnE);
                    break;
                case 3:
                    time_nud_f1.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord9_F1UpS);
                    time_nud_f2.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord9_F2DnE);
                     _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord9_imS;
                    _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord9_imE;
                    //OfftenMethod.NudValue(time_nud_f1, time_nud_f2,
                    //(decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F1UpS, (decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F2DnE);
                    break;
                case 4: break;
            }
            set_rxe = _rxe;
            set_rxs = _rxs;
            button9.Text = _rxs.ToString("0") + "-" + _rxe.ToString("0") + "MHz";
        }

        private void time_btn_stop_Click(object sender, EventArgs e)
        {
            //if (tsm.isThreadStart)
            //{
            //    tsm.Stop();
            //}
            try
            {
                Thread.Sleep(500);
                tsm.Stop();
                this.Invoke(new ThreadStart(delegate()
                {
                    time_btn_start_a.Enabled = true;
                    time_btn_start_a.BackColor = Color.White;
                    time_btn_start_b.Enabled = true;
                    time_btn_start_b.BackColor = Color.White;
                    groupBox14.Enabled = true;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void time_btn_start_b_Click(object sender, EventArgs e)
        {
            //if (!tsm.isThreadStart)
            //{
                time_btn_start_b.Enabled = false;
                time_btn_start_b.BackColor = Color.Green;
                time_btn_start_a.Enabled = false;
                groupBox14.Enabled = false;
                //SaveFreq();
                Ini(1);
            //}
            //else
            //    tsm.Stop();
        }

        private void time_nud_f1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void time_nud_p1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void time_nud_f2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void time_nud_p2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void time_nud_off1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        void ChangeBand_handle()
        {
            time_cb_band.SelectedIndex = FrmMain.Band;
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

       

        private void numericUpDown1_Click(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
            IniFile.SetFileName(Application.StartupPath + "\\JcConfig.ini");
            IniFile.SetString("Settings", "sweep_times", numericUpDown1.Value.ToString());
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
