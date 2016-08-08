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
    public partial class PoiTimeSweepLeft : Form
    {
        DataSweep ds;
        TimeSweepMid tsm;
        ClsUpLoad cul;
         byte imCo1 = 2;
         byte imCo2 = 1;
         byte imLow = 0;
         byte imLess = 0;
         int time = 1;
         float _rxs;
         float _rxe;
         double f1;
         double f2;
         float rmax;
         float rmin;

         public PoiTimeSweepLeft(ClsUpLoad cul,TimeSweepMid tsm)
         {
             InitializeComponent();
             this.cul = cul;
             _rxs = cul.ld[0].ord3_imS;
             _rxe = cul.ld[0].ord3_imE;
             this.tsm = tsm;
         }

         public void Cband(int tx1, int tx2, int rx)
         {
             comboBox1.SelectedIndex = tx1;
             comboBox2.SelectedIndex = tx2;
             comboBox3.SelectedIndex = rx;
         }

        private void time_btn_start_a_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 12 && comboBox3.SelectedIndex == 12 && comboBox2.SelectedIndex == 12)
            {
                MessageBox.Show("该频段tx和rx不能同一频段");
                return;
            }
            time_btn_start_a.Enabled = false;
            time_btn_start_a.BackColor = Color.Green;
            groupBox14.Enabled = false;
            ds.freq1s = Convert.ToSingle(time_nud_f1.Value);
            ds.freq2e = Convert.ToSingle(time_nud_f2.Value);
            ds.pow1= ds.pow2 = Convert.ToSingle(time_nud_p2.Value);
            //ds.timeout = int.Parse(time_cb_step.Text.Replace('s', ' '));
            ds.imCo1 = imCo1;
            ds.imCo2 = imCo2;
            ds.imLow = imLow;
            ds.imLess = imLess;
            ds.tx1 = (byte)(cul.BandCount[cul.BandNames.IndexOf(comboBox1.Text)]);
            ds.tx2 = (byte)(cul.BandCount[cul.BandNames.IndexOf(comboBox2.Text)]);
            ds.rx = (byte)(cul.BandCount[cul.BandNames.IndexOf(comboBox3.Text)]);
            ds.port = 0;
            ds.time1 = (float)time;
            OfftenMethod.ToAddColumns(ds.dt);
            OfftenMethod.ToAddColumns(ds.dtc);
            if (checkBox1.Checked)
                ds.off1 =  Convert.ToDouble(time_nud_off1.Value);
            else
                ds.off1 =  0;
            if(time_check_off1.Checked)
                ds.off2 = Convert.ToDouble(time_nud_off1.Value);
            else
                ds.off2 = 0;
            ds.MaxRx = _rxe;
            ds.MinRx= _rxs;
            tsm.Clone(ds);

            Thread th = new Thread(start);
            th.IsBackground = true;
            th.Start();
        }

        void start()
        {
           // Sweep s = new SweepTime(ds, ClsUpLoad._type.ToString());
           // tsm.Start(s);
           // this.Invoke(new ThreadStart(delegate
           //{
           //    time_btn_start_a.Enabled = true;
           //    time_btn_start_a.BackColor = Color.White;
           //    groupBox14.Enabled = true;
           //}));
        }

        private void time_btn_stop_Click(object sender, EventArgs e)
        {
            tsm.Stop();
            time_btn_start_a.Enabled = true;
            time_btn_start_a.BackColor = Color.White;
            groupBox14.Enabled = true;
        }

        private void PoiTimeSweepLeft_Load(object sender, EventArgs e)
        {
            ds = new DataSweep();
            OfftenMethod.LoadComboBox(comboBox1, cul.BandNames,0);
            OfftenMethod.LoadComboBox(comboBox2, cul.BandNames,1);
            OfftenMethod.LoadComboBox(comboBox3, cul.BandNames,2);
            //comboBox2.Items.Remove("11电信TD2.3G");
            //comboBox1.Items.Remove("9移动TD(A频段)");
            //comboBox1.Items.Remove("12联通TD2.3G");
            //comboBox3.Items.Remove("9移动TD(A频段)");
            //comboBox3.Items.Remove("12联通TD2.3G");
            //comboBox2.Items.Insert(10, "---");
            //comboBox3.Items.Insert(8, "---");
            //comboBox3.Items.Insert(11, "---");
            //comboBox1.Items.Insert(8, "---");
            //comboBox1.Items.Insert(11, "---");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            time_cb_step.SelectedIndex = 2;
            button9.Text = _rxs.ToString("0.00") + "-" + _rxe.ToString("0.00");
            OfftenMethod.ToAddColumns(ds.dtm);
            OfftenMethod.ToAddColumns(ds.dtm_c);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PoiOrder ord = new PoiOrder(imCo1,imCo2,imLow,imLess);
            ord.ShowDialog();
            if (ord.DialogResult == DialogResult.OK)
            {
                imLess = ord.imLess;//阶数高低频
                imLow= ord.imLow;//阶数加减法
                imCo1 = ord.imCo1;//阶数参数
                imCo2 = ord.imCo2;//阶数参数
                button6.Text = ord.val;//扫频阶数按钮text
                label2.Text = OfftenMethod.GetTestBand(imCo1, imCo2, imLow, imLess, f1, f2).ToString("0.00") + "MHz";
            }
        }

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

        private void time_nud_f1_ValueChanged(object sender, EventArgs e)
        {
            f1 = Convert.ToDouble(time_nud_f1.Value);
           label2.Text= OfftenMethod.GetTestBand(imCo1, imCo2, imLow, imLess, f1, f2).ToString("0.00")+"MHz";
        }

        private void time_nud_f2_ValueChanged(object sender, EventArgs e)
        {
            f2 = Convert.ToDouble(time_nud_f2.Value);
            label2.Text = OfftenMethod.GetTestBand(imCo1, imCo2, imLow, imLess, f1, f2).ToString("0.00") + "MHz";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedIndex == 8 || comboBox1.SelectedIndex == 11)
            //{
            //    MessageBox.Show("poi模式当前频段无tx1");
            //    comboBox1.SelectedIndex = 0;
            //    return;
            //}
            time_nud_f1.Maximum = (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox1.Text)]].F1Max;
            time_nud_f1.Minimum = (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox1.Text)]].F1Min;
            time_nud_f1.Value = (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox1.Text)]].ord3_F1UpS;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox2.SelectedIndex == 10)
            //{
            //    MessageBox.Show("poi模式当前频段无tx2");
            //    comboBox2.SelectedIndex = 0;
            //    return;
            //}
            time_nud_f2.Maximum = (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox2.Text)]].F2Max;
            time_nud_f2.Minimum = (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox2.Text)]].F2Min;
            time_nud_f2.Value = (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox2.Text)]].ord3_F2DnE;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox3.SelectedIndex == 8 || comboBox3.SelectedIndex == 11)
            //{
            //    MessageBox.Show("poi模式当前频段无rx");
            //    comboBox3.SelectedIndex = 0;
            //    return;
            //}
            _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox3.Text)]].ord3_imS;
            _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox3.Text)]].ord3_imE;
            rmax = cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox3.Text)]].RxMax;
            rmin = cul.ld[cul.BandCount[cul.BandNames.IndexOf(comboBox3.Text)]].RxMin;
            button9.Text = _rxs.ToString("0.00") + "-" + _rxe.ToString("0.00");
        }

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

        private void time_cb_step_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void time_cb_step_SelectedIndexChanged_1(object sender, EventArgs e)
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

    }
}
