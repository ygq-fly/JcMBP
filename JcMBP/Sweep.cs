using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace JcMBP
{
    public delegate void ControlIni_Sweep_Pow(int s);
    public delegate void ControlIni_Sweep_Vco(bool s, double real_vco,double off_vco);
    public delegate void ControlIni_Sweep_Tx1(int s, ref double sen_tx2,bool istrue);
    public delegate void  ControlIni_Sweep_Tx2(int s, ref double sen_tx2,bool istrue);
    public delegate void Sweep_Test(DataSweep ds);

    interface SweepHanderMethod
    {
        void SweepConmtrol(DataSweep ds);
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
        DataSweep ds;
        public PimTest(DataSweep ds)
        {
            this.ds = ds;
        }
        public void SetOrder()
        {
            ClsJcPimDll.fnSetImOrder(ds.order);//设置阶数   
            if (ClsUpLoad.BandOrder[(int)ds.tx1] == 1 && (ClsUpLoad._type == 0 || ClsUpLoad._type == 1))
                ClsJcPimDll.HwSetImCoefficients(ds.imCo1, ds.imCo2, 1, 0);//设置阶数        
        }
        public int  SetPort()
        {
           return  ClsJcPimDll.fnSetDutPort(ds.port);
        }
    }

    class PoiTest : Iorder
    {
        DataSweep ds;
        public PoiTest(DataSweep ds)
        {
            this.ds = ds;
        }
        public void SetOrder()
        {
            
            ClsJcPimDll.HwSetImCoefficients(ds.imCo1, ds.imCo2, ds.imLow, ds.imLess);//设置阶数
        }
        public int  SetPort()
        {
           return  ClsJcPimDll.fnSetDutPort(ds.port);
        }
    }

    class NPTest : Iorder
    {
        DataSweep ds;
        public NPTest(DataSweep ds)
        {
            this.ds = ds;
        }
        public void SetOrder()
        {
            ClsJcPimDll.HwSetImCoefficients(ds.imCo1, ds.imCo2, ds.imLow, ds.imLess);//设置阶数
        }
        public int  SetPort()
        {
            return ClsJcPimDll.HwSetDutPort(ds.tx1Port, ds.tx2Port, ds.rxPort);
           
        }
    }

    class SetorderAndPort
    {
        string s;
        Iorder iorder;
        DataSweep ds;
        public SetorderAndPort(string s, DataSweep ds)
        {
            this.s = s;
            this.ds = ds;
        }
        public Iorder GetOrder()
        {
            if (s == "2")
                iorder = new PoiTest(ds);
            else if (s == "1"||s=="0"||s=="4")
                iorder = new PimTest(ds);
            else
                iorder = new NPTest(ds);
            return iorder;
        }
    }
   


   public  abstract  class Sweep
    {
        SetorderAndPort sd;
        public DataSweep ds;
        public event ControlIni_Sweep_Pow PowerHander;
        public event ControlIni_Sweep_Vco VcoHander;
        public event Sweep_Test StHander;
        public event ControlIni_Sweep_Tx1 Tx1Hander;
        public event ControlIni_Sweep_Tx2 Tx2Hander;
        public SweepCtrl _ctrl=new SweepCtrl();

        public void Sthandmethod()
        {
            if (StHander != null)
                StHander(ds);
        }
        public void PowHandmethod(int s)
        {
            if (PowerHander != null)
                PowerHander(s);
        }
        public Sweep()
        {
        }
        public  Sweep(DataSweep ds, string type)
        {
            this.ds = ds;
            sd = new SetorderAndPort(type, ds);
        }

        public void Order()
        {
            sd.GetOrder().SetOrder();
        }
        public int  Port()
        {
          return   sd.GetOrder().SetPort();
        }

        

        public void Ini()
        {
          
                System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
                st.Start();
                double sen_tx2 = 0;
                double sen_tx1 = 0;
                TimeSpan ts;
                int s_err = ClsJcPimDll.HwSetMeasBand(ds.tx1, ds.tx2, ds.rx);
                if (Port() <= -10000)//设置端口
                {
                    //MessageBox.Show("当前模块未连接或开关设置错误！");
                    FreqSweepMid.jb_err = true;
                    return;
                }
                Monitor.Enter(_ctrl);
                _ctrl.bQuit = false;
                Monitor.Exit(_ctrl);

                //设置阶数
                Order();
                //设置功率
                ClsJcPimDll.fnSetTxPower(ds.pow1, ds.pow2, ds.off1, ds.off2);
                //设置频率
                int s = ClsJcPimDll.HwSetTxFreqs(ds.freq1s, ds.freq2e, "mhz");
                if (PowerHander != null)
                    PowerHander(s);
                if (s <= -10000)
                    return;

                //开启功放
                ClsJcPimDll.fnSetTxOn(true, ClsJcPimDll.JC_CARRIER_TX1TX2);//开启功放
                //--------------------------------------------------------------------------------------

                //vco检测
                bool isVco = true;

                double real_vco = 0;
                double off_vco = 0;
                if (ClsUpLoad._vco)
                    isVco = ClsJcPimDll.HwGet_Vco(ref real_vco, ref off_vco);//检测vco
                //vco显示
                if (VcoHander != null)
                    VcoHander(isVco, real_vco, off_vco);
                if (isVco == false)
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    MessageBox.Show("错误：VCO未检测到！请检查RX接收链路");
                    return;
                }

                //默认切频段时候耦合器开关为tx2，所以不切tx2
                //ClsJcPimDll.HwSetCoup(ClsJcPimDll.JC_COUP_TX2);

                if (ClsUpLoad.fastmode == true)
                {
                    //TRUE 显示真实值

                    if (Tx2Hander != null)
                        Tx2Hander(s, ref sen_tx2, false);

                    //切换coup1 
                    //ClsJcPimDll.HwSetCoup(ClsJcPimDll.JC_COUP_TX1);//切换端口1

                    //FALSE 显示设置值

                    if (Tx1Hander != null)
                        Tx1Hander(s, ref sen_tx1, true);

                }
                else
                {
                    //--------------------------------------------------------------------------------------

                    double dd1 = 0;
                    double dd2 = 0;
                    //P2功率检测

                    s = ClsJcPimDll.HwGetSig_Smooth(ref dd2, ClsJcPimDll.JC_CARRIER_TX2);//检测功放2稳定度
                    //double sen_tx2 = 0;
                    if (Tx2Hander != null)
                        Tx2Hander(s, ref sen_tx2, false);
                    if (s <= -10000 && ClsUpLoad._checkPow)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                        return;
                    }
                    //--------------------------------------------------------------------------------------
                    //切换coup1
                    ClsJcPimDll.HwSetCoup(ClsJcPimDll.JC_COUP_TX1);//切换端口1
                    //P1功率检测

                    s = ClsJcPimDll.HwGetSig_Smooth(ref dd1, ClsJcPimDll.JC_CARRIER_TX1);//检测tx1稳定度
                    //double sen_tx1 = 0;
                    if (Tx1Hander != null)
                        Tx1Hander(s, ref sen_tx1, false);
                    if (s <= -1000 && ClsUpLoad._checkPow)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                        return;
                    }
                    //--------------------------------------------------------------------------------------
                }
                //st.Stop();

                //MessageBox.Show("time: " + st.ElapsedMilliseconds.ToString() + "ms");
                SweepTest();
         
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

        public abstract void SweepTest();

    }

    public  class SweepTime : Sweep
    {
 

        public SweepTime(DataSweep ds, string type)
            : base(ds, type)
        { }
        public override void SweepTest()
        {
            double get_xnum = 0;
            if (ClsUpLoad.sm == SweepMode.Poi || ClsUpLoad.sm == SweepMode.Np)
            {
                get_xnum = StaticMethod.GetFreq(ds.imCo1, ds.imCo2, ds.imLow, ds.imLess, ds.freq1s, ds.freq2e);//当前扫频频率
                if (get_xnum > ds.MaxRx || get_xnum < ds.MinRx)//不在rx范围内则跳过
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                     MessageBox.Show("互调频率不在rx接收范围内");
                    return;
                }
            }
            else
            {
                get_xnum = StaticMethod.GetFreq(ds.imCo1, ds.imCo2, 0, 0, ds.freq1s, ds.freq2e);//当前扫频频率
                if (ClsUpLoad.BandOrder[(int)ds.tx1]==1 && (ClsUpLoad._type == 0 || ClsUpLoad._type == 1))
                    get_xnum = StaticMethod.GetFreq(ds.imCo1, ds.imCo2, 1, 0, ds.freq1s, ds.freq2e);//当前扫频频率
                if (get_xnum > ds.MaxRx || get_xnum < ds.MinRx )//不在rx范围内则跳过
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    MessageBox.Show("互调频率不在rx接收范围内");
                    return;
                }
            }
            for (int i = 0; i < ds.time1; ++i)
            {
                double x = 0;
                double y = 0;
                Monitor.Enter(_ctrl);
                bool isQuit = _ctrl.bQuit;
                Monitor.Exit(_ctrl);

                if (isQuit)
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    return;
                }
                //读取pim
                double freq_mhz = 0;
                double val = 0;
                ClsJcPimDll.fnGetImResult(ref freq_mhz, ref val, "mhz");//读取互调值和互调频率
                x = (double)freq_mhz;
                val += ds.rx_off;
                y = (double)val;
                ds.sxy.x = x;
                ds.sxy.y = y;
                ds.sxy.current = i;
                ds.sxy.currentPlot = 0;
                ds.sxy.currentCount = i+1;
                ds.sxy.f1 = ds.freq1s;
                ds.sxy.f2 = ds.freq2e;
                Sthandmethod();
            }
            ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
        }


    }

    //重改版本开始（1.6.0.70）快速模式
        //快速模式：初始化时不检测和调整任何功率，只检测tx2功率，
       //快速模式下 第一条线：不切任何开关，只检测tx'2功率
       //第二条线：只在第一点时，先切到tx1检测tx1功率，再切到tx2，检测tx2功率，其他点时保留第一点的功率
  public   class SweepFreq : Sweep
    {
      public SweepFreq(DataSweep ds, string type)
          : base(ds, type)
      { }
        public override void SweepTest()
        {
            double f = ds.freq1s;
            double n1 = Math.Ceiling((ds.freq1e - ds.freq1s) / ds.step1);//扫描点数
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
            double x = 0;
            double y = 0;
            double step1 = ds.step1;
            double step2 = ds.step2 * 2;
          
            for (int i = 0; i <= n1; ++i)
            {

                Monitor.Enter(_ctrl);
                bool isQuit = _ctrl.bQuit;
                Monitor.Exit(_ctrl);
                if (ClsUpLoad.sm == SweepMode.Poi || ClsUpLoad.sm == SweepMode.Np)
                {
                    get_xnum = StaticMethod.GetFreq(ds.imCo1, ds.imCo2, ds.imLow, ds.imLess, f, ds.freq2e);//当前扫频频率
                    if (get_xnum > ds.MaxRx || get_xnum < ds.MinRx)//不在rx范围内则跳过
                    {
                        f += step1;//设置频率
                        m1++;//跳过点数加1
                        continue;
                    }
                }
    
                if (isQuit)
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    return;
                }

                if (f > ds.freq1e) f = ds.freq1e;//当前频率大于结束频率，设置当前频率为结束频率

                if (i != 0)
                {
                    //设置频率
                    s = ClsJcPimDll.fnSetTxPower(ds.pow1, ds.pow2, ds.freq_off1, ds.freq_off2);//设置功率
                    if (s <= -1000)
                    {
                        MessageBox.Show("setpow err");
                    }
                    //设置功率
                    s = ClsJcPimDll.HwSetTxFreqs(f, ds.freq2e, "mhz");//设置频率
                    //检测错误
                    if (s <= -10000)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                        PowHandmethod(s);
                    }
                    if (ClsUpLoad.fastmode == false)
                    {
                        //检测功放稳定度
                        if (ClsJcPimDll.HwGetSig_Smooth(ref dd1, ClsJcPimDll.JC_CARRIER_TX1) <= -1000)
                        {
                            MessageBox.Show("setsmooth err");
                        }
                    }
                }
                //读取pim    
                Random rd = new Random();
                double valzz = rd.Next(1, 4) / 10f;
                if (ClsUpLoad.fastmode)
                    sen_tx1 = ds.pow1 + ds.off1 + valzz;
                else
                    sen_tx1 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX1);//读取显示功率1
                ClsJcPimDll.fnGetImResult(ref freq_mhz, ref val, "mhz");//读取互调频率和互调值
                val += ds.rx_off;//互调值
                //显示

                x = (double)Math.Round(freq_mhz, 1);//互调频率四舍五入保留1位小数
                y = (double)Math.Round(val, 1);//互调值四舍五入保留1位小数
                ds.sen_tx1 = sen_tx1;
                ds.sxy.x = x;
                ds.sxy.y = y;
                ds.sxy.currentPlot = 0;
                ds.sxy.current = i;
                ds.sxy.currentCount = i + 1 - m1;
                ds.sxy.f1 = (double)f;
                ds.sxy.f2 = ds.freq2e;
                Sthandmethod();

                f += step1;//设置频率
            }
            if ((ClsUpLoad.sm == SweepMode.Poi || ClsUpLoad.sm == SweepMode.Np) && ClsUpLoad._portHole == 4)//poi模式4通道
            {
            
                f = ds.freq1s;
                n3 = Math.Ceiling((ds.freq1e - ds.freq1s) / step1);//扫描点数

                for (int i = 0; i <= n3; ++i)
                {
                    Monitor.Enter(_ctrl);
                    bool isQuit = _ctrl.bQuit;
                    Monitor.Exit(_ctrl);

                    get_xnum = StaticMethod.GetFreq(ds.imCo1, ds.imCo2, ds.imLow, ds.imLess, f, ds.freq2s);//当前频率
                    //超过rx范围则跳过
                    if (get_xnum > ds.MaxRx || get_xnum < ds.MinRx)
                    {
                        
                        f += step1;
                        m3++;
                        continue;
                    }

                    if (isQuit)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                        return;
                    }

                    if (f > ds.freq1e) f = ds.freq1e;
                    //设置频率
                    ClsJcPimDll.fnSetTxPower(ds.pow1, ds.pow2, ds.freq_off1, ds.freq_off2);//设置功率
                    //设置功率
                    s = ClsJcPimDll.HwSetTxFreqs(f, ds.freq2s, "mhz");//设置频率
                    //检测错误
                    if (s <= -10000)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                        PowHandmethod(s);
                        return;
                    }
                    ClsJcPimDll.HwGetSig_Smooth(ref dd1, ClsJcPimDll.JC_CARRIER_TX1);//检测功放稳定度
                    //}
                    //读取pim   
                   
                    sen_tx1 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX1);//切换端口
                    ClsJcPimDll.fnGetImResult(ref freq_mhz, ref val, "mhz");//获取互调值和互调频率
                    val += ds.rx_off;
                    //显示
                    x = (double)Math.Round(freq_mhz, 1);//互调频率四舍五入保留一位小数
                    y = (double)Math.Round(val, 1);//互调值四舍五入保留一位小数
                    ds.sen_tx1 = sen_tx1;
                    ds.sxy.x = x;
                    ds.sxy.y = y;
                    ds.sxy.currentPlot = 3;
                    ds.sxy.current = i;
                    //if (ClsUpLoad._portHole == 4)
                    ds.sxy.currentCount = (int)n1 + 1 + i + 1 - m1 - m3;
                    //else
                    //    ds.sxy.currentCount = (int)n1 + 1 + i + 1 - m1 - m3;
                    ds.sxy.f1 = (double)f;
                    ds.sxy.f2 = ds.freq2s;
                    Sthandmethod();
                    f += step1;
          
                }
            }
            //切换开关1
            if (ClsUpLoad.fastmode)
                ClsJcPimDll.HwSetCoup(ClsJcPimDll.JC_COUP_TX1);//切换端口1

            s = ClsJcPimDll.HwSetTxFreqs(ds.freq1s, ds.freq2e, "mhz");//设置频率
            if (s <= -10000)
            {
                ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                PowHandmethod(s);
                return;
            }
            ClsJcPimDll.HwGetSig_Smooth(ref dd1, ClsJcPimDll.JC_CARRIER_TX1);//检测功放稳定度
            sen_tx1 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX1);//获取tx1显示功率

            ClsJcPimDll.HwSetCoup(ClsJcPimDll.JC_COUP_TX2);//切换端口2
            Thread.Sleep(100);//暂停
            f = ds.freq2e;
            n2 = Math.Ceiling((ds.freq2e - ds.freq2s) / step2);//扫描点数
            for (int i = 0; i <= n2; ++i)
            {
                Monitor.Enter(_ctrl);
                bool isQuit = _ctrl.bQuit;
                Monitor.Exit(_ctrl);
                if (ClsUpLoad.sm == SweepMode.Poi || ClsUpLoad.sm == SweepMode.Np)
                {
                    get_xnum = StaticMethod.GetFreq(ds.imCo1, ds.imCo2, ds.imLow, ds.imLess, ds.freq1s, f);//当前扫描频率
                    //频率 超过rx范围就跳过
                    if (get_xnum > ds.MaxRx || get_xnum < ds.MinRx)
                    {
                        f -= step2;
                        m2++;
                        continue;
                    }
                }
              
                if (isQuit)
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    return;
                }
                if (f < ds.freq2s) f = ds.freq2s;
                //设置频率
                //if (ClsUpLoad.sm != SweepMode.Poi)
                //    ClsJcPimDll.fnSetTxPower(43, 43, ds.freq_off1, ds.freq_off1);//设置功率
                //else
                    ClsJcPimDll.fnSetTxPower(ds.pow1, ds.pow2, ds.freq_off1, ds.freq_off2);//设置功率
                //设置功率
                s = ClsJcPimDll.HwSetTxFreqs(ds.freq1s, f, "mhz");//设置频率
                if (s <= -10000)
                {
                    ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                    PowHandmethod(s);
                    return;
                }
                //读取
                if (ClsUpLoad.fastmode)//快速模式只在第一个点检测功率
                {
                    if (i == 0)
                    {
                        ClsJcPimDll.HwGetSig_Smooth(ref dd2, ClsJcPimDll.JC_CARRIER_TX2);//检测功放稳定度
                        sen_tx2 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX2);//获取tx2显示功率
                    }
                }
                else
                {
                    ClsJcPimDll.HwGetSig_Smooth(ref dd2, ClsJcPimDll.JC_CARRIER_TX2);//检测功放稳定度
                    sen_tx2 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX2);//获取tx2显示功率
                }

                ClsJcPimDll.fnGetImResult(ref freq_mhz, ref val, "mhz");//获取互调值和互调频率
                val += ds.rx_off;

                 
          
                //显示
                x = (double)Math.Round(freq_mhz, 1);//互调频率
                y = (double)Math.Round(val, 1);//互调值
                ds.sen_tx2 = sen_tx2;
                ds.sen_tx1 = sen_tx1;
                ds.sxy.x = x;
                ds.sxy.y = y;
                ds.sxy.currentPlot = 1;
                ds.sxy.current = i;
                ds.sxy.currentCount = (int)n1 + 1 + (int)n3 + 1 + i - m1 - m2 - m3;
                ds.sxy.f2 = (double)f;
                ds.sxy.f1 = ds.freq1s;
                Sthandmethod();
                f -= step2;
            }
            if ((ClsUpLoad.sm == SweepMode.Poi || ClsUpLoad.sm == SweepMode.Np) && ClsUpLoad._portHole == 4)
            {
              
                f = ds.freq2e;
                n4 = Math.Ceiling((ds.freq2e - ds.freq2s) / step2);
                for (int i = 0; i <= n4; ++i)
                {
                    Monitor.Enter(_ctrl);
                    bool isQuit = _ctrl.bQuit;
                    Monitor.Exit(_ctrl);
                    get_xnum = StaticMethod.GetFreq(ds.imCo1, ds.imCo2, ds.imLow, ds.imLess, ds.freq1e, f);
                    if (get_xnum > ds.MaxRx || get_xnum < ds.MinRx)
                    {
                 
                        f -= step2;
                        m4++;
                        continue;
                    }
                    if (isQuit)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);//关闭功放
                        return;
                    }
                    if (f < ds.freq2s) f = ds.freq2s;
                    //设置频率
                    ClsJcPimDll.fnSetTxPower(43, 43, ds.freq_off1, ds.freq_off2);
                    //设置功率
                    s = ClsJcPimDll.HwSetTxFreqs(ds.freq1e, f, "mhz");
                    if (s <= -10000)
                    {
                        ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);
                        PowHandmethod(s);
                        return;
                    }
                    //读取
                    ClsJcPimDll.HwGetSig_Smooth(ref dd2, ClsJcPimDll.JC_CARRIER_TX2);
                    sen_tx2 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX2);
                    ClsJcPimDll.fnGetImResult(ref freq_mhz, ref val, "mhz");
                    val += ds.rx_off;
                    //显示
                    x = (double)Math.Round(freq_mhz, 1);
                    y = (double)Math.Round(val, 1);
                    ds.sen_tx2 = sen_tx2;
                    ds.sxy.x = x;
                    ds.sxy.y = y;
                    ds.sxy.currentPlot = 2;
                    ds.sxy.current = i;
                    ds.sxy.currentCount = (int)n3 + 1 + (int)n1 + 1 + (int)n2 + 1 + i + 1 - m1 - m2 - m3 - m4;
                    ds.sxy.f2 = (double)f;
                    ds.sxy.f1 = ds.freq1e;
                    Sthandmethod();
                    f -= step2;
                    
                }
            }
            ClsJcPimDll.fnSetTxOn(false, ClsJcPimDll.JC_CARRIER_TX1TX2);

        }
    }

   public  class SweepCtrl
    {
        public bool bQuit;
    }

}

