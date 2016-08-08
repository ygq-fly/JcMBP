using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace JcMBP
{
    public delegate void ControlIni_Sweep_Pow(int s);
    public delegate void ControlIni_Sweep_Vco(bool s, double real_vco,double off_vco);
    public delegate void ControlIni_Sweep_Tx1(int s, ref double sen_tx2);
    public delegate void  ControlIni_Sweep_Tx2(int s, ref double sen_tx2);
    public delegate void Sweep_Test(TestData testdata);

    interface SweepHanderMethod
    {
        void SweepConmtrol(TestData testdata);
        void Tx2Hand(int s,ref double sen_tx2);
        void Tx1hand(int s, ref double sen_tx1);
        void VcoHand(bool isVco, double real_vco);
        void Powhand(int s);
    }

    interface Iorder
    {
         void SetOrder();
         int SetPort();
    }

    class PimTest : Iorder
    {
        //DataSweep ds;
        TestData testdata;
        int n = 0;
        public PimTest(TestData testdata,int currentNumber)
        {
            this.testdata = testdata;
            n = currentNumber;
        }
        public void SetOrder()
        {
            ClsJcPimDll.fnSetImOrder((byte)testdata.pimDate[n].order);//设置阶数   
        }
        public int  SetPort()
        {
           return  ClsJcPimDll.fnSetDutPort((byte)testdata.tx1Date[n].port);
        }
    }

    class PoiTest : Iorder
    {
        TestData testdata;
        int n = 0;
        public PoiTest(TestData testdata,int currentNumber)
        {
            this.testdata = testdata;
            n = currentNumber;
        }
        public void SetOrder()
        {
            ClsJcPimDll.HwSetImCoefficients((byte)testdata.pimDate[n].imCo1, (byte)testdata.pimDate[n].imCo2,
                                         (byte)testdata.pimDate[n].imLow, (byte)testdata.pimDate[n].imLess);//设置阶数
        }
        public int  SetPort()
        {
           return  ClsJcPimDll.fnSetDutPort((byte)testdata.tx1Date[n].port);
        }
    }

    class NPTest : Iorder
    {
        TestData testdata;
        int n = 0;
        public NPTest(TestData testdata, int currentNumber)
        {
            this.testdata = testdata;
            n = currentNumber;
        }
        public void SetOrder()
        {
            ClsJcPimDll.HwSetImCoefficients((byte)testdata.pimDate[n].imCo1, (byte)testdata.pimDate[n].imCo2,
                                         (byte)testdata.pimDate[n].imLow, (byte)testdata.pimDate[n].imLess);//设置阶数
        }
        public int  SetPort()
        {
            return ClsJcPimDll.HwSetDutPort((byte)testdata.tx1Date[n].port, (byte)testdata.tx2Date[n].port,(byte)testdata.rxDate[n].port );
           
        }
    }

    class SetorderAndPort
    {
        string s;
        Iorder iorder;
        TestData testdata;
        int n;
        public SetorderAndPort(string s, TestData testdata,int currentNumber)
        {
            this.s = s;
            this.testdata =testdata;
            n=currentNumber;
        }
        public Iorder GetOrder()
        {
            if (s == "2")
                iorder = new PoiTest(testdata,n );
            else if (s == "1"||s=="0"||s=="4")
                iorder = new PimTest(testdata,n);
            else
                iorder = new NPTest(testdata,n);
            return iorder;
        }
    }
   


   public  abstract  class Sweep
    {
        SetorderAndPort sd;
        //public DataSweep ds;
        public TestData testdata;
        public int n;
        public event ControlIni_Sweep_Pow PowerHander;
        public event ControlIni_Sweep_Vco VcoHander;
        public event Sweep_Test StHander;
        public event ControlIni_Sweep_Tx1 Tx1Hander;
        public event ControlIni_Sweep_Tx2 Tx2Hander;
        public SweepCtrl _ctrl=new SweepCtrl();

        public void Sthandmethod()
        {
            if (StHander != null)
                StHander(testdata);
        }
        public void PowHandmethod(int s)
        {
            if (PowerHander != null)
                PowerHander(s);
        }
        public Sweep()
        {
        }

        public Sweep(TestData testdata, string type,int currentNumber)
        {
            this.testdata=testdata;
            n = currentNumber;
            sd = new SetorderAndPort(type, testdata,currentNumber);
        }

        public void Order()
        {
            sd.GetOrder().SetOrder();
        }
        public int  Port()
        {
          return   sd.GetOrder().SetPort();
        }

        

        public bool Ini()
        {
            //if (n == 0)
            //{
                int s_err = 0;
                s_err = ClsJcPimDll.HwSetMeasBand((byte)testdata.tx1Date[n].band, (byte)testdata.tx2Date[n].band,
                                                  (byte)testdata.rxDate[n].band);

                if (s_err == 0 && Port() <= -10000)//设置端口
                {
                    //MessageBox.Show("当前模块未连接或开关设置错误！");
                    FreqSweepMid.jb_err = true;
                    return false ;
                }
                Monitor.Enter(_ctrl);
                _ctrl.bQuit = false;
                Monitor.Exit(_ctrl);

                Order();
                ClsJcPimDll.fnSetTxPower(testdata.tx1Date[n].pow, testdata.tx2Date[n].pow,
                                      testdata.tx1Date[n].off, testdata.tx2Date[n].off);//设置功率
                int s = ClsJcPimDll.HwSetTxFreqs(testdata.tx1Date[n].fs, testdata.tx2Date[n].fe, "mhz");//设置频率
                if (PowerHander != null)
                    PowerHander(s);
                if (s <= -10000)
                    return false;
                //设置阶数
                //if (type_trans != 2)
                //    ClsJcPimDll.fnSetImOrder((byte)_pim_order);
                //开启功放
                ClsJcPimDll.fnSetTxOn(true, ClsJcPimDll.JC_CARRIER_TX1TX2);//开启功放
                Thread.Sleep(100);//暂停
                //--------------------------------------------------------------------------------------
                //切换coup2
                ClsJcPimDll.HwSetCoup(ClsJcPimDll.JC_COUP_TX2);
                //vco检测
                bool isVco = true;

                double real_vco = 0;
                double off_vco = 0;
                if (ClsUpLoad._vco)
                    isVco = ClsJcPimDll.HwGet_Vco(ref real_vco, ref off_vco);//检测vco
                //显示
                if (VcoHander != null)
                    VcoHander(isVco, real_vco, off_vco);
                if (isVco == false)
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    MessageBox.Show("错误：VCO未检测到！请检查RX接收链路");
                    return false;
                }
                //--------------------------------------------------------------------------------------
                double dd1 = 0;
                double dd2 = 0;
                //P2功率检测

                s = ClsJcPimDll.HwGetSig_Smooth(ref dd2, ClsJcPimDll.JC_CARRIER_TX2);//检测功放2稳定度
                double sen_tx2 = 0;
                if (Tx2Hander != null)
                    Tx2Hander(s, ref sen_tx2);
                if (s <= -10000 && ClsUpLoad._checkPow)
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    return false ;
                }
                //--------------------------------------------------------------------------------------
                //切换coup1
                ClsJcPimDll.HwSetCoup(ClsJcPimDll.JC_COUP_TX1);//切换端口1
                Thread.Sleep(100);//暂停
                //P1功率检测

                s = ClsJcPimDll.HwGetSig_Smooth(ref dd1, ClsJcPimDll.JC_CARRIER_TX1);//检测tx1稳定度

                double sen_tx1 = 0;
                if (Tx1Hander != null)
                    Tx1Hander(s, ref sen_tx1);
                if (s <= -1000 && ClsUpLoad._checkPow)
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    return false ;
                }
            //}
           return  SweepTest();
        }

        public void Stop()
        {
            if (_ctrl != null)
            {
                Monitor.Enter(_ctrl);
                _ctrl.bQuit = true;
                Monitor.Exit(_ctrl);
            }
        }

        public bool GetCurrentCondition()
        {
            if (_ctrl != null)
            {
                Monitor.Enter(_ctrl);
                bool s=_ctrl.bQuit;
                Monitor.Exit(_ctrl);
                return s;
            }
            else
                return true;
        }

        public abstract bool SweepTest();

    }

    public  class SweepTime : Sweep
    {

        public SweepTime(TestData testdata, string type,int n)
            : base(testdata, type,n)
        {
        }
        public override bool SweepTest()
        {
            ClsJcPimDll.fnSetTxOn(true, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
            double get_xnum = 0;
            get_xnum = StaticMethod.GetFreq((byte)testdata.pimDate[n].imCo1, (byte)testdata.pimDate[n].imCo2,
                                        (byte)testdata.pimDate[n].imLow, (byte)testdata.pimDate[n].imLess,
                                        testdata.tx1Date[n].fs, testdata.tx2Date[n].fe);//当前扫频频率
            if (ClsUpLoad.sm != SweepMode.Poi || ClsUpLoad.sm != SweepMode.Np)
            {            
                if (ClsUpLoad.BandOrder[testdata.tx1Date[n].band] == 1 && (ClsUpLoad._type == 0 || ClsUpLoad._type == 1))
                    get_xnum = StaticMethod.GetFreq((byte)testdata.pimDate[n].imCo1, (byte)testdata.pimDate[n].imCo2,
                                                1, 0,
                                                testdata.tx1Date[n].fs, testdata.tx2Date[n].fe);//当前扫频频率
            
            }
            if (get_xnum > testdata.rxDate[n].currentRxe || get_xnum < testdata.rxDate[n].currentRxs)//不在rx范围内则跳过
            {
                ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                MessageBox.Show("互调频率不在rx接收范围内");
                return false ;
            }
            
            for (int i = 0; i < testdata.tx1Date[n].sweeptime; ++i)
            {
                
                float x = 0;
                float y = 0;
                Monitor.Enter(_ctrl);
                bool isQuit = _ctrl.bQuit;
                Monitor.Exit(_ctrl);

                if (isQuit)
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    return false;
                }
                //读取pim
                double freq_mhz = 0;
                double val = 0;
                ClsJcPimDll.fnGetImResult(ref freq_mhz, ref val, "mhz");//读取互调值和互调频率
                x = (float)freq_mhz;
                val += testdata.tx1Date[n].off;
                y = (float)val;
                testdata.pimDate[n].pimFreq.Add(x);
                testdata.pimDate[n].pimVal_dbm.Add(y);
                testdata.pimDate[n].pimVal_dbc.Add(y - Convert.ToSingle(TimeSweepLeft.st_pow));
                testdata.pimDate[n].num1 = i + 1;
                testdata.pimDate[n].currentTime = i;
                testdata.pimDate[n].currentPort = 0;
                testdata.pimDate[n].currentTestF1 = Convert.ToSingle(testdata.tx1Date[n].fs);
                testdata.pimDate[n].currentTestF2 = Convert.ToSingle(testdata.tx2Date[n].fe);
                //ds.sxy.current = i;
                //ds.sxy.currentPlot = 0;
                //ds.sxy.currentCount = i+1;
                //ds.sxy.f1 = ds.freq1s;
                //ds.sxy.f2 = ds.freq2e;
                Sthandmethod();
            }
            
            ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
            return true;
        }


    }

  public   class SweepFreq : Sweep
    {
      public SweepFreq(TestData testdata, string type,int n)
          : base(testdata, type, n)
      { }
        public override bool  SweepTest()
        {
            ClsJcPimDll.fnSetTxOn(true, ClsJcPimDll.JC_CARRIER_TX1TX2);
            double f = testdata.tx1Date[n].fs;
            double n1 = Math.Ceiling((testdata.tx1Date[n].fe - testdata.tx1Date[n].fs) / testdata.tx1Date[n].step);//扫描点数
            double n2 = 0;//扫描点数
            double n3 = 0;//扫描点数
            double n4 = 0;//扫描点数
            double get_xnum = 0;
            int m1 = 0;//跳过点数
            int m2 = 0;//跳过点数
            int m3 = 0;//跳过点数
            int m4 = 0;//跳过点数
            double val = 0;
            double freq_mhz = 0;
            double sen_tx1 = 0;
            double sen_tx2 = 0;
            double dd1 = 0;
            double dd2 = 0;
            int s = 0;
            float x = 0;
            float y = 0;
            double step1 = testdata.tx1Date[n].step;
            double step2 = step1 * 2;
            //ClsJcPimDll.HwGetSig_Smooth(ref dd2, ClsJcPimDll.JC_CARRIER_TX2);//检测功放稳定度          
            //sen_tx2 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX2);//读取显示功率1
            //testdata.pimDate[n].sen_tx2 = Convert.ToSingle(sen_tx2);

            for (int i = 0; i <= n1; ++i)
            {
                Monitor.Enter(_ctrl);
                bool isQuit = _ctrl.bQuit;
                Monitor.Exit(_ctrl);
                get_xnum = StaticMethod.GetFreq((byte)testdata.pimDate[n].imCo1, (byte)testdata.pimDate[n].imCo2,
                                         (byte)testdata.pimDate[n].imLow, (byte)testdata.pimDate[n].imLess,
                                         f, testdata.tx2Date[n].fe);//当前扫频频率

                ///超出范围的点跳过，测试下个点
                if (ClsUpLoad.sm != SweepMode.Poi || ClsUpLoad.sm != SweepMode.Np)
                {
                    if (ClsUpLoad.BandOrder[testdata.tx1Date[n].band] == 1 && (ClsUpLoad._type == 0 || ClsUpLoad._type == 1))
                        get_xnum = StaticMethod.GetFreq((byte)testdata.pimDate[n].imCo1, (byte)testdata.pimDate[n].imCo2,
                                                    1, 0,
                                                    f, testdata.tx2Date[n].fe);//当前扫频频率
                    if (get_xnum > testdata.rxDate[n].currentRxe || get_xnum < testdata.rxDate[n].currentRxs)//不在rx范围内则跳过
                    {
                        f += step1;//设置频率
                        m1++;//跳过点数加1
                        continue;
                    }

                }
                //else
                //{
                //    get_xnum = StaticMethod.GetFreq(ds.imCo1, ds.imCo2, 0, 0, f, ds.freq2e);//当前扫频频率      
                //    if (FreqSweepLeft.bandname == "dd800" && ClsUpLoad._type == 0 || ClsUpLoad._type == 1)
                //        get_xnum = StaticMethod.GetFreq(ds.imCo1, ds.imCo2, 1, 0, f, ds.freq2e);//当前扫频频率
                //    if (get_xnum > ds.MaxRx || get_xnum < ds.MinRx)//不在rx范围内则跳过
                //    {

                //        f += ds.step1;//设置频率
                //        m1++;//跳过点数加1
                //        continue;
                //        //ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                //        //return;
                //    }
                //}
                if (isQuit)
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    return  false ;
                }

                if (f > testdata.tx1Date[n].fe) f = testdata.tx1Date[n].fe;//当前频率大于结束频率，设置当前频率为结束频率

                //if (i != 0)
                //{
                    //设置频率
                    ClsJcPimDll.fnSetTxPower(testdata.tx1Date[n].pow, testdata.tx2Date[n].pow,
                                            testdata.tx1Date[n].off, testdata.tx2Date[n].off);//设置功率

                    //设置功率
                    double f2=testdata.tx2Date[n].fe;
                    s = ClsJcPimDll.HwSetTxFreqs(f, f2, "mhz");//设置频率
                    //检测错误
                    if (s <= -10000)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                        PowHandmethod(s);
                    }
                    ClsJcPimDll.HwGetSig_Smooth(ref dd1, ClsJcPimDll.JC_CARRIER_TX1);//检测功放稳定度
                //}
                //读取pim            
                sen_tx1 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX1);//读取显示功率1
                ClsJcPimDll.fnGetImResult(ref freq_mhz, ref val, "mhz");//读取互调频率和互调值
                val += testdata.tx1Date[n].off;//互调值
                //显示

                x = (float)Math.Round(freq_mhz, 1);//互调频率四舍五入保留1位小数
                //MessageBox.Show("f1: " + f.ToString("0.00")+" f2: " + testdata.tx2Date[n].fe.ToString("0.0") + "freq: " + x.ToString());

                y = (float)Math.Round(val, 1);//互调值四舍五入保留1位小数
                testdata.pimDate[n].sen_tx1 = Convert.ToSingle(sen_tx1);
                testdata.pimDate[n].pimFreq.Add(x);
                testdata.pimDate[n].pimVal_dbm.Add(y);
                testdata.pimDate[n].pimVal_dbc.Add(y-Convert.ToSingle(FreqSweepLeft.st_pow));
                testdata.pimDate[n].currentTime = i-m1;
                testdata.pimDate[n].currentPort = 0;
                testdata.pimDate[n].num1 = i + 1 - m1;
                testdata.pimDate[n].currentTestF1 = Convert.ToSingle(f);
                testdata.pimDate[n].currentTestF2 = Convert.ToSingle(testdata.tx2Date[n].fe);
                //ds.sxy.currentPlot = 0;
                //ds.sxy.current = i;
                //ds.sxy.currentCount = i + 1 - m1;
                //ds.sxy.f1 = (float)f;
                //ds.sxy.f2 = ds.freq2e;
                Sthandmethod();

                f += step1;//设置频率
            }
            if ((ClsUpLoad.sm == SweepMode.Poi || ClsUpLoad.sm == SweepMode.Np) && ClsUpLoad._portHole == 4)//poi模式4通道
            {
                f = testdata.tx1Date[n].fs;
                n3 = Math.Ceiling((testdata.tx1Date[n].fe-testdata.tx2Date[n].fs) / step1);//扫描点数

                for (int i = 0; i <= n3; ++i)
                {
                    Monitor.Enter(_ctrl);
                    bool isQuit = _ctrl.bQuit;
                    Monitor.Exit(_ctrl);

                    get_xnum = StaticMethod.GetFreq((byte)testdata.pimDate[n].imCo1, (byte)testdata.pimDate[n].imCo2,
                                                 (byte)testdata.pimDate[n].imLow, (byte)testdata.pimDate[n].imLess,
                                                 f, testdata.tx2Date[n].fs);//当前频率
                    //超过rx范围则跳过
                    if (get_xnum > testdata.rxDate[n].currentRxe || get_xnum <testdata.rxDate[n].currentRxs)
                    {
                        f += step1;
                        m3++;
                        continue;
                    }

                    if (isQuit)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                        return false ;
                    }

                    if (f > testdata.tx1Date[n].fe) f = testdata.tx1Date[n].fe;
                    //设置
                    ClsJcPimDll.fnSetTxPower(testdata.tx1Date[n].pow, testdata.tx2Date[n].pow,
                                          testdata.tx1Date[n].off,testdata.tx2Date[n].off);//设置功率
                    //设置
                    s = ClsJcPimDll.HwSetTxFreqs(f, testdata.tx2Date[n].fs, "mhz");//设置频率
                    //检测错误
                    if (s <= -10000)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                        PowHandmethod(s);
                        return false ;
                    }
                    ClsJcPimDll.HwGetSig_Smooth(ref dd1, ClsJcPimDll.JC_CARRIER_TX1);//检测功放稳定度
                    //}
                    //读取pim            
                    sen_tx1 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX1);//切换端口
                    ClsJcPimDll.fnGetImResult(ref freq_mhz, ref val, "mhz");//获取互调值和互调频率
                    val += testdata.tx1Date[n].off;
                    //显示
                    x = (float)Math.Round(freq_mhz, 1);//互调频率四舍五入保留一位小数
                    y = (float)Math.Round(val, 1);//互调值四舍五入保留一位小数
                    //ds.sen_tx1 = sen_tx1;
                    //ds.sxy.x = x;
                    //ds.sxy.y = y;
                    //ds.sxy.currentPlot = 3;
                    //ds.sxy.current = i;
                    ////if (ClsUpLoad._portHole == 4)
                    //ds.sxy.currentCount = (int)n1 + 1 + i + 1 - m1 - m3;
                    //else
                    //    ds.sxy.currentCount = (int)n1 + 1 + i + 1 - m1 - m3;
                    //ds.sxy.f1 = (float)f;
                    //ds.sxy.f2 = ds.freq2s;
                    testdata.pimDate[n].sen_tx1 = Convert.ToSingle(sen_tx1);
                    //testdata.pimDate[n].sen_tx2 = Convert.ToSingle(sen_tx2);
                    testdata.pimDate[n].pimFreq.Add(x);
                    testdata.pimDate[n].pimVal_dbm.Add(y);
                    testdata.pimDate[n].pimVal_dbc.Add(y - Convert.ToSingle(FreqSweepLeft.st_pow));
                    testdata.pimDate[n].currentTime = i;
                    testdata.pimDate[n].currentPort = 3;
                    testdata.pimDate[n].num2 = i + 1- m3;
                    testdata.pimDate[n].currentTestF1 = Convert.ToSingle(f);
                    testdata.pimDate[n].currentTestF2 = Convert.ToSingle(testdata.tx2Date[n].fs);
                    Sthandmethod();
                    f += step1;
                }
            }
            //切换开关2
            s = ClsJcPimDll.HwSetTxFreqs(testdata.tx1Date[n].fs, testdata.tx2Date[n].fe, "mhz");//设置频率
            if (s <= -10000)
            {
                ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                PowHandmethod(s);
                return false ;
            }
            ClsJcPimDll.HwGetSig_Smooth(ref dd1, ClsJcPimDll.JC_CARRIER_TX1);//检测功放稳定度
            sen_tx1 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX1);//获取tx1显示功率
            ClsJcPimDll.HwSetCoup(1);
            Thread.Sleep(100);//暂停
            f = testdata.tx2Date[n].fe;
            n2 = Math.Ceiling((testdata.tx2Date[n].fe - testdata.tx2Date[n].fs) / step2);//扫描点数
            for (int i = 0; i <= n2; ++i)
            {
                Monitor.Enter(_ctrl);
                bool isQuit = _ctrl.bQuit;
                Monitor.Exit(_ctrl);
                get_xnum = StaticMethod.GetFreq((byte)testdata.pimDate[n].imCo1, (byte)testdata.pimDate[n].imCo2,
                                       (byte)testdata.pimDate[n].imLow, (byte)testdata.pimDate[n].imLess,
                                       testdata.tx1Date[n].fs, f);//当前扫频频率
                if (ClsUpLoad.sm != SweepMode.Poi || ClsUpLoad.sm != SweepMode.Np)
                {
                    if (ClsUpLoad.BandOrder[testdata.tx1Date[n].band] == 1 && (ClsUpLoad._type == 0 || ClsUpLoad._type == 1))
                        get_xnum = StaticMethod.GetFreq((byte)testdata.pimDate[n].imCo1, (byte)testdata.pimDate[n].imCo2,
                                                    1, 0,
                                                    testdata.tx1Date[n].fs, f);//当前扫频频率
                    if (get_xnum > testdata.rxDate[n].currentRxe || get_xnum < testdata.rxDate[n].currentRxs)//不在rx范围内则跳过
                    {
                        f -= step2;
                        m2++;
                        continue;
                    }

                }
                //else
                //{
                //    get_xnum = StaticMethod.GetFreq(ds.imCo1, ds.imCo2, 0, 0, ds.freq1s, f);//当前扫频频率
                //    if (ds.tx1 == 1)
                //        get_xnum = StaticMethod.GetFreq(ds.imCo1, ds.imCo2, 1, 0, ds.freq1s, f);//当前扫频频率
                //    if (get_xnum > ds.MaxRx || get_xnum < ds.MinRx)//不在rx范围内则跳过
                //    {
                //        f -= ds.step2;
                //        m2++;
                //        continue;
                //        //ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                //        //return;
                //    }
                //}
                if (isQuit)
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    return false;
                }
                if (f < testdata.tx2Date[n].fs) f = testdata.tx2Date[n].fs;
                //设置频率
                //if (ClsUpLoad.sm != SweepMode.Poi)
                //    ClsJcPimDll.fnSetTxPower(43, 43, ds.freq_off1, ds.freq_off1);//设置功率
                //else
                if (i != 0)
                {
                    ClsJcPimDll.fnSetTxPower(testdata.tx1Date[n].pow, testdata.tx2Date[n].pow,
                                          testdata.tx1Date[n].off, testdata.tx2Date[n].off);//设置功率
                    //设置功率
                    s = ClsJcPimDll.HwSetTxFreqs(testdata.tx1Date[n].fs, f, "mhz");//设置频率
                    if (s <= -10000)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                        PowHandmethod(s);
                        return false ;
                    }
                }
                //读取
                ClsJcPimDll.HwGetSig_Smooth(ref dd2, ClsJcPimDll.JC_CARRIER_TX2);//检测功放稳定度
                sen_tx2 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX2);//获取tx2显示功率
                ClsJcPimDll.fnGetImResult(ref freq_mhz, ref val, "mhz");//获取互调值和互调频率
                val += testdata.tx1Date[n].off;

                 
          
                //显示
                x = (float)Math.Round(freq_mhz, 1);//互调频率
                y = (float)Math.Round(val, 1);//互调值
                //testdata.pimDate[n].sen_tx1 = Convert.ToSingle(sen_tx1);
                testdata.pimDate[n].sen_tx2 = Convert.ToSingle(sen_tx2);
                testdata.pimDate[n].pimFreq.Add(x);
                testdata.pimDate[n].pimVal_dbm.Add(y);
                testdata.pimDate[n].pimVal_dbc.Add(y - Convert.ToSingle(FreqSweepLeft.st_pow));
                testdata.pimDate[n].currentTime = i;
                testdata.pimDate[n].currentPort = 1;
                testdata.pimDate[n].num3 = i + 1  - m2 ;
                testdata.pimDate[n].currentTestF1 = Convert.ToSingle(testdata.tx1Date[n].fs);
                testdata.pimDate[n].currentTestF2 = Convert.ToSingle(f);
                //ds.sen_tx2 = sen_tx2;
                //ds.sen_tx1 = sen_tx1;
                //ds.sxy.x = x;
                //ds.sxy.y = y;
                //ds.sxy.currentPlot = 1;
                //ds.sxy.current = i;
                //ds.sxy.currentCount = (int)n1 + 1 + (int)n3 + 1 + i+1  - m1 - m2 - m3;
                //ds.sxy.f2 = (float)f;
                //ds.sxy.f1 = ds.freq1s;
                Sthandmethod();
                f -= step2;
            }
            if ((ClsUpLoad.sm == SweepMode.Poi || ClsUpLoad.sm == SweepMode.Np) && ClsUpLoad._portHole == 4)
            {
                f = testdata.tx2Date[n].fe;
                n4 = Math.Ceiling((testdata.tx2Date[n].fe - testdata.tx2Date[n].fs) / step2);
                for (int i = 0; i <= n4; ++i)
                {
                    Monitor.Enter(_ctrl);
                    bool isQuit = _ctrl.bQuit;
                    Monitor.Exit(_ctrl);
                    get_xnum = StaticMethod.GetFreq((byte)testdata.pimDate[n].imCo1, (byte)testdata.pimDate[n].imCo2,
                                       (byte)testdata.pimDate[n].imLow, (byte)testdata.pimDate[n].imLess,
                                       testdata.tx1Date[n].fe, f);
                    if (get_xnum > testdata.rxDate[n].currentRxe || get_xnum < testdata.rxDate[n].currentRxs)//不在rx范围内则跳过
                    {
                        f -= step2;
                        m4++;
                        continue;
                    }
                    if (isQuit)
                        break;
                    if (f < testdata.tx2Date[n].fs) f = testdata.tx2Date[n].fs;
                    //设置频率
                    ClsJcPimDll.fnSetTxPower(testdata.tx1Date[n].pow, testdata.tx2Date[n].pow, 
                                          testdata.tx1Date[n].off, testdata.tx2Date[n].off);
                    //设置功率
                    s = ClsJcPimDll.HwSetTxFreqs(testdata.tx1Date[n].fe, f, "mhz");
                    if (s <= -10000)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);
                        PowHandmethod(s);
                        return false ;
                    }
                    //读取
                    ClsJcPimDll.HwGetSig_Smooth(ref dd2, ClsJcPimDll.JC_CARRIER_TX2);
                    sen_tx2 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX2);
                    ClsJcPimDll.fnGetImResult(ref freq_mhz, ref val, "mhz");
                    val += testdata.tx2Date[n].off;
                    //显示
                    x = (float)Math.Round(freq_mhz, 1);
                    y = (float)Math.Round(val, 1);
                    testdata.pimDate[n].currentTime = i;
                    testdata.pimDate[n].currentPort = 2;
                    //ds.sxy.currentCount = (int)n3 + 1 + (int)n1 + 1 + (int)n2 + 1 + i + 1 - m1 - m2 - m3 - m4;
                    testdata.pimDate[n].sen_tx1 = Convert.ToSingle(sen_tx1);
                    testdata.pimDate[n].sen_tx2 = Convert.ToSingle(sen_tx2);
                    testdata.pimDate[n].pimFreq.Add(x);
                    testdata.pimDate[n].pimVal_dbm.Add(y);
                    testdata.pimDate[n].pimVal_dbc.Add(y - Convert.ToSingle(FreqSweepLeft.st_pow));
                    testdata.pimDate[n].num4 = i + 1- m4;
                    testdata.pimDate[n].currentTestF1 = Convert.ToSingle(testdata.tx1Date[n].fe);
                    testdata.pimDate[n].currentTestF2 = Convert.ToSingle(f);
                    Sthandmethod();
                    f -= step2;
                }
            }
            ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);
            return true;
        }
    }

   public  class SweepCtrl
    {
        public bool bQuit;
    }

}

