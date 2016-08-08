//build 1.5.0.30(2015/11/30)  
//  完成调试
//
// build 1.5.0.31(2015/12/2)  
//修改了脚本测试控件更新，脚本测试显示各个曲线和datatable的bug
//
// build 1.5.0.32(2015/12/2)  
//拷贝脚本各个tx12rx的值
//
//build 1.5.0.33(2015/12/2)  
//脚本测试result查看数据没更新
//
////build 1.5.0.34(2015/12/9)  
//txrx校准，开关错误后，isthread没有重置导致再次点校准，不执行

////build 1.5.0.35(2015/12/9)  
//rx校准值控件点击没有计算器，添加了计算器

////build 1.5.0.36_37(2015/12/14)  
//添加单位的切换

////build 1.5.0.38(2015/12/14)  
//华为模式，port2按钮不变色

////build 1.5.0.39(2015/12/22)  
//修改了跟换频段设置默认频率，和相对应最大最小频率

////build 1.5.0.40(2015/12/27)  
//poi模式设置有些频段无tx1tx2或rx

////build 1.5.0.41(2015/12/30)  
//单次测试保存数据bug修改

////build 1.5.0.42(2015/1/12)  
//修改了poi模式下脚本测试过程中出现错误不停止测试，

////build 1.5.0.43(2015/1/13)  
//修改了poi模式下脚本测试过程中出现开关切换错误不停止测试

////build 1.5.0.44(2015/1/25)  
//修改了poi模式下不能选中tx一些频段


////build 1.5.0.44(2015/1/26)  
//华为模式扩展了一个新频段


////build 1.5.1.44(2015/2/1)  
//添加了新8频

////build 1.5.1.45(2015/2/1)  
//新8频800频段3阶互调计算公式2f1-f2

////build 1.5.1.47(2015/2/1)  
//互调测试功率调整的更新。

////build 1.5.1.51(2015/2/1)  
//修改了点频次数为自由可设，添加了vco检测，是否检查功率，脚本测试暂停时间









////2.*.*.*.*国人版本

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JcMBP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if (!OneInstance.IsFirst("JcMBP"))
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool running = true ;
            string sn = IniFile.GetString("SN", "sn", "0", Application.StartupPath + "\\JcConfig.ini");//序列号
            string su = IniFile.GetString("SN", "su", "0", Application.StartupPath + "\\JcConfig.ini");//超级账号
            bool iscode = su == "637" ? true : false;

            if (!iscode)
            {
                //判断授权文件
                Code c = new Code();
                try
                {
                    if (File.Exists(Code.strFilePath))
                    {
                        if (!c.CheckFile(sn))
                        {
                            running = false;
                            MessageBox.Show("授权日期已到！");
                        }
                    }
                    else
                    {
                        running = false;
                        MessageBox.Show("请先生成授权文件！");
                    }
                }
                catch
                {
                    running = false;
                    MessageBox.Show("授权文件缺失或错误，请重新生成授权文件！");
                }
            }
            if (!running)
                Application.Exit();
            else
            {
                Application.Run(new FrmMain());
            }
        }
        public abstract class OneInstance
        {
            public static bool IsFirst(string appId)
            {
                bool flag = false;
                if (OpenMutex(0x1F0001, 0, appId) == IntPtr.Zero)
                {
                    CreateMutex(IntPtr.Zero, 0, appId);
                    flag = true;
                }

                return flag;
            }

            [DllImport("Kernel32.dll")]
            private static extern IntPtr OpenMutex(
            uint dwDesiredAccess, // access 
            int bInheritHandle, // inheritance option 
            string lpName // object name 
            );

            [DllImport("Kernel32.dll")]
            private static extern IntPtr CreateMutex(
            IntPtr lpMutexAttributes, // SD 
            int bInitialOwner, // initial owner 
            string lpName // object name 
            );

        }

    }
}
