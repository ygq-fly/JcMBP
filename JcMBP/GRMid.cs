using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using jcXY2dPlotEx;
namespace JcMBP
{
    public partial class GRMid : Form
    {
        Microsoft.Office.Interop.Excel.Application excel;

        public GRMid()
        {
            InitializeComponent();
        }
        public GRMid(ClsUpLoad cul)
        {
            this.cul = cul;
            InitializeComponent();
        }
        public bool isThreadStart = false;
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Data.DataTable dtc = new System.Data.DataTable();
        System.Data.DataTable singleTestDt = new System.Data.DataTable();
        System.Data.DataTable singleTestDtc = new System.Data.DataTable();
        System.Data.DataTable sweep_pointsDt = new System.Data.DataTable();
        System.Data.DataTable sweep_pointsDtc = new System.Data.DataTable();
        List<System.Data.DataTable> list_singleDt = new List<System.Data.DataTable>();
        List<System.Data.DataTable> list_pointsDt = new List<System.Data.DataTable>();
        Dictionary<List<System.Data.DataTable>, List<System.Data.DataTable>> dic_data = new Dictionary<List<System.Data.DataTable>, List<System.Data.DataTable>>();


        int mode = 0;
        TestData testdata;
        Sweep sweep;
        ClsUpLoad cul;
        bool halfway = true;
        int tx_count = 1;
        int current_portcount = 1;
        int currentSweepCont = 0;
        float _pim_max = float.MinValue;
        float _pim_limit = -110;
        string name = "";
        string barcode = "";
        string tester = "";
        float _rxs = 0;
        float _rxe = 0;
        float fluctuate = 0;
        float currentTxMac = float.MinValue;
        string id = "";
        float set_rxs = 0;
        float set_rxe = 0;
        float pimOffset = 0;
        double[] plot_x = new double[2];
        int byt1 = 2;
        int byt2 = 1;
        string LastCode = "";
        bool isSame = false;
        //ExlConn ec = new ExlConn();
        public void ToAddColumns_j(System.Data.DataTable dt, bool y)
        {
            if (y)
            {
                if (dt.Columns.Count > 1)
                    return;
                dt.Columns.Add("序号");
                dt.Columns.Add("产品名称");
                dt.Columns.Add("产品条码号");
                dt.Columns.Add("产品标准值");
                dt.Columns.Add("TX1");
                dt.Columns.Add("TX1Time");
                dt.Columns.Add("TX2");
                dt.Columns.Add("TX2Time");
                dt.Columns.Add("TX3");
                dt.Columns.Add("TX3Time");
                dt.Columns.Add("TX4");
                dt.Columns.Add("TX4Time");
                dt.Columns.Add("TX5");
                dt.Columns.Add("TX5Time");
                dt.Columns.Add("TX6");
                dt.Columns.Add("TX6Time");
                dt.Columns.Add("TX7");
                dt.Columns.Add("TX7Time");
                dt.Columns.Add("TX8");
                dt.Columns.Add("TX8Time");
                dt.Columns.Add("测试结果(Y/N)");
                dt.Columns.Add("测试次数");
                dt.Columns.Add("测试人员");
                dt.Columns.Add("StartTime");
                dt.Columns.Add("EndTime");
                dt.Columns.Add("ID");
            }
            else
            {
                dt.Columns.Add("TX");
                dt.Columns.Add("No.");
                dt.Columns.Add("Peak");
                dt.Columns.Add("Fluctuate");
                dt.Columns.Add("Result");
            }
        }

        //freq  

        //===========================

        public static void ToNewRows(System.Data.DataTable dt, int number,
                                        string name, string barcode, float limit,
                                        string tx1, string tx1time,
                                        string tx2,string tx2time,
                                        string tx3, string tx3time,
                                        string tx4, string tx4time,
                                        string tx5, string tx5time,
                                        string tx6, string tx6time,
                                        string tx7, string tx7time,
                                        string tx8, string tx8time,
                                        string result, int count, string tester, 
                                        string  start,string  end,string Id)
        {
            DataRow row = dt.NewRow();
            int i = 0;
            row[i++] = number.ToString();
            row[i++] = name;
            row[i++] = barcode;
            row[i++] = limit.ToString("0.0");
            row[i++] = tx1;
            row[i++] = tx1time;
            row[i++] = tx2;
            row[i++] = tx2time;
            row[i++] = tx3;
            row[i++] = tx3time;
            row[i++] = tx4;
            row[i++] = tx4time;
            row[i++] = tx5;
            row[i++] = tx5time;
            row[i++] = tx6;
            row[i++] = tx6time;
            row[i++] = tx7;
            row[i++] = tx7time;
            row[i++] = tx8;
            row[i++] = tx8time;
            row[i++] = result;
            row[i++] = count.ToString();
            row[i++] = tester;
            row[i++] = start;
            row[i++] = end;
            row[i++] = Id;
            dt.Rows.Add(row);//添加行
        }

