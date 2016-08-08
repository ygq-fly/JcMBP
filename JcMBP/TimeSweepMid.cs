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
    public partial class TimeSweepMid : Form
    {
       public   TestData testdata_;
        float _pim_limit = -110;
        float _pim_max = -10000;
        float _pim_min = 0;
        float current_pim_max = -10000;
        float current_pim_min = float.MaxValue;
        ClsUpLoad cul;
        public static bool jb_err = false;
        Form form;
        //public   DataSweep ds;
        Sweep sweep;
        string type = "0";
        FrmMain fm;
        public  bool isThreadStart = false;
        int currentSweepCont = 0;
        public TimeSweepMid(ClsUpLoad cul,FrmMain fm)
        {
            InitializeComponent();
            this.cul = cul;
            this.fm = fm;
            type = ClsUpLoad._type.ToString();
            numericUpDown2.Value = (decimal)_pim_limit;
            //time_dgvPim.Columns.Clear();
            //time_dgvPim.Columns.Add(new DataGridViewColumn());
            //time_dgvPim.Columns.Add(new DataGridViewColumn());
            //time_dgvPim.Columns.Add(new DataGridViewColumn());
            //time_dgvPim.Columns[0].HeaderText = "No.";
            //time_dgvPim.Columns[1].HeaderText = "Peak";
            //time_dgvPim.Columns[2].HeaderText = "Result";
            //time_dgvPim.Columns[0].Width = 100;
          
        }

        public TimeSweepMid()
        {
            InitializeComponent();
        }

        public void GoB(int tx1, int tx2, int rx)
        {
            fm.GoB(tx1, tx2, rx);
        }
        public void GoB2(int tx1, int tx2, int rx)
        {
            if (form != null)
            {
                if (ClsUpLoad.sm == SweepMode.Hw)
                {
                    TimeSweepLeft nf = (TimeSweepLeft)form;
                    nf.Cband(tx1, tx2, rx);
                }
                else if (ClsUpLoad.sm == SweepMode.Poi)
                {
                    PoiTimeSweepLeft nf = (PoiTimeSweepLeft)form;
                    nf.Cband(tx1, tx2, rx);
                }
                else
                {
                    NPTimeSweepLeft nf = (NPTimeSweepLeft)form;
                    nf.Cband(tx1, tx2, rx);
                }
            }
        }
        private void TimeSweepMid_Load(object sender, EventArgs e)
        {

            //ds = new DataSweep();
            //OfftenMethod.ToAddColumns(ds.dt);
            //OfftenMethod.ToAddColumns(ds.dtc);

            if (ClsUpLoad.sm == SweepMode.Hw)
                form = new TimeSweepLeft(cul,this);
            else if (ClsUpLoad.sm == SweepMode.Poi)
                form = new PoiTimeSweepLeft(cul,this);
            else
                form = new NPTimeSweepLeft(cul,this);
            OfftenMethod.SwitchWindow( this,form,panel1);
            form.Show();
            time_plot.MinValue = -150;//timeplot最大值
            time_plot.MaxValue = -30;//timeplot最小值
            time_plot.RealValue = -150;//timeplot实际值
            fm.CUHandle += new ChangeUint(ChangeUnit);
            fm.CLHandle += new ChangeLimit(Changelimit);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                testdata_.limit = _pim_limit = float.Parse(numericUpDown2.Value.ToString());
               //.limit=_pim_limit = float.Parse(numericUpDown2.Value.ToString());
               if (FreqSweepMid.isLoad)
               {
               
                   fm.Limit = Convert.ToSingle(numericUpDown2.Value);
               }
            }
            catch { }
            Main_SetLimit(_pim_limit);
        }

        void Main_SetLimit(float limit_dBm)
        {
            time_plot.Value = limit_dBm;//设置limint参数
            IniFile.SetFileName(Application.StartupPath + "\\JcConfig.ini");//设置文件名
            IniFile.SetString("Settings", "limit", limit_dBm.ToString());//保存limnt到配置文件
            //if (!isdbm)
            //    IniFile.SetString("Settings", "limit", (limit_dBm - (float)freq_nud_pow2.Value).ToString());//保存limnt到配置文件
        }

        public void Clone(DataSweep ds)
        {
            //this.ds = ds;
        }

        //普通测试
        //public void Start(Sweep s)
        //{

        //    isThreadStart = true;
        //    this.Invoke(new ThreadStart(delegate()
        //        {
        //            ds.dt.Clear();
        //            ds.dtc.Clear();
        //            _pim_max = float.MinValue;
        //            _pim_min = float.MaxValue;
        //            time_tb_log.Clear();
        //            if (fm.isdBm)
        //                time_dgvPim.DataSource = ds.dt;
        //            else
        //                time_dgvPim.DataSource = ds.dtc;
        //            time_lbl_limitResulte.Text = "PASS";
        //            time_lbl_limitResulte.ForeColor = Color.Lime;
        //        }));
        //    sweep = s;
        //    sweep.VcoHander += new ControlIni_Sweep_Vco(VcoHand);
        //    sweep.PowerHander += new ControlIni_Sweep_Pow(Powhand);
        //    sweep.Tx1Hander += new ControlIni_Sweep_Tx1(Tx1Hand);
        //    sweep.Tx2Hander += new ControlIni_Sweep_Tx2(Tx2Hand);
        //    sweep.StHander += new Sweep_Test(SweepControl);
        //    Ths();
        //    this.Invoke(new ThreadStart(delegate()
        //        {
        //            time_tb_log.AppendText("功放关闭\r\n");
        //        }));
        //    rem_jpg_data_t(ds);
        //   isThreadStart = false;
        //   sweep.VcoHander -= new ControlIni_Sweep_Vco(VcoHand);
        //   sweep.PowerHander -= new ControlIni_Sweep_Pow(Powhand);
        //   sweep.Tx1Hander -= new ControlIni_Sweep_Tx1(Tx1Hand);
        //   sweep.Tx2Hander -= new ControlIni_Sweep_Tx2(Tx2Hand);
        //   sweep.StHander -= new Sweep_Test(SweepControl);
        //}



        public void DataINIT()
        {
           
            jb_err = false;
            _pim_max = float.MinValue;
            _pim_min = float.MaxValue;
            current_pim_min = float.MaxValue;
            this.Invoke(new ThreadStart(delegate()
               {
                   button1.Enabled = false;
                   time_dgvPim.Enabled = false;
                   time_tb_pim_now.Text = "--";
                   time_tB_valMax.Text = "--";
                   time_tB_valMin.Text = "--";
                   time_tb_pim_now_dbc.Text = "--";
                   time_tB_valMax_dbc.Text = "--";
                   time_tB_valMin_dbc.Text = "--";
                   textBox1.Text = "--";
                   time_lbl_limitResulte.Text = "PASS";
                   time_lbl_limitResulte.ForeColor = Color.Lime;
                   time_tb_log.Clear();
               }));
        }

        public void LastINIT()
        {
            button1.Enabled = true;
            time_dgvPim.Enabled = true;
            MessageBox.Show("测试完成");
        }

        //刘敏要求
        public void Start(Sweep s,TestData testdata,int currentNum)
        {
            //isThreadStart = true;
                testdata_ = testdata;
                currentSweepCont = currentNum;
                isThreadStart = true;
                current_pim_max = float.MinValue;
                
                this.Invoke(new ThreadStart(delegate()
                {        
                    //time_tb_log.Clear();
                    if (fm.isdBm)
                        time_dgvPim.DataSource = testdata.surFaceData_dbm;
                    else
                        time_dgvPim.DataSource = testdata.surFaceData_dbc;

                }));
                sweep = s;

                sweep.VcoHander += new ControlIni_Sweep_Vco(VcoHand);
                sweep.PowerHander += new ControlIni_Sweep_Pow(Powhand);
                sweep.Tx1Hander += new ControlIni_Sweep_Tx1(Tx1Hand);
                sweep.Tx2Hander += new ControlIni_Sweep_Tx2(Tx2Hand);
                sweep.StHander += new Sweep_Test(SweepControl);
                
                

                if (Ths())
                {
                    double val = 0;
                    double val_dbc = 0;

                    for (int i = 0; i < time_dgvPim.Rows.Count; i++)
                    {
                        val += testdata_.pimDate[i].currentpimMax;
                        val_dbc += testdata_.pimDate[i].currentpimMax_dbc;
                    }
                    this.Invoke(new ThreadStart(delegate()
                       {

                           if (time_dgvPim.Rows.Count != 0)
                           {
                               time_tb_pim_now.Text = (val / time_dgvPim.Rows.Count).ToString("0.0");//当前互调值
                               time_tb_pim_now_dbc.Text = (val_dbc / time_dgvPim.Rows.Count).ToString("0.0");//当前互调值
                               if (testdata.surFaceData_dbm.Rows[currentSweepCont] != null)
                               {
                                   DataRow dt = testdata.surFaceData_dbm.Rows[currentSweepCont];
                                   DataRow dtc = testdata.surFaceData_dbc.Rows[currentSweepCont];
                                   if (fm.isdBm)
                                   {
                                       dt[2] = (Convert.ToSingle(dt[1]) - _pim_limit).ToString("0.0");
                                       dtc[2] = dt[2];
                                   }
                                   else
                                   {
                                       dtc[2] = (Convert.ToSingle(dtc[1]) - _pim_limit).ToString("0.0");
                                       dt[2] = dtc[2];
                                   }
                               }
                           }

                       }));
                    if (currentNum == ClsUpLoad.qiaoji_times - 1)
                    {
                        this.Invoke(new ThreadStart(delegate()
                        {
                            time_tb_log.AppendText("功放关闭\r\n");
                        }));
                        //rem_jpg_data_t(ds);

                        //isThreadStart = false;
                        //sweep.StHander -= new Sweep_Test(SweepControl);
                    }
                }
            else
                jb_err = true;
                sweep.VcoHander -= new ControlIni_Sweep_Vco(VcoHand);
                sweep.PowerHander -= new ControlIni_Sweep_Pow(Powhand);
                sweep.Tx1Hander -= new ControlIni_Sweep_Tx1(Tx1Hand);
                sweep.Tx2Hander -= new ControlIni_Sweep_Tx2(Tx2Hand);
                sweep.StHander -= new Sweep_Test(SweepControl);
        
        }

        public void Stop()
        {
            if (isThreadStart)
            {
                sweep.Stop();
                isThreadStart = false;
            }
        }

        bool   Ths()
        {   
           return  sweep.Ini();
         
        }

        void CreatScrollbar_t()
        {
            time_Scrollbar.Minimum = 0;
            time_Scrollbar.LargeChange = time_Scrollbar.Maximum / time_Scrollbar.Height + time_dgvPim.Size.Height;
            time_Scrollbar.SmallChange = 15;
            int a = time_dgvPim.Size.Height / 10 * time_dgvPim.Rows.Count;
            time_Scrollbar.Maximum = a;
            int intHeight = time_dgvPim.Size.Height / 10;
            time_Scrollbar.Value = time_dgvPim.FirstDisplayedScrollingRowIndex * intHeight;
        }

        void PowMessage(int s)
        {
            if (s <= -10000)
            {
                jb_err = true;
                if (s == -10004)
                {
                    MessageBox.Show(this, "信号源设置功率过大，请检查校准文件!");//显示错误信息
                }
                else
                    MessageBox.Show(this, "功率设置错误!");//显示错误信息
            }
        }

        //=====
        //void SweepControl(DataSweep ds)
        //{
        //    try
        //    {
        //        this.Invoke(new ThreadStart(delegate()
        //            {
        //                this.time_tb_show_tx1.Text = ds.sen_tx1.ToString("0.00");//控件显示tx1功率
        //                this.time_tb_show_tx2.Text = ds.sen_tx2.ToString("0.00");//控件显示tx1功率
        //                time_tb_pim_now.Text = ds.sxy.y.ToString("0.0");//当前互调值
        //                time_tb_pim_now_dbc.Text = (ds.sxy.y - 43).ToString("0.0");//当前互调值
        //                float currenty = 0;
        //                //if (fm.isdBm)
        //                currenty = ds.sxy.y;
        //                //else
        //                //currenty = ds.sxy.y -43;
        //                if (currenty > _pim_max)
        //                {
        //                    _pim_max = currenty;//互调最大值
        //                    time_tB_valMax.Text = _pim_max.ToString("0.0");//控件显示互调最大值
        //                    time_tB_valMax_dbc.Text = (_pim_max - 43).ToString("0.0");
        //                }
        //                if (currenty < _pim_min)
        //                {
        //                    _pim_min = currenty;//互调最小值
        //                    time_tB_valMin.Text = _pim_min.ToString("0.0");//控件显示互调最小值
        //                    time_tB_valMin_dbc.Text = (_pim_min - 43).ToString("0.0");
        //                }
        //                if (fm.isdBm)
        //                {
        //                    if (currenty > _pim_limit)
        //                    {
        //                        time_lbl_limitResulte.Text = "FAIL";
        //                        time_lbl_limitResulte.ForeColor = Color.Red;
        //                    }
        //                }
        //                else
        //                {
        //                    if (currenty - 43 > _pim_limit)
        //                    {
        //                        time_lbl_limitResulte.Text = "FAIL";
        //                        time_lbl_limitResulte.ForeColor = Color.Red;
        //                    }
        //                }
        //                if (fm.isdBm)
        //                    this.time_plot.RealValue = currenty;
        //                else
        //                    this.time_plot.RealValue = currenty - 43;
        //                OfftenMethod.ToNewRows(ds.dt, ds.sxy.currentCount,
        //                          (float)ds.sxy.f1, (float)ds.sen_tx1,
        //                          (float)ds.sxy.f2, (float)ds.sen_tx2,
        //                          ds.sxy.x, ds.sxy.y);//添加数据到表格
        //                OfftenMethod.ToNewRows(ds.dtc, ds.sxy.currentCount,
        //                          (float)ds.sxy.f1, (float)ds.sen_tx1,
        //                          (float)ds.sxy.f2, (float)ds.sen_tx2,
        //                          ds.sxy.x, ds.sxy.y - ds.pow1);//添加数据到表格
        //                time_dgvPim.FirstDisplayedScrollingRowIndex = time_dgvPim.Rows.Count - 1;//显示当前行
        //                CreatScrollbar_t();
        //            }));
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}


        void SweepControl(TestData testdata)
        {
            try
            {
                this.Invoke(new ThreadStart(delegate()
                {
                    int currenttime=testdata.pimDate[currentSweepCont].currentTime;
                    this.time_tb_show_tx1.Text = testdata.pimDate[currentSweepCont].sen_tx1.ToString("0.00");//控件显示tx1功率
                    this.time_tb_show_tx2.Text = testdata.pimDate[currentSweepCont].sen_tx2.ToString("0.00");//控件显示tx1功率
                    ////time_tb_pim_now.Text = testdata.pimDate[currentSweepCont].pimVal_dbm[currenttime].ToString("0.0");//当前互调值
                    ////time_tb_pim_now_dbc.Text = testdata.pimDate[currentSweepCont].pimVal_dbc[currenttime].ToString("0.0");//当前互调值
                    float currenty = 0;
                    
                    currenty = testdata.pimDate[currentSweepCont].pimVal_dbm[currenttime];
                 
                    if (currenty > _pim_max)
                    {
                        _pim_max = currenty;//互调最大值
                        time_tB_valMax.Text = _pim_max.ToString("0.0");//控件显示互调最大值
                        time_tB_valMax_dbc.Text = (_pim_max - TimeSweepLeft.st_pow).ToString("0.0");
                        if(fm.isdBm)
                        textBox1.Text = (_pim_max  - _pim_limit).ToString("0.0");
                          else
                            textBox1.Text = (_pim_max - TimeSweepLeft.st_pow - _pim_limit).ToString("0.0");
                        //if (testdata.surFaceData_dbm.Rows.Count >= currentSweepCont+1)
                        //{
                        //    DataRow dt = testdata.surFaceData_dbm.Rows[currentSweepCont];
                        //    DataRow dtc = testdata.surFaceData_dbc.Rows[currentSweepCont];
                        //    dt[1] = _pim_max.ToString("0.0");
                        //    dtc[1] = (_pim_max-43).ToString("0.0");
                        //}
                    }

                    if (currenty > current_pim_max)
                    {
                        current_pim_max = currenty;//互调最大值
                        if (testdata.surFaceData_dbm.Rows.Count >= currentSweepCont + 1)
                        {
                            DataRow dt = testdata.surFaceData_dbm.Rows[currentSweepCont];
                            DataRow dtc = testdata.surFaceData_dbc.Rows[currentSweepCont];
                            dt[1] = current_pim_max.ToString("0.0");
                            dtc[1] = (current_pim_max -TimeSweepLeft.st_pow).ToString("0.0");
                            testdata.pimDate[currentSweepCont].currentpimMax = current_pim_max;
                            testdata.pimDate[currentSweepCont].currentpimMax_dbc = current_pim_max - (float)TimeSweepLeft.st_pow;

                             
                        }
                    }


                    if (currenty < current_pim_min)
                    {
                        current_pim_min = currenty;//设置pim最大值
                        time_tB_valMin.Text = current_pim_min.ToString("0.0");//控件改变text显示互调最大值
                        time_tB_valMin_dbc.Text = (current_pim_min - testdata.tx1Date[currentSweepCont].pow).ToString("0.0");

                    }
                    //if (current_pim_max < current_pim_min)
                    //{
                    //    current_pim_min = current_pim_max;//互调最小值
                    //    time_tB_valMin.Text = current_pim_max.ToString("0.0");//控件显示互调最小值
                    //    time_tB_valMin_dbc.Text = (current_pim_max - TimeSweepLeft.st_pow).ToString("0.0");
                    //}
                    if (fm.isdBm)
                    {
                        if (currenty > _pim_limit)
                        {
                            time_lbl_limitResulte.Text = "FAIL";
                            time_lbl_limitResulte.ForeColor = Color.Red;
                            if (testdata.surFaceData_dbm.Rows.Count >= currentSweepCont + 1)
                            {
                                DataRow dt = testdata.surFaceData_dbm.Rows[currentSweepCont];
                                DataRow dtc = testdata.surFaceData_dbc.Rows[currentSweepCont];
                                dt[3] = "FAIL";
                                dtc[3] = "FAIL";
                                //dt[2] = "--";
                                //dtc[2] = "--";
                            }
                        }
                    }
                    else
                    {
                        if (currenty - TimeSweepLeft.st_pow > _pim_limit)
                        {
                            time_lbl_limitResulte.Text = "FAIL";
                            time_lbl_limitResulte.ForeColor = Color.Red;
                            if (testdata.surFaceData_dbm.Rows.Count >= currentSweepCont + 1)
                            {
                                DataRow dt = testdata.surFaceData_dbm.Rows[currentSweepCont];
                                DataRow dtc = testdata.surFaceData_dbc.Rows[currentSweepCont];
                                dt[3] = "FAIL";
                                dtc[3] = "FAIL";
                            }
                        }
                    }
                    if (fm.isdBm)
                        this.time_plot.RealValue = currenty;
                    else
                        this.time_plot.RealValue = currenty - (float)TimeSweepLeft.st_pow;

                    int m=testdata.pimDate[currentSweepCont].currentTime+1;
                    if (m == 1)
                    {
                        OfftenMethod.ToNewRows(testdata.surFaceData_dbm, currentSweepCont+1,
                                             _pim_max,"--", time_lbl_limitResulte.Text);//添加数据到表格

                        OfftenMethod.ToNewRows(testdata.surFaceData_dbc, currentSweepCont+1,
                                         _pim_max - (float)TimeSweepLeft.st_pow, "--", time_lbl_limitResulte.Text);//添加数据到表格

                        testdata.pimDate[currentSweepCont].currentpimMax = _pim_max;
                        testdata.pimDate[currentSweepCont].currentpimMax_dbc = _pim_max - (float)TimeSweepLeft.st_pow;
                    }
     
                    OfftenMethod.ToNewRows(testdata.pimDate[currentSweepCont].dt_dbm, 
                                            m, 
                                            testdata.pimDate[currentSweepCont].currentTestF1,
                                            testdata.pimDate[currentSweepCont].sen_tx1,
                                            testdata.pimDate[currentSweepCont].currentTestF2, 
                                            testdata.pimDate[currentSweepCont].sen_tx1,
                                             testdata.pimDate[currentSweepCont].pimFreq[m - 1], 
                                             testdata.pimDate[currentSweepCont].pimVal_dbm[m - 1]);//添加数据到表格
                    OfftenMethod.ToNewRows(testdata.pimDate[currentSweepCont].dt_dbc, 
                                            m,
                                            testdata.pimDate[currentSweepCont].currentTestF1,
                                          testdata.pimDate[currentSweepCont].sen_tx1,
                                          testdata.pimDate[currentSweepCont].currentTestF2,
                                          testdata.pimDate[currentSweepCont].sen_tx1,
                                           testdata.pimDate[currentSweepCont].pimFreq[m - 1], 
                                           testdata.pimDate[currentSweepCont].pimVal_dbc[m - 1]);//添加数据到表格


                 
                    

                    if (time_dgvPim.Rows.Count >= 1)
                    {
                        time_dgvPim.FirstDisplayedScrollingRowIndex = time_dgvPim.Rows.Count - 1;//显示当前行
                        time_dgvPim.Rows[time_dgvPim.Rows.Count - 1].Selected = true;
                    }


                    CreatScrollbar_t();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void Powhand(int s)
        {
            this.Invoke(new ThreadStart(delegate()
                {
                    //this.time_tb_log.AppendText("功率设置错误!\r\n");
                    PowMessage(s);
                    this.time_tb_log.AppendText("开始设置功率\r\n");
                    this.time_tb_log.AppendText("开始设置频谱\r\n");
                    this.time_tb_log.AppendText("功放开启\r\n");
                }));
         
        }


        void VcoHand(bool isVco, double real_vco,double off_vco)
        {
            if (ClsUpLoad._vco)
            {
                this.Invoke(new ThreadStart(delegate()
                {
                    this.time_tb_log.AppendText("Now_vco: " + real_vco.ToString("0.00") + " , Offset_vco: " + off_vco.ToString("0.00") + "\r\n");//添加点频vco检测信息text
                }));
            }
            if (isVco)
            {
                this.Invoke(new ThreadStart(delegate()
                {
                    time_tb_rxPass.Text = "PASS";
                }));
            }
            else
            {
                this.Invoke(new ThreadStart(delegate()
                {
                    this.time_tb_rxPass.Text = "FAIL";
                    this.time_tb_rxPass.ForeColor = Color.Red;
                    this.time_tb_log.AppendText("错误： VCO未检测到!" + "\r\n");
                    this.time_tb_log.AppendText("关闭功放\r\n");
                    jb_err = true;
                }));
            }
            if (isVco == false)
            {
                this.Invoke(new ThreadStart(delegate()
                {
                    jb_err = true;
                    MessageBox.Show(this, "错误： VCO未检测到! 请检查RX接收链路");
                }));
            }
            else
            {
                this.Invoke(new ThreadStart(delegate()
                {
                    this.time_tb_log.AppendText("VCO: 正常！" + "\r\n");
                    this.time_tb_log.AppendText("检测功放TX1\r\n");
                }));
            }
        }

        void Tx1Hand(int s, ref double sen_tx1)
        {
            if (s <= -10000&&ClsUpLoad._checkPow)
            {
                jb_err = true;
                if (s == -10018)
                {
                    this.Invoke(new ThreadStart(delegate()
                {
                    this.time_tb_log.AppendText("错误： Tx1未检测到功率!" + "\r\n");
                    MessageBox.Show(this, "错误： Tx1未检测到功率！请检功率输出！");
                }));
                }
                else
                {
                    this.Invoke(new ThreadStart(delegate()
                    {
                        this.time_tb_log.AppendText("错误： TX1功率偏差过大!" + "\r\n");
                        MessageBox.Show(this, "错误： TX1功率偏差过大!");
                    }));
                }
                this.Invoke(new ThreadStart(delegate()
                {
                    this.time_tb_log.AppendText("关闭功放\r\n");
                }));
            }
            else
            {
                sen_tx1 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX1);//tx1显示功率
                testdata_.pimDate[currentSweepCont].sen_tx1 =Convert.ToSingle(sen_tx1);
                this.Invoke(new ThreadStart(delegate()
                {
                    this.time_tb_log.AppendText("开始调整TX1\r\n");
                    this.time_tb_show_tx1.Text = testdata_.pimDate[currentSweepCont].sen_tx1.ToString("0.00");//显示功率
                    this.time_tb_log.AppendText("TX1 =: " + testdata_.pimDate[currentSweepCont].sen_tx1.ToString("0.00") + "\r\n");
                }));
            }
        }

        void Tx2Hand(int s, ref double sen_tx2)
        {
            this.Invoke(new ThreadStart(delegate()
            {
                this.time_tb_log.AppendText("检测功放TX2\r\n");
            }));
            if (s <= -10000&&ClsUpLoad._checkPow)
            {
                jb_err = true;
                if (s == -10018)
                {
                    this.Invoke(new ThreadStart(delegate()
                    {
                        this.time_tb_log.AppendText("错误： Tx2未检测到功率!" + "\r\n");
                        MessageBox.Show(this, "错误： Tx2未检测到功率！请检功率输出！");
                    }));
                }
                else
                {
                    this.Invoke(new ThreadStart(delegate()
                   {
                       this.time_tb_log.AppendText("错误： TX2功率偏差过大!" + "\r\n");
                       MessageBox.Show(this, "错误： TX2功率偏差过大!");
                   }));
                }
                this.Invoke(new ThreadStart(delegate()
                {
                    this.time_tb_log.AppendText("关闭功放\r\n");
                }));
            }
            else
            {            
                sen_tx2 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX2);//读取tx2显示功率
                //ds.sen_tx2 = sen_tx2;
                testdata_.pimDate[currentSweepCont].sen_tx2 = Convert.ToSingle(sen_tx2);
                this.Invoke(new ThreadStart(delegate()
                {
                    this.time_tb_log.AppendText("开始调整TX2\r\n");
                    this.time_tb_show_tx2.Text = testdata_.pimDate[currentSweepCont].sen_tx2.ToString("0.00");//显示功率
                    this.time_tb_log.AppendText("TX2 =: " + testdata_.pimDate[currentSweepCont].sen_tx2.ToString("0.00") + "\r\n");
                }));
            }
        }

        private void time_Scrollbar_Scroll(object sender, EventArgs e)
        {
            try
            {
                //计算滚动条长度
                int int_Hegiht = time_dgvPim.Size.Height / 10;
                int index = 10;
                index = time_Scrollbar.Value / int_Hegiht;
                if (index + 10 + 1 == time_dgvPim.Rows.Count)
                {
                    index = index + 1;
                }
                time_dgvPim.FirstDisplayedScrollingRowIndex = index;  //设置第一行显示 
            }
            catch { }
        }

        private void time_dgvPim_Scroll(object sender, ScrollEventArgs e)
        {
            int intHeight = time_dgvPim.Size.Height / 10;
            time_Scrollbar.Value = time_dgvPim.FirstDisplayedScrollingRowIndex * intHeight;
        }

        private void numericUpDown2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (fm.isdBm)
            {
                fm.IsdBm = false;
            }
            else
            {
                fm.IsdBm = true;
            }
        }
        //=====
        void Changelimit()
        {
            //fm.limit = Convert.ToSingle(numericUpDown2.Value);
            numericUpDown2.Value = Convert.ToDecimal(fm.Limit);
  
        }
        void ChangeUnit()
        {
            if (fm.isdBm)
            {
                button1.Text = "dBc";
                label66.Text = "Limit(dBc):";
                label68.Text = "最大(dBc):";
                label67.Text = "最小(dBc):";
                label21.Text = "平均(dBc):";
                //numericUpDown2.Value -= 43;
                if ( testdata_ != null)
                time_dgvPim.DataSource = testdata_.surFaceData_dbc;
                time_plot.MinValue = -193;//timeplot最大值
                time_plot.MaxValue = -73;//timeplot最小值
                time_dgvPim.Columns[1].HeaderText = "Peak(dBc)";
                ShowPimValue(false);
            }
            else
            {
                button1.Text = "dBm";
                label66.Text = "Limit(dBm):";
                label68.Text = "最大(dBm):";
                label67.Text = "最小(dBm):";
                label21.Text = "平均(dBm):";
                //numericUpDown2.Value += 43;
                if ( testdata_ != null)
                time_dgvPim.DataSource = testdata_.surFaceData_dbm;
                time_plot.MinValue = -150;//timeplot最大值
                time_plot.MaxValue = -30;//timeplot最小值
                time_dgvPim.Columns[1].HeaderText = "Peak(dBm)";
                ShowPimValue(true);
            }
        }

        void ShowPimValue(bool dbm)
        {
            time_tb_pim_now.Visible = dbm;
            time_tB_valMax.Visible = dbm;
            time_tB_valMin.Visible = dbm;
            time_tb_pim_now_dbc.Visible = !dbm;
            time_tB_valMax_dbc.Visible = !dbm;
            time_tB_valMin_dbc.Visible = !dbm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fm.isdBm)
            {
                numericUpDown2.Value -= Convert.ToDecimal(TimeSweepLeft.st_pow);
                fm.IsdBm = false;
            }
            else
            {
                numericUpDown2.Value += Convert.ToDecimal(TimeSweepLeft.st_pow);
                fm.IsdBm = true;
            }
        }

        /// <summary>
        /// 记录扫描jpg图和数据
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ds"></param>
        void rem_jpg_data_t( DataSweep ds)
        {
            this.Invoke(new ThreadStart(delegate
            {
                ds.sxy.str_data = "";
                ds.sxy.image1 = OfftenMethod.SaveImage(groupBox18);//保存图形到内存
                ds.sxy.image2 = OfftenMethod.SaveImage(groupBox17);//保存图形到内存
                this.Refresh();
                    ds.sxy.str_data +=  "   点频模式\r\n";
                    ds.sxy.sweep_data_header =  "   点频模式\r\n\r\n";
                    ds.sxy.str_data += "F1: " + ds.freq1s.ToString() + "MHz" + " (" + cul.AllBandNames[ds.tx1] + ")\r\n";
                    ds.sxy.str_data += "F2: " + ds.freq2e.ToString() + "MHz" + " (" + cul.AllBandNames[ds.tx2] + ")\r\n";
                    ds.sxy.str_data += "Rx: " + cul.ld[ds.rx].ord3_imS.ToString() + " - " + cul.ld[ds.rx].ord3_imE.ToString() + "MHz" + " (" + cul.AllBandNames[ds.rx] + ")\r\n";
                    ds.sxy.str_data += "Power: " + ds.pow1.ToString() + "dBm  ";
                    ds.sxy.str_data += "Times: " + ds.time1.ToString() + "\r\n";
                
                ds.sxy.str_data += "Order: ";
                ds.sxy.str_data += OfftenMethod.PimFormula(ds.imCo1, ds.imCo2, ds.imLow, ds.imLess);
            }));
        }

        private void time_dgvPim_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SingleTestData std;
            if (fm.isdBm) std = new SingleTestData(testdata_.pimDate[time_dgvPim.CurrentRow.Index].dt_dbm,fm.isdBm);
            else std = new SingleTestData(testdata_.pimDate[time_dgvPim.CurrentRow.Index].dt_dbc,fm.isdBm);
            std.ShowDialog();
        }
    }
   
}
