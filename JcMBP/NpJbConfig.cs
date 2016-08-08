using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class NpJbConfig : Form
    {
        ClsUpLoad cul;
        DataTable dt;
        byte imCo1 = 2;
        byte imCo2 = 1;
        byte imLow = 0;
        byte imLess = 0;
        float _rxs;
        float _rxe;
        double f1s;
        double f1e;
        double f2s;
        double f2e;
        float rmax;
        float rmin;
        int n = 0;
        byte porttx1 = 0;
        byte porttx2 = 0;
        byte portrx = 0;
        string bandMessage = "";
        string time_out_Message = "";
        List<string> bandM = new List<string>();
        List<string> time_out_M = new List<string>();
        List<float> limit = new List<float>();
      
        List<byte[]> port_arr = new List<byte[]>();
        
        List<float[]> rx_arr = new List<float[]>();
       
        List<byte[]> im_arr = new List<byte[]>();
        public NpJbConfig(ClsUpLoad cul)
        {
            InitializeComponent();
            this.cul = cul;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SettingFreq sf = new SettingFreq(f1s, f1e,comboBox11.SelectedIndex);
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
            {
                button13.Text = sf.f1.ToString() + "—" + sf.f2.ToString();
                f1e = sf.f2;
                f1s = sf.f1;
                label70.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SettingFreq sf = new SettingFreq(f2s, f2e, comboBox11.SelectedIndex);
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
            {
                button12.Text = sf.f1.ToString() + "—" + sf.f2.ToString();
                f2e = sf.f2;
                f2s = sf.f1;
                label70.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
            }
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4_SelectedIndexChanged(null, null);
            comboBox3_SelectedIndexChanged(null, null);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2s = cul.ld[comboBox4.SelectedIndex].ord3_F1UpS;
            f2e = cul.ld[comboBox4.SelectedIndex].ord3_F1UpE;
            if (comboBox11.SelectedIndex == 1)
                f2e = f2s;
            button12.Text = f2s.ToString("0.00") + "-" + f2e.ToString("0.00");
            label70.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RxRange rr = new RxRange(_rxs, _rxe,rmax,rmin);
            rr.ShowDialog();
            if (rr.DialogResult == DialogResult.OK)
            {
                _rxs = rr._rxs;
                _rxe = rr._rxe;
                button7.Text = _rxs.ToString() + "-" + _rxe.ToString() + "MHz";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1s = cul.ld[comboBox3.SelectedIndex].ord3_F1UpS;
            f1e = cul.ld[comboBox3.SelectedIndex].ord3_F1UpE;
            if (comboBox11.SelectedIndex == 1)
                f1e = f1s;
            button13.Text = f1s.ToString("0.00") + "-" + f1e.ToString("0.00");
            label70.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
        }

        private void NpJbConfig_Load(object sender, EventArgs e)
        {
            OfftenMethod.LoadComboBox(comboBox3, cul.BandNames);
            OfftenMethod.LoadComboBox(comboBox4, cul.BandNames);
            OfftenMethod.LoadComboBox(comboBox1, cul.BandNames);
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox11.SelectedIndex = 0;
            freq_cb_step.SelectedIndex = 1;
            dt = new DataTable();
            ToAddColumns(dt);
            freq_dgvPim.DataSource = dt;
          
        }

        void ToAddColumns(DataTable dt)
        {
            int i = 0;
            dt.Columns.Add("1");
            dt.Columns.Add("2");
            dt.Columns.Add("3");
            dt.Columns.Add("4");
            dt.Columns.Add("5");
            dt.Columns.Add("6");
            dt.Columns.Add("7");
            dt.Columns.Add("8");
            dt.Columns.Add("9");
            dt.Columns.Add("10");
            dt.Columns.Add("11");
            dt.Columns.Add("12");
            dt.Columns.Add("13");
            dt.Columns.Add("14");
            dt.Columns.Add("15");
            dt.Columns.Add("16");
            dt.Columns[i++].ReadOnly = false;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
            dt.Columns[i++].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n++;
            ToNewRows(dt, n, true, comboBox3.Text, f1s, f1e, comboBox4.Text, f2s, f2e, comboBox1.Text,
                comboBox11.Text, (imCo1 + imCo2), button8.Text, Convert.ToSingle(freq_cb_step.Text.Replace('m', ' ')),
                Convert.ToSingle(freq_nud_pow2.Value), Convert.ToSingle(freq_nud_off1.Value), Convert.ToSingle(numericUpDown1.Value));
            bandMessage = textBox1.Text;
            bandM.Add(bandMessage);
            time_out_M.Add("-");
            limit.Add(Convert.ToSingle(numericUpDown2.Value));
            byte[] port = new byte[3];
            port[0] = porttx1;
            port[1] = porttx2;
            port[2] = portrx;
            port_arr.Add(port);
            float[] rx = new float[2];
            rx[0] = _rxs;
            rx[1] = _rxe;
            rx_arr.Add(rx);
            byte[] im = new byte[4];
            im[0] = imCo1;
            im[1] = imCo2;
            im[2] = imLow;
            im[3] = imLess;
            im_arr.Add(im);
        }
        public void ToNewRows(DataTable dt, int n, bool b,
           string tx1, double f1s, double f1e,
           string tx2, double f2s, double f2e,
           string rx,
           string model, int order, string str2,
           float set_s, float pow, float off, float off2)
        {
            DataRow row = dt.NewRow();
            row[0] = b;
            row[1] = n.ToString();
            row[2] = tx1;
            row[3] = f1s.ToString();
            row[4] = f1e.ToString();
            row[5] = tx2;
            row[6] = f2s.ToString();
            row[7] = f2e.ToString();
            row[8] = rx;
            row[9] = model;
            row[10] = order.ToString();
            row[11] = str2;
            row[12] = set_s.ToString();
            row[13] = pow.ToString("0.00");
            row[14] = off.ToString();
            row[15] = off2.ToString();
            dt.Rows.Add(row);
        }

        public void ToNewRows2(DataTable dt, int n, bool b)
        {
            DataRow row = dt.NewRow();
            row[0] = b;
            row[1] = n.ToString();
            row[2] = "--";
            row[3] = "--";
            row[4] = "--";
            row[5] = "--";
            row[6] = "--";
            row[7] = "--";
            row[8] = "--";
            row[9] = "--";
            row[10] = "--";
            row[11] = "--";
            row[12] = "--";
            row[13] = "--";
            row[14] = "--";
            row[15] = "--";
            dt.Rows.Add(row);
        }


        private void button9_Click(object sender, EventArgs e)
        {
            PauseMessage pm = new PauseMessage();
            pm.ShowDialog();
            if (pm.DialogResult == DialogResult.OK)
            {
                try
                {
                    n++;
                    ToNewRows2(dt, n, true);
                    time_out_M.Add(pm.message);
                    bandMessage = "-";
                    bandM.Add(bandMessage);
                    byte[] port = new byte[3];
                    port[0] = 0;
                    port[1] = 0;
                    port[2] = 0;
                    port_arr.Add(port);
                    float[] rx = new float[2];
                    rx[0] = 0;
                    rx[1] = 0;
                    rx_arr.Add(rx);
                    byte[] im = new byte[4];
                    im[0] = 2;
                    im[1] = 1;
                    im[2] = 0;
                    im[3] = 0;
                    im_arr.Add(im);
                    limit.Add(Convert.ToSingle(numericUpDown2.Value));
                    freq_dgvPim.FirstDisplayedScrollingRowIndex = freq_dgvPim.RowCount - 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("   输入值有误  ", "错误提示");
                    n--;
                    return;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rxs = cul.ld[comboBox1.SelectedIndex].ord3_imS;
            _rxe = cul.ld[comboBox1.SelectedIndex].ord3_imE;
            rmax = cul.ld[comboBox1.SelectedIndex].RxMax;
            rmin = cul.ld[comboBox1.SelectedIndex].RxMin;
            button7.Text = _rxs.ToString() + "-" + _rxe.ToString() + "MHz";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
                porttx1 = 0;
            else
                porttx1 = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                porttx2 = 0;
            else
                porttx2 = 1;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                portrx = 0;
            else
                portrx = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int data_len = dt.Rows.Count;
            if (data_len <= 0)
            {
                MessageBox.Show("请添加需要保存的数据");
                return;
            }

            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.InitialDirectory = Application.StartupPath + "\\Jcoffset";
            saveFileDialog1.Filter = "*.jointcom|*.jointcom";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path_save = saveFileDialog1.FileName;

                SetData(path_save, data_len);
                this.DialogResult = DialogResult.OK;
            }
        }

        void SetData(string path, int length)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            IniFile.WritePrivateProfileString("Setting", "num", length.ToString(), path);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IniFile.WritePrivateProfileString("Data", "num" + i.ToString(), get_dataRow_data(dt.Rows[i], i), path);
            }
        }
        string get_dataRow_data(DataRow row, int a)
        {
            string val = "";
            int i = 2;
            if (row[i].ToString() == "--")
            {
                val = "--,--,--,--,--,--,--,--,--,--,--,--,--,--,--,--,--,--,--," + time_out_M[a];
                return val;
            }
            val += cul.BandCount[cul.BandNames.IndexOf(row[i++].ToString())].ToString() + ",";
            val += row[i++] + ",";
            val += row[i++] + ",";
            val += cul.BandCount[cul.BandNames.IndexOf(row[i++].ToString())].ToString() + ",";
            val += row[i++] + ",";
            val += row[i++] + ",";
            val += cul.BandCount[cul.BandNames.IndexOf(row[i++].ToString())].ToString() + ",";
            string value = row[i++].ToString() == "扫频" ? "0" : "1";
            val += value + ",";
            i++;
            val += row[i++] + ",";
            val += row[i++] + ",";
            val += row[i++] + ",";
            val += row[i++] + ",";
            val += row[i++] + ",";
            val += rx_arr[a][0].ToString() + ",";
            val += rx_arr[a][1].ToString() + ",";
            val += limit[a].ToString() + ",";
            val += im_arr[a][0].ToString() + ",";
            val += im_arr[a][1].ToString() + ",";
            val += im_arr[a][2].ToString() + ",";
            val += im_arr[a][3].ToString() + ",";
            val += bandM[a] + ",";
            val += time_out_M[a] + ",";
            val += port_arr[a][0].ToString() + ",";
            val += port_arr[a][1].ToString() + ",";
            val += port_arr[a][2].ToString() ;
            return val;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int curre_row = freq_dgvPim.RowCount;
            for (int i = 0; i < curre_row; i++)
            {
                freq_dgvPim.Rows[i].Cells[0].Value = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int curre_row = freq_dgvPim.RowCount;
            for (int i = 0; i < curre_row; i++)
            {
                if (bool.Parse(freq_dgvPim.Rows[i].Cells[0].FormattedValue.ToString()))
                {
                    freq_dgvPim.Rows[i].Cells[0].Value = false;
                }
                else
                {
                    freq_dgvPim.Rows[i].Cells[0].Value = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int curre_row = freq_dgvPim.RowCount;
            int get_last = 1;
            for (int i = 0; i < curre_row; i++)
            {
                if (bool.Parse(freq_dgvPim.Rows[i].Cells[0].FormattedValue.ToString()))
                {
                    dt.Rows.RemoveAt(i);
                    limit.Remove(limit[i]);
                    bandM.Remove(bandM[i]);
                    port_arr.Remove(port_arr[i]);
                    time_out_M.Remove(time_out_M[i]);
                    rx_arr.Remove(rx_arr[i]);
                    im_arr.Remove(im_arr[i]);
                    n--;
                    i--;
                }
                else
                {
                    DataRow dro = dt.Rows[i];
                    dt.Columns[1].ReadOnly = false;
                    dro[1] = get_last.ToString();
                    dt.Columns[1].ReadOnly = true;
                    get_last++;
                }
                curre_row = freq_dgvPim.RowCount;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int a = freq_dgvPim.CurrentRow.Index;
            if (a == 0)
                return;
            try
            {
                DataTable de = dt.Copy();
                DataRow dro = de.Rows[a];
                if (dro[2].ToString() == "--")
                {
                    return;
                }

                for (int i = 2; i < dt.Columns.Count; i++)
                {
                    dt.Columns[i].ReadOnly = false;
                    dt.Rows[a][i] = dt.Rows[a - 1][i];
                    dt.Rows[a - 1][i] = dro[i];
                    dt.Columns[i].ReadOnly = false;
                }

                byte[] s = port_arr[a - 1];
                port_arr[a - 1] = port_arr[a];
                port_arr[a] = s;

                float[] s2 = rx_arr[a - 1];
                rx_arr[a - 1] = rx_arr[a];
                rx_arr[a] = s2;

                string s3 = bandM[a - 1];
                bandM[a - 1] = bandM[a];
                bandM[a] = s3;

                float s4 = limit[a - 1];
                limit[a - 1] = limit[a];
                limit[a] = s4;

                string s5 = time_out_M[a - 1];
                time_out_M[a - 1] = time_out_M[a];
                time_out_M[a] = s5;

                byte[] s6 = im_arr[a - 1];
                im_arr[a - 1] = im_arr[a];
                im_arr[a] = s6;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int a = freq_dgvPim.CurrentRow.Index;
            if (a == n - 1)
                return;
            try
            {
                DataTable de = dt.Copy();
                DataRow dro = de.Rows[a];
                if (dro[2].ToString() == "--")
                {
                    return;
                }
                for (int i = 2; i < dt.Columns.Count; i++)
                {
                    dt.Columns[i].ReadOnly = false;
                    dt.Rows[a][i] = dt.Rows[a + 1][i];
                    dt.Rows[a + 1][i] = dro[i];
                    dt.Columns[i].ReadOnly = false;
                }

                byte[] s = port_arr[a + 1];
                port_arr[a + 1] = port_arr[a];
                port_arr[a] = s;

                float[] s2 = rx_arr[a + 1];
                rx_arr[a + 1] = rx_arr[a];
                rx_arr[a] = s2;

                string s3 = bandM[a + 1];
                bandM[a + 1] = bandM[a];
                bandM[a] = s3;

                float s4 = limit[a + 1];
                limit[a + 1] = limit[a];
                limit[a] = s4;

                string s5 = time_out_M[a + 1];
                time_out_M[a + 1] = time_out_M[a];
                time_out_M[a] = s5;

                byte[] s6 = im_arr[a + 1];
                im_arr[a + 1] = im_arr[a];
                im_arr[a] = s6;
            }
            catch (Exception ex)
            {
                return;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            PoiOrder ord = new PoiOrder(imCo1, imCo2, imLow, imLess);
            ord.ShowDialog();
            if (ord.DialogResult == DialogResult.OK)
            {
                imLess = ord.imLess;//阶数高低频
                imLow = ord.imLow;//阶数加减法
                imCo1 = ord.imCo1;//阶数参数
                imCo2 = ord.imCo2;//阶数参数
                button8.Text = ord.val;//扫频阶数按钮text
                label70.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\Jcoffset";
            openFileDialog1.Filter = "*.jointcom|*.jointcom";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    im_arr.Clear();
                    limit.Clear();
                    bandM.Clear();
                    time_out_M.Clear();
                    port_arr.Clear();
                    rx_arr.Clear();
                    limit.Clear();
                    dt.Clear();
                    n = 0;
                    IniFile.SetFileName(openFileDialog1.FileName);
                    int num_c = int.Parse(IniFile.GetString("Setting", "num", "0"));
                    for (int i = 0; i < num_c; i++)
                    {
                        string[] str_ini = IniFile.GetString("Data", "num" + i.ToString(), " ").Split(',');
                        if (str_ini[0] == "--")
                        {
                            ToNewRows2(dt, i + 1, true);
                            time_out_M.Add(str_ini[19]);
                            bandMessage = "-";
                            bandM.Add(bandMessage);
                            byte[] port = new byte[3];
                            port[0] = 0;
                            port[1] = 0;
                            port[2] = 0;
                            port_arr.Add(port);
                            float[] rx = new float[2];
                            rx[0] = 0;
                            rx[1] = 0;
                            rx_arr.Add(rx);
                            byte[] im = new byte[4];
                            im[0] = 2;
                            im[1] = 1;
                            im[2] = 0;
                            im[3] = 0;
                            im_arr.Add(im);
                            limit.Add(-110);
                            n++;
                        }
                        else
                        {
                            comboBox11.SelectedIndex = int.Parse(str_ini[7]);
                            comboBox3.SelectedIndex = int.Parse(str_ini[0]);
                            comboBox4.SelectedIndex = int.Parse(str_ini[3]);
                            comboBox1.SelectedIndex = int.Parse(str_ini[6]);
                            freq_nud_pow2.Value = decimal.Parse(str_ini[10]);
                            freq_nud_off1.Value = decimal.Parse(str_ini[11]);
                            numericUpDown1.Value = decimal.Parse(str_ini[12]);
                            numericUpDown2.Value = decimal.Parse(str_ini[15]);
                            ToNewRows(dt, i + 1, true, cul.BandNames[int.Parse(str_ini[0])], float.Parse(str_ini[1]), float.Parse(str_ini[2]),
                                cul.BandNames[int.Parse(str_ini[3])], float.Parse(str_ini[4]), float.Parse(str_ini[5]),
                                cul.BandNames[int.Parse(str_ini[6])], str_ini[7] == "1" ? "点频" : "扫频", int.Parse(str_ini[16]) + int.Parse(str_ini[17]), str_ini[8],
                                 float.Parse(str_ini[9]), float.Parse(str_ini[10]), float.Parse(str_ini[11]), float.Parse(str_ini[12]));
                            f1s = float.Parse(str_ini[1]);
                            f1e = float.Parse(str_ini[2]);
                            f2s = float.Parse(str_ini[4]);
                            f2e = float.Parse(str_ini[5]);

                            time_out_M.Add(str_ini[21]);
                            bandMessage = str_ini[20];
                            bandM.Add(bandMessage);
                            byte[] port = new byte[3];
                            port[0] = byte.Parse(str_ini[22]);
                            if (port[0] == 0)
                                radioButton6.Checked = true;
                            port[1] = byte.Parse(str_ini[23]);
                            if (port[1] == 0)
                                radioButton2.Checked = true;
                            port[2] = byte.Parse(str_ini[24]);
                            if (port[2] == 0)
                                radioButton4.Checked = true;
                            port_arr.Add(port);
                            float[] rx = new float[2];
                           _rxs= rx[0] = float.Parse(str_ini[13]);
                           _rxe= rx[1] = float.Parse(str_ini[14]);
                           byte[] im = new byte[4];
                           imCo1= im[0] = byte.Parse(str_ini[16]);
                           imCo2= im[1] = byte.Parse(str_ini[17]);
                           imLow= im[2] = byte.Parse(str_ini[18]);
                           imLess= im[3] = byte.Parse(str_ini[19]);
                            im_arr.Add(im);
                            rx_arr.Add(rx);
                            button7.Text = _rxs.ToString() + "-" + _rxe.ToString() + "MHz";
                            limit.Add(float.Parse(str_ini[15]));
                            label70.Text = OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
                            n++;
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("读取错误");
                    return;
                }
            }
        }

        private void freq_dgvPim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = freq_dgvPim.CurrentRow.Index;

            DataRow dro = dt.Rows[a];
            if (dro[2].ToString() == "--")
            {
                return;
            }

            comboBox3.SelectedIndex =  cul.BandCount[cul.BandNames.IndexOf(dro[2].ToString())];
            f1s = double.Parse(dro[3].ToString());
            f1e = double.Parse(dro[4].ToString());
            comboBox4.SelectedIndex =  cul.BandCount[cul.BandNames.IndexOf(dro[2].ToString())];
            f2s = double.Parse(dro[6].ToString());
            f2e = double.Parse(dro[7].ToString());
            comboBox1.SelectedIndex =  cul.BandCount[cul.BandNames.IndexOf(dro[2].ToString())];
            comboBox11.SelectedIndex = dro[9].ToString() == "点频" ? 1 : 0;
            _rxs = rx_arr[a][0];
            _rxe = rx_arr[a][1];
            button8.Text = dro[11].ToString();
            imCo1= im_arr[a][0];
            imCo2 = im_arr[a][1];
            imLow = im_arr[a][2];
            imLess = im_arr[a][3];
            if (port_arr[a][0] == 1)
                radioButton5.Checked = true;
            else
                radioButton6.Checked = true;
            if (port_arr[a][1] == 1)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            if (port_arr[a][2] == 1)
                radioButton3.Checked = true;
            else
                radioButton4.Checked = true;
            if (comboBox11.SelectedIndex == 0)
            {
                switch (dro[12].ToString())
                {
                    case "0.1": freq_cb_step.SelectedIndex = 0; break;
                    case "1": freq_cb_step.SelectedIndex = 1; break;
                    case "2": freq_cb_step.SelectedIndex = 2; break;
                    case "3": freq_cb_step.SelectedIndex = 3; break;
                    case "5": freq_cb_step.SelectedIndex = 4; break;
                    case "10": freq_cb_step.SelectedIndex = 5; break;
                }
          
            }
            freq_nud_pow2.Value = decimal.Parse(dro[13].ToString());
            freq_nud_off1.Value = decimal.Parse(dro[14].ToString());
            numericUpDown1.Value = decimal.Parse(dro[15].ToString());
            numericUpDown2.Value = (decimal)limit[a];
            if (bandM[a] != "")
            {
                textBox1.Text = bandM[a];
            }
            button7.Text =  _rxs + "—" + _rxe + "MHz";

            //if (comboBox11.SelectedIndex == 0)
            //{
               label70.Text= OfftenMethod.GetTestBand_f(imCo1, imCo2, imLow, imLess, f1s, f1e, f2s, f2e);
            //}
            //else
            //{
            //    label70.Text = OfftenMethod.GetTestBand(imCo1, imCo2, imLow, imLess, f1s, f2e).ToString("0.00")+"MHz";
            //}
        }

        private void freq_nud_pow2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void freq_nud_off1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void numericUpDown1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void numericUpDown2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }
    }
}

