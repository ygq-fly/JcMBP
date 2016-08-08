using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace JcMBP
{
   


    class OfftenMethod
    {
        /// <summary>
        /// panel加载窗体
        /// </summary>
        /// <param name="CurrentF">当前窗体</param>
        /// <param name="SwitchF">切换窗体</param>
        /// <param name="p">panel</param>
        public static void SwitchWindow(Form CurrentF, Form SwitchF, Panel p)
        {
            SwitchF.TopLevel = false;
            CurrentF.Controls.Add(SwitchF);
            SwitchF.Parent = p;
        }
        /// <summary>
        /// 显示当前活动窗体，隐藏不活动窗体
        /// </summary>
        /// <param name="CurrentF"></param>
        /// <param name="SwitchF"></param>
        public static void ShowW(Form CurrentF, Form SwitchF)
        {
            CurrentF.Hide();
            SwitchF.Show();
        }

        /// <summary>
        /// 设置控件最大最小值
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="fe"></param>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        public static void NudValue(NumericUpDown fs,NumericUpDown fe,decimal val1,decimal val2)
        {       
            fs.Minimum = val1;
            fs.Maximum = val2;
            fe.Minimum = val1;
            fe.Maximum = val2;
            fs.Value = val1;
            fe.Value = val2;
        }

        /// <summary>
        /// 加载combobox频段信息
        /// </summary>
        /// <param name="cb">comcobox控件</param>
        /// <param name="val">信息</param>
        public static void LoadComboBox(ComboBox cb, List<string> val, int band)
        {
            cb.Items.Clear();

            switch (band)
            {
                case 0:
                    for (int i = 0; i < val.Count; i++)
                    {
                        if (ClsUpLoad.TX1Enable[i] == 1)
                            cb.Items.Add(val[i]);
                    }
                    break;
                case 1:
                    for (int i = 0; i < val.Count; i++)
                    {
                        if (ClsUpLoad.TX2Enable[i] == 1)
                            cb.Items.Add(val[i]);
                    }
                    break;
                case 2:
                    for (int i = 0; i < val.Count; i++)
                    {
                        if (ClsUpLoad.RXEnable[i] == 1)
                            cb.Items.Add(val[i]);
                    }
                    break;
            }
        }


        public static void LoadComboBox(ComboBox cb, List<string> val)
        {
            cb.Items.Clear();
        
            for (int i = 0; i < val.Count; i++)
            {
                    cb.Items.Add(val[i]);
            }
           
        }
        /// <summary>
        /// ab端口comboxbo频段信息
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="val"></param>
        public static void LoadComboBox_d(ComboBox cb, List<string> val)
        {
            cb.Items.Clear();
            for (int i = 0; i < val.Count; i++)
            {
                cb.Items.Add(val[i]+"_1");
                cb.Items.Add(val[i] + "_2");
            }
        }

        /// <summary>
        /// 加载频段label
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="val"></param>
        public static void LoadLabel(Label[] labels, List< string> val)
        {
            for (int i = 0; i < labels.Length; i++)
            {
                if (i < val.Count)
                {
                    labels[i].Text = val[i] + ":";
                }
                else
                {
                    labels[i].Text = "------";
                }
            }
        }

        /// <summary>
        /// 加载补偿到numericupdown
        /// </summary>
        /// <param name="nuds"></param>
        /// <param name="val"></param>
        public static void LoadOffect(NumericUpDown[] nuds, List<double> val)
        {
            for (int i = 0; i < nuds.Length; i++)
            {
                if (i < val.Count)
                    nuds[i].Value = (decimal)val[i];
                else
                {
                    nuds[i].Value = 0;
                    nuds[i].Enabled = false;
                }
            }
        }

        /// <summary>
        /// 获取各个频段rx和tx补偿
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="nuds"></param>
        /// <param name="band"></param>
        /// <param name="isr"></param>
        /// <returns></returns>
        public static double GetOffectAndSet(string filename, NumericUpDown[] nuds, int band,bool isr)
        {
            double val = 0;
            val = Convert.ToDouble(nuds[band].Value);
            IniFile.SetFileName(filename);
            if (isr)
                IniFile.SetString("Rx_Offsets", "rx_band", val.ToString());//保存offset
            else
                IniFile.SetString("Tx_Offsets", "tx_band", val.ToString());//保存offset
            return val;
        }


        /// <summary>
        /// 添加扫描数据到datatable
        /// </summary>
        /// <param name="dt">datatable</param>
        /// <param name="n">当前点</param>
        /// <param name="f1">起始频率</param>
        /// <param name="p1">功率</param>
        /// <param name="f2">结束频率</param>
        /// <param name="p2">功率</param>
        /// <param name="fpim">扫描频率</param>
        /// <param name="fval">互调值</param>
        public static void ToNewRows(DataTable dt, int n,
                                  float maxval, string fluctuate, string result)
        {
            DataRow row = dt.NewRow();
            row[0] = n.ToString();
            row[1] = maxval.ToString("0.0");
            row[2] = fluctuate;
            row[3] = result;
            dt.Rows.Add(row);//添加行
        }

        public static void ToNewRowsGR(DataTable dt, int n,int tx,
                                 float maxval, string fluctuate, string result)
        {
            DataRow row = dt.NewRow();
            row[0] = "TX" + n.ToString();
            row[1] = tx.ToString();
            row[2] = maxval.ToString("0.0");
            row[3] = fluctuate;
            row[4] = result;
            dt.Rows.Add(row);//添加行
        }


        /// <summary>
        /// 添加扫描数据到datatable
        /// </summary>
        /// <param name="dt">datatable</param>
        /// <param name="n">当前点</param>
        /// <param name="f1">起始频率</param>
        /// <param name="p1">功率</param>
        /// <param name="f2">结束频率</param>
        /// <param name="p2">功率</param>
        /// <param name="fpim">扫描频率</param>
        /// <param name="fval">互调值</param>
        public static  void ToNewRows(DataTable dt, int n,
               float f1, float p1,
               float f2, float p2,
               float fpim, float fval)
        {
            DataRow row = dt.NewRow();
            row[0] = n.ToString();
            row[1] = f1.ToString();
            row[2] = p1.ToString("0.00");
            row[3] = f2.ToString();
            row[4] = p2.ToString("0.00");
            row[5] = fpim.ToString();
            row[6] = fval.ToString("0.0");
            dt.Rows.Add(row);//添加行
        }

        /// <summary>
        /// 添加扫描数据到datatable
        /// </summary>
        /// <param name="dt">datatable</param>
        /// <param name="n">当前点</param>
        /// <param name="f1">起始频率</param>
        /// <param name="p1">功率</param>
        /// <param name="f2">结束频率</param>
        /// <param name="p2">功率</param>
        /// <param name="fpim">扫描频率</param>
        /// <param name="fval">互调值</param>
        public static void ToNewRows_pdf(DataTable dt, int n,string mode,
               string f1, string f2,string rx,string pimgs,
                string maxval, string result)
        {
            int i = 0;
            DataRow row = dt.NewRow();
            row[i++] = n.ToString();
            row[i++] = mode;
            row[i++] = f1;
            row[i++] = f2;
            row[i++] = rx;
            row[i++] = pimgs;
            row[i++] = maxval;
            row[i++] = result;
            dt.Rows.Add(row);//添加行
        }

        /// <summary>
        /// datatable添加列头
        /// </summary>
        /// <param name="dt"></param>
       public static   void ToAddColumns(DataTable dt)
        {
            if (dt.Columns.Count > 1)
                return;
            dt.Columns.Add("NO.");//添加数据源
            dt.Columns.Add("F1(MHz)");//添加数据源
            dt.Columns.Add("P1(dBm)");//添加数据源
            dt.Columns.Add("F2(MHz)");//添加数据源
            dt.Columns.Add("P2(dBm)");//添加数据源
            dt.Columns.Add("Im_F(MHz)");//添加数据源
            dt.Columns.Add("Im_V(dBm)");//添加数据源
        }


       /// <summary>
       /// datatable添加列头
       /// </summary>
       /// <param name="dt"></param>
       public static void ToAddColumns_pdf(DataTable dt)
       {
           if (dt.Columns.Count > 1)
               return;
           dt.Columns.Add("NO.");//添加数据源
           dt.Columns.Add("扫描模式");//添加数据源
           dt.Columns.Add("F1频段");//添加数据源
           dt.Columns.Add("F2频段");//添加数据源
           dt.Columns.Add("RX频段");//添加数据源
           dt.Columns.Add("互调公式");//添加数据源
           dt.Columns.Add("最大值");//添加数据源
           dt.Columns.Add("测试结果");//添加数据源
       }

        /// <summary>
        /// 脚本测试datatable添加列头
        /// </summary>
        /// <param name="dt"></param>
       public static void ToAddColumns_j(DataTable dt)
       {
           if (dt.Columns.Count > 1)
               return;
           dt.Columns.Add("0");//添加数据源
           dt.Columns.Add("1");//添加数据源
           dt.Columns.Add("2");//添加数据源
           dt.Columns.Add("4");//添加数据源
       }

        /// <summary>
        /// 获取测试阶数公式
        /// </summary>
        /// <param name="imCo1"></param>
        /// <param name="imCo2"></param>
        /// <param name="imLow"></param>
        /// <param name="imLess"></param>
        /// <returns></returns>
       public static string PimFormula(byte imCo1,byte imCo2,byte imLow,byte imLess)
       {
           string val = "";
           string sign = " - "; 
           byte n = imCo1;
           byte m = imCo2;
           string f1 = "F1";
           string f2 = "F2";

           if (imLow == 1)
           {
               f1 = "F2";
               f2 = "F1";
           }
           if (imLess == 1)
               sign = " + ";
           if (n == 0)
           {
               val = m.ToString() + "F2";
               return val;
           }
           if (m == 0)
           {
               val = n.ToString() + "F1";
               return val;
           }
           val = n.ToString() + f1 + sign + m.ToString() + f2;
          
           return val;
       }

        /// <summary>
        /// 获取点频测试点
        /// </summary>
        /// <param name="imCo1"></param>
        /// <param name="imCo2"></param>
        /// <param name="imLow"></param>
        /// <param name="imLess"></param>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
       public static double GetTestBand(byte imCo1,byte imCo2,byte imLow,byte imLess,double f1,double f2)
       {
           double val = 0;
           byte n = imCo1;
           byte m = imCo2;
           if (imLow == 1)
           {
               n = imCo2;
               m = imCo1;
           }

           if (imLess == 1)
           {
               val = n * f1 + m * f2;
           }
           else
               val = n * f1 - m * f2;
           return Math.Abs(val);
       }

        /// <summary>
        /// 获取扫描测试范围
        /// </summary>
        /// <param name="imCo1"></param>
        /// <param name="imCo2"></param>
        /// <param name="imLow"></param>
        /// <param name="imLess"></param>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="f3"></param>
        /// <param name="f4"></param>
        /// <returns></returns>
       public static string GetTestBand_f(byte imCo1,byte imCo2,byte imLow,byte imLess,double f1, double f2, double f3, double f4)
       {
           string s = "";
           double num1 = GetTestBand(imCo1, imCo2, imLow, imLess, f1, f3);
           double num2 = GetTestBand(imCo1, imCo2, imLow, imLess, f1, f4);
           double num3 = GetTestBand(imCo1, imCo2, imLow, imLess, f2, f3);
           double num4 = GetTestBand(imCo1, imCo2, imLow, imLess, f2, f4);
           double max = 0;
           double min = 0;
           double[] num = new double[] { num1, num2, num3, num4 };
           max = num[0];
           min = num[0];
           for (int i = 0; i < 4; i++)
           {
               max = num[i] >= max ? num[i] : max;
               min = num[i] <= min ? num[i] : min;
           }
           s = min.ToString("0.00") + "-" + max.ToString("0.00") + "MHz";
           return s;
       }

       public static double[] GetTestBand_val(byte imCo1, byte imCo2, byte imLow, byte imLess, double f1, double f2, double f3, double f4)
       {
           double[] v = new double[2];
           double num1 = GetTestBand(imCo1, imCo2, imLow, imLess, f1, f3);
           double num2 = GetTestBand(imCo1, imCo2, imLow, imLess, f1, f4);
           double num3 = GetTestBand(imCo1, imCo2, imLow, imLess, f2, f3);
           double num4 = GetTestBand(imCo1, imCo2, imLow, imLess, f2, f4);
           double max = 0;
           double min = 0;
           double[] num = new double[] { num1, num2, num3, num4 };
           max = num[0];
           min = num[0];
           for (int i = 0; i < 4; i++)
           {
               max = num[i] >= max ? num[i] : max;
               min = num[i] <= min ? num[i] : min;
           }
           v[0] = min;
           v[1] = max;

           return v;
       
       }

        /// <summary>
        /// 脚本测试，datatable添加数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="n"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="avg"></param>
        /// <param name="str"></param>
       public static  void ToNewRows_test(DataTable dt, string n,
           float max, float min, float avg, string str)//添加脚本测试数据
       {
           DataRow row = dt.NewRow();
           row[0] = n;

           if (max == 0 && min == 0 && avg == 0 && str == "0")
           {
               row[1] = "---";
               row[2] = "---";
               row[3] = "---";
           }
           else
           {
               row[1] = max.ToString();//互调最大值
               row[2] = min.ToString();//互调最小值
               row[3] = str;
           }
           dt.Rows.Add(row);//添加数据到表格
       }

      
        /// <summary>
        /// 获取全屏jpg
        /// </summary>
        /// <param name="handel"></param>
        /// <returns></returns>
       public static   System.Drawing.Image SaveImage(Form handel)
       {
           string strTitle = "";
           System.Drawing.Image pimImage = JpgReport.GetWindow(handel.Handle);//需要保存的图形控件
           Graphics g = Graphics.FromImage(pimImage);
           StringFormat drawFormat = new StringFormat();
           drawFormat.Alignment = StringAlignment.Near;
           strTitle = "Time: " + DateTime.Now.ToString();
           g.DrawImage(pimImage, new Point(0, 0));//画图
           g.DrawString(strTitle, new System.Drawing.Font("Tahoma", 12, FontStyle.Regular), new SolidBrush(Color.White),
           new PointF(800, 10), drawFormat);
           return pimImage;
       }

        /// <summary>
        /// 获取单个控件jpg
        /// </summary>
        /// <param name="gb"></param>
        /// <returns></returns>
       public static System.Drawing.Image SaveImage(GroupBox gb)
       {
           string strTitle = "";
           System.Drawing.Image pimImage = JpgReport.GetWindow(gb.Handle);//需要保存的图形控件
           Graphics g = Graphics.FromImage(pimImage);
           StringFormat drawFormat = new StringFormat();
           drawFormat.Alignment = StringAlignment.Near;
           strTitle = "Time: " + DateTime.Now.ToString();
           g.DrawImage(pimImage, new Point(0, 0));//画图
           g.DrawString(strTitle, new System.Drawing.Font("Tahoma", 12, FontStyle.Regular), new SolidBrush(Color.White),
           new PointF(800, 10), drawFormat);
           return pimImage;
       }

        /// <summary>
        /// 保存jpg文件
        /// </summary>
        /// <param name="jpgFileName"></param>
        /// <param name="handel"></param>
        /// <returns></returns>
       public static  bool SaveJpg(string jpgFileName,Form handel)
       {
           try
           {
               if (!File.Exists(jpgFileName))//判断文件名是否存在
               {
                   //if (!Directory.Exists(Application.StartupPath + "\\picture"))//判断文件目录是否存在
                   //{
                   //    Directory.CreateDirectory(Application.StartupPath + "\\picture");//不存在创建
                   //}
                   System.Drawing.Image pimImage = SaveImage(handel);
                 
                   pimImage.Save(jpgFileName);//保存图形

   
                   handel.Refresh();
                   return true;
               }
               else
               {
                   MessageBox.Show(handel, "The JPG file name has already existed!");
                   return false;
               }
           }
           catch (Exception e)
           {
               MessageBox.Show("保存JPG文件异常：" + e.ToString());
               return false;
           }
       }

        /// <summary>
        /// 保存校准数据
        /// </summary>
       public static void SaveOff()
       {
           string path = Application.StartupPath;
           IniFile.SetFileName(path + "\\JcConfig.ini");
           string des_path = IniFile.GetString("PATH", "offset_file_path", "0");//获取保存校准数据地址
           if (Directory.Exists(des_path))
           {
               try
               {
                   System.IO.File.Copy(path + "\\JcOffset.db", des_path + "\\JcOffset.db", true);//保存校准数据
                   MessageBox.Show("保存成功！");
               }
               catch
               {
                   MessageBox.Show("保存地址错误, 请更改配置文件中的地址");
               }
           }
           else
           {
               MessageBox.Show("保存地址错误, 请更改配置文件中的地址");
           }
       }

        /// <summary>
        /// 保存pdf
        /// </summary>
        /// <param name="sre"></param>
        /// <param name="cjt"></param>
        /// <param name="isdbm"></param>
        /// <returns></returns>
       public static bool savepdf(string sre,List<DataSweep> cjt,bool isdbm)
       {
           #region 定义前导空格的数量
           float Xleading = 27.5f;
           float Yleading = 27.5f;
           float Xdelta = 10f;
           float Ydelta = 20f;
           #endregion
           bool is_succ = false;
           string path = Application.StartupPath + "\\pdf";
           try
           {
               if (!Directory.Exists(path))//判断存放的文件夹是否存在
               {
                   Directory.CreateDirectory(path);//不存在就创建
               }
               string str = path + "\\" + sre + ".pdf";//文件名
               iTextSharp.text.Rectangle pageSize = new iTextSharp.text.Rectangle(400f, 400f);//设置pdf页面大小
               pageSize.BackgroundColor = new iTextSharp.text.BaseColor(0xFF, 0xFF, 0xDE);//设置页面颜色
               Document document = new Document(pageSize);//初始化
               document.SetMargins(-20, -20, 170, 0);
               PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(str, FileMode.Create));//创建pdf

               BaseFont baseFont2 = BaseFont.CreateFont("C:\\WINDOWS\\FONTS\\SIMKAI.TTF",
                                                       BaseFont.IDENTITY_H,
                                                       BaseFont.NOT_EMBEDDED);
               //使用宋体字体
               BaseFont baseFont = BaseFont.CreateFont("C:\\WINDOWS\\FONTS\\SIMKAI.TTF",
                                                       BaseFont.IDENTITY_H,
                                                       BaseFont.NOT_EMBEDDED);
              
               iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont2);//字体
               iTextSharp.text.Font font2 = new iTextSharp.text.Font(baseFont2);//字体
                
               font2.Size = 9;

               document.Open();

               PdfContentByte cb = writer.DirectContent;
                
               
               iTextSharp.text.Paragraph paragraph, paragraph2;


               DrawReportHeader(cb, baseFont, Xleading, Yleading, Xdelta, Ydelta);

               DrawReportAbstract(cb, baseFont, Xleading, Yleading, Xdelta, Ydelta, PoiFreqSweepLeft.jbName, cjt.Count);

               DrawReportFooter(cb, baseFont, Xleading, Yleading, Xdelta, Ydelta);
              
                  
                   PdfPTable table2 = new PdfPTable(8);//初始化8列的表格
                   //paragraph = new Paragraph("F1(MHz)", font2);
                   ////paragraph.Alignment = Element.ALIGN_RIGHT; ;
                   table2.TotalWidth = 950;
                   table2.SetWidths(new float[] { 50f, 80f, 155f, 155f, 155f, 130f, 130f,95f});//设置每列的宽度
             
             
                   table2.AddCell( new Phrase("NO.", font2));//添加第一行第一列数据
                   table2.AddCell(new Phrase("模式", font2));//添加第一行第二列数据
                   table2.AddCell(new Phrase("F1(MHz)", font2));//添加第一行第三列数据
                   table2.AddCell(new Phrase("F2(MHz)", font2));//添加第一行第四列数据
                   table2.AddCell(new Phrase("RX(MHz)", font2));//添加第一行第五列数据
                   table2.AddCell(new Phrase("PIM公式", font2));//添加第一行第六列数据
                   table2.AddCell(new Phrase("PEAK(dBm)", font2));//添加第一行第七列数据
                   table2.AddCell(new Phrase("结论", font2));//添加第一行第七列数据

                   if (cjt.Count <= 14)
                   {
                       for (int j = 0; j < cjt.Count; j++)
                       {

                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[0], font2));//添加第j行第一列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[1], font2));//添加第j行第二列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[2], font2));//添加第j行第三列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[3], font2));//添加第j行第四列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[4], font2));//添加第j行第五列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[5], font2));//添加第j行第六列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[6], font2));//添加第j行第七列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[7], font2));//添加第j行第七列数据

                           table2.AddCell(new Phrase(j.ToString(), font2));//添加第j行第七列数据
                           string oV = cjt[j].sxy.overViewMessage + "\r\n";
                           paragraph = new iTextSharp.text.Paragraph(oV, font);
                           document.Add(paragraph);

                       }
                       document.Add(table2);//添加表格
                   }
                   else
                   {

                       for (int j = 0; j < 14; j++)
                       {

                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[0].Trim(), font2));//添加第j行第一列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[1].Trim(), font2));//添加第j行第二列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[2].Trim(), font2));//添加第j行第三列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[3].Trim(), font2));//添加第j行第四列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[4].Trim(), font2));//添加第j行第五列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[5].Trim(), font2));//添加第j行第六列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[6].Trim(), font2));//添加第j行第七列数据
                           table2.AddCell(new Phrase(cjt[j].sxy.pdf_val[7].Trim(), font2));//添加第j行第七列数据

                       }
                       document.Add(table2);//添加表格
                       document.SetMargins(-20, -20, 50, 0);
                       document.NewPage();//添加下一页
                       PdfPTable table3 = new PdfPTable(8);//初始化8列的表格
                       table3.TotalWidth = 950;
                       table3.SetWidths(new float[] { 50f, 80f, 155f, 155f, 155f, 130f, 130f, 95f });//设置每列的宽度


                       table3.AddCell(new Phrase("NO.", font2));//添加第一行第一列数据
                       table3.AddCell(new Phrase("模式", font2));//添加第一行第二列数据
                       table3.AddCell(new Phrase("F1(MHz)", font2));//添加第一行第三列数据
                       table3.AddCell(new Phrase("F2(MHz)", font2));//添加第一行第四列数据
                       table3.AddCell(new Phrase("RX(MHz)", font2));//添加第一行第五列数据
                       table3.AddCell(new Phrase("PIM公式", font2));//添加第一行第六列数据
                       table3.AddCell(new Phrase("PEAK(dBm)", font2));//添加第一行第七列数据
                       table3.AddCell(new Phrase("结论", font2));//添加第一行第七列数据
                       for (int j = 14; j < cjt.Count; j++)
                       {

                           table3.AddCell(new Phrase(cjt[j].sxy.pdf_val[0].Trim(), font2));//添加第j行第一列数据
                           table3.AddCell(new Phrase(cjt[j].sxy.pdf_val[1].Trim(), font2));//添加第j行第二列数据
                           table3.AddCell(new Phrase(cjt[j ].sxy.pdf_val[2].Trim(), font2));//添加第j行第三列数据
                           table3.AddCell(new Phrase(cjt[j ].sxy.pdf_val[3].Trim(), font2));//添加第j行第四列数据
                           table3.AddCell(new Phrase(cjt[j ].sxy.pdf_val[4].Trim(), font2));//添加第j行第五列数据
                           table3.AddCell(new Phrase(cjt[j ].sxy.pdf_val[5].Trim(), font2));//添加第j行第六列数据
                           table3.AddCell(new Phrase(cjt[j ].sxy.pdf_val[6].Trim(), font2));//添加第j行第七列数据
                           table3.AddCell(new Phrase(cjt[j].sxy.pdf_val[7].Trim(), font2));//添加第j行第七列数据

                       }
                       document.Add(table3);//添加表格
                       //绘制上方粗直线
                       cb.SetLineWidth(4f);
                       cb.MoveTo(20, 380);
                       cb.LineTo(380, 380);
                       cb.Stroke();
                       DrawReportFooter(cb, baseFont, Xleading, Yleading, Xdelta, Ydelta);
                   }

                   for (int i = 0; i < cjt.Count; i++)
                   {

                       if (i == 0)//第一页
                       {
                           document.SetMargins(36, 0, 36, 0);
                           document.NewPage();//添加下一页
                           if (!cjt[i].sxy.str_data.Contains("模式"))//判断是否是换线提示
                           {
                               paragraph = new iTextSharp.text.Paragraph(cjt[i].sxy.str_data, font);
                               document.Add(paragraph);//添加文本到pdf
                               continue;
                           }
                           paragraph = new iTextSharp.text.Paragraph(cjt[i].sxy.str_data, font);
                           document.Add(paragraph);//添加文本到pdf
                           iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(cjt[i].sxy.image1, BaseColor.WHITE);
                           img.SetAbsolutePosition(20, 20);//设置图片位置
                           img.ScaleAbsolute(270, 200);//设置图片大小
                           writer.DirectContent.AddImage(img);//添加图片大小
                           iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(cjt[i].sxy.image2, BaseColor.WHITE);
                           img2.SetAbsolutePosition(290, 20);//设置图片位置
                           img2.ScaleAbsolute(100, 200);//设置图片大小
                           writer.DirectContent.AddImage(img2);//添加图片大小
                           int num_count = cjt[i].dt.Rows.Count / 20;//计算需要几张表格，
                           int get_count = 20;//每张20行
                           int cou = -1;//当前脚本数据行

                           for (int w = 0; w < num_count + 1; w++)
                           {
                               PdfPTable table = new PdfPTable(7);//初始化7列的表格
                               table.TotalWidth = 850;
                               table.SetWidths(new float[] { 70f, 130f, 130f, 130f, 130f, 130f, 130f });//设置每列的宽度
                               document.SetMargins(-40, -40, 0, 0);//设置表格边界 
                               document.NewPage();//创建下一页
                               paragraph = new iTextSharp.text.Paragraph(cjt[i].sxy.sweep_data_header, font);
                               paragraph.Alignment = Element.ALIGN_CENTER;
                               document.Add(paragraph);//添加文本
                               if (w == num_count)//最后一张表格
                               {
                                   get_count = cjt[i].dt.Rows.Count % 20 + 1;//计算最后一张表格行数
                               }
                               for (int j = 0; j < get_count; j++)
                               {
                                   cou++;//当前脚本数据行
                                   if (cjt[i].dt.Rows.Count <= 0) continue;
                                   DataRow dtr = cjt[i].dt.Rows[cou];
                                   if (!isdbm)
                                       dtr = cjt[i].dtc.Rows[cou];
                                   if (w == 0 && j == 0)//第一张表格第一行添加行标题
                                   {
                                       cou--;//当前脚本数据行
                                       table.AddCell(new Phrase("NO", font2));//添加第一行第一列数据
                                       table.AddCell(new Phrase("F1(MHz)", font2));//添加第一行第二列数据
                                       table.AddCell(new Phrase("P1(dBm)", font2));//添加第一行第三列数据
                                       table.AddCell(new Phrase("F2(MHz)", font2));//添加第一行第四列数据
                                       table.AddCell(new Phrase("P2(dBm)", font2));//添加第一行第五列数据
                                       table.AddCell(new Phrase("F_im(MHz)", font2));//添加第一行第六列数据
                                       if (isdbm)
                                           table.AddCell(new Phrase("P_im(dBm)", font2));//添加第一行第七列数据
                                       else
                                           table.AddCell(new Phrase("P_im(dBc)", font2));//添加第一行第七列数据
                                   }
                                   else
                                   {
                                       table.AddCell(new Phrase(dtr[0].ToString(), font2));//添加第j行第一列数据
                                       table.AddCell(new Phrase(dtr[1].ToString(), font2));//添加第j行第二列数据
                                       table.AddCell(new Phrase(dtr[2].ToString(), font2));//添加第j行第三列数据
                                       table.AddCell(new Phrase(dtr[3].ToString(), font2));//添加第j行第四列数据
                                       table.AddCell(new Phrase(dtr[4].ToString(), font2));//添加第j行第五列数据
                                       table.AddCell(new Phrase(dtr[5].ToString(), font2));//添加第j行第六列数据
                                       table.AddCell(new Phrase(dtr[6].ToString(), font2));//添加第j行第七列数据
                                   }
                               }
                               document.Add(table);//添加表格
                           }
                       }


                       else
                       {
                           document.SetMargins(36, 0, 36, 0);
                           document.NewPage();//添加下一页
                           if (!cjt[i].sxy.str_data.Contains("模式"))//判断是否是换线提示
                           {
                               paragraph = new iTextSharp.text.Paragraph(cjt[i].sxy.str_data, font);

                               document.Add(paragraph);//添加文本
                               continue;
                           }
                           paragraph = new iTextSharp.text.Paragraph(cjt[i].sxy.str_data, font);
                           document.Add(paragraph);//添加文本到pdf
                           iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(cjt[i].sxy.image1, BaseColor.WHITE);
                           img.SetAbsolutePosition(20, 20);//设置曲线图形图片位置
                           img.ScaleAbsolute(270, 200);//设置曲线图形图片大小
                           writer.DirectContent.AddImage(img);//添加图片
                           iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(cjt[i].sxy.image2, BaseColor.WHITE);
                           img2.SetAbsolutePosition(290, 20);//设置互调值图形图片位置
                           img2.ScaleAbsolute(100, 200);//设置互调值图形图片大小
                           writer.DirectContent.AddImage(img2);//添加图片
                           int num_count = cjt[i].dt.Rows.Count / 20;//计算需要几张表格，
                           int get_count = 20;//每张20行
                           int cou = -1;//当前脚本数据行

                           for (int w = 0; w < num_count + 1; w++)
                           {
                               PdfPTable table = new PdfPTable(7);//初始化7列的表格
                               table.TotalWidth = 850;

                               table.SetWidths(new float[] { 70f, 130f, 130f, 130f, 130f, 130f, 130f });//设置每列的宽度
                               table.HorizontalAlignment = Element.ALIGN_CENTER;
                               //table.TotalWidth = 850;
                               document.SetMargins(-40, -40, 0, 0);//设置表格边界
                               document.NewPage();//创建下一页
                               paragraph = new iTextSharp.text.Paragraph(cjt[i].sxy.sweep_data_header, font);
                               paragraph.Alignment = Element.ALIGN_CENTER;
                               document.Add(paragraph);//添加文本
                               if (w == num_count)//最后一张表格
                               {
                                   get_count = cjt[i].dt.Rows.Count % 20 + 1;//计算最后一张表格行数
                               }
                               for (int j = 0; j < get_count; j++)
                               {
                                   cou++;//当前脚本数据行
                                   if (cjt[i].dt.Rows.Count <= 0) continue;
                                   DataRow dtr = cjt[i].dt.Rows[cou];//计算最后一张表格行数
                                   if (!isdbm)
                                       dtr = cjt[i].dtc.Rows[cou];//计算最后一张表格行数
                                   if (w == 0 && j == 0)
                                   {
                                       cou--;//当前脚本数据行
                                       table.AddCell(new Phrase("NO", font2));//添加第一行第一列数据
                                       table.AddCell(new Phrase("F1(MHz)", font2));//添加第一行第二列数据
                                       table.AddCell(new Phrase("P1(dBm)", font2));//添加第一行第三列数据
                                       table.AddCell(new Phrase("F2(MHz)", font2));//添加第一行第四列数据
                                       table.AddCell(new Phrase("P2(dBm)", font2));//添加第一行第五列数据
                                       table.AddCell(new Phrase("F_im(MHz)", font2));//添加第一行第六列数据
                                       if (isdbm)
                                           table.AddCell(new Phrase("P_im(dBm)", font2));//添加第一行第七列数据
                                       else
                                           table.AddCell(new Phrase("P_im(dBc)", font2));//添加第一行第七列数据
                                   }
                                   else
                                   {
                                       table.AddCell(new Phrase(dtr[0].ToString(), font2));//添加第j行第一列数据
                                       table.AddCell(new Phrase(dtr[1].ToString(), font2));//添加第j行第二列数据
                                       table.AddCell(new Phrase(dtr[2].ToString(), font2));//添加第j行第三列数据
                                       table.AddCell(new Phrase(dtr[3].ToString(), font2));//添加第j行第四列数据
                                       table.AddCell(new Phrase(dtr[4].ToString(), font2));//添加第j行第五列数据
                                       table.AddCell(new Phrase(dtr[5].ToString(), font2));//添加第j行第六列数据
                                       table.AddCell(new Phrase(dtr[6].ToString(), font2));//添加第j行第七列数据
                                   }
                               }
                               document.Add(table);//添加表格
                           }
                       }
                   }

                   //for (int i = 0; i < 50; i++)
                   //{



                   //    if (i == 0)//第一页
                   //    {
                   //        document.SetMargins(36, 0, 36, 0);
                   //        document.NewPage();//添加下一页
                          
                   //        paragraph = new iTextSharp.text.Paragraph(i.ToString(), font);
                   //        document.Add(paragraph);//添加文本到pdf
                   //        //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(cjt[i].sxy.image1, BaseColor.WHITE);
                   //        //img.SetAbsolutePosition(20, 20);//设置图片位置
                   //        //img.ScaleAbsolute(270, 200);//设置图片大小
                   //        //writer.DirectContent.AddImage(img);//添加图片大小
                   //        //iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(cjt[i].sxy.image2, BaseColor.WHITE);
                   //        //img2.SetAbsolutePosition(290, 20);//设置图片位置
                   //        //img2.ScaleAbsolute(100, 200);//设置图片大小
                   //        //writer.DirectContent.AddImage(img2);//添加图片大小
                   //        int num_count = 2;//计算需要几张表格，
                   //        int get_count = 20;//每张20行
                   //        int cou = -1;//当前脚本数据行

                   //        for (int w = 0; w < num_count + 1; w++)
                   //        {
                   //            PdfPTable table = new PdfPTable(7);//初始化7列的表格
                   //            table.TotalWidth = 850;
                   //            table.SetWidths(new float[] { 70f, 130f, 130f, 130f, 130f, 130f, 130f });//设置每列的宽度
                   //            document.SetMargins(-40, -40, 0, 0);//设置表格边界 
                   //            document.NewPage();//创建下一页
                   //            paragraph = new iTextSharp.text.Paragraph(i.ToString()+"di jizhang", font);
                   //            paragraph.Alignment = Element.ALIGN_CENTER;
                   //            document.Add(paragraph);//添加文本
                   //            if (w == num_count)//最后一张表格
                   //            {
                   //                get_count = 20;//计算最后一张表格行数
                   //            }
                   //            for (int j = 0; j < get_count; j++)
                   //            {
                   //                cou++;//当前脚本数据行
                   //                //DataRow dtr = cjt[i].dt.Rows[cou];
                   //                //if (!isdbm)
                   //                //    dtr = cjt[i].dtc.Rows[cou];
                   //                if (w == 0 && j == 0)//第一张表格第一行添加行标题
                   //                {
                   //                    cou--;//当前脚本数据行
                   //                    table.AddCell(new Phrase("NO", font2));//添加第一行第一列数据
                   //                    table.AddCell(new Phrase("F1(MHz)", font2));//添加第一行第二列数据
                   //                    table.AddCell(new Phrase("P1(dBm)", font2));//添加第一行第三列数据
                   //                    table.AddCell(new Phrase("F2(MHz)", font2));//添加第一行第四列数据
                   //                    table.AddCell(new Phrase("P2(dBm)", font2));//添加第一行第五列数据
                   //                    table.AddCell(new Phrase("F_im(MHz)", font2));//添加第一行第六列数据
                   //                    if (isdbm)
                   //                        table.AddCell(new Phrase("P_im(dBm)", font2));//添加第一行第七列数据
                   //                    else
                   //                        table.AddCell(new Phrase("P_im(dBc)", font2));//添加第一行第七列数据
                   //                }
                   //                else
                   //                {
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第一列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第二列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第三列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第四列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第五列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第六列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第七列数据
                   //                }
                   //            }
                   //            document.Add(table);//添加表格
                   //        }
                   //    }


                   //    else
                   //    {
                   //        document.SetMargins(36, 0, 36, 0);
                   //        document.NewPage();//添加下一页
                   //        //if (!cjt[i].sxy.str_data.Contains("模式"))//判断是否是换线提示
                   //        //{
                   //        //    paragraph = new iTextSharp.text.Paragraph(cjt[i].sxy.str_data, font);

                   //        //    document.Add(paragraph);//添加文本
                   //        //    continue;
                   //        //}
                   //        paragraph = new iTextSharp.text.Paragraph(i.ToString(), font);
                   //        document.Add(paragraph);//添加文本到pdf
                   //        //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(cjt[i].sxy.image1, BaseColor.WHITE);
                   //        //img.SetAbsolutePosition(20, 20);//设置曲线图形图片位置
                   //        //img.ScaleAbsolute(270, 200);//设置曲线图形图片大小
                   //        //writer.DirectContent.AddImage(img);//添加图片
                   //        //iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(cjt[i].sxy.image2, BaseColor.WHITE);
                   //        //img2.SetAbsolutePosition(290, 20);//设置互调值图形图片位置
                   //        //img2.ScaleAbsolute(100, 200);//设置互调值图形图片大小
                   //        //writer.DirectContent.AddImage(img2);//添加图片
                   //        int num_count = 2;//计算需要几张表格，
                   //        int get_count = 20;//每张20行
                   //        int cou = -1;//当前脚本数据行

                   //        for (int w = 0; w < num_count + 1; w++)
                   //        {
                   //            PdfPTable table = new PdfPTable(7);//初始化7列的表格
                   //            table.TotalWidth = 850;

                   //            table.SetWidths(new float[] { 70f, 130f, 130f, 130f, 130f, 130f, 130f });//设置每列的宽度
                   //            table.HorizontalAlignment = Element.ALIGN_CENTER;
                   //            //table.TotalWidth = 850;
                   //            document.SetMargins(-40, -40, 0, 0);//设置表格边界
                   //            document.NewPage();//创建下一页
                   //            paragraph = new iTextSharp.text.Paragraph(i.ToString()+"dijizhang", font);
                   //            paragraph.Alignment = Element.ALIGN_CENTER;
                   //            document.Add(paragraph);//添加文本
                   //            if (w == num_count)//最后一张表格
                   //            {
                   //                get_count = 20;//计算最后一张表格行数
                   //            }
                   //            for (int j = 0; j < get_count; j++)
                   //            {
                   //                cou++;//当前脚本数据行
                   //                //DataRow dtr = cjt[i].dt.Rows[cou];//计算最后一张表格行数
                   //                //if (!isdbm)
                   //                //    dtr = cjt[i].dtc.Rows[cou];//计算最后一张表格行数
                   //                if (w == 0 && j == 0)
                   //                {
                   //                    cou--;//当前脚本数据行
                   //                    table.AddCell(new Phrase("NO", font2));//添加第一行第一列数据
                   //                    table.AddCell(new Phrase("F1(MHz)", font2));//添加第一行第二列数据
                   //                    table.AddCell(new Phrase("P1(dBm)", font2));//添加第一行第三列数据
                   //                    table.AddCell(new Phrase("F2(MHz)", font2));//添加第一行第四列数据
                   //                    table.AddCell(new Phrase("P2(dBm)", font2));//添加第一行第五列数据
                   //                    table.AddCell(new Phrase("F_im(MHz)", font2));//添加第一行第六列数据
                   //                    if (isdbm)
                   //                        table.AddCell(new Phrase("P_im(dBm)", font2));//添加第一行第七列数据
                   //                    else
                   //                        table.AddCell(new Phrase("P_im(dBc)", font2));//添加第一行第七列数据
                   //                }
                   //                else
                   //                {
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第一列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第二列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第三列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第四列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第五列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第六列数据
                   //                    table.AddCell(new Phrase(i.ToString(), font2));//添加第j行第七列数据
                   //                }
                   //            }
                   //            document.Add(table);//添加表格
                   //        }
                   //    }
                   //}
               document.Close();//关闭
               is_succ = true;
           }
           catch (Exception ex)
           {
               MessageBox.Show("err:" + ex.ToString());
               is_succ = false;
           }
           return is_succ;
       }



       private static void DrawReportHeader(PdfContentByte cb,
                                 BaseFont bFont,
                                 float Xleading,
                                 float Yleading,
                                 float Xdelta,
                                 float Ydelta)
       {
           #region 绘制报表头部
           //绘制报头的日期与时间
           //cb.BeginText();
           //cb.SetTextMatrix(Xleading, (842f - Xleading));
           //cb.SetFontAndSize(bFont, 15);
           //cb.ShowText("Date Time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
           //cb.EndText();

           //绘制上方粗直线
           cb.SetLineWidth(4f);
           cb.MoveTo(20, 380);
           cb.LineTo(380,380);
           cb.Stroke();

           //绘制近下方细直线
           cb.SetLineWidth(1f);
           cb.MoveTo(40,365);
           cb.LineTo(137,365);

           cb.MoveTo(243,365);
           cb.LineTo(360,365);
           cb.Stroke();

           //绘制近下方细直线上的文字
           cb.BeginText();
           string s = "SCRIPT TEST ABSTRACT";
           cb.SetFontAndSize(bFont, 10);
           cb.ShowTextAligned(Element.ALIGN_CENTER, s, 191, 363, 0);
           cb.EndText();
           #endregion
       }

       private static  void DrawReportAbstract(PdfContentByte cb,
                                       BaseFont bFont,
                                       float Xleading,
                                       float Yleading,
                                       float Xdelta,
                                       float Ydelta,string name,int count)
       {
           string s;
           BaseColor col;

           #region 绘制报表摘要部分
           //绘制大框线
           cb.SetLineWidth(1f);
           cb.Rectangle(40,258, 320f, 92f);
           cb.Stroke();

           //填充大框线内的小框
           col = new BaseColor(0, 128, 128);
           cb.SetColorFill(col);
           cb.Rectangle(43,261,314f,86f);
           cb.Fill();
           cb.Stroke();

           //在小框上绘制摘要文字，包括Description、Model NO.、Serial NO.、Operator
           col = new BaseColor(194, 254, 122);
           cb.SetColorFill(col);
           cb.SetFontAndSize(bFont, 10);

           cb.BeginText();
           s = "Name:";
           cb.ShowTextAligned(Element.ALIGN_LEFT, s, 45,335, 0);

           s = "Count:";
           cb.ShowTextAligned(Element.ALIGN_LEFT, s,45,307, 0);

           s = "Date:";
           cb.ShowTextAligned(Element.ALIGN_LEFT, s,45 ,282, 0);

           s = name;
           cb.ShowTextAligned(Element.ALIGN_LEFT, s, 60, 321, 0);

           s = count.ToString();
           cb.ShowTextAligned(Element.ALIGN_LEFT, s, 60, 293, 0);

           s = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
           cb.ShowTextAligned(Element.ALIGN_LEFT, s, 60, 265, 0);
           cb.EndText();



           //绘制中间细直线
           cb.SetLineWidth(1f);
           cb.MoveTo(40,243);
           cb.LineTo(137,243);

           cb.MoveTo(243,243);
           cb.LineTo(360,243);
           cb.Stroke();

           //绘制中间细直线上的文字
           cb.BeginText();
           col = new BaseColor(0, 0, 0);
           cb.SetColorFill(col);
           s = "SCRIPT TEST DETAILS";
           cb.SetFontAndSize(bFont, 10);
           cb.ShowTextAligned(Element.ALIGN_CENTER, s,191,240, 0);
           cb.EndText();
           #endregion
       }

    

     

       private static void DrawReportFooter(PdfContentByte cb,
                              BaseFont bFont,
                              float Xleading,
                              float Yleading,
                              float Xdelta,
                              float Ydelta)
       {
           BaseColor col;
           string s;

           #region 绘制报表尾部
        

           //绘制下方粗直线
           cb.SetLineWidth(4f);
           cb.MoveTo(20,20);
           cb.LineTo(380,20);
           cb.Stroke();

           ////嵌入公司logo      
           //System.Drawing.Image img = System.Drawing.Image.FromFile("logo.gif");
           System.Drawing.Image img = (System.Drawing.Image)Properties.Resources.logo;
           MemoryStream mem = new MemoryStream();
           img.Save(mem, System.Drawing.Imaging.ImageFormat.Gif);
           byte[] bytes = mem.ToArray();

           iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(bytes);
           img2.SetAbsolutePosition(350, 0);
           img2.ScalePercent(5);
           cb.AddImage(img2);
           #endregion
       }

       public static bool savepdf(string sre, DataSweep cjt, bool isdbm,bool mode)
       {
           bool is_succ = false;
           string path = Application.StartupPath + "\\pdf";
           try
           {
               if (!Directory.Exists(path))//判断存放的文件夹是否存在
               {
                   Directory.CreateDirectory(path);//不存在就创建
               }
               string str = path + "\\" + sre + ".pdf";//文件名
               iTextSharp.text.Rectangle pageSize = new iTextSharp.text.Rectangle(400f, 400f);//设置pdf页面大小
               pageSize.BackgroundColor = new iTextSharp.text.BaseColor(0xFF, 0xFF, 0xDE);//设置页面颜色
               Document document = new Document(pageSize);//初始化
               PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(str, FileMode.Create));//创建pdf
               BaseFont baseFont2 = BaseFont.CreateFont("C:\\WINDOWS\\FONTS\\SIMKAI.TTF",
                                                       BaseFont.IDENTITY_H,
                                                       BaseFont.NOT_EMBEDDED);
               iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont2);//字体
               iTextSharp.text.Font font2 = new iTextSharp.text.Font(baseFont2);//字体
               font2.Size = 8;

               document.Open();
               iTextSharp.text.Paragraph paragraph, paragraph2;

                       paragraph = new iTextSharp.text.Paragraph(cjt.sxy.str_data, font);
                       document.Add(paragraph);//添加文本到pdf
                       iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(cjt.sxy.image1, BaseColor.WHITE);
                       img.SetAbsolutePosition(20, 20);//设置图片位置
                       img.ScaleAbsolute(270, 200);//设置图片大小
                       writer.DirectContent.AddImage(img);//添加图片大小
                       iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(cjt.sxy.image2, BaseColor.WHITE);
                       img2.SetAbsolutePosition(290, 20);//设置图片位置
                       img2.ScaleAbsolute(100, 200);//设置图片大小
                       writer.DirectContent.AddImage(img2);//添加图片大小
                       DataTable dt;
                       DataTable dtc;
                       if (mode)
                       {
                           dt = cjt.dtm;
                           dtc = cjt.dtm_c;
                       }
                       else
                       {
                           dt = cjt.dt;
                           dtc = cjt.dtc;
                       }
                       int num_count = dt.Rows.Count / 20;//计算需要几张表格，
                       int get_count = 20;//每张20行
                       int cou = -1;//当前脚本数据行

                       for (int w = 0; w < num_count + 1; w++)
                       {
                           if (dt.Rows.Count <= 0)
                               break;
                           PdfPTable table = new PdfPTable(7);//初始化7列的表格
                           table.TotalWidth = 850;
                           table.SetWidths(new float[] { 70f, 130f, 130f, 130f, 130f, 130f, 130f });//设置每列的宽度
                           document.SetMargins(-40, -40, 0, 0);//设置表格边界 
                           document.NewPage();//创建下一页
                           paragraph = new iTextSharp.text.Paragraph(cjt.sxy.sweep_data_header, font);
                           paragraph.Alignment = Element.ALIGN_CENTER;
                           document.Add(paragraph);//添加文本
                           if (w == num_count)//最后一张表格
                           {
                               get_count = dt.Rows.Count % 20 + 1;//计算最后一张表格行数
                           }
                           for (int j = 0; j < get_count; j++)
                           {
                               cou++;//当前脚本数据行
                               if (dt.Rows.Count <= 0)
                                   continue;
                               DataRow dtr = dt.Rows[cou];
                               if (!isdbm)
                                   dtr = dtc.Rows[cou];
                               if (w == 0 && j == 0)//第一张表格第一行添加行标题
                               {
                                   cou--;//当前脚本数据行
                                   table.AddCell(new Phrase("NO", font2));//添加第一行第一列数据
                                   table.AddCell(new Phrase("F1(MHz)", font2));//添加第一行第二列数据
                                   table.AddCell(new Phrase("P1(dBm)", font2));//添加第一行第三列数据
                                   table.AddCell(new Phrase("F2(MHz)", font2));//添加第一行第四列数据
                                   table.AddCell(new Phrase("P2(dBm)", font2));//添加第一行第五列数据
                                   table.AddCell(new Phrase("F_im(MHz)", font2));//添加第一行第六列数据
                                   if (isdbm)
                                       table.AddCell(new Phrase("P_im(dBm)", font2));//添加第一行第七列数据
                                   else
                                       table.AddCell(new Phrase("P_im(dBc)", font2));//添加第一行第七列数据
                               }
                               else
                               {
                                   table.AddCell(new Phrase(dtr[0].ToString(), font2));//添加第j行第一列数据
                                   table.AddCell(new Phrase(dtr[1].ToString(), font2));//添加第j行第二列数据
                                   table.AddCell(new Phrase(dtr[2].ToString(), font2));//添加第j行第三列数据
                                   table.AddCell(new Phrase(dtr[3].ToString(), font2));//添加第j行第四列数据
                                   table.AddCell(new Phrase(dtr[4].ToString(), font2));//添加第j行第五列数据
                                   table.AddCell(new Phrase(dtr[5].ToString(), font2));//添加第j行第六列数据
                                   table.AddCell(new Phrase(dtr[6].ToString(), font2));//添加第j行第七列数据
                               }
                           }
                           document.Add(table);//添加表格
                       }
                              
               document.Close();//关闭
               is_succ = true;
           }
           catch (Exception ex)
           {
               MessageBox.Show("err:" + ex.ToString());
               is_succ = false;
           }
           return is_succ;
       }


       public static bool SaveCsv_pdf(string csvFileName, TestData testdata, bool isdbm)
       {
           //string path = Application.StartupPath + "\\csv";//目录
           //if (!Directory.Exists(path))//判断目录是否存在
           //{
           //    Directory.CreateDirectory(path);//不存在创建
           //}
           
           try
           {
              
               if (!File.Exists(csvFileName))//判断文件名是否存在
               {
                   DataTable dtb;
                   DataTable resultDb;
                   CsvReport_Pim_Entry[] cp;
                   List<CsvReport_Pim_Entry[]> lcr = new List<CsvReport_Pim_Entry[]>();

                   resultDb = testdata.surFaceData_dbm;
                   if (!isdbm)
                       resultDb = testdata.surFaceData_dbc;
                   cp = new CsvReport_Pim_Entry[resultDb.Rows.Count];
                   for (int i = 0; i < resultDb.Rows.Count; i++)//添加数据到csv
                   {
                       DataRow row = resultDb.Rows[i];
                       cp[i] = new CsvReport_Pim_Entry();
                       cp[i].No = int.Parse(row[0].ToString());
                       cp[i].MaxVal = row[1].ToString();
                       cp[i].Fluctuate = row[2].ToString();
                       cp[i].Result =row[3].ToString();

                   }
                   lcr.Add(cp);//保存cp

                   for (int j = 0; j < testdata.pimDate.Count; j++)
                   {

                       dtb = testdata.pimDate[j].dt_dbm;
                       if (!isdbm)
                           dtb = testdata.pimDate[j].dt_dbc;
                       cp = new CsvReport_Pim_Entry[dtb.Rows.Count];
                       for (int i = 0; i < dtb.Rows.Count; i++)//添加数据到csv
                       {
                           DataRow row = dtb.Rows[i];
                           cp[i] = new CsvReport_Pim_Entry();
                           cp[i].No = int.Parse(row[0].ToString());
                           cp[i].F1 = float.Parse(row[1].ToString());
                           cp[i].P1 = float.Parse(row[2].ToString());
                           cp[i].F2 = float.Parse(row[3].ToString());
                           cp[i].P2 = float.Parse(row[4].ToString());
                           cp[i].Im_F = float.Parse(row[5].ToString());
                           cp[i].Im_V = float.Parse(row[6].ToString());
                       }
                       lcr.Add(cp);//保存cp
                       if (j == testdata.pimDate.Count - 1)
                           CsvReport.Save_Csv_Pim(csvFileName+".csv", lcr, testdata.pimDate.Count+1,isdbm);//保存到csv
                   }
                   return true;
               }
               else
               {
                   return false;
               }
           }
           catch (Exception e)
           {
               MessageBox.Show("保存CSV文件异常");
               return false;
           }
       }

       public static bool SaveCsv_pdf(string csvFileName, List<DataSweep> cjt,bool isdbm)
       {
           string path = Application.StartupPath + "\\csv";//目录
           if (!Directory.Exists(path))//判断目录是否存在
           {
               Directory.CreateDirectory(path);//不存在创建
           }
           try
           {
               if (!File.Exists(csvFileName))//判断文件名是否存在
               {
                   DataTable dtb;

                   CsvReport_Pim_Entry[] cp;
                   List<CsvReport_Pim_Entry[]> lcr = new List<CsvReport_Pim_Entry[]>();
                   int dt_num = cjt.Count;//数据数量
                   for (int j = 0; j < cjt.Count + 1; j++)
                   {
                       if (!cjt[j].sxy.str_data.Contains("模式"))//判断是否是换线信息
                       {
                           dt_num--;
                           continue;
                       }
                       dtb = cjt[j].dt;
                       if (!isdbm)
                           dtb = cjt[j].dtc;
                       cp = new CsvReport_Pim_Entry[dtb.Rows.Count];
                       for (int i = 0; i < dtb.Rows.Count; i++)//添加数据到csv
                       {
                           DataRow row = dtb.Rows[i];
                           cp[i] = new CsvReport_Pim_Entry();
                           cp[i].No = int.Parse(row[0].ToString());
                           cp[i].F1 = float.Parse(row[1].ToString());
                           cp[i].P1 = float.Parse(row[2].ToString());
                           cp[i].F2 = float.Parse(row[3].ToString());
                           cp[i].P2 = float.Parse(row[4].ToString());
                           cp[i].Im_F = float.Parse(row[5].ToString());
                           cp[i].Im_V = float.Parse(row[6].ToString());
                       }
                       lcr.Add(cp);//保存cp
                       if (j == dt_num-1)
                           CsvReport.Save_Csv_Pim(csvFileName, lcr, dt_num,isdbm);//保存到csv
                   }
                   return true;
               }
               else
               {
                   return false;
               }
           }
           catch (Exception e)
           {
               MessageBox.Show("保存CSV文件异常");
               return false;
           }
       }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
       public static  void Formula(object sender)
       {
           NumericUpDown number = (NumericUpDown)sender;
           TouchPad((NumericUpDown)sender, number.Value.ToString());
       }
        /// <summary>
        /// 计算器控件
        /// </summary>
        /// <param name="n"></param>
        /// <param name="text"></param>
       private static  void TouchPad(NumericUpDown n, string text)
       {
           TouchPad testTouchPad = new TouchPad(ref n, text);//计算器
           testTouchPad.ShowDialog();
       }

       //public static void SetY(ref double start, ref double end,double )
       //{ 
       
       //}
    }






    class CsvReport_Pim_Entry
    {
        int no;
        float p1;
        float f1;
        float p2;
        float f2;
        float im_f;
        float im_v;

        string maxVal;
        string result;
        string fluctuate;

        public string MaxVal
        {
            get { return maxVal; }
            set { maxVal  = value; }
        }

        public string Fluctuate
        {
            get { return fluctuate; }
            set { fluctuate = value; }
        }

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        /// <summary>
        /// 扫描项序号
        /// </summary>
        public int No
        {
            get { return no; }
            set { no = value; }
        }

        /// <summary>
        /// 功放1输出功率，单位 dBm
        /// </summary>
        public float P1
        {
            get { return p1; }
            set { p1 = value; }
        }

        /// <summary>
        /// 功放1中心频率，单位 MHz
        /// </summary>
        public float F1
        {
            get { return f1; }
            set { f1 = value; }
        }

        /// <summary>
        /// 功放2输出功率，单位 dBm
        /// </summary>
        public float P2
        {
            get { return p2; }
            set { p2 = value; }
        }

        /// <summary>
        /// 功放2中心频率，单位 MHz
        /// </summary>
        public float F2
        {
            get { return f2; }
            set { f2 = value; }
        }

        /// <summary>
        /// 扫描点的频率，单位 MHz
        /// </summary>
        public float Im_F
        {
            get { return im_f; }
            set { im_f = value; }
        }

        /// <summary>
        /// 扫描点的互调值，单位 dBc
        /// </summary>
        public float Im_V
        {
            get { return im_v; }
            set { im_v = value; }
        }
    }
    class CsvReport
    {
        /// <summary>
        /// 将互调扫描参数header，互调扫描项列表entries保存到文件fileName
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="entries"></param>
        /// <param name="header"></param>
        internal static void Save_Csv_Pim(string fileName,List<CsvReport_Pim_Entry[]> entries ,bool isdbm)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(fileName, false, Encoding.ASCII);
                sw.WriteLine("NO., F1, P1, F2, P2, Im_V, Im_F");

                for (int j = 0; j < entries.Count; j++)
                {


                    string s4;
                    for (int i = 0; i < entries[j].Length; i++)
                    {
                        s4 = entries[i][j].No.ToString() + ", " +
                             entries[i][j].F1.ToString("0.0000000") + ", " +
                             entries[i][j].P1.ToString("0.0000000") + ", " +
                             entries[i][j].F2.ToString("0.0000000") + ", " +
                             entries[i][j].P2.ToString("0.0000000") + ", " +
                             entries[i][j].Im_F.ToString("0.0000000") + ", " +
                             entries[i][j].Im_V.ToString("0.0000000");

                        sw.WriteLine(s4);
                        sw.WriteLine("\r\n\r\n");
                    }
                }
                sw.Flush();
                sw.Close();
                sw.Dispose();

            }
            catch          
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
        internal static void Save_Csv_Pim(string fileName, List<CsvReport_Pim_Entry[]> entries, int num,bool isdbm)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(fileName, false, Encoding.ASCII);
                if(isdbm)
                    sw.WriteLine("NO., MaxVal(dBm), Fluctuate, Result");
                else sw.WriteLine("NO., MaxVal(dBc), Fluctuate, Result");
                string s;
               
                for (int i = 0; i < entries[0].Length; i++)
                {
                    s = entries[0][i].No.ToString() + ", " +entries[0][i].MaxVal + ", " +
                            entries[0][i].Fluctuate + ", " +
                            entries[0][i].Result;


                    sw.WriteLine(s);

                }
                sw.WriteLine("\r\n\r\n");
                

                 if(isdbm) sw.WriteLine("NO., F1, P1, F2, P2, Im_V(dBm), Im_F");
                 else sw.WriteLine("NO., F1, P1, F2, P2, Im_V(dBc), Im_F");
                string s4;
                for (int j = 1; j < num; j++)
                {

                    for (int i = 0; i < entries[j].Length; i++)
                    {
                        s4 = entries[j][i].No.ToString() + ", " +
                             entries[j][i].F1.ToString("0.0000000") + ", " +
                             entries[j][i].P1.ToString("0.0000000") + ", " +
                             entries[j][i].F2.ToString("0.0000000") + ", " +
                             entries[j][i].P2.ToString("0.0000000") + ", " +
                             entries[j][i].Im_F.ToString("0.0000000") + ", " +
                             entries[j][i].Im_V.ToString("0.0000000");

                        sw.WriteLine(s4);

                    }
                    sw.WriteLine("\r\n\r\n");
                }
                sw.Flush();
                sw.Close();
                sw.Dispose();

            }
            catch
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}
