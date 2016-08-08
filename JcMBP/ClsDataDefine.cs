//
//各种Enum信息
//Write By San!
//@JointCom.com
//2014-9-3.
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace JcMBP
{
    class ClsDataDefine
    {
    }
    enum Info_Band
    {
        F700 = 0,
        F700_B = 1,
        F800 = 2,
        F800_B = 3,
        F900 = 4,
        F900_B = 5,
        F1800 = 6,
        F1800_B = 7,
        F1900 = 8,
        F1900_B = 9,
        F2100 = 10,
        F2100_B = 11,
        F2600 = 12,
        F2600_B = 13
    }

    enum Info_Signal
    {
        Tx1=0,
        Tx2=1
    }

    enum PIM_Mode
    {
        FreqSweep = 1,
        TimeSweep = 2
    }

    enum PIM_Order
    {
        IM3 = 3,
        IM5 = 5,
        IM7 = 7,
        IM9 = 9,
        IM11 = 11
    }

    enum PIM_Type
    {
        Reflection = 1,
        Transmission = 2
    }

    enum PIM_Unit
    {
        dBm = 1,
        dBc = 2
    }

    enum PIM_Directions
    {
        Low = 1,
        High = 2
    }

   public  enum SweepMode
    {
        Hw = 1,
        Poi = 2,
        Np = 3
    }

    enum CheckMode
    {
        ST = 1,
        Sf = 2,
        Rx = 3,
        Tx = 4,
        Gr=5
    }

    class MsgID
    {
        public const int PIM_SUCCESS = 0X0400 + 1000;
        public const int PIM_END = 0X0400 + 1001;
        public const int PIM_ERROR = 0X0400 + 1002;
        public const int OTHER_ERROR = 0x0400 + 1003;
        public const int RX_ERROR = 0X0400 + 1004;
        public const int TX_ERROR = 0X0400 + 1005;
    }

    class WindowsMessage
    {
        //BOOL PostMessage(HWND hWnd,
        //                UINT Msg,
        //                WPARAM wParam,
        //                LPARAM lParam
        //            );
        [DllImport("User32.dll", CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool PostMessage([InAttribute] IntPtr hWnd,
                                                      uint Msg,
                                                      uint wParam,
                                                      int lParam);

        //HWND FindWindow(LPCTSTR lpClassName,
        //LPCTSTR lpWindowName
        //);
        [DllImport("User32.dll", CharSet = CharSet.Ansi)]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindoNname);
    }

    class IniFile
    {
        private static string fName = "";

        private static readonly uint maxCharCount = 256;


   [DllImport("kernel32")]
        internal static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

          

        // DWORD WINAPI GetPrivateProfileString(
        // __in   LPCTSTR lpAppName,
        // __in   LPCTSTR lpKeyName,
        // __in   LPCTSTR lpDefault,
        // __out  LPTSTR lpReturnedString,
        // __in   DWORD nSize,
        // __in   LPCTSTR lpFileName
        // );
        [DllImport("Kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        private static extern uint GetPrivateProfileStringA([In()] [MarshalAs(UnmanagedType.LPStr)] string sectionName,
                                                            [In()] [MarshalAs(UnmanagedType.LPStr)] string keyName,
                                                            [In()] [MarshalAs(UnmanagedType.LPStr)] string defaultString,
                                                            [Out()] [MarshalAs(UnmanagedType.LPStr)] StringBuilder returnedString,
                                                            uint charCount,
                                                            [In()] [MarshalAs(UnmanagedType.LPStr)] string fName);

        //  BOOL WINAPI WritePrivateProfileString(
        //  __in  LPCTSTR lpAppName,
        //  __in  LPCTSTR lpKeyName,
        //  __in  LPCTSTR lpString,
        //  __in  LPCTSTR lpFileName
        //  );
        [DllImport("Kernel32.dll", EntryPoint = "WritePrivateProfileStringA")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WritePrivateProfileStringA([In()] [MarshalAs(UnmanagedType.LPStr)] string sectionName,
                                                              [In()] [MarshalAs(UnmanagedType.LPStr)] string keyName,
                                                              [In()] [MarshalAs(UnmanagedType.LPStr)] string value,
                                                              [In()] [MarshalAs(UnmanagedType.LPStr)] string fName);



        internal static string GetString(string section,
                                         string key,
                                         string defaultValue)
        {
            StringBuilder sb = new StringBuilder((int)maxCharCount);

            GetPrivateProfileStringA(section, key, defaultValue, sb, maxCharCount, fName);

            return sb.ToString();
        }
        internal static string GetString(string section,
                                         string key,
                                         string defaultValue,
                                         string filename)
        {
            StringBuilder sb = new StringBuilder((int)maxCharCount);

            GetPrivateProfileStringA(section, key, defaultValue, sb, maxCharCount, filename);

            return sb.ToString();
        }
        internal static bool SetString(string section,
                                       string key,
                                       string value)
        {
            return WritePrivateProfileStringA(section, key, value, fName);
        }

        internal static void SetFileName(string fileName)
        {
            fName = fileName;
        }
        internal static bool SetString(string section,
                                       string key,
                                       string value,
                                       string fileName)
        {
            return WritePrivateProfileStringA(section, key, value, fileName);
        }

        /// <summary>
        /// 从以逗号和空格隔开的字符串str
        /// 获取第i项，最多maxCount项，索引从零开始
        /// （2B写法！）
        /// </summary>
        /// <param name="str"></param>
        /// <param name="i"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        internal static string GetItemFrom(string str, int i, int maxCount)
        {
            int j1, j2, k;
            string item = "";

            //获取最后一项
            if (i >= (maxCount - 1))
            {
                j1 = str.LastIndexOf(",");

                if (j1 >= 0)
                    item = str.Substring((j1 + 1), (str.Length - j1 - 1));

                //获取前面的项
            }
            else
            {
                k = 0;
                j1 = 0;
                j2 = str.IndexOf(',', j1);
                if (j2 < 0)
                    item = str;

                while (j2 > 0)
                {
                    k++;

                    if (k >= (i + 1))
                        break;

                    j1 = j2;

                    j2 = str.IndexOf(',', (j1 + 1));
                }

                if (k == (i + 1))
                {
                    if (j1 > 0)
                        item = str.Substring((j1 + 1), (j2 - j1 - 1));
                    else
                        item = str.Substring(j1, (j2 - j1));
                }
            }

            //返回找到的项
            return item.Trim();
        }


        /// <summary>
        /// 在以逗号和空格隔开的字符串, 获知其包含数据项的数目
        /// （2B写法！）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static int CountOfItemIn(string str)
        {
            int c = 0;
            int i1 = 0;
            int i2 = 0;
            string item = "";

            i2 = str.IndexOf(',', i1);

            while (i2 > 0)
            {
                c++;

                i1 = i2;

                i2 = str.IndexOf(',', (i1 + 1));
            }

            if (c > 0)
            {
                i1 = str.LastIndexOf(",");

                item = str.Substring(i1, (str.Length - i1));

                if (!String.IsNullOrEmpty(item.Trim()))
                    c++;
            }
            return c;
        }


    }
}
