using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
   public  class ClsUpLoad
    {
        string filename;
        public  string filenameS;
        public  string filenameB;
        public static List<int> Ord=new List<int>();
        public ClsUpLoad(string filename)
        {
            this.filename = filename;
        }
        #region 配置文件
        public static  SweepMode sm=SweepMode.Poi;
        public static  float _limit = -110;//limit指标
        public static  bool _vco = false;//vco检测
        public static   bool _checkTwoSignalROSC = false;//同步线
        public static  bool _checkPow = false;//功率
        public static  bool _cyclicSweep = false;
        public static  bool _demoMode = false;
        public static  bool _pdfTable = true;//pdf生成表格
        public static  decimal _sleepTime = 100;
        public static  int _portHole = 2;
        public static string addr_sen="";
        public static string addr_sig1="";//信号源1
        public  static string addr_sig2="";//信号源2
        public static string addr_ana="";
        public static  string addr_sen_ext="";
        public static  string addr_swh="";
        public static int _type = 1;
        public   int length = 8;
        public static int sweep_index = 5;
        public static int qiaoji_times = 0;
        public static string id = "";

        #endregion


        //public Dictionary<string, int> d_BandNum = new Dictionary<string, int>();
        //public Dictionary<int, string> d_BandString = new Dictionary<int, string>();
        public List<double> RxVal = new List<double>();//rx校准数据
        public List<double> TxVal = new List<double>();//tx校准数据
        public List<string> AllBandNames = new List<string>();
        public static List<byte> AllBandOrder = new List<byte>();
        public List<string> BandNames = new List<string>();
        public List<int> BandCount = new List<int>();
        public static List<byte> BandOrder = new List<byte>();
        public LoadingData[] ld;
        public static List<int> TX1Enable = new List<int>();
        public static List<int> TX2Enable = new List<int>();  
        public static List<int> RXEnable = new List<int>();  
        
       /// <summary>
       /// 加载配置文件数据
       /// </summary>
        public void UpLoad()
        {
            IniFile.SetFileName(filename + "\\JcConfig.ini");
            addr_sen = IniFile.GetString("Settings", "sensor", "0");//功率计地址
            addr_sig1 = IniFile.GetString("Settings", "signal1", "0");//信号源1地址
            addr_sig2 = IniFile.GetString("Settings", "signal2", "0");//信号源2地址
            addr_ana = IniFile.GetString("Settings", "analyzer", "0");//频谱仪地址
            _limit = float.Parse(IniFile.GetString("Settings", "limit", "-110"));
            _vco = IniFile.GetString("Settings", "vco_enable", "1") == "0" ? false : true;
            _checkTwoSignalROSC = IniFile.GetString("Settings", "CheckTwoSignalROSC", "1") == "1" ? true : false;
            _checkPow = IniFile.GetString("DEBUG", "checkpow", "1") == "1" ? true : false;
            //_cyclicSweep = IniFile.GetString("DEBUG", "circulation", "0") == "1" ? true : false;
            //_demoMode = IniFile.GetString("Settings", "demo_mode", "0") == "1" ? true : false;
            _pdfTable = IniFile.GetString("DEBUG", "pdf_table", "0") == "1" ? true : false;
            _sleepTime = decimal.Parse(IniFile.GetString("Settings", "poi_sleep_time", "20000"));
            _portHole = int.Parse(IniFile.GetString("Port", "scanNumber", "2"));
            _type = int.Parse(IniFile.GetString("Settings", "type_trans", "1"));
            sweep_index = int.Parse(IniFile.GetString("Settings", "sweep_times", "5"));
            qiaoji_times = int.Parse(IniFile.GetString("Settings", "qiaoji_times", "5"));
            id = IniFile.GetString("Settings", "pim_id", "12345");
            if (_type == 0||_type==1)
            {            
                sm =SweepMode.Hw;
                filenameB = filename + "\\Band\\band";
                filenameS = filename + "\\Band\\bandtext.ini";
                 length = int.Parse(IniFile.GetString("BandCount", "count", "8",filenameS));
                 OrderS();
            }
            else if (_type == 2)
            {
                length = 12;
                sm = SweepMode.Poi;
                filenameB = filename + "\\Band\\poi_band";
                filenameS = filename + "\\Band\\poibandtext.ini";
                length = int.Parse(IniFile.GetString("BandCount", "count", "12", filenameS));
            }
            else if (_type == 3)
            {
                length = 12;
                sm = SweepMode.Np;
                filenameB = filename + "\\Band\\newpoi_band";
                filenameS = filename + "\\Band\\newpbandtext.ini";
                length = int.Parse(IniFile.GetString("BandCount", "count", "12", filenameS));
            }
            else
            {
                sm = SweepMode.Hw;
                filenameB = filename + "\\Band\\newband";
                filenameS = filename + "\\Band\\newbandtext.ini";
                length = int.Parse(IniFile.GetString("BandCount", "count", "16", filenameS));
            }

            GetRT();
            BandS();
            GetData();
        }

        void GetData()
        {
            ld = new LoadingData[length];
            for (int i = 0; i < length; i++)
            {
                IniFile.SetFileName(filenameS);
                string val = IniFile.GetString("Text", "band" + i.ToString(), "error");
                if (val.Contains(":"))
                    continue;
                ld[i] = new LoadingData();
                ld[i].LoadSettings(filenameB + i.ToString() + "_Specifics.ini");
            }
        }

        void GetRT()
        {          
            
            for (int i = 0; i < length; i++)
            {
                IniFile.SetFileName(filenameB + i.ToString() + "_Specifics.ini");
                double val=double.Parse(IniFile.GetString("Tx_Offsets","tx_band","0"));
                TxVal.Add(val);
                val = double.Parse(IniFile.GetString("Rx_Offsets", "rx_band", "0"));
                RxVal.Add(val);
            }
        }

        void BandS()
        { 
             
            IniFile.SetFileName(filenameS);
            
            for (int i = 0; i < length; i++)
            {
                
                string val=IniFile.GetString("Text","band"+i.ToString(),"error");
                //if (_type == 1 || _type == 0)
                //{
                try
                {
                    if (val.Contains("--")&&!val.Contains(",")) val = "notband,99,0,111:0";

                    string[] vals = val.Split(',');
                    
                    AllBandNames.Add(vals[0]);
                    BandOrder.Add(byte.Parse(vals[2].Substring(0, 1)));
                    int enable = Convert.ToInt32(vals[3].Substring(0,3), 16);
                    TX1Enable.Add((enable & 0x100) >> 8);
                    TX2Enable.Add((enable & 0x010) >> 4);
                    RXEnable.Add((enable & 0x001));
                    if (val.Contains(":0")) continue;
                    BandNames.Add(vals[0]);
                    BandCount.Add(int.Parse(vals[1]));
                    //BandOrder.Add(byte.Parse(vals[2]));
                    //d_BandNum.Add(val, i);
                    //d_BandString.Add(i, val);
                    //}
                    //else
                    //{
                    //    string[] vals = val.Split(',');
                    //    AllBandNames.Add(vals[0]);
                    //    BandNames.Add(vals[0]);
                    //    BandCount.Add(int.Parse(vals[1]));
                    //}
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message+"\r\n"+val);
                }
            }
        }
        
        void OrderS()
        {
            IniFile.SetFileName(filenameS);
            string val = IniFile.GetString("Order", "order" , "-1000");
            string[] vals = val.Split(',');
            for (int i = 0; i < vals.Length; i++)
            {
                Ord.Add(int.Parse(vals[i]));
            }

        }

    }

    /// <summary>
    /// 各个频段数据
    /// </summary>
    public  class LoadingData
    {
       
        public float set_rx_Max = 0;//rx最大值
        public float set_rx_Min = 0;//rx最小值
        public string Info;
        public float ord3_F1UpS = 930;//默认3阶f1起始频率
        public float ord3_F1UpE = 937;//默认3阶f1结束频率
        public float ord3_F2DnS = 945;//默认3阶f2起始频率
        public float ord3_F2DnE = 960;//默认3阶f2结束频率
        public float ord3_F1Step = 1;//默认3阶f1步进
        public float ord3_F2Step = 1;//默认3阶f1步进
        public float ord3_imS = 899;//默认3阶rx起始频率
        public float ord3_imE = 915;//默认3阶rx结束频率
        public float ord5_F1UpS = 933;
        public float ord5_F1UpE = 941;
        public float ord5_F2DnS = 942;
        public float ord5_F2DnE = 957;
        public float ord5_F1Step = 1;
        public float ord5_F2Step = 1;
        public float ord5_imS = 885;
        public float ord5_imE = 915;
        public float ord7_F1UpS = 938;
        public float ord7_F1UpE = 942;
        public float ord7_F2DnS = 947;
        public float ord7_F2DnE = 955;
        public float ord7_F1Step = 1;
        public float ord7_F2Step = 1;
        public float ord7_imS = 886;
        public float ord7_imE = 912;
        public float ord9_F1UpS = 939;
        public float ord9_F1UpE = 942;
        public float ord9_F2DnS = 946;
        public float ord9_F2DnE = 952;
        public float ord9_F1Step = 1;
        public float ord9_F2Step = 1;
        public float ord9_imS = 886;
        public float ord9_imE = 912;
      
        public float TxS = 930;
        public float TxE = 960;
        public float RxS = 885;
        public float RxE = 915;

        public float F1Min = 925;//f1最小值
        public float F1Max = 960;//f1最大值
        public float F2Min = 925;//f2最小值
        public float F2Max = 960;//f2最大值
        public float RxMin = 880;//rx最小值
        public float RxMax = 915;//tx最大值
       

        

        internal void LoadSettings(string fileName)
        {
            IniFile.SetFileName(fileName);
            ord3_F1UpS = float.Parse(IniFile.GetString("Specifics", "ord3_F1UpS", "869")); //F1: 869~871.5 
            ord3_F1UpE = float.Parse(IniFile.GetString("Specifics", "ord3_F1UpE", "871.5"));
            ord3_F2DnS = float.Parse(IniFile.GetString("Specifics", "ord3_F2DnS", "889")); //F2: 889~894
            ord3_F2DnE = float.Parse(IniFile.GetString("Specifics", "ord3_F2DnE", "894"));
            ord3_F1Step = float.Parse(IniFile.GetString("Specifics", "ord3_F1Step", "1")); //Step
            ord3_F2Step = float.Parse(IniFile.GetString("Specifics", "ord3_F2Step", "1"));
            ord3_imS = float.Parse(IniFile.GetString("Specifics", "ord3_imS", "844")); //Im3: 844~849
            ord3_imE = float.Parse(IniFile.GetString("Specifics", "ord3_imE", "849"));

            ord5_F1UpS = float.Parse(IniFile.GetString("Specifics", "ord5_F1UpS", "869")); //F1: 869~871.5 
            ord5_F1UpE = float.Parse(IniFile.GetString("Specifics", "ord5_F1UpE", "871.5"));
            ord5_F2DnS = float.Parse(IniFile.GetString("Specifics", "ord5_F2DnS", "889")); //F2: 889~894
            ord5_F2DnE = float.Parse(IniFile.GetString("Specifics", "ord5_F2DnE", "894"));
            ord5_F1Step = float.Parse(IniFile.GetString("Specifics", "ord5_F1Step", "1")); //Step
            ord5_F2Step = float.Parse(IniFile.GetString("Specifics", "ord5_F2Step", "1"));
            ord5_imS = float.Parse(IniFile.GetString("Specifics", "ord5_imS", "844")); //Im3: 844~849
            ord5_imE = float.Parse(IniFile.GetString("Specifics", "ord5_imE", "849"));

            ord7_F1UpS = float.Parse(IniFile.GetString("Specifics", "ord7_F1UpS", "869")); //F1: 869~871.5 
            ord7_F1UpE = float.Parse(IniFile.GetString("Specifics", "ord7_F1UpE", "871.5"));
            ord7_F2DnS = float.Parse(IniFile.GetString("Specifics", "ord7_F2DnS", "889")); //F2: 889~894
            ord7_F2DnE = float.Parse(IniFile.GetString("Specifics", "ord7_F2DnE", "894"));
            ord7_F1Step = float.Parse(IniFile.GetString("Specifics", "ord7_F1Step", "1")); //Step
            ord7_F2Step = float.Parse(IniFile.GetString("Specifics", "ord7_F2Step", "1"));
            ord7_imS = float.Parse(IniFile.GetString("Specifics", "ord7_imS", "844")); //Im3: 844~849
            ord7_imE = float.Parse(IniFile.GetString("Specifics", "ord7_imE", "849"));

            ord9_F1UpS = float.Parse(IniFile.GetString("Specifics", "ord9_F1UpS", "869")); //F1: 869~871.5 
            ord9_F1UpE = float.Parse(IniFile.GetString("Specifics", "ord9_F1UpE", "871.5"));
            ord9_F2DnS = float.Parse(IniFile.GetString("Specifics", "ord9_F2DnS", "889")); //F2: 889~894
            ord9_F2DnE = float.Parse(IniFile.GetString("Specifics", "ord9_F2DnE", "894"));
            ord9_F1Step = float.Parse(IniFile.GetString("Specifics", "ord9_F1Step", "1")); //Step
            ord9_F2Step = float.Parse(IniFile.GetString("Specifics", "ord9_F2Step", "1"));
            ord9_imS = float.Parse(IniFile.GetString("Specifics", "ord9_imS", "844")); //Im3: 844~849
            ord9_imE = float.Parse(IniFile.GetString("Specifics", "ord9_imE", "849"));



            TxS = float.Parse(IniFile.GetString("Specifics", "TxS", "869")); //Tx: 869~894
            TxE = float.Parse(IniFile.GetString("Specifics", "TxE", "894"));
            RxS = float.Parse(IniFile.GetString("Specifics", "RxS", "824")); //Rx: 824~849
            RxE = float.Parse(IniFile.GetString("Specifics", "RxE", "849"));

            F1Min = float.Parse(IniFile.GetString("Specifics", "F1Min", "925"));
            F1Max = float.Parse(IniFile.GetString("Specifics", "F1Max", "960"));
            F2Min = float.Parse(IniFile.GetString("Specifics", "F2Min", "925"));
            F2Max = float.Parse(IniFile.GetString("Specifics", "F2Max", "960"));
            set_rx_Min = RxMin = float.Parse(IniFile.GetString("Specifics", "RxMin", "0"));
            set_rx_Max = RxMax = float.Parse(IniFile.GetString("Specifics", "RxMax", "0"));

        }

        internal class ScriptConfig
        { 
        
        
        }

      
    }
    class BandIni
    {
        float f1s = 0;
        float f1e = 0;
        float f2s = 0;
        float f2e = 0;
    
    }
}
