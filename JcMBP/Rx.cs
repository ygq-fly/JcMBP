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
    public partial class Rx : Form
    {
        ClsUpLoad cul;
        NumericUpDown[] nuds;
        byte off_dutport = 0;
        double off_rx_loss = 0;
        public  bool isThreadStart = false;
        int band = 0;
        public Rx(ClsUpLoad cul)
        {
            InitializeComponent();
            this.cul = cul;
        }

        private void Rx_Load(object sender, EventArgs e)
        {
            if (ClsUpLoad._type == 2)
                rxoffset_btn_start_b.Visible = false;
            if (ClsUpLoad._type == 1)
            {
                rxoffset_btn_start_a.Text = "REV";
                rxoffset_btn_start_b.Text = "FWD";
            }
            OfftenMethod.LoadComboBox(cb_rxoffset_band, cul.BandNames);
            cb_rxoffset_band.SelectedIndex = 0;
            Label[] lables = new Label[]{label25,label27,label28,label29,label30,label31,
                                        label26,label38,label39,label37,label54,label50,label1};
            nuds = new NumericUpDown[]{nud_rxoffset_0,nud_rxoffset_1,nud_rxoffset_2,nud_rxoffset_3,
                                                        nud_rxoffset_4,nud_rxoffset_5,nud_rxoffset_6,nud_rxoffset_7,
                                                        nud_rxoffset_8,nud_rxoffset_9,nud_rxoffset_10,nud_rxoffset_11,nud_rxoffset_12};
            OfftenMethod.LoadLabel(lables, cul.AllBandNames);
            OfftenMethod.LoadOffect(nuds, cul.RxVal);
        }

        void run_rxoffset(byte byDutPort)
        {
            if (!isThreadStart)
            {
                isThreadStart = true;
                cb_rxoffset_band.Enabled = false;
                 off_dutport = 0;
                 off_rx_loss = 0;
                 band =cul.BandCount[cul.BandNames.IndexOf(cb_rxoffset_band.Text)];
                off_dutport = byDutPort;//端口
                off_rx_loss = OfftenMethod.GetOffectAndSet(cul.filenameB + band.ToString() + "_Specifics.ini", nuds, band, true);//获取offset

                if (MessageBox.Show("确认是否 开始 RX 校准！校准差损值: " + off_rx_loss.ToString(), "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    rxoffset_btn_start_a.BackColor = Color.White;//改变rx校准port1按钮颜色
                    rxoffset_btn_start_b.BackColor = Color.White;//改变rx校准port2按钮颜色   
                    rxoffset_btn_start_a.Enabled = true;
                    rxoffset_btn_start_b.Enabled = true;
                    cb_rxoffset_band.Enabled = true;
                    button2.Enabled = true;
                    isThreadStart = false;
                    return;
                }

                int rxcount = ClsJcPimDll.JcGetOffsetRxNum((byte)band);//读取校准次数
                if (rxcount < -10000)
                {
                    MessageBox.Show("数据库错误");//显示信息
                    isThreadStart = false;
                    return;
                }
                this.progress_offset_rx.Minimum = 0;//设置进度条最小值为0
                this.progress_offset_rx.Maximum = rxcount + 5;//设置进度条最大值
                this.progress_offset_rx.Value = 0;//设置进度条当前值

                if (byDutPort == 0)
                    rxoffset_btn_start_a.BackColor = Color.Green;//改变rx校准port1按钮颜色
                else
                    rxoffset_btn_start_b.BackColor = Color.Green;//改变rx校准port2按钮颜色

                //设置开关

                ClsJcPimDll.fnSetMeasBand((byte)band);//设置频段

                if (ClsJcPimDll.fnSetDutPort(byDutPort) <= -10000)//设置端口
                {
                    MessageBox.Show("开关设置错误！");
                    rxoffset_btn_start_a.BackColor = Color.White;//改变rx校准port1按钮颜色
                    rxoffset_btn_start_b.BackColor = Color.White;//改变rx校准port2按钮颜色   
                    rxoffset_btn_start_a.Enabled = true;
                    rxoffset_btn_start_b.Enabled = true;
                    cb_rxoffset_band.Enabled = true;
                    button2.Enabled = true;
                    isThreadStart = false;
                    return;
                }

                Thread.Sleep(300 + 200);//暂停
                button2.Enabled = false;//改变vco按钮
                Thread trd = new Thread(Start_offset_rx);//开启线程
                trd.IsBackground = true;
                trd.Start();
                //isThreadStart = true;
            }
        }

      

        void Start_offset_rx()
        {
            this.Invoke(new ThreadStart(delegate()
            {
                tb_offset_rx_log.Text = ("<<Start>>\r\n");//设置rx校准信息text
            }));
            byte[] err = new byte[256];
            int s = ClsJcPimDll.JcSetOffsetRx((byte)band, off_dutport, off_rx_loss,
                                      new ClsJcPimDll.Callback_Get_RX_Offset_Point(Callback_offset_rx));//开始rx校准
            if (s <= -10000)
            {
                ClsJcPimDll.JcGetError(err, 256);//获取错误
                MessageBox.Show(this, Encoding.ASCII.GetString(err));//显示错误
            }

            this.Invoke(new ThreadStart(delegate()
            {
                //if(s>-10000)
                //    MessageBox.Show("校准完成");
                this.tb_offset_rx_log.AppendText("<<Rx Offset Complete!>>");//添加text
                this.progress_offset_rx.Value = this.progress_offset_rx.Maximum;//进度条值为最大值
                rxoffset_btn_start_a.BackColor = Color.White;
                rxoffset_btn_start_b.BackColor = Color.White;
                rxoffset_btn_start_a.Enabled = true;
                rxoffset_btn_start_b.Enabled = true;
                cb_rxoffset_band.Enabled = true;
                button2.Enabled = true;
                if (s > -10000)
                    MessageBox.Show(this, "校准完成");//显示信息
            }));
            isThreadStart = false;

        }

        void Callback_offset_rx(double offset_freq, double Offset_val)
        {
            this.Invoke(new ThreadStart(delegate()
            {
                this.tb_offset_rx_log.AppendText("Rx Offset: " + offset_freq.ToString("0.00") + " , " + Offset_val.ToString("0.00") + "\r\n");//增加rx校准信息text
                this.progress_offset_rx.Value += 1;//进度条值加1
            }));
        }

        private void rxoffset_btn_start_a_Click(object sender, EventArgs e)
        {
            rxoffset_btn_start_a.Enabled = false;
            rxoffset_btn_start_b.Enabled = false;
            rxoffset_btn_start_a.BackColor = Color.Green;
            button2.Enabled = false;
            run_rxoffset(0);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vco_offect();
        }

        public void Vco_offect()
        {
            this.tb_offset_rx_log.Clear();
            button2.BackColor = Color.Green;//vco检测按钮
            button2.Enabled = false;//vco检测按钮
            rxoffset_btn_start_a.Enabled = false;//rx port1按钮
            rxoffset_btn_start_b.Enabled = false;//rx port2按钮
            Thread th = new Thread(thread_vcoOffect);//开启线程
            th.IsBackground = true;
            th.Start();
        }
        public void thread_vcoOffect()
        {
            double val = 0;
            this.Invoke(new ThreadStart(delegate
            {
                this.tb_offset_rx_log.Text = ("<<Start>>\r\n");
            }));
            int[] band = new int[cul.BandNames.Count];
            for (int i = 0; i < band.Length; i++)
            {

                band[i] = cul.BandCount[cul.BandNames.IndexOf(cb_rxoffset_band.Items[i].ToString())];
            }
            for (int i = 0; i < cul.BandNames.Count; i++)
            {
                int bands = cul.BandCount[cul.BandNames.IndexOf(cb_rxoffset_band.Items[i].ToString())];
                ClsJcPimDll.fnSetMeasBand((byte)bands);//设置频段
                
                if (ClsJcPimDll.fnSetDutPort(0) <= -10000)//设置端口
                {
                           MessageBox.Show("开关设置错误！");                
                    break;
                }
                Thread.Sleep(100);//暂停
                if (ClsJcPimDll.JcGetVcoDsp(ref val, (byte)(band[i] * 2)) == false)//检测vco
                {
                        MessageBox.Show(cul.AllBandNames[band[i]] + ": RX链路未检测到信号");
                        break;            
                }
                else
                {
                    //ClsJcPimDll.JcSetOffsetVco((byte)band[i], (byte)0, val);
                    if (ClsJcPimDll.JcSetOffsetVco((byte)band[i], (byte)0, val) <= -1000)//保存vco
                    {
                        MessageBox.Show("vco保存错误");
                    }
                    this.Invoke(new ThreadStart(delegate
                    {
                        this.tb_offset_rx_log.AppendText(cul.AllBandNames[band[i]] + "  PORT1  " +
                                                        "VCO : " + val.ToString("0.00") + "\r\n");//显示信息
                    }));
                }
                //============
                if (ClsJcPimDll.fnSetDutPort(1) <= -10000)//切换端口
                {
                       MessageBox.Show("开关设置错误！");
                    break;
                }
                Thread.Sleep(100);//暂停
                //ClsJcPimDll.JcGetVcoDsp(ref val, (byte)(band[i] * 2 + 1));//检测vco
                if (ClsJcPimDll.JcGetVcoDsp(ref val, (byte)(band[i] * 2 + 1)) == false)//检测vco
                {
                       MessageBox.Show(cul.AllBandNames[band[i]] + ": RX链路未检测到信号");
                    break;
                }
                else
                {
                    ClsJcPimDll.JcSetOffsetVco((byte)band[i], (byte)1, val);//切换端口
                    if (ClsJcPimDll.JcSetOffsetVco((byte)band[i], (byte)1, val) <= -1000)//保存vco
                    {
                        MessageBox.Show("vco保存错误");
                    }
                    this.Invoke(new ThreadStart(delegate
                    {

                        this.tb_offset_rx_log.AppendText(cul.AllBandNames[band[i]] + "  PORT2  " + "VCO : " + val.ToString("0.00") + "\r\n");//显示信息
                    }));
                }
            }
           

            this.Invoke(new ThreadStart(delegate
            {
                this.tb_offset_rx_log.AppendText("<<Vco Complete!>>");
                button2.Enabled = true;//rx页面vco检测按钮
                button2.BackColor = Color.White;//rx页面vco检测按钮
                rxoffset_btn_start_a.Enabled = true;//rx校准port1按钮
                rxoffset_btn_start_b.Enabled = true;//rx校准port2按钮
             
            }));
        }

        private void rxoffset_btn_start_b_Click(object sender, EventArgs e)
        {
            rxoffset_btn_start_a.Enabled = false;
            rxoffset_btn_start_b.Enabled = false;
            rxoffset_btn_start_b.BackColor = Color.Green;
            button2.Enabled = false;
            run_rxoffset(1);
        }

        private void nud_rxoffset_0_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_rxoffset_1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_rxoffset_2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_rxoffset_3_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_rxoffset_4_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_rxoffset_5_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_rxoffset_6_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_rxoffset_7_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_rxoffset_8_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_rxoffset_9_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_rxoffset_10_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_rxoffset_11_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }
    }
}
