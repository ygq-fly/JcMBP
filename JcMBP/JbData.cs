using System;
using System.Collections.Generic;
using System.Text;

namespace JcMBP
{
    public  class JbData
    {
        public byte tx1 = 0;
        public byte tx2 = 0;
        public byte rx = 0;
        public float f1s = 0;
        public float f1e = 0;
        public float f2s = 0;
        public float f2e = 0;
        public string formula = "";
        public byte model = 0;
        public float time = 5;
        public float step = 1;
        public float pow = 43;
        public float off1 = 0;
        public float off2 = 0;
        public float rxs = 0;
        public float rxe = 0;
        public float limit = -110;
        public byte imCo1 = 2;
        public byte imCo2 = 1;
        public byte imLow = 0;
        public byte imLess = 0;
        public string bandM = "";
        public string time_out_M = "";
        public byte porttx1 = 0;
        public byte porttx2 = 0;
        public byte portrx = 0;

        public  void LoadData(string filename, int i,int Np)
        {
            IniFile.SetFileName(@filename);
            string[] str = (IniFile.GetString("Data", "num" + i.ToString(), "0")).Split(',');
            if (str[0].ToString() == "--")
            {
                time_out_M = str[18];
                return;
            }
            tx1 = byte.Parse(str[0]);
            f1s = float.Parse(str[1]);
            f1e = float.Parse(str[2]);
            tx2 = byte.Parse(str[3]);
            f2s = float.Parse(str[4]);
            f2e = float.Parse(str[5]);
            rx = byte.Parse(str[6]);
            model = byte.Parse(str[7]);
            formula = str[8];
            time = step = float.Parse(str[9]);
            pow = float.Parse(str[10]);
            off1 = float.Parse(str[11]);
            off2 = float.Parse(str[12]);
            rxs = float.Parse(str[13]);
            rxe = float.Parse(str[14]);
            limit = float.Parse(str[15]);
            imCo1 = byte.Parse(str[16]);
            imCo2 = byte.Parse(str[17]);
            imLow = byte.Parse(str[18]);
            imLess = byte.Parse(str[19]);
            if (Np == 3)
            {
                porttx1 = byte.Parse(str[22]);
                porttx2 = byte.Parse(str[23]);
                portrx = byte.Parse(str[24]);
            }
       
                bandM = str[20];
                time_out_M = str[21];
           
        }
    }
}
