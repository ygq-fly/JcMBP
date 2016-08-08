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
    public delegate void Cband(int tx1,int tx2,int rx);
    public partial class NPFreqSweepLeft : Form
    {
        ClsUpLoad cul;
        DataSweep ds;
        FreqSweepMid fsm;
        JbData[] jd;
        byte imCo1 = 2;
        byte imCo2 = 1;
        byte imLow = 0;
        byte imLess = 0;
        float _rxs;
        float _rxe;
        double f1s;
        double f1e;
        double f2s;
        double f2e;
        float f1max;
        float f1min;
        float f2max;
        float f2min;
        float rmax;
        float rmin;
        public NPFreqSweepLeft()
        {
            InitializeComponent();
        }

        public  NPFreqSweepLeft(ClsUpLoad cul,FreqSweepMid fm)
        {
            InitializeComponent();
            this.cul = cul;
            this.fsm = fm;
        }
        public   void Cband(int tx1,int tx2,int rx)
        {
            comboBox3.SelectedIndex = tx1;
            comboBox4.SelectedIndex = tx2;
            comboBox1.SelectedIndex = rx;
        }


        public void GoB2(int tx1, int tx2, int rx)
        {
            fsm.GoB2(tx1, tx2, rx);
        }


        void Ini(byte port)
        {
            ds.freq1s = Convert.ToSingle(f1s);
            ds.freq1e = Convert.ToSingle(f1e);
            ds.freq2s = Convert.ToSingle(f2s);
            ds.freq2e = Convert.ToSingle(f2e);
            ds.pow1 = ds.pow2 = Convert.ToSingle(freq_nud_pow2.Value);
            ds.step1 = ds.step2 = Convert.ToSingle(freq_cb_step.Text.Replace('m', ' '));
            ds.tx1 = (byte)(cul.BandCount[cul.BandNames.IndexOf(comboBox3.Text)]);
            ds.tx2 = (byte)(cul.BandCount[cul.BandNames.IndexOf(comboBox4.Text)]);
            ds.rx = (byte)(cul.BandCount[cul.BandNames.IndexOf(comboBox1.Text)]);
            ds.MaxRx = _rxe;
            ds.MinRx = _rxs;
            ds.imCo1 = imCo1;
            ds.imCo2 = imCo2;
            ds.imLess = imLess;
            ds.imLow = imLow;
            
            OfftenMethod.ToAddColumns(ds.dtm);
            OfftenMethod.ToAddColumns(ds.dtm_c);
            if (freq_check_off1.Checked)
                ds.off1 =  ds.freq_off1 = Convert.ToDouble(freq_nud_off1.Value);
            else
                ds.off1 =  ds.freq_off1 = 0;
            if (checkBox2.Checked)
                ds.off2 = ds.freq_off2 = Convert.ToDouble(numericUpDown4.Value);
            else
                ds.off2 = ds.freq_off2 = 0;
            ds.port = port;

            if (radioButton6.Checked)
                ds.tx1Port = 0;
            else
                ds.tx1Port = 1;
            if (radioButton2.Checked)
                ds.tx2Port = 0;
            else
                ds.tx2Port = 1;
            if (radioButton4.Checked)
                ds.rxPort = 0;
            else
                ds.rxPort = 1;

            fsm.Clone(ds);

            Thread th = new Thread(start);
            th.IsBackground = true;
            th.Start();
        }

        void start()
        {
            //Sweep  s= new SweepFreq(ds, ClsUpLoad._type.ToString());
            //fsm.Start(s);
            //this.Invoke(new ThreadStart(delegate()
            //   {
            //       time_btn_start_a.Enabled = true;
            //       time_btn_start_a.BackColor = Color.White;
            //       time_btn_start_b.Enabled = true;
            //       groupBox1.Enabled = true;
            //   }));
        }
        private void time_btn_start_a_Click(object sender, EventArgs e)
        {
            //if (!fsm.isThreadStart)
            //{
            time_btn_start_a.Enabled = false;
            time_btn_start_a.BackColor = Color.Green;
            time_btn_start_b.Enabled = false;
            groupBox1.Enabled = false;
                label45_Click(null,null);
                Ini(0);
            //}
            //else
            //    fsm.Stop();
        }

        private void FreqSweepLeft_Load(object sender, EventArgs e)
        {
            ControlIni();
            ds = new DataSweep();
        }

        void ControlIni()
        {
            OfftenMethod.LoadComboBox(comboBox3, cul.BandNames);
            OfftenMethod.LoadComboBox(comboBox4, cul.BandNames);
            OfftenMethod.LoadComboBox(comboBox1, cul.BandNames);
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            freq_cb_step.SelectedIndex = 1;
        }

        private void time_btn_start_b_Click(object sender, EventArgs e)
        {
            if (!fsm.isThreadStart)
                Ini(1);
            else
                fsm.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PoiOrder ord = new PoiOrder(imCo1, imCo2, imLow, imLess);
            ord.ShowDialog();
            if (ord.DialogResult == DialogResult.OK)
            {
                imLess = ord.imLess;//阶数高低频
                imLow = ord.imLow;//阶数加减法
                imCo1 = ord.imCo1;//阶数参数
                imCo2 = ord.imCo2;//阶数参数
                button5.Text = ord.val;//扫频阶数按钮text
                label4.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
            }
        }

        private void time_btn_start_b_Click_1(object sender, EventArgs e)
        {
            label1_Click(null, null);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            fsm.JbControl();
        }

        private void label45_Click(object sender, EventArgs e)
        {
            fsm.JbControl_f();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SettingFreq sf = new SettingFreq(f1s,f1e,f1max,f1min);
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
            {
                button11.Text = sf.f1.ToString() + "——" + sf.f2.ToString();
                f1e = sf.f2;
                f1s = sf.f1;
                label4.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
            }
        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            f2s = cul.ld[comboBox4.SelectedIndex].ord3_F1UpS;
            f2e = cul.ld[comboBox4.SelectedIndex].ord3_F1UpE;
            f2max = cul.ld[comboBox4.SelectedIndex].F2Max;
            f2min = cul.ld[comboBox4.SelectedIndex].F2Min;
            button1.Text = f2s.ToString("0.00") + "-" + f2e.ToString("0.00");
            label4.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
            if (comboBox3.SelectedIndex < 0 || comboBox4.SelectedIndex < 0 || comboBox1.SelectedIndex < 0)
                return;
            GoB2(comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox1.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingFreq sf = new SettingFreq(f2s, f2e,f2max,f2min);
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
            {
                button1.Text = sf.f1.ToString() + "——" + sf.f2.ToString();
                f2e = sf.f2;
                f2s = sf.f1;
                label4.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1s = cul.ld[comboBox3.SelectedIndex].ord3_F1UpS;
             f1e= cul.ld[comboBox3.SelectedIndex].ord3_F1UpE;
             f1max = cul.ld[comboBox3.SelectedIndex].F1Max;
             f1min = cul.ld[comboBox3.SelectedIndex].F1Min;
             
             button11.Text = f1s.ToString("0.00") + "-" + f1e.ToString("0.00");
             label4.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
             if (comboBox3.SelectedIndex < 0 || comboBox4.SelectedIndex < 0 || comboBox1.SelectedIndex < 0)
                 return;
             GoB2(comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox1.SelectedIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rxs = cul.ld[comboBox1.SelectedIndex].ord3_imS;
            _rxe = cul.ld[comboBox1.SelectedIndex].ord3_imE;
            rmax = cul.ld[comboBox1.SelectedIndex].RxMax;
            rmin = cul.ld[comboBox1.SelectedIndex].RxMin;
            button8.Text = _rxs.ToString("0.00") + "-" + _rxe.ToString("0.00");
            if (comboBox3.SelectedIndex < 0 || comboBox4.SelectedIndex < 0 || comboBox1.SelectedIndex < 0)
                return;
            GoB2(comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox1.SelectedIndex);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            RxRange rr = new RxRange(_rxs, _rxe,rmax,rmin);
            rr.ShowDialog();
            if (rr.DialogResult == DialogResult.OK)
            {
                _rxs = rr._rxs;
                _rxe = rr._rxe;
                button8.Text = _rxs.ToString("0.00") + "-" + _rxe.ToString("0.00");
            }
        }

        private void time_btn_start_b_Click_2(object sender, EventArgs e)
        {
          
            poi_script ps = new poi_script();
            ps.ShowDialog();
            if (ps.DialogResult == DialogResult.OK)
            {
                label1_Click(null, null);
                time_btn_start_a.Enabled = false;
                time_btn_start_b.Enabled = false;
                groupBox1.Enabled = false;
                time_btn_start_b.BackColor = Color.Green;
                ds.jb.Clear();
                ds.jbc.Clear();
                ds.sxy.pf_arr[0].Clear();
                ds.sxy.pf_arr[1].Clear();
                ds.sxy.pf_arr[2].Clear();
                ds.sxy.pf_arr[3].Clear();
                string path_test = ps.path_test;
                IniFile.SetFileName(@path_test);
                ds.num = int.Parse(IniFile.GetString("Setting", "num", "1"));
                fsm.DateAndGr(ds.num);
                jd = new JbData[ds.num];
                for (int i = 0; i < ds.num; i++)
                {
                     jd[i] = new JbData();
                    jd[i].LoadData(@path_test, i, ClsUpLoad._type);
                }
                JbIni();
            }
        }

        void JbIni()
        {
           
            Thread th = new Thread(Jbstart);
            th.IsBackground = true;
            th.Start();
        }

        void JbIni_(JbData jb,int i)
        {
            ds.freq1s = jb.f1s;
            ds.freq1e = jb.f1e;
            ds.freq2s = jb.f2s;
            ds.freq2e = jb.f2e;
            ds.pow1 = ds.pow2 = jb.pow;
            ds.step1 = ds.step2 = jb.step;
            ds.time1 = ds.time2 = jb.time;
            ds.tx1 = jb.tx1;
            ds.tx2 = jb.tx2;
            ds.rx = jb.rx;
            ds.imCo1 = jb.imCo1;
            ds.imCo2 = jb.imCo2;
            ds.imLow = jb.imLow;
            ds.imLess = jb.imLess;
            ds.off1 = ds.freq_off1 = jb.off1;
            ds.off2 = ds.freq_off2 = jb.off2;
            ds.tx1Port = jb.porttx1;
            ds.tx2Port = jb.porttx2;
            ds.rxPort = jb.portrx;
            ds.MaxRx = jb.rxe;
            ds.MinRx = jb.rxs;
            ds.sxy.bandM = jb.bandM;
            ds.sxy.time_out_M = jb.time_out_M;
            ds.sxy.model = jb.model;
            //if (ds.sxy.model == 1)
            //{
            //    ds.MinRx = 2;
            //    ds.MaxRx = ds.time2;
            //}
            ds.timeou_mes = jb.time_out_M;
            this.Invoke(new ThreadStart(delegate
          {
              OfftenMethod.ToAddColumns(ds.dt);
              OfftenMethod.ToAddColumns(ds.dtc);
              OfftenMethod.ToAddColumns_j(ds.jb);
              OfftenMethod.ToAddColumns_j(ds.jbc);
              OfftenMethod.ToNewRows_test(ds.jb, (i + 1).ToString(), 0, 0, 0, "0");
              OfftenMethod.ToNewRows_test(ds.jbc, (i + 1).ToString(), 0, 0, 0, "0");
          }));
            fsm.Clone(ds);
        }

        void Jbstart()
        {
           // for (int i = 0; i < ds.num; i++)
           // {
           //     Sweep s;
           //     JbIni_(jd[i],i);
           //     UpdateGroupControl(i);
           //     if (ds.sxy.model == 1)
           //         s = new SweepTime(ds, ClsUpLoad._type.ToString());
           //     else
           //         s = new SweepFreq(ds, ClsUpLoad._type.ToString());
           //     fsm.JbStart(s, i, jd[i].time_out_M);
           //     Thread.Sleep(Convert.ToInt32(ClsUpLoad._sleepTime));
           //     if (FreqSweepMid.jb_err)
           //         break;
           // }
           // this.Invoke(new ThreadStart(delegate
           //{
           //    fsm.DateAndGr();
           //    time_btn_start_a.Enabled = true;
           //    time_btn_start_b.Enabled = true;
           //    groupBox1.Enabled = true;
           //    time_btn_start_b.BackColor = Color.White;
           //}));
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            PoiOrder ord = new PoiOrder(imCo1, imCo2, imLow, imLess);
            ord.ShowDialog();
            if (ord.DialogResult == DialogResult.OK)
            {
                imLess = ord.imLess;//阶数高低频
                imLow = ord.imLow;//阶数加减法
                imCo1 = ord.imCo1;//阶数参数
                imCo2 = ord.imCo2;//阶数参数
                button5.Text = ord.val;//扫频阶数按钮text
                label4.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
            }
        }

       public  void UpdateGroupControl(int i)
        {
            //fsm.isThreadStart = false;
            if (jd[i].time_out_M != "-")
                return;
            this.Invoke(new ThreadStart(delegate
            {
                button5.Text = OfftenMethod.PimFormula(jd[i].imCo1, jd[i].imCo2, jd[i].imLow, jd[i].imLess);
                imCo1 = jd[i].imCo1;
                imCo2 = jd[i].imCo2;
                imLow = jd[i].imLow;
                imLess = jd[i].imLess;
                freq_nud_off1.Value = Convert.ToDecimal(jd[i].off1);
                numericUpDown4.Value = Convert.ToDecimal(jd[i].off2);
                comboBox3.SelectedIndex = (int)jd[i].tx1;
                comboBox4.SelectedIndex = (int)jd[i].tx2;
                comboBox1.SelectedIndex = (int)jd[i].rx;
                f1s = jd[i].f1s;
                f1e = jd[i].f1e;
                f2s = jd[i].f2s;
                f2e = jd[i].f2e;
                button11.Text = f1s.ToString("0.00") + "-" + f1e.ToString("0.00");
                button1.Text = f2s.ToString("0.00") + "-" + f2e.ToString("0.00");
                if (jd[i].porttx1 == 0)
                    radioButton6.Checked = true;
                else
                    radioButton5.Checked = true;
                if (jd[i].porttx2 == 0)
                    radioButton2.Checked = true;
                else
                    radioButton1.Checked = true;
                if (jd[i].portrx == 0)
                    radioButton4.Checked = true;
                else
                    radioButton3.Checked = true;
                freq_nud_pow2.Value = (decimal)jd[i].pow;
                switch (jd[i].step.ToString())
                {
                    case "0.1": freq_cb_step.SelectedIndex = 0; break;
                    case "1": freq_cb_step.SelectedIndex = 1; break;
                    case "2": freq_cb_step.SelectedIndex = 2; break;
                    case "3": freq_cb_step.SelectedIndex = 3; break;
                    case "5": freq_cb_step.SelectedIndex = 4; break;
                    case "10": freq_cb_step.SelectedIndex = 5; break;
                }

                button8.Text = jd[i].rxs.ToString("0.00") + "-" + jd[i].rxe.ToString("0.00") + "MHz";
                label4.Text = OfftenMethod.GetTestBand_f(jd[i].imCo1, jd[i].imCo2, jd[i].imLow, jd[i].imLess,
                                                           jd[i].f1s, jd[i].f1e, jd[i].f2s, jd[i].f2e);
                fsm.numericUpDown2.Value = Convert.ToDecimal(jd[i].limit);
            }));
        }

        private void freq_cb_step_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void time_btn_stop_Click(object sender, EventArgs e)
        {
            fsm.Stop();
            time_btn_start_a.Enabled = true;
            time_btn_start_a.BackColor = Color.White;
            time_btn_start_b.Enabled = true;
            time_btn_start_b.BackColor = Color.White;
            groupBox1.Enabled = true;
        }

        private void freq_nud_pow2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void freq_nud_off1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void numericUpDown4_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