        int dsds = -1;
        private void button1_Click(object sender, EventArgs e)
        {


        }

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
            //freq_plot.SetChannelVisible(4, false);//设置通道是否显示
            //freq_plot.SetChannelVisible(5, false);//设置通道是否显示
            //freq_plot.SetChannelVisible(6, false);//设置通道是否显示
            //freq_plot.SetChannelVisible(7, false);//设置通道是否显示
            //if (ClsUpLoad._portHole == 4)
            //{
            //    freq_plot.SetChannelVisible(2, true);//设置通道是否显示
            //    freq_plot.SetChannelVisible(3, true);//设置通道是否显示
            //}
            freq_plot.SetSmoothing(true);
            freq_plot.Resume();
            freq_plot.MajorLineWidth = freq_plot.MajorLineWidth;
        }

        private void GRMid_Load(object sender, EventArgs e)
        {

            ToAddColumns_j(dt, true);
            //ToAddColumns_j(dtc, true);
            ToAddColumns_j(singleTestDt, false);
            //ToAddColumns_j(singleTestDtc, false);
            OfftenMethod.ToAddColumns(sweep_pointsDt);
            //OfftenMethod.ToAddColumns(sweep_pointsDtc);

            dg.DataSource = dt;
            dataGridView1.DataSource = singleTestDt;
            OfftenMethod.LoadComboBox(cb_band, cul.BandNames, 0);
            cb_band.SelectedIndex = 0;
            cb_order.SelectedIndex = 0;
            cb_step.SelectedIndex = 1;
            tb_id.Text = ClsUpLoad.id;
            set_rxe = _rxe;
            set_rxs = _rxs;
            button1.Text = set_rxs.ToString("0") + "-" + set_rxe.ToString("0");
            pimOffset = float.Parse(IniFile.GetString("Settings", "pimOffset", "0", System.Windows.Forms.Application.StartupPath + "\\JcConfig.ini"));
            PlotInfo();
            freq_plot.SetXStartStop(_rxs - 2, _rxe + 2);
            //ToNewRows(dt);
        }





        public static bool DataTable2Excel(System.Data.DataTable dataTable, string fileName, int rowsCount)
        {
            bool rt = false;//==用于返回值
            if (dataTable == null && rowsCount < 1)
            {
                return false;
            }
            int rowNum = dataTable.Rows.Count;//获取行数
            int colNum = dataTable.Columns.Count;//获取列数
            int SheetNum = (rowNum - 1) / rowsCount + 1; //获取工作表数
            string sqlText = "";//带类型的列名
            string sqlValues = "";//值
            string colCaption = "";//列名
            for (int i = 0; i < colNum; i++)
            {
                if (i != 0)
                {
                    sqlText += " , ";
                    colCaption += " , ";
                }
                sqlText += "[" + dataTable.Columns[i].Caption.ToString() + "] VarChar";//生成带VarChar列的标题
                colCaption += "[" + dataTable.Columns[i].Caption.ToString() + "]";//生成列的标题
            }
            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
            OleDbConnection cn = new OleDbConnection(sConnectionString);
            try
            {

                int sheet = 1;//表数
                int dbRow = 0;//数据的行数
                //打开连接
                cn.Open();

                //判断文件是否存在,存在则先删除
                if (File.Exists(fileName))
                {

                }

                while (sheet <= SheetNum)
                {

                    string sqlCreate = "CREATE TABLE [Sheet" + sheet.ToString() + "] (" + sqlText + ")";
                    OleDbCommand cmd = new OleDbCommand(sqlCreate, cn);
                    //创建Excel文件


                    cmd.ExecuteNonQuery();
                    //}
                    for (int srow = 0; srow < rowsCount; srow++)
                    {
                        sqlValues = "";
                        for (int col = 0; col < colNum; col++)
                        {
                            if (col != 0)
                            {
                                sqlValues += " , ";
                            }
                            sqlValues += "'" + dataTable.Rows[dbRow][col].ToString() + "'";//拼接Value语句
                        }
                        String queryString = "INSERT INTO [Sheet" + sheet.ToString() + "] (" + colCaption + ") VALUES (" + sqlValues + ")";
                        cmd.CommandText = queryString;
                        cmd.ExecuteNonQuery();//插入数据
                        dbRow++;//目前数据的行数自增
                        if (dbRow >= rowNum)
                        {
                            //目前数据的行数等于rowNum时退出循环
                            break;
                        }
                    }
                    sheet++;
                }
                rt = true;
            }
            catch
            {
            }
            finally
            {
                cn.Close();
            }

            return rt;

        }

