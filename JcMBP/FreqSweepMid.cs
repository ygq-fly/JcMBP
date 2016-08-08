
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using jcXY2dPlotEx;
namespace JcMBP
{


    //public delegate 
    public partial class FreqSweepMid : Form
    {
        public bool isThreadStart = false;
        public static bool jb_err = false;
        public static bool isLoad = false;
        int curr_row = 0;
        Form form;
        ClsUpLoad cul;
        int dbm_y = -140;
        int dbm_y_e = -80;
        int dbc_y = -183;
        int dbc_y_e = -123;
       //singleSweepDataResult
       //   List<singleSweepDataResult>  JiaobenSweepDatRult =new 
        //public  DataSweep ds;

       public TestData testdata_;
        int currentSweepCont = 0;
        int isFirstAdd = 0;

        public  List<DataSweep> ds_arr=new List<DataSweep>();
        Sweep sweep=null;
        int getnum = 0;
        float _pim_max = float.MinValue;
        float _pim_min = float.MaxValue;
        float current_pim_max = float.MinValue;
        float current_pim_min = float.MaxValue;
        float _pim_limit = -110;
        string type = "0";
        
        FrmMain fm;
        public FreqSweepMid(ClsUpLoad cul,FrmMain fm)
        {
            InitializeComponent();
            this.fm = fm;
            this.cul = cul;
            type = ClsUpLoad._type.ToString();

            //freq_dgvPim.Columns.Clear();
            //freq_dgvPim.Columns.Add(new DataGridViewColumn());
            //freq_dgvPim.Columns.Add(new DataGridViewColumn());
            //freq_dgvPim.Columns.Add(new DataGridViewColumn());
            //freq_dgvPim.Columns[0].HeaderText = "No.";
            //freq_dgvPim.Columns[1].HeaderText = "Peak";
            //freq_dgvPim.Columns[2].HeaderText = "Result";
            //freq_dgvPim.Columns[0].Width = 100;
        }

        public FreqSweepMid()
        {
            InitializeComponent();
        }

        public void GoB(int tx1, int tx2, int rx)
        {
            if (form != null)
            {
                 if (ClsUpLoad.sm == SweepMode.Hw)
                 {
                     FreqSweepLeft nf = (FreqSweepLeft)form;
                     nf.Cband(tx1, tx2, rx);
                 }
                 else if (ClsUpLoad.sm == SweepMode.Poi)
                 {
                     PoiFreqSweepLeft nf = (PoiFreqSweepLeft)form;
                     nf.Cband(tx1, tx2, rx);
                 }
                 else
                 {
                     NPFreqSweepLeft nf = (NPFreqSweepLeft)form;
                     nf.Cband(tx1, tx2, rx);
                 }
            }
        }

        public void GoB2(int tx1, int tx2, int rx)
        {
            fm.GoB2(tx1, tx2, rx);
        }

        private void FreqSweepMid_Load(object sender, EventArgs e)
        {
            isLoad = true;
            //ds = new DataSweep();                   
            if (ClsUpLoad.sm == SweepMode.Hw)
                form = new FreqSweepLeft(cul,this);
            else if (ClsUpLoad.sm == SweepMode.Poi)
                form = new PoiFreqSweepLeft(cul,this);
            else
                form = new NPFreqSweepLeft(cul,this);
            OfftenMethod.SwitchWindow(this, form, panel1);
            form.Show();
            PlotInfo();
            numericUpDown2.Value = (decimal)_pim_limit;
            fm.CUHandle += new ChangeUint(ChangeUnit);
            fm.CLHandle += new ChangeLimit(ChangeLimit);
        }

        /// <summary>
        /// 初始化坐标控件
        /// </summary>
        void PlotInfo()
        {
            freq_plot.SetAlwaysMinorLine(true);
            //上扫频，扫描线
            freq_plot.SetChannelIcon(0, CurveIconStyle.cisSolidDiamond, true);
            //下扫频。
            freq_plot.SetChannelIcon(1, CurveIconStyle.cisSolidDiamond, true);
            //poi 新增上扫频
            freq_plot.SetChannelIcon(2, CurveIconStyle.cisSolidDiamond, true);
            //poi 下扫频
            freq_plot.SetChannelIcon(3, CurveIconStyle.cisSolidDiamond, true);
            freq_plot.SetChannelIcon(4, CurveIconStyle.cisSolidDiamond, true);
            //下扫频。
            freq_plot.SetChannelIcon(5, CurveIconStyle.cisSolidDiamond, true);
            //poi 新增上扫频
            freq_plot.SetChannelIcon(6, CurveIconStyle.cisSolidDiamond, true);
            //poi 下扫频
            freq_plot.SetChannelIcon(7, CurveIconStyle.cisSolidDiamond, true);

            freq_plot.SetChannelColor(0, Color.Yellow);//设置通道颜色
            freq_plot.SetChannelColor(1, Color.Red);//设置通道颜色
            freq_plot.SetChannelColor(2, Color.LawnGreen);//设置通道颜色
            freq_plot.SetChannelColor(3, Color.Pink);//设置通道颜色
            freq_plot.SetChannelColor(4, Color.Yellow);//设置通道颜色
            freq_plot.SetChannelColor(5, Color.Red);//设置通道颜色
            freq_plot.SetChannelColor(6, Color.LawnGreen);//设置通道颜色
            freq_plot.SetChannelColor(7, Color.Pink);//设置通道颜色

            freq_plot.SetMarkColor(0, Color.Orange);//设置通道mark颜色
            freq_plot.SetMarkColor(1, Color.Orange);//设置通道mark颜色
            freq_plot.SetChannelVisible(0, true);//设置通道是否显示
            freq_plot.SetChannelVisible(1, true);//设置通道是否显示
            freq_plot.SetChannelVisible(4, false);//设置通道是否显示
            freq_plot.SetChannelVisible(5, false);//设置通道是否显示
            freq_plot.SetChannelVisible(6, false);//设置通道是否显示
            freq_plot.SetChannelVisible(7, false);//设置通道是否显示
            if (  ClsUpLoad._portHole== 4)
            {
                freq_plot.SetChannelVisible(2, true);//设置通道是否显示
                freq_plot.SetChannelVisible(3, true);//设置通道是否显示
            }
            freq_plot.SetSmoothing(true);
            freq_plot.Resume();       
            freq_plot.MajorLineWidth = freq_plot.MajorLineWidth;
        }

        private void numericUpDown2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        /// <summary>
        /// 改变limit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                testdata_.limit = _pim_limit = float.Parse(numericUpDown2.Value.ToString());
              
