using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace JcMBP
{
  public  class TestData
    {
        public TestData(int number)
        {
            if (surFaceData_dbm.Columns.Count > 1)
                return;
            surFaceData_dbm.Columns.Add("No.");
            surFaceData_dbm.Columns.Add("Peak");
            surFaceData_dbm.Columns.Add("Fluctuate");
            surFaceData_dbm.Columns.Add("Result");
            surFaceData_dbc.Columns.Add("No.");
            surFaceData_dbc.Columns.Add("Peak");
            surFaceData_dbc.Columns.Add("Fluctuate");
            surFaceData_dbc.Columns.Add("Result");

            for (int i = 0; i < number; i++)
            {
                tx1Date.Add(new Tx_());
                tx2Date.Add(new Tx_());
                rxDate.Add(new Rx_());
                pimDate.Add(new Pim());
            }
        
        }
      public  List<Tx_> tx1Date = new List<Tx_>();
      public List<Tx_> tx2Date = new List<Tx_>();
      public  List<Rx_> rxDate = new List<Rx_>();
      public  List<Pim> pimDate = new List<Pim>();
      public float limit = -110;
      public float limit_dbc = -153;
      public DataTable surFaceData_dbm = new DataTable();
      public DataTable surFaceData_dbc = new DataTable();
      public float dbm_y = -140;
      public float dbm_y_e = -80;
      public float dbc_y = -183;
      public float dbc_y_e = -123;
    }



    public class Tx_
    {
      public  int band ;
      public double fs ;
      public double fe ;
      public double pow ;
      public string bandName ;
      public int port ;
      public double off ;
      public int sweeptime ;
      public double step ;
    }

   public   class Rx_
    {
       public int band ;
       public string bandName ;
       public float maxVal ;
       public float MinVal ;
       public float currentRxs ;
       public float currentRxe ;
       public int port ;
      
    }

   public  class Pim
    {
       public Pim()
       {
           if (dt_dbm.Columns.Count > 1)
               return;
           dt_dbm.Columns.Add("NO.");//添加数据源
           dt_dbm.Columns.Add("F1(MHz)");//添加数据源
           dt_dbm.Columns.Add("P1(dBm)");//添加数据源
           dt_dbm.Columns.Add("F2(MHz)");//添加数据源
           dt_dbm.Columns.Add("P2(dBm)");//添加数据源
           dt_dbm.Columns.Add("Im_F(MHz)");//添加数据源
           dt_dbm.Columns.Add("Im_V(dBm)");//添加数据源
           dt_dbc.Columns.Add("NO.");//添加数据源
           dt_dbc.Columns.Add("F1(MHz)");//添加数据源
           dt_dbc.Columns.Add("P1(dBm)");//添加数据源
           dt_dbc.Columns.Add("F2(MHz)");//添加数据源
           dt_dbc.Columns.Add("P2(dBm)");//添加数据源
           dt_dbc.Columns.Add("Im_F(MHz)");//添加数据源
           dt_dbc.Columns.Add("Im_V(dBm)");//添加数据源
       }
       
    public  List<float> pimVal_dbm = new List<float>();
    public  List<float> pimVal_dbc = new List<float>();
    public  List<float> pimFreq = new List<float>();
    public  string result = "Fail";
    public DataTable dt_dbm = new DataTable();
    public DataTable dt_dbc = new DataTable();
    public int nowSweepPoint = 1;
    public int num1 = 0;
    public int num2 = 0;
    public int num3 = 0;
    public  int num4 = 0;
    public int currentPort = 0;
    public int currentTime = 0;
    public int imCo1;
    public int imCo2;
    public int imLow;
    public int imLess;
    public int order;
    public float sen_tx1 = 43;
    public float sen_tx2 = 43;
    public float currentTestF1 = 0;
    public float currentTestF2 = 0;
    public float currentpimMax = 0;
    public float currentpimMax_dbc = 0;
    }
}