        void InsertDate(string fileName, int row, System.Data.DataTable dt)
        {
            if (!File.Exists(fileName))
            {
                DataTable2Excel(dt, fileName, 20);
                return;
            }

            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
            OleDbConnection cn = new OleDbConnection(sConnectionString);
            try
            {
                cn.Open();
                OleDbCommand com = new OleDbCommand();
                com.Connection = cn;
                //
                string selcetSql = "select * from[Sheet1$]";
                com.CommandText = selcetSql;
                OleDbDataAdapter adapter = new OleDbDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Sheet1");
                int count = ds.Tables[0].Rows.Count;
                //
                //MessageBox.Show(count.ToString());
                string sqlText = "";
                string sqlValue = "";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i != 0)
                    {
                        sqlText += " , ";
                        sqlValue += " , ";
                    }
                    sqlText += "[" + dt.Columns[i].Caption.ToString() + "]";//生成列的标题

                    if (i == 0)
                    {
                        sqlValue += "'" + (count + 1).ToString() + "'";//拼接Value语句
                    }
                    else
                    {
                        sqlValue += "'" + dt.Rows[row][i].ToString() + "'";//拼接Value语句
                    }
                }


                //selcetSql = "select * from[Sheet1$] where 产品条码号= " + "'" + dt.Rows[row][2].ToString() + "'";
                //com.CommandText = selcetSql;
                // adapter = new OleDbDataAdapter(com);
                // ds = new DataSet();
                //adapter.Fill(ds, "Sheet1");
                //count = ds.Tables[0].Rows.Count;
                ////MessageBox.Show("count is " + count.ToString());
                string sql;
                //if (count >= 1)
                //{
                //    sql = "update [Sheet1$] set ";
                //    for (int i = 1; i < dt.Columns.Count; i++)
                //    {
                //        if (i != 1) sql += ",";                        
                //       sql += "[" + dt.Columns[i].Caption.ToString() + "] =" + "'" + dt.Rows[row][i].ToString() + "'";
                //    }
                //    sql += " where [产品条码号] ='" + dt.Rows[row][2].ToString() + "'";
                //}
                if (isSame)
                {
                    sql = "update [Sheet1$] set ";
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (i != 1) sql += ",";                        
                        sql += "[" + dt.Columns[i].Caption.ToString() + "] =" + "'" + dt.Rows[row][i].ToString() + "'";
                    }
                    sql += " where [序号] ='" + count.ToString() + "'";
                    
                }
                else sql = "INSERT INTO [Sheet1$] (" + sqlText + ") VALUES (" + sqlValue + ")";

                //MessageBox.Show("sql  is " + sql);
                com.CommandText = sql;
                com.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }
        }

        void FreqDate(int port)
        {
            testdata = new TestData(Convert.ToInt32(nud_portcount.Value));
            for (int i = 0; i < nud_portcount.Value; i++)
            {
                //st_pow = Convert.ToSingle(freq_nud_pow1.Value);
                testdata.tx1Date[i].fs = Convert.ToSingle(nud_f1s.Value);
                testdata.tx1Date[i].fe = Convert.ToSingle(nud_f1e.Value);
                testdata.tx2Date[i].fs = Convert.ToSingle(nud_f2s.Value);
                testdata.tx2Date[i].fe = Convert.ToSingle(nud_f2e.Value);
                testdata.tx1Date[i].pow = Convert.ToSingle(nud_pow.Value);
                testdata.tx2Date[i].pow = Convert.ToSingle(nud_pow.Value);
                if (mode == 0)
                {
                    testdata.tx1Date[i].step = Convert.ToSingle(cb_step.Text.Replace('m', ' '));
                    testdata.tx2Date[i].step = Convert.ToSingle(cb_step.Text.Replace('m', ' '));
                }
                else
                {
                    testdata.tx1Date[i].sweeptime = Convert.ToInt32(cb_step.Text);
                    testdata.tx2Date[i].sweeptime = Convert.ToInt32(cb_step.Text);
                }
                testdata.tx1Date[i].band = cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)];
                testdata.tx2Date[i].band = cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)];
                testdata.rxDate[i].band = cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)];
                testdata.pimDate[i].order = byte.Parse(cb_order.Text.Substring(2));
                testdata.tx1Date[i].off = Convert.ToDouble(nud_offset.Value);
                testdata.tx2Date[i].off = Convert.ToDouble(nud_offset.Value);
                testdata.rxDate[i].currentRxe = set_rxe;
                testdata.rxDate[i].currentRxs = set_rxs;
                testdata.rxDate[i].port = port;
                testdata.tx1Date[i].port = port;
                testdata.tx2Date[i].port = port;
                testdata.rxDate[i].bandName = cb_band.Text.ToLower();
                testdata.tx1Date[i].bandName = cb_band.Text.ToLower();
                testdata.tx2Date[i].bandName = cb_band.Text.ToLower();
                testdata.pimDate[i].imCo1 = (int.Parse(cb_order.Text.Substring(2)) + 1) / 2;
                testdata.pimDate[i].imCo2 = (int.Parse(cb_order.Text.Substring(2)) - 1) / 2;
                testdata.pimDate[i].imLess = 0;
                testdata.pimDate[i].imLow = 0;

                tester = tb_tester.Text;
                barcode = tb_barcode.Text;
                name = tb_name.Text;
                _pim_limit = Convert.ToSingle(nud_limit.Value);
                id = tb_id.Text.Trim();
                halfway = true;
                if (barcode == LastCode)
                {
                    isSame = true;
                }
                LastCode = barcode;

                float pim_rs = byt1 * Convert.ToSingle(nud_f1s.Value) - byt2 * Convert.ToSingle(nud_f2e.Value);
                float pim_re = byt1 * Convert.ToSingle(nud_f1e.Value) - byt2 * Convert.ToSingle(nud_f2s.Value);
                freq_plot.SetXStartStop(pim_rs - 2, pim_re + 2);
                IniFile.SetString("Settings", "pim_id", id, System.Windows.Forms.Application.StartupPath + "\\JcConfig.ini");
            }
            
        }


        bool IniOK()
        {
            if (tb_barcode.Text == "" || tb_name.Text == "" || tb_tester.Text == "") return false;
            return true;
        }
        private void bt_tx1_Click(object sender, EventArgs e)
        {
            if (!IniOK())
            {
                MessageBox.Show("请输入完整信息");
                return;
            }
            FreqDate(0);
            LockControl(0);
            Thread th = new Thread(Start);
            th.IsBackground = true;
            th.Start();
        }

        void LockControl(int n)
        {
            bt_tx1.Enabled = false;
            bt_tx2.Enabled = false;
            if(n==0) bt_tx1.BackColor = Color.Green;
            else bt_tx2.BackColor = Color.Green;
        }

        void UnLockControl()
        {
            this.Invoke(new ThreadStart(delegate
            {
                bt_tx1.Enabled = true;
                bt_tx2.Enabled = true;
                bt_tx1.BackColor = Color.White;
                bt_tx2.BackColor = Color.White;
            }));
        }

        void DataClear()
        {
            list_pointsDt.Clear();
            list_singleDt.Clear();
            singleTestDt.Clear();
            //singleTestDtc.Clear();
            sweep_pointsDt.Clear();
            //sweep_pointsDtc.Clear();
        }

        void Start()
        {

            int testcount = 0;
            isThreadStart = true;
            tx_count = Convert.ToInt32(nud_portcount.Value);
            current_portcount = Convert.ToInt32(nud_testcount.Value);
            int currentDataTableRow = dt.Rows.Count;//当前有几条数据
            plot_x = OfftenMethod.GetTestBand_val((byte)byt1, (byte)byt2, 0, 0, Convert.ToDouble(nud_f1s.Value), Convert.ToDouble(nud_f1e.Value), Convert.ToDouble(nud_f2s.Value), Convert.ToDouble(nud_f2e.Value));
            this.Invoke(new ThreadStart(delegate
            {
                if (mode == 0)
                    freq_plot.SetXStartStop(plot_x[0]-2, plot_x[1]+2);
                DataClear();
                textBox1.Clear();
                ToNewRows(dt, currentDataTableRow + 1, name, barcode, _pim_limit, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "Y", current_portcount, tester, DateTime.Now.ToString("yyyy/MM/dd hh:mm"), "", id);
                //ToNewRows(dtc, currentDataTableRow + 1, name, barcode, _pim_limit, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "Y", current_portcount, tester, DateTime.Now.ToString("yyyy/MM/dd hh:mm"), "", id);
            }));
            try
            {
            for (int i = 0; i < tx_count; i++)
            {
                currentSweepCont = i;
                _pim_max = float.MinValue;
                if (mode == 0)
                    sweep = new SweepFreq(testdata, ClsUpLoad._type.ToString(), i);
                else
                    sweep = new SweepTime(testdata, ClsUpLoad._type.ToString(), i);
                if (sweep.GetCurrentCondition()) break;
                //if (i >= 1)
                //{
                //GRMessageForm grmf = new GRMessageForm("请注意换线！");
                //if (grmf.ShowDialog(this) == DialogResult.Cancel)
                //{
                //    break;
                //}
                //else if (grmf.ShowDialog(this) == DialogResult.Retry)
                //{
                //    this.Invoke(new ThreadStart(delegate
                //       {
                //           int dataCount = dt.Rows.Count;
                //           DataRow dr = dt.Rows[dataCount - 1];
                //           dr.Delete();
                //           i -= 1;
                //       }));
                //}

                //if (MessageBox.Show("提示", "保存数据", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //{
                //    this.Invoke(new ThreadStart(delegate
                //       {
                //           int dataCount = dt.Rows.Count;
                //           DataRow dr = dt.Rows[dataCount - 1];
                //           dt.Rows.Remove(dr);
                //           i -= 1;
                //       }));
                //}
              

                    //}
                    for (int y = 0; y < current_portcount; y++)
                    {
                        if (y != 0)
                        {
                            GRMessageForm grmf = new GRMessageForm("请注意敲击！");
                            if (grmf.ShowDialog(this) == DialogResult.Cancel)
                            {
                                UnLockControl();
                                isThreadStart = false;
                                return;
                            }
                            //else if (grmf.ShowDialog(this) == DialogResult.Retry)
                            //{
                            //    this.Invoke(new ThreadStart(delegate
                            //   {
                            //       int n1 = singleTestDt.Rows.Count;
                            //       DataRow dr1 = singleTestDt.Rows[n1 - 1];
                            //       singleTestDt.Rows.Remove(dr1);
                            //       y -= 1;
                            //   }));
                            //}


                        }
                        currentTxMac = float.MinValue;
                        testcount++;
                        this.Invoke(new ThreadStart(delegate
                        {

                            if (i != 0 || y != 0) textBox1.AppendText("\r\n");
                            textBox1.AppendText("TX" + (i + 1).ToString() + " 第" + (y + 1).ToString() + "次测试:\r\n");
                            OfftenMethod.ToNewRowsGR(singleTestDt, i + 1, y + 1, 0, "0", "PASS");
                            testdata.pimDate[currentSweepCont].pimFreq.Clear();
                            testdata.pimDate[currentSweepCont].pimVal_dbm.Clear();
                            freq_plot.Clear();
                        }));
                        sweep_pointsDt.Clear();

                        if (sweep.GetCurrentCondition()) break;

                        StartFreqSweep();

                        System.Data.DataTable linshi = sweep_pointsDt.Copy();
                        list_pointsDt.Add(linshi);
                        if (sweep.GetCurrentCondition())
                            break;
                    }

                    this.Invoke(new ThreadStart(delegate
                    {

                        int n = dt.Rows.Count;
                        DataRow dr = dt.Rows[n - 1];
                        //DataRow drc = dtc.Rows[n - 1];
                        string nowtime = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
                        dr[5 + currentSweepCont * 2] = nowtime;
                        //drc[5 + currentSweepCont * 2] = nowtime;
                        textBox1.AppendText("\r\nTX" + (currentSweepCont + 1).ToString() + "完成测试间：" + nowtime + "\r\n");
                        if (mode == 0)
                        {
                            freq_plot.SetXStartStop(plot_x[0]-2, plot_x[1]+2);
                        }
                        else
                        {
                            freq_plot.SetXStartStop(0, 10);
                        }
                    }));

                    if (sweep.GetCurrentCondition())
                        break;
                    this.Invoke(new ThreadStart(delegate
                    {
                        GRSaveWin grsw = new GRSaveWin();

                        if (grsw.ShowDialog(this) != DialogResult.OK)
                        {

                            int dataCount = dt.Rows.Count;
                            DataRow dr = dt.Rows[dataCount - 1];
                            dr[5 + currentSweepCont * 2] = "";
                            dr[4 + currentSweepCont * 2] = "";
                            //dt.Rows.Remove(dr);
                            int single_currentRows = singleTestDt.Rows.Count;
                            for (int z = 0; z < single_currentRows - current_portcount * i; z++)
                            {
                                singleTestDt.Rows.RemoveAt(single_currentRows - 1 - z);
                            }
                            dataCount = dt.Rows.Count;
                            //ToNewRows(dt, dataCount + 1, name, barcode, _pim_limit, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "Y", current_portcount, tester, DateTime.Now.ToString("yyyy/MM/dd hh:mm"), "", id);
                            //ToNewRows(dtc, dataCount + 1, name, barcode, _pim_limit, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "Y", current_portcount, tester, DateTime.Now.ToString("yyyy/MM/dd hh:mm"), "", id);
                            i -= 1;

                        }
                    }));

                   
                }

            }
            catch(Exception ex)
            {
            MessageBox.Show(ex.Message);
            }
            this.Invoke(new ThreadStart(delegate
            {
                int n = dt.Rows.Count;
                DataRow dr = dt.Rows[n - 1];
                //DataRow drc = dtc.Rows[n - 1];
                dr[24] = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
                //drc[24] = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
                if (!halfway)
                {
                    dr[20] = "N";
                   
                }
                UnLockControl();
            }));
            if (!sweep.GetCurrentCondition() && halfway)
            {
                 DialogResult dr= MessageBox.Show("提示", "是否保存数据到excel?", MessageBoxButtons.OKCancel);
                if(dr==DialogResult.OK)
                InsertDate(System.Windows.Forms.Application.StartupPath + "\\数据结果.xls", currentDataTableRow, dt);
            }
            isThreadStart = false;
     
        }


        /////////sweep



        void StartFreqSweep()
        {
            //this.Invoke(new ThreadStart(delegate
            //{
            //    //if (fm.isdBm)
            //        dg.DataSource = testdata.pimDate[currentSweepCont].dt_dbm; 
            //    //else
            //    //    dg.DataSource = dtc;
            //}));

            sweep.PowerHander += new ControlIni_Sweep_Pow(Powhand_f);
            sweep.VcoHander += new ControlIni_Sweep_Vco(VcoHand);
            sweep.Tx1Hander += new ControlIni_Sweep_Tx1(Tx1Hand);
            sweep.Tx2Hander += new ControlIni_Sweep_Tx2(Tx2Hand);

            sweep.StHander += new Sweep_Test(SweepControl);
            sweep.Ini();
            sweep.PowerHander -= new ControlIni_Sweep_Pow(Powhand_f);
            sweep.VcoHander -= new ControlIni_Sweep_Vco(VcoHand);
            sweep.Tx1Hander -= new ControlIni_Sweep_Tx1(Tx1Hand);
            sweep.Tx2Hander -= new ControlIni_Sweep_Tx2(Tx2Hand);
            sweep.StHander -= new Sweep_Test(SweepControl);

        }

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
                sweep.Stop();
            }
        }

        /// <summary>
        /// vco检测
        /// </summary>
        /// <param name="isVco"></param>
        /// <param name="real_vco"></param>
        /// <param name="off"></param>
        void VcoHand(bool isVco, double real_vco, double off)
        {
            this.Invoke(new ThreadStart(delegate
            {
                if (isVco)
                {
                }
                else
                {
                    MessageBox.Show("VCO FAIl");
                    sweep.Stop();
                }
                if (isVco == false)
                {
                    MessageBox.Show(this, "错误： VCO未检测到! 请检查RX接收链路");
                    sweep.Stop();
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
            if (s <= -10000 && ClsUpLoad._checkPow)
            {
                this.Invoke(new ThreadStart(delegate
                {
                    if (s == -10018)
                        MessageBox.Show(this, "错误： 未检测到功率！请检功率输出！");
                    else
                    {
                        MessageBox.Show(this, "错误： TX1功率偏差过大!");
                    }
                }));
                sweep.Stop();
            }
            else
            {
                sen_tx1 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX1);//tx1显示功率
                double r = sen_tx1;
                testdata.pimDate[currentSweepCont].sen_tx1 = Convert.ToSingle(r);
                //this.Invoke(new ThreadStart(delegate
                //{
                //    //this.time_tb_show_tx1.Text = r.ToString("0.00");//显示功率    
                //}));
            }
        }

        //tx2检测
        void Tx2Hand(int s, ref double sen_tx2)
        {
            if (s <= -10000 && ClsUpLoad._checkPow)
            {
                this.Invoke(new ThreadStart(delegate
                {
                    if (s == -10018)
                    {
                        MessageBox.Show(this, "错误： 未检测到功率！请检功率输出！");

                    }
                    else
                    {
                        MessageBox.Show(this, "错误： TX2功率偏差过大!");
                        ;
                    }
                }));
                sweep.Stop();
                return;
            }
            else
            {
                sen_tx2 = ClsJcPimDll.HwGetCoup_Dsp(ClsJcPimDll.JC_COUP_TX2);//读取tx2显示功率
                double r = sen_tx2;
                testdata.pimDate[currentSweepCont].sen_tx2 = Convert.ToSingle(r);
                //this.Invoke(new ThreadStart(delegate
                //{
                //    //this.time_tb_show_tx2.Text = r.ToString("0.00");//设置显示功率text
                //}));
            }
        }



   

        /// <summary>
        /// 扫描数据更新
        /// </summary>
        /// <param name="ds"></param>
        void SweepControl(TestData testdata)
        {
            //try
            //{
            float currenty = 0;
            this.Invoke(new ThreadStart(delegate
            {
                int length = testdata.pimDate[currentSweepCont].pimFreq.Count - 1;//更具存入的互调值的数组的长度来计算当前的点 

                currenty = testdata.pimDate[currentSweepCont].pimVal_dbm[length]+pimOffset;


                if (currenty > _pim_max)
                {
                    _pim_max = currenty;//设置pim最大值
                    int n = dt.Rows.Count;
                    DataRow dr = dt.Rows[n - 1];
                    //DataRow drc = dtc.Rows[n - 1];
                    dr[4 + currentSweepCont*2] = _pim_max.ToString("0.0");
                    //drc[4 + currentSweepCont*2] = _pim_max.ToString("0.0");

                }

                if (currenty > currentTxMac)
                {
                    currentTxMac = currenty;
                    int n1 = singleTestDt.Rows.Count;
                    DataRow dr1 = singleTestDt.Rows[n1 - 1];
                    //DataRow drc1 = singleTestDtc.Rows[n1 - 1];
                    dr1[2] = currentTxMac.ToString("0.0");
                    //drc1[2] = _pim_max.ToString("0.0");

                    fluctuate = currentTxMac - _pim_limit;
                    dr1[3] = fluctuate.ToString("0.0");
                    //drc1[3] = fluctuate.ToString("0.0");
                }


                if (currenty > _pim_limit)
                {
                    int n = dt.Rows.Count;
                    DataRow dr = dt.Rows[n - 1];
                    //DataRow drc = dtc.Rows[n - 1];
                    dr[20] = "N";
                    //drc[12] = "fail";
                    int n1 = singleTestDt.Rows.Count;
                    DataRow dr1 = singleTestDt.Rows[n1 - 1];
                    //DataRow drc1 = singleTestDtc.Rows[n1-1];
                    dr1[4] = "FAIL";
                    //drc1[4] = "FAIL";
                }



                int m = length + 1;



                if (mode == 0)
                {
                    int freqlength = testdata.pimDate[currentSweepCont].pimFreq.Count;
                    PointF pf = new PointF(testdata.pimDate[currentSweepCont].pimFreq[freqlength - 1], testdata.pimDate[currentSweepCont].pimVal_dbm[freqlength - 1]+pimOffset);
                    PointF pfc = new PointF(testdata.pimDate[currentSweepCont].pimFreq[freqlength - 1], testdata.pimDate[currentSweepCont].pimVal_dbc[freqlength - 1]+pimOffset);
                    //ChangeY(testdata.pimDate[currentSweepCont].pimVal_dbm[freqlength - 1]);
                    ChangeY(testdata.pimDate[currentSweepCont].pimVal_dbm[freqlength - 1] + pimOffset);
                    this.freq_plot.Add(new PointF[1] { pf }, testdata.pimDate[currentSweepCont].currentPort, length + 1);//坐标控件添加点
                    this.freq_plot.Add(new PointF[1] { pfc }, testdata.pimDate[currentSweepCont].currentPort + 4, length + 1);//坐标控件添加点
                    this.freq_plot.MajorLineWidth = this.freq_plot.MajorLineWidth;
                }
                else
                {
                    int freqlength = testdata.pimDate[currentSweepCont].pimFreq.Count;
                    PointF pf = new PointF(m, testdata.pimDate[currentSweepCont].pimVal_dbm[freqlength - 1]+pimOffset);
                    PointF pfc = new PointF(m, testdata.pimDate[currentSweepCont].pimVal_dbc[freqlength - 1]+pimOffset);
                    ChangeY(testdata.pimDate[currentSweepCont].pimVal_dbm[freqlength - 1] + pimOffset);
                    this.freq_plot.Add(new PointF[1] { pf }, 0, length + 1);//坐标控件添加点
                    //this.freq_plot.Add(new PointF[1] { pfc }, 0, length + 1);//坐标控件添加点
                    this.freq_plot.MajorLineWidth = this.freq_plot.MajorLineWidth;
                }




                //OfftenMethod.ToNewRows(sweep_pointsDt, m, testdata.pimDate[currentSweepCont].currentTestF1,
                //                 testdata.pimDate[currentSweepCont].sen_tx1, testdata.pimDate[currentSweepCont].currentTestF2, testdata.pimDate[currentSweepCont].sen_tx2,
                //                  testdata.pimDate[currentSweepCont].pimFreq[m - 1], testdata.pimDate[currentSweepCont].pimVal_dbm[m - 1]+pimOffset);//添加数据到表格
                //OfftenMethod.ToNewRows(sweep_pointsDtc, m, testdata.pimDate[currentSweepCont].currentTestF1,
                //                      testdata.pimDate[currentSweepCont].sen_tx1, testdata.pimDate[currentSweepCont].currentTestF2, testdata.pimDate[currentSweepCont].sen_tx2,
                //                       testdata.pimDate[currentSweepCont].pimFreq[m - 1], testdata.pimDate[currentSweepCont].pimVal_dbc[m - 1]+pimOffset);//添加数据到表

                textBox1.AppendText("PIM(" +
                                    testdata.pimDate[currentSweepCont].currentTestF1.ToString("0.0") +
                                    " - " +
                                    testdata.pimDate[currentSweepCont].currentTestF2.ToString("0.0") +
                                    "):  " +
                                    testdata.pimDate[currentSweepCont].pimVal_dbm[m - 1].ToString("0.0") +
                                    "dBm @ " +
                                    (testdata.pimDate[currentSweepCont].pimFreq[m - 1]+ pimOffset).ToString("0.0") +
                                    "MHz\r\n");

            }));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        //////

        float y_Max = -80;
        float y_Min = -140;

        void ChangeY(float y)
        {
           

            if (y == -200)
                return;
            if (y > y_Max)
            {
                y_Max = y + 10;
              
            }
            if (y < y_Min)
            {
                y_Min = (int)y - 10;

            }
             freq_plot.SetYStartStop(y_Max, y_Min);
        }

        void ChangeX(float x)
        {

           
         
         

        }


        private void bt_stop_Click(object sender, EventArgs e)
        {
            if (sweep != null)
                sweep.Stop();
            halfway = false;
            isThreadStart = false;
            
        }

        private void cb_order_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{

            OfftenMethod.NudValue(nud_f1s, nud_f1e,
                                                 (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].TxS, (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].TxE);
            OfftenMethod.NudValue(nud_f2s, nud_f2e,
                                     (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].TxS, (decimal)cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].TxE);
            int m = cb_order.SelectedIndex;

            switch (m)
            {
                case 0:
                    nud_f1s.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord3_F1UpS);
                    nud_f2s.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord3_F2DnS);
                    nud_f1e.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord3_F1UpE);
                    nud_f2e.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord3_F2DnE);
                    _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord3_imS;
                    _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord3_imE;
                    byt1=2;
                    byt2=1;
                    break;
                case 1:
                    nud_f1s.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord5_F1UpS);
                    nud_f2s.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord5_F2DnS);
                    nud_f1e.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord5_F1UpE);
                    nud_f2e.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord5_F2DnE);
                    _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord5_imS;
                    _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord5_imE;
                     byt1=3;
                    byt2=2;
                    break;
                case 2:
                    nud_f1s.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord7_F1UpS);
                    nud_f2s.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord7_F2DnS);
                    nud_f1e.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord7_F1UpE);
                    nud_f2e.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord7_F2DnE);
                    _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord7_imS;
                    _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord7_imE;
                     byt1=4;
                    byt2=3;
                    break;
                case 3:
                    nud_f1s.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord9_F1UpS);
                    nud_f2s.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord9_F2DnS);
                    nud_f1e.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord9_F1UpE);
                    nud_f2e.Value = Convert.ToDecimal(cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord9_F2DnE);
                    _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord9_imS;
                    _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord9_imE;
                     byt1=5;
                    byt2=4;
                    break;
                case 4: break;
            }
            _rxs = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord3_imS;
            _rxe = cul.ld[cul.BandCount[cul.BandNames.IndexOf(cb_band.Text)]].ord3_imE;
            
          
            set_rxe = _rxe;
            set_rxs = _rxs;
            button1.Text = _rxs.ToString("0") + "-" + _rxe.ToString("0") + "MHz";
            if (mode == 0)
                freq_plot.SetXStartStop(_rxs - 2, _rxe + 2);
            else
                freq_plot.SetXStartStop(0, 10);
            freq_plot.SetYStartStop(-80, -140);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message+"\r\n"+ex.ToString());
            //}
        }

        private void bt_tx2_Click(object sender, EventArgs e)
        {
            if (!IniOK())
            {
                MessageBox.Show("请输入完整信息");
                return;
            }
            FreqDate(1);
            LockControl(1);
            Thread th = new Thread(Start);
            th.IsBackground = true;
            th.Start();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count <= 0) return;
            //int n = dataGridView1.CurrentRow.Index;
            //SingleTestData std;
            //std = new SingleTestData(list_pointsDt[n], true);
            //std.ShowDialog();
        }

        private void nud_portcount_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_testcount_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_limit_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_f1s_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_f1e_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_f2s_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_f2e_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_pow_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void nud_offset_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //ToNewRows(dt, 1, "ygq", "123", -110, "", "", "", "", "", "", "", "", "Y", 5, "ygq", DateTime.Now);
            dsds++;
            InsertDate(System.Windows.Forms.Application.StartupPath + "\\数据结果.xls", dsds, dt);
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int n = e.RowCount;
            dataGridView1.FirstDisplayedScrollingRowIndex = n - 1;
        }

        private void dg_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int n = e.RowCount;
            dg.FirstDisplayedScrollingRowIndex = n - 1;
        }

        private void cb_step_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            RxRange rr = new RxRange(set_rxs,set_rxe, _rxe, _rxs);
            rr.ShowDialog();
            if (rr.DialogResult == DialogResult.OK)
            {
                set_rxs = rr._rxs;
                set_rxe = rr._rxe;
                button1.Text = set_rxs.ToString("0") + "-" + set_rxe.ToString("0");
            }
        }

        private void btn_mode_Click(object sender, EventArgs e)
        {
            if (btn_mode.Text == "扫频")
            {
                freq_plot.SetXStartStop(0, 10);
                freq_plot.SetYStartStop(-80, -140);
                mode = 1;
                nud_f1e.Enabled = false;
                nud_f2s.Enabled = false;
                btn_mode.Text = "点频";
                lbl_step.Text = "点数";
                cb_step.Items.Clear();
                cb_step.Items.AddRange(new string[] { "1", "3", "5", "10" });
               

            }
            else
            {
                freq_plot.SetYStartStop(-80, -140);
                freq_plot.SetXStartStop(_rxs - 2, _rxe + 2);
                mode=0;
                nud_f1e.Enabled = true;
                nud_f2s.Enabled = true;
                btn_mode.Text = "扫频";
                lbl_step.Text = "步进";
                cb_step.Items.Clear();
                cb_step.Items.AddRange(new string[] { "0.5m","1m","3m","5m","10m" });
            }
            cb_step.SelectedIndex = 1;
        }
    }
}
