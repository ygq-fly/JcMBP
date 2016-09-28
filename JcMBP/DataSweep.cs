using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Drawing;

namespace JcMBP
{

    class Setting
    { 
    
    }
    /// <summary>
    /// 扫描数据
    /// </summary>
    public  class DataSweep
    {
        #region 设置数据
        public string jbName = "";
        public int num = 0;
        public string pauseMessage = "";
        public double ystart = 0;
        public double yend = 0;
        public double xstart = 0;
        public double xend = 0;
        public double limit = -110;
        public int timeout = 10;
        public byte order = 3;
        public  byte port = 0;
        public  double sen_tx1 = 0;//tx1显示功率
        public  double sen_tx2 = 0;//tx2显示功率
        public  double x = 0;
        public  double y = 0;
        public  double freq_mhz = 0;//互调频率
        public  double val = 0;//互调值
        public  DataTable dt;
        public  DataTable dtc;
        public  DataTable dtm;
        public  DataTable dtm_c;
        public DataTable jb;
        public DataTable jbc;
        public DataTable dtm_count;
        public DataTable dtm_c_count;
        public SweepXY sxy;
        public double MaxRx;
        public double MinRx;
        public double dbm_y = -140;
        public double dbm_y_e = -80;
        public double dbc_y = -183;
        public double dbc_y_e = -123;
        public  string timeou_mes = "";
        #endregion

        #region 扫描数据
        //=============
        public double freq1s;
        public double freq1e;
        public double freq2s;
        public double freq2e;
        public double step1;
        public double step2;
        public double pow1;
        public double pow2;
        public double time1;
        public double time2;
        public byte tx1 = 3;
        public byte tx2 = 3;
        public byte rx = 3;
        public byte imCo1 = 2;
        public byte imCo2 = 1;
        public byte imLow = 0;
        public byte imLess = 0;
        public byte tx1Port = 0;
        public byte tx2Port = 0;
        public byte rxPort = 0;
        public double time_off1 = 0;
        public double time_off2 = 0;
        public double freq_off1 = 0;
        public double freq_off2 = 0;
        public double rx_off = 0;
        public double off1 = 0;
        public double off2 = 0;
        #endregion

        public DataSweep()
        {
            dt = new DataTable();//点频
            dtc = new DataTable();
            dtm = new DataTable();//扫频
            dtm_c = new DataTable();
            jbc = new DataTable();//脚本
            jb = new DataTable();
            sxy = new SweepXY();
        }

    }

  public   class SweepXY
  {
      public DateTime starttime ;
      public DateTime endtime;
      public TimeSpan spantime; 
      public string str_data = "";
      public string overViewMessage = "";
      public string sweep_data_header = "";
      public System.Drawing.Image image1 = null;
      public System.Drawing.Image image2 = null;
      public string bandM = "";
      public string time_out_M = "-";
      public byte model = 0;
      public List<string> pdf_val = new List<string>();
        public double  x;
        public double   y;
        public double f1;
        public double f2;
        public int current;
        public int currentPlot;
        public double currentf1;
        public double currentf2;
        public double max = 0;
        public double min = 0;
        public string result = "PASS";
        public int n1 = 0;
        public int n2 = 0;
        public int n3 = 0;
        public int n4 = 0;
        public int currentCount;
        public List<PointF> lf0 = new List<PointF>();//第一条point点
        public List<PointF> lf1 = new List<PointF>();//第二条point点
        public List<PointF> lf2 = new List<PointF>();//第三条point点
        public List<PointF> lf3 = new List<PointF>();//第四条point点
        public List<PointF> lf0c = new List<PointF>();
        public List<PointF> lf1c = new List<PointF>();
        public List<PointF> lf2c = new List<PointF>();
        public List<PointF> lf3c = new List<PointF>();

        public Dictionary<int, List<PointF>> pf_arr = new Dictionary<int, List<PointF>>();
        
       public SweepXY()
        {
            pf_arr.Add(0, lf0);
            pf_arr.Add(1, lf1);
            pf_arr.Add(2, lf2);
            pf_arr.Add(3, lf3);
            pf_arr.Add(4, lf0c);
            pf_arr.Add(5, lf1c);
            pf_arr.Add(6, lf2c);
            pf_arr.Add(7, lf3c);
        }
        
    }
}
