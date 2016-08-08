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
    public partial class PoiFreqSweepLeft : Form
    {
       ClsUpLoad cul;
        DataSweep ds;
        FreqSweepMid fsm;
       public static JbData[] jd;
       public static string jbName = "";
        byte imCo1 = 2;
        byte imCo2 = 1;
        byte imLow = 0;
        byte imLess = 0;
        float _rxs;
        float _rxe;
        double f1;
        double f2;
        double f1s;
        double f1e;
        double f2s;
        double f2e;
        float rmax;
        float rmin;

        string jb_path = "";

        public  PoiFreqSweepLeft(ClsUpLoad cul,FreqSweepMid fsm)
        {
            InitializeComponent();
            this.cul = cul;
            this.fsm = fsm;
       
        }

        public void Cband(int tx1, int tx2, int rx)
        {
            comboBox3.SelectedIndex = comboBox3.Items.IndexOf(cul.BandNames[cul.BandCount.IndexOf(tx1)]);
            comboBox4.SelectedIndex = comboBox3.Items.IndexOf(cul.BandNames[cul.BandCount.IndexOf(tx2)]); ;
            comboBox1.SelectedIndex = comboBox3.Items.IndexOf(cul.BandNames[cul.BandCount.IndexOf(rx)]);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="port"></param>
        void Ini(byte port)
        {       
            ds.freq1s = Convert.ToSingle(freq_nud_fstart1.Value);
            ds.freq1e = Convert.ToSingle(freq_nud_fstop1.Value);
            ds.freq2s = Convert.ToSingle(freq_nud_fstart2.Value);
            ds.freq2e = Convert.ToSingle(freq_nud_fstop2.Value);
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
            ds.imLow=imLow;
            if (freq_check_off1.Checked)
                ds.off1 =  ds.freq_off1 = Convert.ToDouble(freq_nud_off1.Value);
            else
                ds.off1 =  ds.freq_off1 = 0;
            if (checkBox2.Checked)
                ds.off2 = ds.freq_off2 = Convert.ToDouble(numericUpDown4.Value);
            else
                ds.off2 = ds.freq_off2 = 0;
            ds.port = port;
            
            fsm.Clone(ds);
            Thread th = new Thread(start);
            th.IsBackground = true;
            th.Start();
        }

        /// <summary>
        /// 开始
        /// </summary>
        void start()
        {
            //Sweep s = new SweepFreq(ds, ClsUpLoad._type.ToString());
            //fsm.Start(s);
            //this.Invoke(new ThreadStart(delegate()
            //{
            //    time_btn_start_a.Enabled = true;
            //    time_btn_start_a.BackColor = Color.White;
            //    time_btn_start_b.Enabled = true;
            //    groupBox1.Enabled = true;
            //}));
        }

        /// <summary>
        /// port1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_btn_start_a_Click(object sender, EventArgs e)
        {
            //if (!fsm.isThreadStart)
            //{
            if (comboBox1.SelectedIndex == 12 && comboBox3.SelectedIndex == 12 && comboBox4.SelectedIndex == 12)
            {
                MessageBox.Show("该频段tx和rx不能同一频段");
                return;
            }
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


        private void PoiFreqSweepLeft_Load(object sender, EventArgs e)
        {
            ControlIni();
            ds = new DataSweep();
            OfftenMethod.ToAddColumns(ds.dtm);
            OfftenMethod.ToAddColumns(ds.dtm_c);
        }

        /// <summary>
        /// 更新控件
        /// </summary>
        void ControlIni()
        {
            OfftenMethod.LoadComboBox(comboBox3, cul.BandNames,0);
            OfftenMethod.LoadComboBox(comboBox4, cul.BandNames,1);
            OfftenMethod.LoadComboBox(comboBox1, cul.BandNames,2);
            //comboBox4.Items.Remove("11电信TD2.3G");
            //comboBox1.Items.Remove("9移动TD(A频段)");
            //comboBox1.Items.Remove("12联通TD2.3G");
            //comboBox3.Items.Remove("9移动TD(A频段)");
            //comboBox3.Items.Remove("12联通TD2.3G");
            //comboBox4.Items.Insert(10, "---");
            //comboBox3.Items.Insert(8, "---");
            //comboBox3.Items.Insert(11, "---");
            //comboBox1.Items.Insert(8, "---");
            //comboBox1.Items.Insert(11, "---");
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            freq_cb_step.SelectedIndex = 1;

        }

        /// <summary>
        /// 根据阶数设
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void freq_cb_im_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox3.SelectedIndex == 8||comboBox3.SelectedIndex == 11  )
            //{
            //    MessageBox.Show("poi模式当前频段无tx1");
            //    comboBox3.SelectedIndex = 0;
            //    return;
            //}
            OfftenMethod.NudValue(freq_nud_fstart1, freq_nud_fstop1,
                                            (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox3.Text)]].F1Min, (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox3.Text)]].F1Max);
            freq_nud_fstart1.Value = (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox3.Text)]].ord3_F1UpS;
            freq_nud_fstop1.Value = (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox3.Text)]].ord3_F1UpE;
        }


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox4.SelectedIndex == 10)
            //{
            //    MessageBox.Show("poi模式当前频段无tx2");
            //    comboBox4.SelectedIndex = 0;
            //    return;
            //}
            OfftenMethod.NudValue(freq_nud_fstart2, freq_nud_fstop2,
                                             (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox4.Text)]].F2Min, (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox4.Text)]].F2Max);
            freq_nud_fstart2.Value = (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox4.Text)]].ord3_F2DnS;
            freq_nud_fstop2.Value = (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox4.Text)]].ord3_F2DnE;
        }

        /// <summary>
        /// port2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_btn_start_b_Click(object sender, EventArgs e)
        {
            if (!fsm.isThreadStart)
                Ini(1);
            else
                fsm.Stop();
        }

        /// <summary>
        /// 设置rx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
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

        /// <summary>
        /// 设置阶数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 脚本测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_btn_start_b_Click_1(object sender, EventArgs e)
        {
            poi_script ps = new poi_script(jb_path);
            ps.ShowDialog();
            if (ps.DialogResult == DialogResult.OK)
            {
                label1_Click(null, null);
                time_btn_start_a.Enabled = false;
                time_btn_start_b.Enabled = false;
                time_btn_start_b.BackColor = Color.Green;
                groupBox1.Enabled = false;
                ds.jb.Clear();
                ds.jbc.Clear();
                ds.sxy.pf_arr[0].Clear();
                ds.sxy.pf_arr[1].Clear();
                ds.sxy.pf_arr[2].Clear();
                ds.sxy.pf_arr[3].Clear();
                string path_test = ps.path_test;
                jb_path = ps.path_test;
                IniFile.SetFileName(@path_test);
                ds.num = int.Parse(IniFile.GetString("Setting", "num", "1"));
                fsm.DateAndGr(ds.num);
                jd = new JbData[ds.num];
                for (int i = 0; i < ds.num; i++)
                {
                    jd[i] = new JbData();
                    jd[i].LoadData(@path_test, i, ClsUpLoad._type);
                }
                string[] names = path_test.Split('\\');
                jbName = names[names.Length - 1];
                fsm.ChangeJbUnit();
                JbIni();
            }
        }

        void JbIni()
        {
            Thread th = new Thread(Jbstart);
            th.IsBackground = true;
            th.Start();
        }

        void Jbstart()
        {
            //ds.sxy.starttime = DateTime.Now;

            //for (int i = 0; i < ds.num; i++)
            //{
            //    JbIni_(jd[i], i);
            //    UpdateGroupControl(i);
            //    Sweep s;
            //    if (ds.sxy.model == 1)
            //        s = new SweepTime(ds, ClsUpLoad._type.ToString());
            //    else
            //        s = new SweepFreq(ds, ClsUpLoad._type.ToString());
            //    fsm.JbStart(s, i, jd[i].time_out_M);
            //    Thread.Sleep(Convert.ToInt32(ClsUpLoad._sleepTime));
            //    if (FreqSweepMid.jb_err||time_btn_start_b.Enabled)
            //        break;
            //}
            //this.Invoke(new ThreadStart(delegate
            //{
            //    ds.sxy.endtime = DateTime.Now;
            //    ds.sxy.spantime = ds.sxy.endtime - ds.sxy.starttime;
            //    fsm.DateAndGr();
            //    time_btn_start_a.Enabled = true;
            //    time_btn_start_b.Enabled = true;
            //    groupBox1.Enabled = true;
            //    time_btn_start_b.BackColor = Color.White;
            //}));
        }

        void JbIni_(JbData jb, int i)
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

        /// <summary>
        /// 脚本测试，根据当前频段更新数据和控件
        /// </summary>
        /// <param name="i"></param>
        public  void UpdateGroupControl(int i)
        {
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
                 comboBox3.SelectedIndex =comboBox3.Items.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)jd[i].tx1)]);
                 comboBox4.SelectedIndex = comboBox4.Items.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)jd[i].tx2)]);
                 comboBox1.SelectedIndex = comboBox1.Items.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)jd[i].rx)]);
                 f1s = jd[i].f1s;
                 f1e = jd[i].f1e;
                 f2s = jd[i].f2s;
                 f2e = jd[i].f2e;
                 _rxs = jd[i].rxs;
                 _rxe = jd[i].rxe;
                 freq_nud_fstart1.Value = Convert.ToDecimal(f1s);
                 freq_nud_fstop1.Value = Convert.ToDecimal(f1e);
                 freq_nud_fstart2.Value = Convert.ToDecimal(f2s);
                 freq_nud_fstop2.Value = Convert.ToDecimal(f2e);
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

        private void label1_Click(object sender, EventArgs e)
        {
            fsm.JbControl();
        }

        private void label45_Click(object sender, EventArgs e)
        {
            fsm.JbControl_f();
        }

        private void freq_nud_fstart1_ValueChanged(object sender, EventArgs e)
        {
            f1s = Convert.ToDouble(freq_nud_fstart1.Value);
            label4.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
        }

        private void freq_nud_fstop1_ValueChanged(object sender, EventArgs e)
        {
            f1e = Convert.ToDouble(freq_nud_fstop1.Value);
            label4.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
        }

        private void freq_nud_fstart2_ValueChanged(object sender, EventArgs e)
        {
            f2s = Convert.ToDouble(freq_nud_fstart2.Value);
            label4.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
        }

        private void freq_nud_fstop2_ValueChanged(object sender, EventArgs e)
        {
            f2e = Convert.ToDouble(freq_nud_fstop2.Value);
            label4.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedIndex == 8 || comboBox1.SelectedIndex == 11)
            //{
            //    MessageBox.Show("poi模式当前频段无rx");
            //    comboBox1.SelectedIndex = 0;
            //    return;
            //}
            _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox1.Text)]].ord3_imS;
            _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox1.Text)]].ord3_imE;
            rmax = cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox1.Text)]].RxMax;
            rmin = cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox1.Text)]].RxMin;
            button8.Text = _rxs.ToString("0.00") + "-" + _rxe.ToString("0.00");
        }

        private void time_btn_stop_Click(object sender, EventArgs e)
        {
            fsm.Stop();
            time_btn_start_a.Enabled = true;
            time_btn_start_a.BackColor = Color.White;
            time_btn_start_b.Enabled = true;
            groupBox1.Enabled = true;
        }

        private void freq_nud_fstart1_MouseClick(object sender, MouseEventArgs e)
        {            time_btn_start_b.BackColor = Color.White;

            OfftenMethod.Formula(sender);
        }

        private void freq_nud_fstop1_MouseClick(object sender, MouseEventArgs e)
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

        private void numericUpDown4_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void freq_cb_step_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
    }
}
