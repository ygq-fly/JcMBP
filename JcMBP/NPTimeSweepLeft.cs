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
    public partial class NPTimeSweepLeft : Form
    {
        ClsUpLoad cul;
        DataSweep ds;
        TimeSweepMid tsm;
        NPFreqSweepLeft nsf=new NPFreqSweepLeft();
        byte imCo1 = 2;
        byte imCo2 = 1;
        byte imLow = 0;
        byte imLess = 0;
        float _rxs;
        float _rxe;
        double f1;
        double f2;
        double time = 0;
        float f1max;
        float f1min;
        float f2max;
        float f2min;
        float rmax;
        float rmin;

        public NPTimeSweepLeft(ClsUpLoad cul,TimeSweepMid tsm)
        {
            InitializeComponent();
            this.cul = cul;
            this.tsm = tsm;
            _rxs = cul.ld[0].ord3_imS;
            _rxe = cul.ld[0].ord3_imE;
        }


        void GoB(int tx1, int tx2, int rx)
        {
            tsm.GoB(tx1, tx2, rx);
        }
        public void Cband(int tx1, int tx2, int rx)
        {
            comboBox1.SelectedIndex = tx1;
            comboBox2.SelectedIndex = tx2;
            comboBox3.SelectedIndex = rx;
        }

        /// <summary>
        /// 初始化扫描数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_btn_start_a_Click(object sender, EventArgs e)
        {
            time_btn_start_a.Enabled = false;
            time_btn_start_a.BackColor = Color.Green;
            groupBox14.Enabled = false;
            ds.freq1s = Convert.ToSingle(time_nud_f1.Value);
            ds.freq2e = Convert.ToSingle(time_nud_f2.Value);
            ds.pow1 = ds.pow2 = Convert.ToSingle(time_nud_p2.Value);
            ds.imCo1 = imCo1;
            ds.imCo2 = imCo2;
            ds.imLow = imLow;
            ds.imLess = imLess;
            ds.time1 = (float)time;
            ds.tx1 = (byte)(cul.BandCount[cul.BandNames.IndexOf(comboBox1.Text)]);
            ds.tx2 = (byte)(cul.BandCount[cul.BandNames.IndexOf(comboBox2.Text)]);
            ds.rx = (byte)(cul.BandCount[cul.BandNames.IndexOf(comboBox3.Text)]);
            OfftenMethod.ToAddColumns(ds.dt);
            OfftenMethod.ToAddColumns(ds.dtc);
            ds.port = 0;
            if (checkBox1.Checked)
                ds.off1 = Convert.ToDouble(time_nud_off1.Value);
            else
                ds.off1 = 0;
            if (time_check_off1.Checked)
                ds.off2 = Convert.ToDouble(time_nud_off1.Value);
            else
                ds.off2 = 0;
            ds.xstart = _rxs - 2;
            ds.xend = _rxe + 2;
            ds.MaxRx = _rxe;
            ds.MinRx = _rxs;
            if (radioButton6.Checked)
                ds.tx1Port = 0;
            else
                ds.tx1Port = 1;

            if (radioButton4.Checked)
                ds.tx2Port = 0;
            else
                ds.tx2Port = 1;

            if (radioButton1.Checked)
                ds.rxPort = 0;
            else
                ds.rxPort = 1;

            tsm.Clone(ds);
            Thread th = new Thread(start);
            th.IsBackground = true;
            th.Start();
        }

        /// <summary>
        /// 开始扫描
        /// </summary>
        void start()
        {
            //Sweep s = new SweepTime(ds, ClsUpLoad._type.ToString());
            //tsm.Start(s);
            //this.Invoke(new ThreadStart(delegate()
            //    {
            //        time_btn_start_a.Enabled = true;
            //        time_btn_start_a.BackColor = Color.White;
            //        groupBox14.Enabled = true;
            //    }));
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NPTimeSweepLeft_Load(object sender, EventArgs e)
        {
            ds = new DataSweep();
            OfftenMethod.LoadComboBox(comboBox1, cul.BandNames);
            OfftenMethod.LoadComboBox(comboBox2, cul.BandNames);
            OfftenMethod.LoadComboBox(comboBox3, cul.BandNames);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            time_cb_step.SelectedIndex = 2;
            button9.Text=_rxs.ToString("0.00")+"-"+_rxe.ToString("0.00");
        }

        /// <summary>
        /// 设置rx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            RxRange rr = new RxRange(_rxs, _rxe,rmax,rmin);
            rr.ShowDialog();
            if (rr.DialogResult == DialogResult.OK)
            {
                _rxs = rr._rxs;
                _rxe = rr._rxe;
                button9.Text = _rxs.ToString("0.00") + "-" + _rxe.ToString("0.00");
            }
        }

        /// <summary>
        /// 设置阶数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            PoiOrder ord = new PoiOrder(imCo1, imCo2, imLow, imLess);
            ord.ShowDialog();
            if (ord.DialogResult == DialogResult.OK)
            {
                imLess = ord.imLess;//阶数高低频
                imLow = ord.imLow;//阶数加减法
                imCo1 = ord.imCo1;//阶数参数
                imCo2 = ord.imCo2;//阶数参数
                button6.Text = ord.val;//扫频阶数按钮text
                label2.Text = OfftenMethod.GetTestBand(imCo1, imCo2, imLow, imLess, f1, f2).ToString("0.00") + "MHz";
            }
        }

    
        /// <summary>
        /// 设置f1频率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_nud_f1_ValueChanged(object sender, EventArgs e)
        {
            f1 = Convert.ToDouble(time_nud_f1.Value);
            label2.Text = OfftenMethod.GetTestBand(imCo1, imCo2, imLow, imLess, f1, f2).ToString("0.00") + "MHz";
        }

        /// <summary>
        /// 设置f2频率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_nud_f2_ValueChanged(object sender, EventArgs e)
        {
            f2 = Convert.ToDouble(time_nud_f2.Value);
            label2.Text = OfftenMethod.GetTestBand(imCo1, imCo2, imLow, imLess, f1, f2).ToString("0.00") + "MHz";
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_btn_stop_Click(object sender, EventArgs e)
        {
            tsm.Stop();
            time_btn_start_a.Enabled = true;
            time_btn_start_a.BackColor = Color.White;
            groupBox14.Enabled = true;
        }

        /// <summary>
        /// 根据频段改变f1频率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            time_nud_f1.Maximum = Convert.ToDecimal(cul.ld[comboBox1.SelectedIndex].F1Max);
            time_nud_f1.Minimum = Convert.ToDecimal(cul.ld[comboBox1.SelectedIndex].F1Min);
            time_nud_f1.Value = Convert.ToDecimal(cul.ld[comboBox1.SelectedIndex].ord3_F1UpS);

            GoB(comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex);
        }

        /// <summary>
        /// 根据频段改变f2频率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            time_nud_f2.Maximum = Convert.ToDecimal(cul.ld[comboBox2.SelectedIndex].F2Max);
            time_nud_f2.Minimum = Convert.ToDecimal(cul.ld[comboBox2.SelectedIndex].F2Min);
            time_nud_f2.Value = Convert.ToDecimal(cul.ld[comboBox2.SelectedIndex].ord3_F2DnE);
            GoB(comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex);
        }

        /// <summary>
        /// 根据频段改变rx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rxs = cul.ld[comboBox3.SelectedIndex].ord3_imS;
            _rxe = cul.ld[comboBox3.SelectedIndex].ord3_imE;
            rmax = cul.ld[comboBox3.SelectedIndex].RxMax;
            rmin = cul.ld[comboBox3.SelectedIndex].RxMin;
            button9.Text = _rxs.ToString("0.00") + "-" + _rxe.ToString("0.00");
            GoB(comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex);
        }

        #region numericupdown控件事件
        private void time_nud_f1_MouseClick(object sender, MouseEventArgs e)
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

        private void numericUpDown3_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void time_nud_off1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        #endregion

        /// <summary>
        /// 设置点频次数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_cb_step_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (time_cb_step.SelectedIndex)
            {
                case 0: time = 1;
                    break;
                case 1: time = 5;
                    break;
                case 2: time = 10;
                    break;
                case 3: time = 20;
                    break;
                case 4: time = 30;
                    break;
            }
        }

        private void groupBox14_Enter(object sender, EventArgs e)
        {

        }
    }
}
