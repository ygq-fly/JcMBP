using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JcMBP
{
    public delegate void ChangeUint();
    public delegate void ChangeBand();
    public delegate void ChangeLimit();
    public delegate void ChangeVco_enable();
    public partial class FrmMain : Form
    {
        public event ChangeUint CUHandle;
        public static  event ChangeBand CBHandle;
        public event ChangeLimit CLHandle;
        public static event ChangeVco_enable CVHandle;
        public FrmMain()
        {
            InitializeComponent();
        }
        //2边联动
        public  bool isdBm = true;//单位切换联动
        public static int band = 0;//华为模式频段联动
        public static int count = 1;
        public static bool vco = true;
        public  float limit = -110;
        //
        TimeSweepMid tm = null;
       public  FreqSweepMid fm = null;
        Rx rx = null;
        Tx tx = null;
        GRMid gr = null;
        ClsUpLoad cul = null;
        CheckMode cm=CheckMode.ST;
        private void FrmMain_Load(object sender, EventArgs e)
        {
             this.Text = Application.ProductVersion;//版本号
            try
            {
                //int n = (0x111 & 0x100) >> 8;
                int v1 = 0;
                int v2 = 0;
                int v3 = 0;
                int v4 = 0;
                ClsJcPimDll.JcGetDllVersion(ref v1, ref v2, ref v3, ref v4);//获取动态库版本号
                this.Text += (" && " + v1.ToString() + "." + v2.ToString() + "." + v3.ToString() + "." + v4.ToString());//动态库版本号
            }
            catch{}
            cul = new ClsUpLoad(Application.StartupPath);
            cul.UpLoad();
            tm = new TimeSweepMid(cul,this);
            tm.TopLevel = false;
            this.Controls.Add(tm);
            tm.Parent = this.panel1;
            tm.Show();
            button1.BackColor = Color.Blue;
            if (tx == null)
            {
                tx = new Tx(cul);
                OfftenMethod.SwitchWindow(this, tx, panel1);
            }
            if (rx == null)
            {
                rx = new Rx(cul);
                OfftenMethod.SwitchWindow(this, rx, panel1);
            }
            if (fm == null)
            {
                fm = new FreqSweepMid(cul,this);
                OfftenMethod.SwitchWindow(this, fm, panel1);
            }
            if (tm == null)
            {
                tm = new TimeSweepMid(cul,this);
                OfftenMethod.SwitchWindow(this, tm, panel1);
            }
            if (gr == null)
            {
                gr = new GRMid(cul);
                OfftenMethod.SwitchWindow(this, gr, panel1);
            }
            Setting();
            //========================================
        }


        void Setting()
        {
            if (ClsUpLoad._type == 1 || ClsUpLoad._type == 0)
            {
                添加测试脚本数据ToolStripMenuItem.Enabled = false;
                测试时间间隔ToolStripMenuItem.Enabled = false;
                保存校准结果ToolStripMenuItem.Enabled = true;
            }
            switch (ClsUpLoad._type)
            {
                case 0: label1.Text = "反射模式";
                    break;
                case 1: label1.Text = "传输模式";
                    break;
                case 2: label1.Text = "POI模式";
                    break;
                case 3: label1.Text = "NewPOI模式";
                    break;
                case 4: label1.Text = "新8频模式";
                    break;
            }
        }

        public bool IsdBm
        {
            get { return isdBm; }
            set
            {
               
                CUHandle();
                isdBm = value;
            }
        }

        public static  int Band
        {
            get { return band; }

            set {
                band = value;
                CBHandle();
              
            }
        }

        public static bool Vco
        {
            get { return vco; }

            set
            {
                vco = value;
                CVHandle();
                
            }
        }
        public  float Limit
        {
        
            get {               
                return limit;
            }

            set
            {
                limit = value;
                CLHandle();
              
                
            }
        }
       

        public void GoB(int tx1, int tx2, int rx)
        {
            if(fm!=null)
            fm.GoB(tx1, tx2, rx);
        }
        public void GoB2(int tx1, int tx2, int rx)
        {
            if (tm != null)
                tm.GoB2(tx1, tx2, rx);
        }
        private void FrmMain_Resize(object sender, EventArgs e)
        {

            
        }

        //========================控件事件
      
       //==================================================

        //=================方法
        void SingleCheck(object sender)
        {
            //timeToolStripMenuItem.Checked = false;
            //freqToolStripMenuItem.Checked = false;
            //rXToolStripMenuItem.Checked = false;
            //tXToolStripMenuItem.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
            switch((int)cm)
            {
                case 1: tm.Hide();
                    break;
                case 2: fm.Hide();
                    break;
                case 3: rx.Hide();
                    break;
                case 4: tx.Hide();
                    break;
            }
        }

        void SingleButtonCheck(object sender)
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
            //timeToolStripMenuItem.Checked = false;
            //freqToolStripMenuItem.Checked = false;
            //rXToolStripMenuItem.Checked = false;
            //tXToolStripMenuItem.Checked = false;
            //((ToolStripMenuItem)sender).Checked = true;
            ((Button)sender).BackColor = Color.Blue;
            ((Button)sender).ForeColor = Color.White;
            switch ((int)cm)
            {
                case 1: tm.Hide();
                    break;
                case 2: fm.Hide();
                    break;
                case 3: rx.Hide();
                    break;
                case 4: tx.Hide();
                    break;
                case 5: gr.Hide();
                    break;
            }
        }

        private void 添加测试脚本数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClsUpLoad._type == 2)
            {
                JbComfig jc = new JbComfig(cul);
            jc.ShowDialog();

            }
            else if (ClsUpLoad._type == 3)
            {
                NpJbConfig njc = new NpJbConfig(cul);
                njc.Show();
            }
        }

        private void 测试时间间隔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SleepTime st = new SleepTime(ClsUpLoad._sleepTime);
            st.ShowDialog();
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClsUpLoad._type == 2 || ClsUpLoad._type == 3)
            {
                DebugPoi dp = new DebugPoi(cul);
                dp.ShowDialog();
            }
            else
            {
                Debug d = new Debug(cul);
                d.ShowDialog();
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            string saddr = ClsUpLoad.addr_sig1 + "," +
                         ClsUpLoad.addr_sig2 + "," +
                         ClsUpLoad.addr_ana + "," +
                         ClsUpLoad.addr_sen + "," +
                         ClsUpLoad.addr_swh;//添加地址
            if (ClsJcPimDll.fnSetInit(saddr) == 0)//连接
            {
                ClsJcPimDll.HwSetIsExtBand(false);
                if (ClsUpLoad._checkTwoSignalROSC)
                {
                    int n = ClsJcPimDll.fnCheckTwoSignalROSC();
                    if (n <= -10000)
                    {
                        try
                        {
                            ClsJcPimDll.HwSetExit();
                        }
                        catch
                        {
                            ClsJcPimDll.fnSetExit();
                        }
                        MessageBox.Show("请检查同步线");
                        Thread.Sleep(100);
                        return;
                    }
                }
                panel1.Enabled = true;//tabcontrol控件
                btn_open.Enabled = false;//连接按钮
                debugToolStripMenuItem.Enabled = true;//debug
                //modeToolStripMenuItem.Enabled = true;
            }
            else
            {
                    byte[] bError = new byte[512];
                    ClsJcPimDll.JcGetError(bError, 512);//获取错误
                    MessageBox.Show(Encoding.ASCII.GetString(bError));//显示错误
                    ClsJcPimDll.fnSetExit();//关闭连接
                }
            }

        private void btn_close_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;//tabcontrol控件
            try { ClsJcPimDll.HwSetExit(); }//关闭连接
            catch { ClsJcPimDll.fnSetExit(); }//关闭连接
            btn_open.Enabled = true;//连接按钮
            debugToolStripMenuItem.Enabled = false;//debug
            //modeToolStripMenuItem.Enabled = false;
            Thread.Sleep(1000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Save sp=new Save();
            //sp.ShowDialog();
            bool success=false;
            string s="";
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (OfftenMethod.SaveJpg(sfd.FileName + ".jpg", this))
                {
                    success = true;
                    s += " Save Picture Success\r\n";
                }

                if (cm == CheckMode.Sf)
                {
                    success = OfftenMethod.SaveCsv_pdf(sfd.FileName, fm.testdata_, isdBm);
                }
                else if (cm == CheckMode.ST)
                {
                    success = OfftenMethod.SaveCsv_pdf(sfd.FileName, tm.testdata_, isdBm);
                }
                if (success) s += "Save Excel Success";
                else s += "Save Excel Fail";
                MessageBox.Show(s);
            }
        }

        private void 保存校准结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OfftenMethod.SaveOff();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { ClsJcPimDll.HwSetExit(); }//关闭连接
            catch { ClsJcPimDll.fnSetExit(); }//关闭连接
        }

        private void rxoffset_btn_save_Click(object sender, EventArgs e)
        {
            // Save sp = new Save();
            // bool success = false;
            // if (ClsUpLoad._type == 0)
            // { 
             
            // }
            // if (fm.ds_arr.Count <= 0 )
            //{
                //if (cm == CheckMode.Sf)
                //{
                //    if (fm.ds.sxy.image1 == null)
                //        return;
                //}
                //else
                //{
                //    if (tm.ds.sxy.image1 == null)
                //        return;
                //}
           //      sp.ShowDialog();
           //      if (sp.DialogResult == DialogResult.OK)
           //      {
           //          try
           //          {
           //              if (cm == CheckMode.Sf)
           //              {
           //                  success = OfftenMethod.savepdf(sp.pictureName, fm.ds, isdBm, true);
           //                  success = OfftenMethod.SaveCsv_pdf(sp.pictureName, fm.ds, isdBm, true);
           //              }
           //              else if (cm == CheckMode.ST)
           //              {
           //                  success = OfftenMethod.savepdf(sp.pictureName, tm.ds, isdBm, false);
           //                  success = OfftenMethod.SaveCsv_pdf(sp.pictureName, tm.ds, isdBm, false);
           //              }
           //          }
           //          catch (Exception ex)
           //          {
           //              MessageBox.Show(ex.Message);
           //          }

           //      }
           // }
           //else
           // {
           //     sp.ShowDialog();
           //     try
           //     {
           //         if (sp.DialogResult == DialogResult.OK)
           //             success = OfftenMethod.savepdf(sp.pictureName, fm.ds_arr, isdBm);
           //     }
           //     catch (Exception ex)
           //     {
           //         MessageBox.Show(ex.Message);
           //     }
           // }

           // if(success)
           //     MessageBox.Show("Success");
           // else
           //     MessageBox.Show("Fail");
            //OfftenMethod.savepdf("800",fm.ds_arr,true);
        }


        private void button1_Click(object sender, EventArgs e)
        {
       
            if (fm.isThreadStart || tx.isThreadStart || rx.isThreadStart||gr.isThreadStart)
                return;
            SingleButtonCheck(sender);
            tm.Show();
            cm = CheckMode.ST;
        }

        private void button2_Click(object sender, EventArgs e)
        {
      
            if (tm.isThreadStart||tx.isThreadStart||rx.isThreadStart|| gr.isThreadStart)
                return;
            SingleButtonCheck(sender);
            fm.Show();
            cm = CheckMode.Sf;
        }

        private void button3_Click(object sender, EventArgs e)
        {         
          
            if (tm.isThreadStart || tx.isThreadStart || fm.isThreadStart|| gr.isThreadStart)
                return;
            SingleButtonCheck(sender);
            rx.Show();
            cm = CheckMode.Rx;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            if (tm.isThreadStart || fm.isThreadStart || rx.isThreadStart|| gr.isThreadStart)
                return;
            SingleButtonCheck(sender);
            tx.Show();
            cm = CheckMode.Tx;
        }

        private void 测试次数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SweepTimes sts=new SweepTimes();
            sts.ShowDialog(); 
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tm.isThreadStart||fm.isThreadStart || tx.isThreadStart || rx.isThreadStart)
                return;
            SingleButtonCheck(sender);
            gr.Show();
            cm = CheckMode.Gr;
        }


        //====================

    }
}