                fm.Limit = Convert.ToSingle(numericUpDown2.Value.ToString());
               
            }
            catch { }
            Main_SetLimit(_pim_limit);
        }

        /// <summary>
        /// 更新控件和保存limit
        /// </summary>
        /// <param name="limit_dBm"></param>
        void Main_SetLimit(float limit_dBm)
        {      
            freq_plot.SetLimitEnalbe(true, limit_dBm, Color.White);//设置控件limit
            freq_plot.MajorLineWidth = freq_plot.MajorLineWidth;
            
            IniFile.SetFileName(Application.StartupPath + "\\JcConfig.ini");//设置文件名
            IniFile.SetString("Settings", "limit", limit_dBm.ToString());//保存limnt到配置文件
            //if (!isdbm)
            //    IniFile.SetString("Settings", "limit", (limit_dBm - (float)ds.pow1).ToString());//保存limnt到配置文件
        }

        /// <summary>
        /// 功率检测
        /// </summary>
        /// <param name="s"></param>
        void Powhand_f(int s)
        {
            if (s <= -10000)
            {
                this.Invoke(new ThreadStart(delegate()
                {
                    if (s == -10004)
                    {
                        MessageBox.Show(this, "信号源设置功率过大，请检查校准文件!");//显示错误信息
                    }
                    else
                        MessageBox.Show(this, "功率设置错误!");//显示错误信息
                }));
                jb_err = true;
            }
        }

        /// <summary>
        /// vco检测
        /// </summary>
        /// <param name="isVco"></param>
        /// <param name="real_vco"></param>
        /// <param name="off"></param>
        void VcoHand(bool isVco, double real_vco,double off)
        {
            this.Invoke(new ThreadStart(delegate
           {
               if (isVco)
               {

                   this.time_tb_rxPass.Text = "PASS";
               }
               else
               {
                   this.time_tb_rxPass.Text = "FAIL";
                   this.time_tb_rxPass.ForeColor = Color.Red;
               }
               if (isVco == false)
               {
                   MessageBox.Show(this, "错误： VCO未检测到! 请检查RX接收链路");
                   isThreadStart = false;
                   jb_err = true;
               }
           }));
        }

        /// <summary>
        /// tx1检测
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sen_tx1"></param>
        void Tx1Hand(int s, ref double sen_tx1)
        {
               if (s <= -10000&&ClsUpLoad._checkPow)
               {
                    this.Invoke(new ThreadStart(delegate
                   {
                       if (s == -10018)
                       {
                           MessageBox.Show(this, "错误： 未检测到功率！请检功率输出！");
                           isThreadStart = false;
                       }
                       else
                       {
                           MessageBox.Show(this, "错误： TX1功率偏差过大!");
                           isThreadStart = false;
                       }
                   }));
                    jb_err = true;
               }
               else
               {
                   sen_tx1 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX1);//tx1显示功率
                   double r = sen_tx1;
                   testdata_.pimDate[currentSweepCont].sen_tx1 = Convert.ToSingle(r);
                   this.Invoke(new ThreadStart(delegate
                    {
                        this.time_tb_show_tx1.Text = r.ToString("0.00");//显示功率    
                    }));
               }
        }

        //tx2检测
        void Tx2Hand(int s, ref double sen_tx2)
        {
               if (s <= -10000&&ClsUpLoad._checkPow)
               {
                    this.Invoke(new ThreadStart(delegate
                   {
                       if (s == -10018)
                       {
                           MessageBox.Show(this, "错误： 未检测到功率！请检功率输出！");
                           isThreadStart = false;
                       }
                       else
                       {
                           MessageBox.Show(this, "错误： TX2功率偏差过大!");
                           isThreadStart = false;
                       }
                   }));
                    jb_err = true;
                    return;
               }
               else
               {
                   sen_tx2 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX2);//读取tx2显示功率
                   double r = sen_tx2;
                   testdata_.pimDate[currentSweepCont].sen_tx2 = Convert.ToSingle(r);
                   this.Invoke(new ThreadStart(delegate
           {
               this.time_tb_show_tx2.Text = r.ToString("0.00");//设置显示功率text
           }));
               }
        }

        /// <summary>
        /// 扫描数据更新
        /// </summary>
        /// <param name="ds"></param>
        void SweepControl(TestData testdata)
        {
            float currenty = 0;
            int currenttime = testdata.pimDate[currentSweepCont].currentTime;
            
            this.Invoke(new ThreadStart(delegate
           {
               int length = testdata.pimDate[currentSweepCont].pimFreq.Count-1;//更具存入的互调值的数组的长度来计算当前的点 
               this.time_tb_show_tx1.Text = testdata.pimDate[currentSweepCont].sen_tx1.ToString("0.00");//控件显示tx1功率
               this.time_tb_show_tx2.Text = testdata.pimDate[currentSweepCont].sen_tx2.ToString("0.00");//控件显示tx2功率

               //if (testdata.pimDate[currentSweepCont].pimFreq[length] <= testdata.rxDate[currentSweepCont].currentRxe &&
               //    testdata.pimDate[currentSweepCont].pimFreq[length] >= testdata.rxDate[currentSweepCont].currentRxs)
               //{
                
                   currenty = testdata.pimDate[currentSweepCont].pimVal_dbm[length];
                 
               //}
               //else
               //{
               //    testdata.pimDate[currentSweepCont].pimVal_dbm[length] = -200;
               //    currenty = -200;
               //}
              
               //if (fm.isdBm)

                
               //else
               //    currenty = (float)ds.sxy.y - 43;
               if (currenty > _pim_max)
               {
                   _pim_max = currenty;//设置pim最大值
                   time_tB_valMax.Text = _pim_max.ToString("0.0");//控件改变text显示互调最大值
                   time_tB_valMax_dbc.Text = (_pim_max - testdata.tx1Date[currentSweepCont].pow).ToString("0.0");
                   if(fm.isdBm)
                   textBox1.Text = (_pim_max  - _pim_limit).ToString("0.0");
                   else
                    textBox1.Text = (_pim_max - testdata.tx1Date[currentSweepCont].pow - _pim_limit).ToString("0.0");

               }

               if (currenty > current_pim_max )
               {
                    current_pim_max = currenty;//设置pim最大值
                   if (testdata.surFaceData_dbm.Rows.Count >= currentSweepCont + 1)
                   {
                       DataRow dt = testdata.surFaceData_dbm.Rows[currentSweepCont];
                       DataRow dtc = testdata.surFaceData_dbc.Rows[currentSweepCont];
                       dt[1] = current_pim_max.ToString("0.0");
                       dtc[1] = (current_pim_max - (float)FreqSweepLeft.st_pow).ToString("0.0");
                       testdata.pimDate[currentSweepCont].currentpimMax = current_pim_max;
                       testdata.pimDate[currentSweepCont].currentpimMax_dbc = current_pim_max - (float)FreqSweepLeft.st_pow;
                      
                   }
               }

               if (currenty < current_pim_min)
               {
                   current_pim_min = currenty;//设置pim最大值
                   time_tB_valMin.Text = current_pim_min.ToString("0.0");//控件改变text显示互调最大值
                   time_tB_valMin_dbc.Text = (current_pim_min - testdata.tx1Date[currentSweepCont].pow).ToString("0.0");

               }

               //if (current_pim_max < current_pim_min )
               //{
               //    current_pim_min = current_pim_max;//设置pim最小值
               //    time_tB_valMin.Text = current_pim_min.ToString("0.0");//控件改变text显示互调最小值
               //    time_tB_valMin_dbc.Text = (current_pim_min - (float)FreqSweepLeft.st_pow).ToString("0.0");
               //}
               if (fm.isdBm)
               {
                   if (currenty > _pim_limit)
                   {
                       time_lbl_limitResulte.Text = "FAIL";//互调值大于limit改变控件text
                       time_lbl_limitResulte.ForeColor = Color.Red;
                       if (testdata.surFaceData_dbm.Rows.Count >= currentSweepCont+1)
                       {
                           DataRow dt = testdata.surFaceData_dbm.Rows[currentSweepCont];
                           DataRow dtc = testdata.surFaceData_dbc.Rows[currentSweepCont];
                           dt[3] = "FAIL";
                           dtc[3] = "FAIL";
                       }
                   }
               }
               else
               {
                   if (currenty - (float)FreqSweepLeft.st_pow > _pim_limit )
                   {
                       time_lbl_limitResulte.Text = "FAIL";//互调值大于limit改变控件text
                       time_lbl_limitResulte.ForeColor = Color.Red;
                       if (testdata.surFaceData_dbm.Rows.Count >= currentSweepCont+1)
                       {
                           DataRow dt = testdata.surFaceData_dbm.Rows[currentSweepCont];
                           DataRow dtc = testdata.surFaceData_dbc.Rows[currentSweepCont];
                           dt[3] = "FAIL";
                           dtc[3] = "FAIL";
                       }
                   }
               }

               int freqlength = testdata.pimDate[currentSweepCont].pimFreq.Count;
               PointF pf = new PointF(testdata.pimDate[currentSweepCont].pimFreq[freqlength-1], testdata.pimDate[currentSweepCont].pimVal_dbm[freqlength-1]);
               PointF pfc = new PointF(testdata.pimDate[currentSweepCont].pimFreq[freqlength-1], testdata.pimDate[currentSweepCont].pimVal_dbc[freqlength-1]);
               ChangeY(testdata.pimDate[currentSweepCont].pimVal_dbm[freqlength-1]);
               this.freq_plot.Add(new PointF[1] { pf }, testdata.pimDate[currentSweepCont].currentPort, length+1);//坐标控件添加点
               this.freq_plot.Add(new PointF[1] { pfc }, testdata.pimDate[currentSweepCont].currentPort + 4, length + 1);//坐标控件添加点
               this.freq_plot.MajorLineWidth = this.freq_plot.MajorLineWidth;

               int m = length + 1;

               if (isFirstAdd==0)
               {
                   isFirstAdd++;
                   OfftenMethod.ToNewRows(testdata.surFaceData_dbm, currentSweepCont+1,
                                               currenty,"--", time_lbl_limitResulte.Text);//添加数据到表格
                   OfftenMethod.ToNewRows(testdata.surFaceData_dbc, currentSweepCont+1,
                                            currenty - (float)FreqSweepLeft.st_pow,"--", time_lbl_limitResulte.Text);//添加数据到表格
                   testdata.pimDate[currentSweepCont].currentpimMax = _pim_max;
                   testdata.pimDate[currentSweepCont].currentpimMax_dbc = _pim_max - (float)FreqSweepLeft.st_pow;

               }
               OfftenMethod.ToNewRows(testdata.pimDate[currentSweepCont].dt_dbm, m, testdata.pimDate[currentSweepCont].currentTestF1,
                                   testdata.pimDate[currentSweepCont].sen_tx1, testdata.pimDate[currentSweepCont].currentTestF2, testdata.pimDate[currentSweepCont].sen_tx1,
                                    testdata.pimDate[currentSweepCont].pimFreq[m - 1], testdata.pimDate[currentSweepCont].pimVal_dbm[m - 1]);//添加数据到表格
               OfftenMethod.ToNewRows(testdata.pimDate[currentSweepCont].dt_dbc, m, testdata.pimDate[currentSweepCont].currentTestF1,
                                 testdata.pimDate[currentSweepCont].sen_tx1, testdata.pimDate[currentSweepCont].currentTestF2, testdata.pimDate[currentSweepCont].sen_tx1,
                                  testdata.pimDate[currentSweepCont].pimFreq[m - 1], testdata.pimDate[currentSweepCont].pimVal_dbc[m - 1]);//添加数据到表
               if (freq_dgvPim.Rows.Count >= 1)
               {
                   freq_dgvPim.FirstDisplayedScrollingRowIndex = freq_dgvPim.Rows.Count - 1;//显示当前行
                   freq_dgvPim.Rows[freq_dgvPim.Rows.Count - 1].Selected = true;
               }
               CreatScrollbar();
           }));
        }

        void ChangeY(float y)
        {

            if (y == -200)
                return;
            if (y > testdata_.dbm_y_e)
            {
                testdata_.dbm_y_e = (int)y + 10;
                testdata_.dbc_y_e = testdata_.dbm_y_e - (float)FreqSweepLeft.st_pow;
            }
            if (y < testdata_.dbm_y)
            {
                testdata_.dbm_y = (int)y - 10;
                testdata_.dbc_y = testdata_.dbm_y - (float)FreqSweepLeft.st_pow;
            }
            if (fm.isdBm)
                freq_plot.SetYStartStop(testdata_.dbm_y, testdata_.dbm_y_e);
            else
                freq_plot.SetYStartStop(testdata_.dbc_y, testdata_.dbc_y_e);
        }
        //void ChangeY_j(float y)
        //{
        //    if (y == -200)
        //        return;
        //    if (y > ds.dbm_y_e)
        //    {
        //        ds.dbm_y_e = (int)y + 10;
        //        ds.dbc_y_e = ds.dbm_y_e - 43;
        //    }
        //    if (y < ds.dbm_y)
        //    {
        //        ds.dbm_y = (int)y - 10;
        //        ds.dbc_y = ds.dbm_y - 43;
        //    }
        //    if (fm.isdBm)
        //        freq_plot.SetYStartStop(ds.dbm_y, ds.dbm_y_e);
        //    else
        //        freq_plot.SetYStartStop(ds.dbc_y, ds.dbc_y_e);
        //}

        /// <summary>
        /// 脚本扫描数据更新
        /// </summary>
        /// <param name="ds"></param>
        /// 
        void SweepControl_j(DataSweep ds)
        {
            this.Invoke(new ThreadStart(delegate
            {

                this.time_tb_show_tx1.Text = ds.sen_tx1.ToString("0.0");
                this.time_tb_show_tx2.Text = ds.sen_tx2.ToString("0.0");
                //time_tb_pim_now.Text = ds.sxy.y.ToString();////控件改变text显示互调当前值
                //time_tb_pim_now_dbc.Text = (ds.sxy.y - 43).ToString();


                float currenty = 0;
                    currenty = (float)ds.sxy.y;

                    if (ds.sxy.x <= ds.MaxRx && ds.sxy.x >= ds.MinRx)
                    {
                        time_tb_pim_now.Text = ds.sxy.y.ToString("0.0");////控件改变text显示互调当前值
                        time_tb_pim_now_dbc.Text = (ds.sxy.y - (float)FreqSweepLeft.st_pow).ToString("0.0");
                        currenty = (float)ds.sxy.y;
                    }
                    else
                    {
                        ds.sxy.y = -200;
                        currenty = (float)ds.sxy.y;
                    }

                    if (currenty > _pim_max && ds.sxy.x <= ds.MaxRx && ds.sxy.x >= ds.MinRx)
                {
                    _pim_max = currenty;//设置pim最大值
                    ds.sxy.max = _pim_max;
                    time_tB_valMax.Text = _pim_max.ToString();//控件改变text显示互调最大值
                    time_tB_valMax_dbc.Text = (_pim_max - (float)FreqSweepLeft.st_pow).ToString();
                }
                    if (currenty < _pim_min && ds.sxy.x <= ds.MaxRx && ds.sxy.x >= ds.MinRx)
                {
                    _pim_min = currenty;//设置pim最小值
                    ds.sxy.min = _pim_min;
                    time_tB_valMin.Text = _pim_min.ToString();//控件改变text显示互调最小值
                    time_tB_valMin_dbc.Text = (_pim_min - (float)FreqSweepLeft.st_pow).ToString();
                }
                if (fm.isdBm)
                {
                    if (currenty > _pim_limit && currenty != -200)
                    {
                        time_lbl_limitResulte.Text = "FAIL";//互调值大于limit改变控件text
                        time_lbl_limitResulte.ForeColor = Color.Red;
                    }
                }
                else
                {
                    if (currenty - (float)FreqSweepLeft.st_pow > _pim_limit && currenty != -243)
                    {
                        time_lbl_limitResulte.Text = "FAIL";//互调值大于limit改变控件text
                        time_lbl_limitResulte.ForeColor = Color.Red;
                    }
                }
                ds.sxy.result = time_lbl_limitResulte.Text;
                PointF pf;
                PointF pfc;
                if (ds.sxy.model == 1)
                {
                    pf = new PointF(ds.sxy.currentCount+1, ds.sxy.y);
                    pfc = new PointF(ds.sxy.currentCount+1, ds.sxy.y - (float)ds.pow1);
                }
                else
                {
                    pf = new PointF(ds.sxy.x, ds.sxy.y);
                    pfc = new PointF(ds.sxy.x, ds.sxy.y - (float)ds.pow1);
                }
                ChangeY(ds.sxy.y);
                this.freq_plot.Add(new PointF[1] { pf }, ds.sxy.currentPlot, ds.sxy.current);//坐标控件添加点
                this.freq_plot.Add(new PointF[1] { pfc }, ds.sxy.currentPlot + 4, ds.sxy.current);//坐标控件添加点
                this.freq_plot.MajorLineWidth = this.freq_plot.MajorLineWidth;
                DataRow dr_test = ds.jb.Rows[getnum];
                DataRow dr_testc = ds.jbc.Rows[getnum];
                dr_test[1] = _pim_max.ToString("0.0");
                dr_test[2] = _pim_min.ToString("0.0");
                dr_test[3] = time_lbl_limitResulte.Text;
                dr_testc[1] = (_pim_max - ds.pow1).ToString("0.0");
                dr_testc[2] = (_pim_min - ds.pow1).ToString("0.0");
                dr_testc[3] = time_lbl_limitResulte.Text;
                ds.sxy.pf_arr[ds.sxy.currentPlot].Add(pf);
                ds.sxy.pf_arr[ds.sxy.currentPlot+4].Add(pfc);
                OfftenMethod.ToNewRows(ds.dt, ds.sxy.currentCount,
                       (float)ds.sxy.f1, (float)ds.sen_tx1,
                       (float)ds.sxy.f2, (float)ds.sen_tx2,
                       ds.sxy.x, ds.sxy.y);//添加数据到表格
                OfftenMethod.ToNewRows(ds.dtc, ds.sxy.currentCount,
                          (float)ds.sxy.f1, (float)ds.sen_tx1,
                          (float)ds.sxy.f2, (float)ds.sen_tx2,
                          ds.sxy.x, ds.sxy.y - (float)ds.pow1);//添加数据到表格
                dataGridView1.FirstDisplayedScrollingRowIndex = ds.jb.Rows.Count - 1;
                curr_row = ds.jb.Rows.Count - 1;
            }));
        }


       

        void CreatScrollbar()
        {
            freq_Scrollbar.Minimum = 0;
            freq_Scrollbar.LargeChange = freq_Scrollbar.Maximum / freq_Scrollbar.Height + freq_dgvPim.Size.Height;
            freq_Scrollbar.SmallChange = 15;
            int a = freq_dgvPim.Size.Height / 10 * freq_dgvPim.Rows.Count;
            freq_Scrollbar.Maximum = a;
            int intHeight = freq_dgvPim.Size.Height / 10;
            freq_Scrollbar.Value = freq_dgvPim.FirstDisplayedScrollingRowIndex * intHeight;
        }

        /// <summary>
        /// 传递datasweep
        /// </summary>
        /// <param name="ds"></param>
        public void Clone(DataSweep ds)
        {
            //this.ds = ds;
        }

        /// <summary>
        /// 拷贝扫描数据
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public DataSweep  Clone_j(DataSweep ds)
        {
            DataSweep d = new DataSweep();
            d.sxy.x = ds.sxy.x;
            d.sxy.y = ds.sxy.y;
            d.sxy.n1 = ds.sxy.n1;
            d.sxy.n2 = ds.sxy.n2;
            d.sxy.n3 = ds.sxy.n3;
            d.sxy.n4 = ds.sxy.n4;
            d.MaxRx = ds.MaxRx;
            d.MinRx = ds.MinRx;
            d.dbc_y = ds.dbc_y;
            d.dbc_y_e = ds.dbc_y_e;
            d.dbm_y = ds.dbm_y;
            d.dbm_y_e = ds.dbm_y_e;
            d.sxy.max = ds.sxy.max;
            d.sxy.min = ds.sxy.min;
            d.sxy.result = ds.sxy.result;
            d.sxy.str_data = "";
            d.sxy.str_data = ds.sxy.str_data;
            d.sxy.overViewMessage = ds.sxy.overViewMessage;
            d.tx1 = ds.tx1;
            d.tx2 = ds.tx2;
            d.rx = ds.rx;
            d.imCo1 = ds.imCo1;
            d.imCo2 = ds.imCo2;
            d.imLess = ds.imLess;
            d.imLow = ds.imLow;
            d.freq1s = ds.freq1s;
            d.freq2s = ds.freq2s;
            d.freq1e = ds.freq1e;
            d.freq2e = ds.freq2e;
            d.step1 = ds.step1;
            d.time1 = ds.time1;
            d.pow1 = ds.pow1;
            d.sxy.bandM = ds.sxy.bandM;
            d.sxy.time_out_M = ds.sxy.time_out_M;
            d.sxy.model = ds.sxy.model;
            d.sxy.lf0.AddRange(ds.sxy.lf0.ToArray());
            d.sxy.lf1.AddRange(ds.sxy.lf1.ToArray());
            d.sxy.lf2.AddRange(ds.sxy.lf2.ToArray());
            d.sxy.lf3.AddRange(ds.sxy.lf3.ToArray());
            d.sxy.lf0c.AddRange(ds.sxy.lf0c.ToArray());
            d.sxy.lf1c.AddRange(ds.sxy.lf1c.ToArray());
            d.sxy.lf2c.AddRange(ds.sxy.lf2c.ToArray());
            d.sxy.lf3c.AddRange(ds.sxy.lf3c.ToArray());
            DataTable datresult = ds.dt.Copy();
            d.dt = datresult;
            d.dtc = ds.dtc.Copy();
            d.sxy.pdf_val.AddRange(ds.sxy.pdf_val.ToArray());
            d.timeou_mes = ds.timeou_mes;
            return d;
        }

        public void DataINIT()
        {
          
            jb_err = false;
            _pim_max = float.MinValue;
            _pim_min = float.MaxValue;
            current_pim_min = float.MaxValue;
            dbm_y = -140;
            dbm_y_e = -80;
            dbc_y = -183;
            dbc_y_e = -123;
            isFirstAdd = 0;
          
            this.Invoke(new ThreadStart(delegate()
            {
                button1.Enabled = false;
                freq_dgvPim.Enabled = false;
                time_tb_pim_now.Text = "--";
                time_tB_valMax.Text = "--";
                time_tB_valMin.Text = "--";
                time_tb_pim_now_dbc.Text = "--";
                time_tB_valMax_dbc.Text = "--";
                time_tB_valMin_dbc.Text = "--";
                time_lbl_limitResulte.Text = "PASS";
                textBox1.Text = "--";
                time_lbl_limitResulte.ForeColor = Color.Lime;
            }));
        }

        public void LastINIT()
        {
            button1.Enabled = true;
            freq_dgvPim.Enabled = true;
            MessageBox.Show("扫描完成");
        }

        /// <summary>
        /// 开始扫描
        /// </summary>
        /// <param name="s"></param>
        public void Start(Sweep s, TestData testdata, int currentNum)
        {
            testdata_ = testdata;
            isFirstAdd = 0;
            currentSweepCont = currentNum;
            isThreadStart = true;
            current_pim_max = float.MinValue;
            //current_pim_min = float.MaxValue;
            this.Invoke(new ThreadStart(delegate
            {             
                freq_plot.SetXStartStop(testdata.rxDate[currentNum].currentRxs - 2, testdata.rxDate[currentNum].currentRxe + 2);
                if (fm.isdBm)
                    freq_plot.SetYStartStop(dbm_y,dbm_y_e);//设置坐标起始结束
                else
                    freq_plot.SetYStartStop(dbc_y,dbc_y_e);//设置坐标起始结束
                time_lbl_limitResulte.Text = "PASS";
                time_lbl_limitResulte.ForeColor = Color.Lime;
           
            freq_plot.Clear();
       
                if (fm.isdBm)
                    freq_dgvPim.DataSource = testdata.surFaceData_dbm;
                else
                    freq_dgvPim.DataSource = testdata.surFaceData_dbc;
            }));

            sweep = s;
            //if (currentSweepCont == 0)
            //{
                sweep.PowerHander += new ControlIni_Sweep_Pow(Powhand_f);
                sweep.VcoHander += new ControlIni_Sweep_Vco(VcoHand);
                sweep.Tx1Hander += new ControlIni_Sweep_Tx1(Tx1Hand);
                sweep.Tx2Hander += new ControlIni_Sweep_Tx2(Tx2Hand);
            //}
            sweep.StHander += new Sweep_Test(SweepControl);

            if ( Ths())
            {
                double val = 0;
                double val_dbc = 0;
                for (int i = 0; i < freq_dgvPim.Rows.Count; i++)
                {
                    val += testdata_.pimDate[i].currentpimMax;
                    val_dbc += testdata_.pimDate[i].currentpimMax_dbc;
                }
                this.Invoke(new ThreadStart(delegate
               {
                   if (freq_dgvPim.Rows.Count != 0)
                   {
                       time_tb_pim_now.Text = (val / freq_dgvPim.Rows.Count).ToString("0.0");////控件改变text显示互调当前值
                       time_tb_pim_now_dbc.Text = (val_dbc / freq_dgvPim.Rows.Count).ToString("0.0");
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
            }
            else
            jb_err = true;
                isThreadStart = false;
                sweep.PowerHander -= new ControlIni_Sweep_Pow(Powhand_f);
                sweep.VcoHander -= new ControlIni_Sweep_Vco(VcoHand);
                sweep.Tx1Hander -= new ControlIni_Sweep_Tx1(Tx1Hand);
                sweep.Tx2Hander -= new ControlIni_Sweep_Tx2(Tx2Hand);
                sweep.StHander -= new Sweep_Test(SweepControl);
            //}
        }

      
        
        /// <summary>
        /// 开始脚本扫描
        /// </summary>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <param name="mesage"></param>
        //public void JbStart(Sweep s,int i,string mesage)
        //{
        //    this.Invoke(new ThreadStart(delegate
        //    {
        //        ds.dbm_y = -140;
        //        ds.dbm_y_e = -80;
        //        ds.dbc_y = -183;
        //        ds.dbc_y_e = -123;
        //        numericUpDown2.Value = (decimal)PoiFreqSweepLeft.jd[curr_row].limit;
        //       if(ds.sxy.model==0)
        //        freq_plot.SetXStartStop(ds.MinRx - 2, ds.MaxRx + 2);
        //        else
        //           freq_plot.SetXStartStop(0, ds.time1+2);
        //        if (fm.isdBm)
        //            freq_plot.SetYStartStop(dbm_y,dbm_y_e);//设置坐标起始结束
        //        else
        //            freq_plot.SetYStartStop(dbc_y, dbc_y_e);//设置坐标起始结束
        //        time_lbl_limitResulte.Text = "PASS";
        //        time_lbl_limitResulte.ForeColor = Color.Lime;
        //        ds.dt.Clear();
        //        ds.dtc.Clear();
        //        ds.sxy.lf0.Clear();
        //        ds.sxy.lf1.Clear();
        //        ds.sxy.lf2.Clear();
        //        ds.sxy.lf3.Clear();
        //        ds.sxy.lf0c.Clear();
        //        ds.sxy.lf1c.Clear();
        //        ds.sxy.lf2c.Clear();
        //        ds.sxy.lf3c.Clear();
        //        ds.sxy.pdf_val.Clear();
        //        ds.sxy.str_data = "";
        //        ds.sxy.overViewMessage = "";
        //        jb_err = false;
        //    }));
        //    if (mesage != "-")
        //    {
        //        this.Invoke(new ThreadStart(delegate
        //        {
        //            MessageBox.Show(mesage);
        //            progressBar1.Value += 1;
        //        }));
        //        ds_arr.Add(Clone_j(ds));
        //        rem_jpg_data(i, ds_arr);
                
        //        return;
        //    }
          
        //    freq_plot.Clear();
        //    this.Invoke(new ThreadStart(delegate
        //    {
        //        _pim_max = float.MinValue;
        //        _pim_min = float.MaxValue;
        //        if (fm.isdBm)
        //            dataGridView1.DataSource = ds.jb;
        //        else
        //            dataGridView1.DataSource = ds.jbc;
        //    }));
        //    sweep = s;
        //    sweep.PowerHander += new ControlIni_Sweep_Pow(Powhand_f);
        //    sweep.VcoHander += new ControlIni_Sweep_Vco(VcoHand);
        //    sweep.Tx1Hander += new ControlIni_Sweep_Tx1(Tx1Hand);
        //    sweep.Tx2Hander += new ControlIni_Sweep_Tx2(Tx2Hand);
        //    sweep.StHander += new Sweep_Test(SweepControl_j);
        //    getnum = i;
        //    freq_plot.Clear();
           
        //    sweep = s;
        //    Ths();
        //    ds_arr.Add(Clone_j(ds));
        //    rem_jpg_data(i, ds_arr);
        //    this.Invoke(new ThreadStart(delegate
        //   {
        //       progressBar1.Value += 1;
        //   }));
        //    isThreadStart = false;
        //    sweep.PowerHander -= new ControlIni_Sweep_Pow(Powhand_f);
        //    sweep.VcoHander -= new ControlIni_Sweep_Vco(VcoHand);
        //    sweep.Tx1Hander -= new ControlIni_Sweep_Tx1(Tx1Hand);
        //    sweep.Tx2Hander -= new ControlIni_Sweep_Tx2(Tx2Hand);
        //    sweep.StHander -= new Sweep_Test(SweepControl_j);
        //}

        /// <summary>
        /// 停止扫描
        /// </summary>
        public void Stop()
        {
            //sweep.Stop();
            //isThreadStart = false;
            //if (isThreadStart)
            //{
            if (sweep != null)
            {
                sweep.Stop();
            }
            //    isThreadStart = false;
            //}
        }

        /// <summary>
        /// 开始扫描
        /// </summary>
        bool  Ths()
        {
            //isThreadStart = true;
            return  sweep.Ini();
        }

       
        public void JbControl()
        {
            progressBar1.Visible = true;
            dataGridView1.Visible = true;
            if(dataGridView1.RowCount>0)
            UpdatePlotControl(dataGridView1.CurrentRow.Index);
        }

        public void DateAndGr(int num)
        {
            this.Invoke(new ThreadStart(delegate
           {
               ds_arr.Clear();
               dataGridView1.Enabled = false;
               progressBar1.Maximum = num + 1;
               progressBar1.Minimum = 0;
               progressBar1.Value = 0;
           }));
        }

        public void DateAndGr()
        {
               dataGridView1.Enabled = true;
               progressBar1.Value = progressBar1.Maximum;
               MessageBox.Show("扫描完成");
        }

        public void JbControl_f()
        {
            freq_plot.Clear();
            progressBar1.Hide();
            dataGridView1.Hide();
            //UpdatePlotControl(ds);
        }


        /// <summary>
        /// 更新当前选中脚本数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pointf_num = dataGridView1.CurrentRow.Index;
            curr_row = pointf_num;
            this.dataGridView1.Rows[pointf_num].Selected = true;
            //if (ds_arr[pointf_num].timeou_mes == "")
            //    return;
            UpdatePlotControl(pointf_num);
            //if (ClsUpLoad.sm == SweepMode.Np)
            //{
            //    NPFreqSweepLeft nsf = (NPFreqSweepLeft)form;
            //    nsf.UpdateGroupControl(pointf_num);
            //}
            //else
            //{
            //    PoiFreqSweepLeft nsf = (PoiFreqSweepLeft)form;
            //    nsf.UpdateGroupControl(pointf_num);
            //}
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="num"></param>
        void UpdatePlotControl(DataSweep ds)
        {
            if (ds.sxy.current <= 0)
                return;
            freq_plot.Clear();
            if (!fm.isdBm)
                freq_plot.SetYStartStop(ds.dbc_y, ds.dbc_y_e);
            else
                freq_plot.SetYStartStop(ds.dbm_y, ds.dbm_y_e);
            freq_plot.SetXStartStop(ds.MinRx - 2, ds.MaxRx + 2);
                if (ds.sxy.lf0.Count > 0)
                {
                    for (int i = 0; i < ds.sxy.lf0.Count; i++)
                    {
                        freq_plot.Add(new PointF[1] { ds.sxy.lf0[i] }, 0, i);
                        freq_plot.Add(new PointF[1] { ds.sxy.lf0c[i] }, 4, i);
                    }
                }
                if (ds.sxy.lf1.Count > 0)
                {
                    for (int i = 0; i < ds.sxy.lf1.Count; i++)
                    {
                        freq_plot.Add(new PointF[1] { ds.sxy.lf1[i] }, 1, i);
                        freq_plot.Add(new PointF[1] { ds.sxy.lf1c[i] }, 5, i);
                    }
                }
                if (ds.sxy.lf2.Count > 0)
                {
                    for (int i = 0; i < ds.sxy.lf2.Count; i++)
                    {
                        freq_plot.Add(new PointF[1] { ds.sxy.lf2[i] }, 2, i);
                        freq_plot.Add(new PointF[1] { ds.sxy.lf2c[i] }, 6, i);
                    }
                }
                if (ds.sxy.lf3.Count > 0)
                {
                    for (int i = 0; i < ds.sxy.lf3.Count; i++)
                    {
                        freq_plot.Add(new PointF[1] { ds.sxy.lf3[i] }, 3, i);
                        freq_plot.Add(new PointF[1] { ds.sxy.lf3c[i] }, 7, i);
                    }
                }

            freq_plot.MajorLineWidth = freq_plot.MajorLineWidth;
            time_tB_valMax.Text = ds.sxy.max.ToString("0.0");
            time_tB_valMin.Text = ds.sxy.min.ToString("0.0");
            time_lbl_limitResulte.Text = ds.sxy.result;
            if (ds.sxy.result == "FAIL")
            {
                time_lbl_limitResulte.ForeColor = Color.Red;
            }
            else
                time_lbl_limitResulte.ForeColor = Color.Lime;
            time_tb_pim_now.Text = "---";
            time_tb_pim_now_dbc.Text = "---";
        }

        void UpdatePlotControl(int num)
        {
            if (testdata_==null)
                return;
            this.freq_dgvPim.Rows[num].Selected = true;
            freq_plot.Clear();
            if (!fm.isdBm)
                freq_plot.SetYStartStop(testdata_.dbc_y, testdata_.dbc_y_e);
            else
                freq_plot.SetYStartStop(testdata_.dbm_y, testdata_.dbm_y_e);
            //if (ds_arr[num].sxy.model == 1)
            //{              
            //    freq_plot.SetXStartStop(0, ds_arr[num].time1 + 2);
            //    for (int i = 0; i < ds_arr[num].sxy.lf0.Count; i++)
            //    {
            //        freq_plot.Add(new PointF[1] { ds_arr[num].sxy.lf0[i] }, 0, i);
            //        freq_plot.Add(new PointF[1] { ds_arr[num].sxy.lf0c[i] }, 4, i);
            //    }
            //}
            //else
            //{

                freq_plot.SetXStartStop(testdata_.rxDate[num].currentRxs - 2, testdata_.rxDate[num].currentRxe + 2);
                int n1 = testdata_.pimDate[num].num1;
                int n2 = testdata_.pimDate[num].num2;
                int n3 = testdata_.pimDate[num].num3;
                int n4 = testdata_.pimDate[num].num4;
                if (n1 > 0)
                {
                    for (int i = 0; i < testdata_.pimDate[num].num1; i++)
                    {
                        freq_plot.Add(new PointF[1] { new PointF(testdata_.pimDate[num].pimFreq[i], testdata_.pimDate[num].pimVal_dbm[i]) }, 0, i);
                        freq_plot.Add(new PointF[1] { new PointF(testdata_.pimDate[num].pimFreq[i], testdata_.pimDate[num].pimVal_dbc[i]) }, 4, i);
                    }
                }
                if (n2 > 0)
                {
                    //for (int i = 0; i < ds_arr[num].sxy.lf1.Count; i++)
                    //{
                    //    freq_plot.Add(new PointF[1] { ds_arr[num].sxy.lf1[i] }, 1, i);
                    //    freq_plot.Add(new PointF[1] { ds_arr[num].sxy.lf1c[i] }, 5, i);
                    //}
                }
                if (n3 > 0)
                {
                  
                    for (int i = n1+n2; i < n1+n2+n3; i++)
                    {
                        freq_plot.Add(new PointF[1] {new PointF(testdata_.pimDate[num].pimFreq[i], testdata_.pimDate[num].pimVal_dbm[i]) }, 1, i-n1-n2);
                        freq_plot.Add(new PointF[1] { new PointF(testdata_.pimDate[num].pimFreq[i], testdata_.pimDate[num].pimVal_dbc[i]) }, 5, i-n1-n2);
                    }
                }
                if (n4 > 0)
                {
                    //for (int i = 0; i < ds_arr[num].sxy.lf3.Count; i++)
                    //{
                    //    freq_plot.Add(new PointF[1] { ds_arr[num].sxy.lf3[i] }, 3, i);
                    //    freq_plot.Add(new PointF[1] { ds_arr[num].sxy.lf3c[i] }, 7, i);
                    //}
                }
            //}
            freq_plot.MajorLineWidth = freq_plot.MajorLineWidth;
            //time_tB_valMax.Text = ds_arr[num].sxy.max.ToString("0.0");
            //time_tB_valMin.Text = ds_arr[num].sxy.min.ToString("0.0");
            //time_tB_valMax_dbc.Text = (ds_arr[num].sxy.max-43).ToString("0.0");
            //time_tB_valMin_dbc.Text = (ds_arr[num].sxy.min-43).ToString("0.0");
            //time_lbl_limitResulte.Text = ds_arr[num].sxy.result;
            //if (ds_arr[num].sxy.result == "FAIL")
            //{
            //    time_lbl_limitResulte.ForeColor = Color.Red;
            //}
            //else
            //    time_lbl_limitResulte.ForeColor = Color.Lime;
            //time_tb_pim_now.Text = "---";
            //time_tb_pim_now_dbc.Text = "---";
        }

        /// <summary>
        /// 保存pdf
        /// </summary>
        public void Savepdf()
        { 
            string s="";
            OfftenMethod.savepdf(s, ds_arr,false);
        }

        /// <summary>
        /// 记录扫描jpg图和数据
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ds"></param
        void rem_jpg_data(int i, List<DataSweep> ds)
        {
            this.Invoke(new ThreadStart(delegate
            {
               double maxval=0;
                if(fm.isdBm)
                    maxval=ds[i].sxy.max;
                else
                    maxval = ds[i].sxy.max + FreqSweepLeft.st_pow;
                if (ds[i].sxy.time_out_M != "-")
                {
                    ds[i].sxy.str_data += "NO" + (i + 1).ToString() + "\r\n" + ds[i].sxy.time_out_M;
 
                    return;
                }
                ds[i].sxy.image1 = OfftenMethod.SaveImage(groupBox2);//保存图形到内存
                ds[i].sxy.image2 = OfftenMethod.SaveImage(groupBox17);//保存图形到内存
                this.Refresh();
                //ds[i].sxy.overViewMessage += "NO" + (getnum + 1).ToString() + " 发射频段：" + "(" + cul.BandNames[ds[i].tx1] + ")+(" + cul.BandNames[ds[i].tx2] + ")" + " 接收频段:" + "(" + cul.BandNames[ds[i].rx] + ")"
                //                            + " 阶数：" + OfftenMethod.PimFormula(ds[i].imCo1, ds[i].imCo2, ds[i].imLow, ds[i].imLess) + " 最大值：" + ds[i].sxy.max.ToString("0.0") +
                //                            " 测试结果：" + ds[i].sxy.result;
                 
                if (ds[i].sxy.model == 0)//保存测试信息到内存
                {
                    ds[i].sxy.pdf_val.AddRange(new string[]{(getnum + 1).ToString(), " 扫频", ds[i].freq1s.ToString() + "-" + ds[i].freq1e.ToString() ,
                                           ds[i].freq2s.ToString() + "-" + ds[i].freq2e.ToString() , ds[i].MinRx.ToString() + "-" + ds[i].MaxRx.ToString() ,
                                             OfftenMethod.PimFormula(ds[i].imCo1, ds[i].imCo2, ds[i].imLow, ds[i].imLess), maxval.ToString("0.00"), ds[i].sxy.result});
                    ds[i].sxy.str_data += "NO" + (getnum + 1).ToString() + "   扫频模式\r\n";
                    ds[i].sxy.sweep_data_header = "NO" + (getnum + 1).ToString() + "   扫频模式\r\n\r\n";
                    ds[i].sxy.str_data += "F1: " + ds[i].freq1s.ToString() + " - " + ds[i].freq1e.ToString() + "MHz" + " (" + cul.BandNames[ds[i].tx1] + ")\r\n";
                    ds[i].sxy.str_data += "F2: " + ds[i].freq2s.ToString() + " - " + ds[i].freq2e.ToString() + "MHz" + " (" + cul.BandNames[ds[i].tx2] + ")\r\n";
                }
                else
                {
                    ds[i].sxy.pdf_val.AddRange(new string[]{ (getnum + 1).ToString(), " 点频", ds[i].freq1s.ToString() + "-" + ds[i].freq1e.ToString(),
                                          ds[i].freq2s.ToString() + "-" + ds[i].freq2e.ToString(), ds[i].MinRx.ToString() + "-" + ds[i].MaxRx.ToString() ,
                                            OfftenMethod.PimFormula(ds[i].imCo1, ds[i].imCo2, ds[i].imLow, ds[i].imLess), maxval.ToString("0.00"), ds[i].sxy.result});
                    ds[i].sxy.str_data += "NO" + (getnum + 1).ToString() + "   点频模式\r\n";
                    ds[i].sxy.sweep_data_header = "NO" + (getnum + 1).ToString() + "   点频模式\r\n\r\n";
                    ds[i].sxy.str_data += "F1: " + ds[i].freq1s.ToString() + "MHz" + " (" + cul.BandNames[ds[i].tx1] + ")\r\n";
                    ds[i].sxy.str_data += "F2: " + ds[i].freq2e.ToString() + "MHz" + " (" + cul.BandNames[ds[i].tx2] + ")\r\n";
                }
                if (ds[i].sxy.model == 0)
                    ds[i].sxy.str_data += "Rx: " + ds[i].MinRx.ToString() + " - " + ds[i].MaxRx.ToString() + "MHz" + " (" + cul.BandNames[ds[i].rx] + ")\r\n";
                else
                    ds[i].sxy.str_data += "Rx: " + cul.ld[ds[i].rx].ord3_imS.ToString() + " - " + cul.ld[ds[i].rx].ord3_imE.ToString() + "MHz" + " (" + cul.BandNames[ds[i].rx] + ")\r\n";
                ds[i].sxy.str_data += "Power: " + ds[i].pow1.ToString() + "dBm  ";
                if (ds[i].sxy.model == 0)
                {
                    ds[i].sxy.str_data += "Step: " + ds[i].step1.ToString() + "Mhz\r\n";
                }
                else
                {
                    ds[i].sxy.str_data += "Times: " + ds[i].time1.ToString() + "\r\n";
                }
                ds[i].sxy.str_data += "Order: ";
                ds[i].sxy.str_data +=OfftenMethod.PimFormula(ds[i].imCo1, ds[i].imCo2, ds[i].imLow, ds[i].imLess);
            }));
        }

        void rem_jpg_data_f(DataSweep ds)
        {
            this.Invoke(new ThreadStart(delegate
            {
                ds.sxy.str_data = "";
                ds.sxy.image1 = OfftenMethod.SaveImage(groupBox2);//保存图形到内存
                ds.sxy.image2 = OfftenMethod.SaveImage(groupBox17);//保存图形到内存
                this.Refresh();
                    ds.sxy.str_data += "NO" + (getnum + 1).ToString() + "   扫频模式\r\n";
                    ds.sxy.sweep_data_header = "NO" + (getnum + 1).ToString() + "   扫频模式\r\n\r\n";
                    ds.sxy.str_data += "F1: " + ds.freq1s.ToString() + " - " + ds.freq1e.ToString() + "MHz" + " (" + cul.AllBandNames[ds.tx1] + ")\r\n";
                    ds.sxy.str_data += "F2: " + ds.freq2s.ToString() + " - " + ds.freq2e.ToString() + "MHz" + " (" + cul.AllBandNames[ds.tx2] + ")\r\n";
                    ds.sxy.str_data += "Rx: " + ds.MinRx.ToString() + " - " + ds.MaxRx.ToString() + "MHz" + " (" + cul.AllBandNames[ds.rx] + ")\r\n";           
                    ds.sxy.str_data += "Power: " + ds.pow1.ToString() + "dBm  ";
                    ds.sxy.str_data += "Step: " + ds.step1.ToString() + "Mhz\r\n";    
                    ds.sxy.str_data += "Order: ";
                    ds.sxy.str_data += OfftenMethod.PimFormula(ds.imCo1, ds.imCo2, ds.imLow, ds.imLess);
            }));
        }

        private void freq_Scrollbar_Scroll(object sender, EventArgs e)
        {
            try
            {
                //计算滚动条长度
                int int_Hegiht = freq_dgvPim.Size.Height / 10;
                int index = 10;
                index = freq_Scrollbar.Value / int_Hegiht;
                if (index + 10 + 1 == freq_dgvPim.Rows.Count)
                {
                    index = index + 1;
                }
                freq_dgvPim.FirstDisplayedScrollingRowIndex = index;  //设置第一行显示 
            }
            catch { }
        }

        private void freq_dgvPim_Scroll(object sender, ScrollEventArgs e)
        {
            int intHeight = freq_dgvPim.Size.Height / 10;
            freq_Scrollbar.Value = freq_dgvPim.FirstDisplayedScrollingRowIndex * intHeight;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewRow dgr = dgv.Rows[e.RowIndex];   //获得DataGridViewRow  
            if (dgr.Cells[3].Value.ToString() == "FAIL")
            {
                dgr.Cells[3].Style.ForeColor = Color.Red;   //设置行背景色     
            }
            else
            {
                dgr.Cells[3].Style.ForeColor = Color.Green;
            }
            //dataGridView1.FirstDisplayedScrollingRowIndex = curr_row;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int row_ = dataGridView1.Rows.Count - 1;
            this.dataGridView1.Rows[row_].Selected = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pointf_num = dataGridView1.CurrentRow.Index;
            if (ds_arr[pointf_num].timeou_mes != "-")
            {
                return;
            }
            J_TestResultForm test_D = new J_TestResultForm(ds_arr[pointf_num],fm.isdBm);
            test_D.ShowDialog();          
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


        void ChangeLimit()
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
                if (testdata_ != null)
                {
                    freq_dgvPim.DataSource = testdata_.surFaceData_dbc;
                    freq_plot.SetYStartStop(testdata_.dbc_y, testdata_.dbc_y_e);
                }
                //if (dataGridView1.Visible)
                //{
                //    dataGridView1.DataSource = ds.jbc;
                //    dataGridView1.FirstDisplayedScrollingRowIndex = curr_row;
                //    this.dataGridView1.Rows[curr_row].Selected = true;
                //    for (int i = 0; i < PoiFreqSweepLeft.jd.Length; i++)
                //    {
                //        PoiFreqSweepLeft.jd[i].limit -= 43;

                //    }
                //    numericUpDown2.Value = (decimal)PoiFreqSweepLeft.jd[curr_row].limit;
                //    if (ds_arr.Count > 0 && ds_arr.Count > curr_row)
                //    freq_plot.SetYStartStop(ds_arr[curr_row].dbc_y, ds_arr[curr_row].dbc_y_e);
                //    else
                //        freq_plot.SetYStartStop(ds.dbc_y, ds.dbc_y_e);
                //}

                ShowPimValue(false);
                freq_dgvPim.Columns[1].HeaderText = "Peak(dBc)";
                freq_plot.SetChannelVisible(0, false);//设置通道是否显示
                freq_plot.SetChannelVisible(1, false);//设置通道是否显示
                freq_plot.SetChannelVisible(4, true);//设置通道是否显示
                freq_plot.SetChannelVisible(5, true);//设置通道是否显示
                freq_plot.SetChannelVisible(2, false);//设置通道是否显示
                freq_plot.SetChannelVisible(3, false);//设置通道是否显示
                if (ClsUpLoad._portHole == 4)
                {
                    freq_plot.SetChannelVisible(6, true);//设置通道是否显示
                    freq_plot.SetChannelVisible(7, true);//设置通道是否显示
                }
             
                freq_plot.MajorLineWidth = freq_plot.MajorLineWidth;
            }
            else
            {
              
                button1.Text = "dBm";
                label66.Text = "Limit(dBm):";
                label68.Text = "最大(dBm):";
                label67.Text = "最小(dBm):";
                label21.Text = "平均(dBm):";
                //numericUpDown2.Value += 43;
                if (testdata_ != null)
                {
                    freq_dgvPim.DataSource = testdata_.surFaceData_dbm;
                    freq_plot.SetYStartStop(testdata_.dbm_y, testdata_.dbm_y_e);
                }
                //if (dataGridView1.Visible)
                //{
                //    dataGridView1.DataSource = ds.jb;
                //    dataGridView1.FirstDisplayedScrollingRowIndex = curr_row;
                //    this.dataGridView1.Rows[curr_row].Selected = true;
                //    for (int i = 0; i < PoiFreqSweepLeft.jd.Length; i++)
                //    {
                //        PoiFreqSweepLeft.jd[i].limit += 43;
                        
                //    }
                  
                //    numericUpDown2.Value = (decimal)PoiFreqSweepLeft.jd[curr_row].limit;
                //    if(ds_arr.Count>0&&ds_arr.Count>curr_row)
                //    freq_plot.SetYStartStop(ds_arr[curr_row].dbm_y, ds_arr[curr_row].dbm_y_e);
                //    else
                //        freq_plot.SetYStartStop(ds.dbm_y, ds.dbm_y_e);
                //}
                ShowPimValue(true);
                freq_dgvPim.Columns[1].HeaderText = "Peak(dBm)";
                freq_plot.SetChannelVisible(0, true );//设置通道是否显示
                freq_plot.SetChannelVisible(1, true);//设置通道是否显示
                freq_plot.SetChannelVisible(4, false );//设置通道是否显示
                freq_plot.SetChannelVisible(5, false );//设置通道是否显示
                freq_plot.SetChannelVisible(6, false);//设置通道是否显示
                freq_plot.SetChannelVisible(7, false);//设置通道是否显示
                if (ClsUpLoad._portHole == 4)
                {
                    freq_plot.SetChannelVisible(2, true);//设置通道是否显示
                    freq_plot.SetChannelVisible(3, true);//设置通道是否显示
                }
  
                freq_plot.MajorLineWidth = freq_plot.MajorLineWidth;
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
            //if (ds.jb.Rows.Count<=0)
            //    return;
            //if (dbm)
            //{
            //    DataRow dr_test = ds.jb.Rows[curr_row];
            //    time_tB_valMax.Text = dr_test[1].ToString();
            //    time_tB_valMin.Text = dr_test[2].ToString();
            //}
            //else
            //{
            //    DataRow dr_testc = ds.jbc.Rows[curr_row];
            //    time_tB_valMax_dbc.Text = dr_testc[1].ToString();
            //    time_tB_valMin_dbc.Text = dr_testc[2].ToString();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fm.isdBm)
            {
                numericUpDown2.Value -=Convert.ToDecimal(FreqSweepLeft.st_pow);
                fm.IsdBm = false;
            
            }
            else
            {
                numericUpDown2.Value +=Convert.ToDecimal(FreqSweepLeft.st_pow);
                fm.IsdBm = true;
              
            }

        }


        public void ChangeJbUnit()
        {
            if (!fm.isdBm)
            {

                dataGridView1.DataSource = testdata_.surFaceData_dbc; ;

                for (int i = 0; i < PoiFreqSweepLeft.jd.Length; i++)
                {
                    PoiFreqSweepLeft.jd[i].limit -= (float)FreqSweepLeft.st_pow;

                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void freq_dgvPim_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewRow dgr = dgv.Rows[e.RowIndex];   //获得DataGridViewRow  
            //if (Convert.ToSingle(dgr.Cells[5].Value) > testdata_.rxDate[currentSweepCont].currentRxe ||
            //    Convert.ToSingle(dgr.Cells[5].Value) < testdata_.rxDate[currentSweepCont].currentRxs)
            //{
            //    dgr.DefaultCellStyle.ForeColor = Color.Red; //设置行背景色     
            //}    
        }

        private void freq_dgvPim_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (freq_dgvPim.Rows.Count <= 0) return;
            SingleTestData std;
            if (fm.isdBm) std = new SingleTestData(testdata_.pimDate[freq_dgvPim.CurrentRow.Index].dt_dbm,fm.isdBm);
            else std = new SingleTestData(testdata_.pimDate[freq_dgvPim.CurrentRow.Index].dt_dbc,fm.isdBm);
            std.ShowDialog();
            
        }

        private void freq_dgvPim_MouseClick(object sender, MouseEventArgs e)
        {
            if (freq_dgvPim.Rows.Count<=0) return;
            int pointf_num = freq_dgvPim.CurrentRow.Index;
            this.freq_dgvPim.Rows[pointf_num].Selected = true;
            UpdatePlotControl(pointf_num);
        }
    }
}
