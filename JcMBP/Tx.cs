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
    public partial class Tx : Form
    {
        ClsUpLoad cul;
        public  bool isThreadStart=false;
        byte _off_band = 0;          
        byte _off_dutport = 0;
        double  _off_tx_loss = 0;
        double _off_tx_pow = 43;
        NumericUpDown[] nuds;
        public Tx(ClsUpLoad cul)
        {
            InitializeComponent();
            this.cul = cul;
        }

        private void Tx_Load(object sender, EventArgs e)
        {
            tx_offset_pb.Image = Image.FromFile(Application.StartupPath + "\\Band\\发射校准.JPG");
            if (ClsUpLoad._type == 2||ClsUpLoad._type==1)
                txoffset_btn_start_b.Visible = false;
            OfftenMethod.LoadComboBox(cb_txoffset_band, cul.BandNames);
            cb_txoffset_band.SelectedIndex = 0;
            Label[] lables = new Label[]{label12,label15,label16,label17,label18,label19,
                                         label14,label41,label42,label40,label58,label56,label2};
            nuds = new NumericUpDown[]{nud_txoffset_0,nud_txoffset_1,nud_txoffset_2,nud_txoffset_3,
                                                        nud_txoffset_4,nud_txoffset_5,nud_txoffset_6,nud_txoffset_7,
                                                        nud_txoffset_8,nud_txoffset_9,nud_txoffset_10,nud_txoffset_11,nud_txoffset_12};
            OfftenMethod.LoadLabel(lables, cul.AllBandNames);
            OfftenMethod.LoadOffect(nuds, cul.TxVal);
        }

        private void txoffset_btn_start_a_Click(object sender, EventArgs e)
        {
            txoffset_btn_start_a.Enabled = false;
            txoffset_btn_start_b.Enabled = false;
            txoffset_btn_start_a.BackColor = Color.Green;
            cb_txoffset_band.Enabled = false;
            run_txoffset(0);
        }

        private void txoffset_btn_start_b_Click(object sender, EventArgs e)
        {
            txoffset_btn_start_a.Enabled = false;
            txoffset_btn_start_b.Enabled = false;
            txoffset_btn_start_b.BackColor = Color.Green;
            cb_txoffset_band.Enabled = false;
            run_txoffset(1);
        }

        void run_txoffset(byte byDutport)
        {
            if (!isThreadStart)
            {
                isThreadStart = true;
                _off_band = (byte)cul.BandCount[cul.BandNames.IndexOf(cb_txoffset_band.Text)];
             
                _off_dutport = byDutport;//获取端口

                _off_tx_loss = OfftenMethod.GetOffectAndSet(cul.filenameB + _off_band.ToString() + "_Specifics.ini", nuds, (int)_off_band, false);//获取offset
                if (MessageBox.Show("确认是否 开始 TX 校准！ 校准差损值: " + _off_tx_loss.ToString(), "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    txoffset_btn_start_a.BackColor = Color.White;//改变tx校准port1按钮颜色
                    txoffset_btn_start_b.BackColor = Color.White;//改变tx校准port2按钮颜色
                    txoffset_btn_start_a.Enabled = true;
                    txoffset_btn_start_b.Enabled = true;
                    cb_txoffset_band.Enabled = true;
                    isThreadStart = false;
                    return;
                }

                int txcount = ClsJcPimDll.JcGetOffsetTxNum(_off_band);//获取tx次数
                if (txcount < -10000)
                {
                    MessageBox.Show("数据库错误");//显示信息
                    isThreadStart = false;
                    return;
                }
                this.progress_offset_tx.Minimum = 0;//设置进度条最小值为0
                this.progress_offset_tx.Maximum = txcount * 2 + 5;//设置进度条最大值
                this.progress_offset_tx.Value = 0;//设置进度条当前值

                _off_tx_pow = Convert.ToDouble(this.nud_txoffset_pow.Value);//获取校准功率

                if (byDutport == 0)
                    txoffset_btn_start_a.BackColor = Color.Green;//改变tx校准端口1按钮颜色
                else
                    txoffset_btn_start_b.BackColor = Color.Green;//改变tx校准端口2按钮颜色



                //设置开关

                ClsJcPimDll.fnSetMeasBand(_off_band);//设置频段
                if (ClsJcPimDll.fnSetDutPort(_off_dutport) <= -10000)//设置端口
                {
                    MessageBox.Show(this, "开关设置错误！");
                    txoffset_btn_start_a.BackColor = Color.White;//改变tx校准port1按钮颜色
                    txoffset_btn_start_b.BackColor = Color.White;//改变tx校准port2按钮颜色
                    txoffset_btn_start_a.Enabled = true;
                    txoffset_btn_start_b.Enabled = true;
                    cb_txoffset_band.Enabled = true;
                    isThreadStart = false;
                    return;
                }

                Thread.Sleep(300);//暂停
                Thread trd = new Thread(Start_offset_tx);//开启线程
                trd.IsBackground = true;
                trd.Start();
            }
        }

        void Start_offset_tx()
        {
            this.Invoke(new ThreadStart(delegate()
            {
                tb_offset_tx_log.Text = ("<<Start>>\r\n");//tx校准text
            }));
            byte[] err = new byte[256];
            int s = ClsJcPimDll.JcSetOffsetTx(_off_band, _off_dutport, _off_tx_pow, _off_tx_loss,
                                      new ClsJcPimDll.Callback_Get_TX_Offset_Point(Callback_offset_tx));//开始tx校准
            if (s <= -10000)
            {
                ClsJcPimDll.JcGetError(err, 256);//获取错误
                this.Invoke(new ThreadStart(delegate()
          {
              MessageBox.Show(this, Encoding.ASCII.GetString(err));//显示错误
          }));
            }
            this.Invoke(new ThreadStart(delegate()
            {
                tb_offset_tx_log.AppendText("<<Tx Offset Complete!>>");//添加tx校准信息
                this.progress_offset_tx.Value = progress_offset_tx.Maximum;//进度条值设置为最大值
                txoffset_btn_start_a.BackColor = Color.White;//改变tx校准port1按钮颜色
                txoffset_btn_start_b.BackColor = Color.White;//改变tx校准port2按钮颜色
                txoffset_btn_start_a.Enabled = true;
                txoffset_btn_start_b.Enabled = true;
                cb_txoffset_band.Enabled = true;
                if (s > -10000)
                    MessageBox.Show(this, "校准完成");//显示信息
            }));

            isThreadStart = false;
        }

        void Callback_offset_tx(double offset_freq, double Offset_real_val, double Offset_dsp_val)
        {
            this.Invoke(new ThreadStart(delegate()
            {
                this.tb_offset_tx_log.AppendText("Tx Offset: " + offset_freq.ToString("0.00") + " , " +
                                                                 (Offset_real_val + Convert.ToDouble(nud_txoffset_pow.Value)).ToString("0.00") + " , " +
                                                                 (Convert.ToDouble(nud_txoffset_pow.Value) - Offset_dsp_val).ToString("0.00") + "\r\n");//添加tx校准信息
                this.progress_offset_tx.Value += 1;//进度条值加1
            }));
        }

        private void nud_txoffset_0_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_3_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_4_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_5_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_6_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_7_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_8_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_9_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_10_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_11_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_txoffset_pow_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void cb_txoffset_band_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
    }
}
