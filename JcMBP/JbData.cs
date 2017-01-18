using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public  class JbData
    {
        ClsUpLoad cul;
        public byte tx1 = 0;
        public byte tx2 = 0;
        public byte rx = 0;
        public double f1s = 0;
        public double f1e = 0;
        public double f2s = 0;
        public double f2e = 0;
        public string formula = "";
        public byte model = 0;
        public double time = 5;
        public double step = 1;
        public double pow = 43;
        public double off1 = 0;
        public double off2 = 0;
        public double rx_off = 0;
        public double rxs = 0;
        public double rxe = 0;
        public double limit = -110;
        public byte imCo1 = 2;
        public byte imCo2 = 1;
        public byte imLow = 0;
        public byte imLess = 0;
        public string bandM = "";
        public string time_out_M = "";
        public byte porttx1 = 0;
        public byte porttx2 = 0;
        public byte portrx = 0;

        public  void LoadData(string filename, int i,int Np,ClsUpLoad cul)
        {
           
                IniFile.SetFileName(@filename);
                string[] str = (IniFile.GetString("Data", "num" + i.ToString(), "0")).Split(',');
                if (str[0].ToString() == "--")
                {
                    time_out_M = str[18];
                    return;
                }
                this.cul = cul;
                tx1 = byte.Parse(str[0]);
                f1s = double.Parse(str[1]);
                f1e = double.Parse(str[2]);
                tx2 = byte.Parse(str[3]);
                f2s = double.Parse(str[4]);
                f2e = double.Parse(str[5]);
                rx = byte.Parse(str[6]);
                model = byte.Parse(str[7]);
                formula = str[8];
                time = step = double.Parse(str[9]);
                pow = double.Parse(str[10]);
                off1 = double.Parse(str[11]);
                off2 = double.Parse(str[12]);
                rx_off = double.Parse(str[13]);
                rxs  = double.Parse(str[14]);
                rxe = double.Parse(str[15]);
                //GetRx();
                limit = double.Parse(str[16]);
                imCo1 = byte.Parse(str[17]);
                imCo2 = byte.Parse(str[18]);
                imLow = byte.Parse(str[19]);
                imLess = byte.Parse(str[20]);
                if (Np == 3)
                {
                    porttx1 = byte.Parse(str[23]);
                    porttx2 = byte.Parse(str[24]);
                    portrx = byte.Parse(str[25]);
                }

                bandM = str[21];
                time_out_M = str[22];
      
        }

        public void GetRx()
        {
            int jb_band = imCo1 + imCo2;
            switch (jb_band)
            {
                case 3:
                    rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)rx)])]].ord3_imE;
                    rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)rx)])]].ord3_imS;
                    break;
                case 5:
                    rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)rx)])]].ord5_imE;
                    rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)rx)])]].ord5_imS;
                    break;
                case 7:
                    rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)rx)])]].ord7_imE;
                    rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)rx)])]].ord7_imS;
                    break;
                case 9:
                    rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)rx)])]].ord9_imE;
                    rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)rx)])]].ord9_imS;
                    break;
                default:
                    rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)rx)])]].ord3_imE;
                    rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cul.BandNames[cul.BandCount.IndexOf((int)rx)])]].ord3_imS;
                    break;
            }


        }

     
    }
}
