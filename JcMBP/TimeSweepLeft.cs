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
        DataSweep ds;
        TimeSweepMid tsm;
        ClsUpLoad cul;
        int time = 1;
        double _rxs = 0;
        double _rxe = 0;
        public TimeSweepLeft(ClsUpLoad cul,TimeSweepMid tsm)
        {
            InitializeComponent();
            this.cul = cul;
            this.tsm = tsm;
        }
        public void Cband(int tx1, int tx2, int rx)
        {
            time_cb_band.SelectedIndex = rx;
        }

        void Ini(byte port)
        {
            ds.freq1s = Convert.ToDouble(time_nud_f1.Value);
            ds.freq2e = Convert.ToDouble(time_nud_f2.Value);
            ds.pow1 = Convert.ToSingle(time_nud_p1.Value);
            ds.pow2 = Convert.ToSingle(time_nud_p2.Value);
            ds.timeout = Convert.ToInt32(numericUpDown1.Value);
            ds.order = byte.Parse(time_cb_im.Text.Substring(2));
            ds.imCo1 = (byte)(Convert.ToInt32(ds.order) / 2 + 1);
            ds.imCo2 = (byte)(Convert.ToInt32(ds.imCo1) - 1);
            ds.tx1 = (byte)(cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]);
            ds.tx2 = (byte)(cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]);
            ds.rx = (byte)(cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]);
            ds.port = port;
            ds.MaxRx = _rxe;
            ds.MinRx = _rxs;
            ds.time1 = Convert.ToSingle(numericUpDown1.Value); ;
            if (time_check_off1.Checked)
                ds.rx_off= ds.off1 = ds.off2 = ds.time_off2 = ds.time_off1 = Convert.ToDouble(time_nud_off1.Value);
            else
                ds.rx_off= ds.off1 = ds.off2 = ds.time_off2 = ds.time_off1 = 0;
            OfftenMethod.ToAddColumns(ds.dt);
            OfftenMethod.ToAddColumns(ds.dtc);
            tsm.Clone(ds);
            Thread th = new Thread(start);
            th.IsBackground = true;
            th.Start();
        }

        void start()
        {
            Sweep s = new SweepTime(ds, ClsUpLoad._type.ToString());
            tsm.Start(s);
            //for (int i = 0; i < FrmMain.count; i++)
            //{

            //    tsm.Start(s);
            //    if (i >= 1)
            //    {
            //        MessageBox.Show("请敲击");
            //    }
            //}
            this.Invoke(new ThreadStart(delegate()
            {
                time_btn_start_a.Enabled = true;
                time_btn_start_a.BackColor = Color.White;
                time_btn_start_b.Enabled = true;
                time_btn_start_b.BackColor = Color.White;
                groupBox14.Enabled = true;
                time_check_vco.Enabled = true;
             
            }));
        }
        private void  time_btn_start_a_Click(object sender, EventArgs e)
        {
            //if (!tsm.isThreadStart)
            //{
          
                time_btn_start_a.Enabled = false;
                time_btn_start_a.BackColor = Color.Green;
                time_btn_start_b.Enabled = false;
                groupBox14.Enabled = false;
                time_check_vco.Enabled = false;
                Ini(0);
            
            //}
            //else
            //{
            //    tsm.Stop();
            //}
        }

        private void TimeSweepLeft_Load(object sender, EventArgs e)
        {
            OfftenMethod.LoadComboBox(time_cb_band, cul.BandNames,0);
            ds = new DataSweep();
           FrmMain.CBHandle += new ChangeBand(ChangeBand_handle);
           FrmMain.CVHandle += new ChangeVco_enable(ChangeVco_handle);
            time_cb_band.SelectedIndex = 0;
            time_cb_im.SelectedIndex = 0;
            numericUpDown1.Value = ClsUpLoad.sweep_index;
        }

        private void time_cb_im_SelectedIndexChanged(object sender, EventArgs e)
        {
            FrmMain.Band = time_cb_band.SelectedIndex;
            OfftenMethod.NudValue(time_nud_f1, time_nud_f2,
                   (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].F1Min, (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].F2Max);               
            switch (time_cb_im.SelectedIndex)
            {
                case 0:
                    time_nud_f1.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord3_F1UpS);
                    time_nud_f2.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord3_F2DnE);
                    //OfftenMethod.NudValue(time_nud_f1, time_nud_f2,
                    // (decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F1UpS, (decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F2DnE);               
                    break;
                case 1:
                    time_nud_f1.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord5_F1UpS);
                    time_nud_f2.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord5_F2DnE);
                    //OfftenMethod.NudValue(time_nud_f1, time_nud_f2,
                    //(decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F1UpS, (decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F2DnE);
                    break;
                case 2:
                    time_nud_f1.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord7_F1UpS);
                    time_nud_f2.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord7_F2DnE);
                    //OfftenMethod.NudValue(time_nud_f1, time_nud_f2,
                    //(decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F1UpS, (decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F2DnE);
                    break;
                case 3:
                    time_nud_f1.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord9_F1UpS);
                    time_nud_f2.Value = Convert.ToDecimal((decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord9_F2DnE);
                    //OfftenMethod.NudValue(time_nud_f1, time_nud_f2,
                    //(decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F1UpS, (decimal)cul.ld[time_cb_band.SelectedIndex].ord3_F2DnE);
                    break;
                case 4: break;
            }
            _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord3_imS;
            _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(time_cb_band.Text)]].ord3_imE;
        }

        private void time_btn_stop_Click(object sender, EventArgs e)
        {
            tsm.Stop();
           
        }

        private void time_btn_start_b_Click(object sender, EventArgs e)
        {
            //if (!tsm.isThreadStart)
            //{
                time_btn_start_b.Enabled = false;
                time_btn_start_b.BackColor = Color.Green;
                time_btn_start_a.Enabled = false;
                groupBox14.Enabled = false;
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


    }
}
