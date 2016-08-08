//-------------------------
// JcMBP 底层库转换
// 版本 1.1
// write by San
//-------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace JcMBP
{

/////////////////////////////////////////////////////////////////////////////////////////////
////测试（请无视）
/////////////////////////////////////////////////////////////////////////////////////////////
//JC_API int  JcGetIDN(const unsigned long &viSession);
//JC_API void JcFindRsrc();

    
    public class ClsJcPimDll
    {
        //const string Path = "D:\\Sync_ProJects\\Jointcom\\JcPimMultiBandV2\\Debug\\JcPimMultiBandV2.dll";
        const string Path = "JcPimMultiBandV2.dll";

        public const byte JC_CARRIER_TX1TX2 = 0;
        public const byte JC_CARRIER_TX1 = 1;
        public const byte JC_CARRIER_TX2 = 2;

        public const byte JC_COUP_TX1 = 0;
        public const byte JC_COUP_TX2 = 1;

        public const byte JC_DEVICE_SIG1 = 0;
        public const byte JC_DEVICE_SIG2 = 1;
        public const byte JC_DEVICE_SENSOR = 2;
        public const byte JC_DEVICE_ANALYZER = 3;
        public const byte JC_DEVICE_SWITCH = 4;

        public const byte JC_INTERNAL_BAND_700 = 0;
        public const byte JC_INTERNAL_BAND_800 = 1;
        public const byte JC_INTERNAL_BAND_900 = 2;
        public const byte JC_INTERNAL_BAND_1800 = 3;
        public const byte JC_INTERNAL_BAND_1900 = 4;
        public const byte JC_INTERNAL_BAND_2100 = 5;
        public const byte JC_INTERNAL_BAND_2600 = 6;

        public const byte JC_SWITCH_BAND_700_A = 0;
        public const byte JC_SWITCH_BAND_700_B = 1;
        public const byte JC_SWITCH_BAND_800_A = 2;
        public const byte JC_SWITCH_BAND_800_B = 3;
        public const byte JC_SWITCH_BAND_900_A = 4;
        public const byte JC_SWITCH_BAND_900_B = 5;
        public const byte JC_SWITCH_BAND_1800_A = 6;
        public const byte JC_SWITCH_BAND_1800_B = 7;
        public const byte JC_SWITCH_BAND_1900_A = 8;
        public const byte JC_SWITCH_BAND_1900_B = 9;
        public const byte JC_SWITCH_BAND_2100_A = 10;
        public const byte JC_SWITCH_BAND_2100_B = 11;
        public const byte JC_SWITCH_BAND_2600_A = 12;
        public const byte JC_SWITCH_BAND_2600_B = 13;

        //------------------------------------------------底层 API--------------------------------------------------------
        
        //开关控制
        //JIONTCOM_API void HwSetBandEnable(int iBand, BOOL_ isEnable);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HwSetBandEnable(int iBand, bool isEnable);

        //JIONTCOM_API void HwSetExit();
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HwSetExit();

        //vco检测
        //JC_API BOOL_ JcGetVcoDsp(JC_RETURN_VALUE vco, BYTE_ bySwitchBand);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool JcGetVcoDsp(ref double vco, byte bySwitchBand);

        //获取错误
        //JC_API void  JcGetError(char* msg, size_t max);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void JcGetError(byte[] msg, int max);

        //设备状态查询
        //JC_API BOOL_ JcGetDeviceStatus(BYTE_ byDevic);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool JcGetDeviceStatus(byte byDevice);

        //设置信号源（未补偿）
        //JC_API void  JcSetSig(BYTE_ byCarrier, double freq_khz, double pow_dbm);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void JcSetSig(byte byCarrier, double freq_khz, double pow_dbm);

        //返回信号是否获取到源外部参数
        //JC_API BOOL_ JcGetSig_ExtRefStatus(BYTE_ byCarrier);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool JcGetSig_ExtRefStatus(byte byCarrier);

        //设置信号源_高级功能（调用数据库补偿）
        //JC_API JC_STATUS JcSetSig_Advanced(BYTE_ byCarrier, BYTE_ byBand, BYTE_ byPort,
		//						             double freq_khz, double pow_dbm,
		//						             bool isOffset, double dOffset);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JcSetSig_Advanced(byte byCarrier, byte byBand, byte byPort,
                                                   double freq_khz, double pow_dbm,
                                                   bool isOffet, double dOffset);

        //设置TX显示功率
        //JC_API double JcGetSig_CoupDsp(BYTE_ byCoup, BYTE_ byBand, BYTE_ byPort,
        //					             double freq_khz, double pow_dbm, double dExtOffset);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern double JcGetSig_CoupDsp(byte byCoup, byte byBand, byte byPort,
                                                     double freq_khz, double pow_dbm, double dExtOffset);

        //读取传感器
        //JC_API double JcGetSen();
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern double JcGetSen();

        //读取频谱
        //JC_API double JcGetAna(double freq_khz, bool isMax);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern double JcGetAna(double freq_khz, bool isMax);

        //设置频谱内部offset
        //JC_API void   JcSetAna_RefLevelOffset(double offset);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void JcSetAna_RefLevelOffset(double offset);

        //设置开关
        //JC_API BOOL_  JcSetSwitch(int iSwitchTx1, int iSwitchTx2,
		//				            int iSwitchPim, int iSwitchDet);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool JcSetSwitch(int iSwitchTx1, int iSwitchTx2,
                                              int iSwitchPim, int iSwitchDet);

        //------------------------------------------------扩展 API--------------------------------------------------------

        //JIONTCOM_API void HwSetIsExtBand(BOOL_ isUse);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HwSetIsExtBand(bool isUse);

        //设置初始化地址：格式为逗号隔开(SG1addr,SG2Addr,SAAddr,PMAddr)
        //JIONTCOM_API BOOL_ FnSetInit(ADDRESS_ cDeviceAddr);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int fnSetInit(string cDeviceAddr);

        //关闭连接
        //JIONTCOM_API void FnSetExit();
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int fnSetExit();

        //设置频段
        //JIONTCOM_API void FnSetMeasBand(BYTE_ byBandIndex);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int fnSetMeasBand(byte byBandIndex);
        //设置频段
        //JIONTCOM_API void FnSetMeasBand(BYTE_ byBandIndex);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HwSetMeasBand(byte byTx1Band,byte byTx2Band,byte byRxBand);

        //设置平均次数
        //JIONTCOM_API void FnSetImAvg(BYTE_ byAvgTime);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int fnSetImAvg(byte byAvgTime);

        //设置测试端口(请先设置频段后)
        //JIONTCOM_API bool_ FnSetDutPort(BYTE_ byPort);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int fnSetDutPort(byte byPort);

        //设置测试端口(请先设置频段后)
        //JIONTCOM_API bool_ FnSetDutPort(BYTE_ byPort);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HwSetDutPort(byte tx1, byte tx2, byte byPort);

        //设置互调阶数
        //JIONTCOM_API void FnSetImOrder(BYTE_ byImOrder);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int fnSetImOrder(byte byImOrder);

        //设置tx功率
        //JIONTCOM_API void FnSetTxPower(double dTxPower1, double dTxPower2,
        //                               double dPowerOffset1, double dPowerOffset2);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int fnSetTxPower(double dTxPower1, double dTxPower2,
                                               double dPowerOffset1, double dPowerOffset2);

        //设置tx频率
        //JIONTCOM_API JC_STATUS FnSetTxFreqs(double dCarrierFreq1, double dCarrierFreq2, UNIT_ cUnits);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int fnSetTxFreqs(double dCarrierFreq1, double dCarrierFreq2, string cUnits);

        //tx开启
        //JIONTCOM_API void FnSetTxOn(BOOL_ bOn, BYTE_ byCarrier = 0);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int fnSetTxOn(bool bOn, byte byCarrier = 0);

        //获取互调值
        //JIONTCOM_API void FnGetImResult(JC_RETURN_VALUE dFreq, JC_RETURN_VALUE dPimResult, UNIT_ cUnits);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int fnGetImResult(ref double dFreq, ref double dPimResult, string cUnits);

        //设置同频段同端口的tx1，tx2开关
        //JIONTCOM_API void HwSetCoup(BYTE_ byCoup);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HwSetCoup(byte byCoup);

        //读取tx1、tx2的显示功率
        //JIONTCOM_API double HwGetCoup_Dsp(BYTE_ byCoup);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern double HwGetCoup_Dsp(byte byCoup);

        ////检测功放稳定度(必须功放开启后检测)
        //JC_STATUS HwGetSig_Smooth(JC_RETURN_VALUE dd, BYTE_ byCarrier);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HwGetSig_Smooth(ref double dd, byte byCarrier);

        //设置tx频率(hw版本)
        //JIONTCOM_API JC_STATUS HwSetTxFreqs(double dCarrierFreq1, double dCarrierFreq2, UNIT_ cUnits);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HwSetTxFreqs(double dCarrierFreq1, double dCarrierFreq2, string cUnits);

        //JIONTCOM_API BOOL_ HwGet_Vco();
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FnGet_Vco();

        //JIONTCOM_API BOOL_ HwGet_Vco(double& real_val, double& vco_val)
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HwGet_Vco(ref double real_val, ref double vco_val);

        //poi 设置阶数
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HwSetImOrder(byte byImOrder, byte byImLow, byte byImLess);
        //新增数据库偏移
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JcSetOffsetTxIncremental(byte byInternalBand ,byte byDutPort, byte coup,byte setOrread,double Incremental);

        //poi 
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HwSetImCoefficients(byte byImCo1, byte byImCo2, byte byImLow, byte byImLess);
        //------------------------------------------------函数指针--------------------------------------------------------

        //RX校准过程中的回调委托
        //typedef void(*Callback_Get_RX_Offset_Point)(double offset_freq, double Offset_val);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void Callback_Get_RX_Offset_Point(double offset_freq, double Offset_val);

        //TX校准过程中的回调委托
        //typedef void(*Callback_Get_TX_Offset_Point)(double offset_freq, double Offset_real_val, double Offset_dsp_val);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void Callback_Get_TX_Offset_Point(double offset_freq, double Offset_real_val, double Offset_dsp_val);

        //测试回调委托（测试使用）
        //JC_API void testcb(Callback_Get_RX_Offset_Point pHandler);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testcb(Callback_Get_RX_Offset_Point pHandler);

        //（测试使用）
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gettestval(int a, int b);
        //------------------------------------------------OFFSET API--------------------------------------------------------

        //JC_API long JcGetOffsetRxNum(BYTE_ byInternalBand);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 JcGetOffsetRxNum(byte byInternalBand);
        //JC_API long JcGetOffsetTxNum(BYTE_ byInternalBand);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 JcGetOffsetTxNum(byte byInternalBand);

        //获取rx校准值
        //JC_API JC_STATUS JcGetOffsetRx(JC_RETURN_VALUE offset_val,
        //					             BYTE_ byInternalBand, BYTE_ DutPort,
		//					             double freq_mhz);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JcGetOffsetRx(ref double offset_val,
                                               byte byInternalBand, byte byDutPort,
                                               double freq_mhz);

        //开始rx校准，需很长的时间执行，获取执行状态请回调
        //JC_API JC_STATUS JcSetOffsetRx(byte byInternalBand, BYTE_ DutPort,
        //                               double loss_db, Callback_Get_RX_Offset_Point pHandler);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JcSetOffsetRx(byte MeasBand, byte DutPort,
                                               double loss_db, Callback_Get_RX_Offset_Point pHandler);

        //获取tx校准值
        //JC_API JC_STATUS JcGetOffsetTx(JC_RETURN_D offset_val, 
        //                               byte byInternalBand, BYTE_ DutPort,
        //                               BYTE_ coup, BYTE_ real_or_dsp,
        //                               double freq_mhz, double tx_dbm);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JcGetOffsetTx(ref double offset_val,
                                               byte byInternalBand, byte byDutPort,
                                               byte coup, byte real_or_dsp,
                                               double freq_mhz, double tx_dbm);

        //开始tx校准，需很长的时间执行，获取执行状态请回调
        //JC_API JC_STATUS JcSetOffsetTx(BYTE_ byInternalBand, BYTE_ byDutPort,
        //                               double des_p_dbm, double loss_db, Callback_Get_TX_Offset_Point pHandler);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JcSetOffsetTx(byte byInternalBand, byte byDutPort,
                                               double des_p_dbm, double loss_db, Callback_Get_TX_Offset_Point pHandler);

        //开始tx单步校准（不会保存结果），不建议使用
        //JC_API JC_STATUS JcSetOffsetTx_Single(JC_RETURN_D resulte, JC_RETURN_D resulte_sen,
        //                                      int coup,
        //                                      double des_p_dbm, double des_f_mhz,
        //                                      double loss_db);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JcSetOffsetTx_Single(ref double resulte, ref double resulte_sen,
                                                      int coup,
                                                      double des_p_dbm, double des_f_mhz,
                                                      double loss_db);

        //JC_API JC_STATUS JcGetOffsetVco(JC_RETURN_VALUE offset_vco, BYTE_ byInternalBand, BYTE_ byDutport);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JcGetOffsetVco(ref double offset_vco, byte byInternalBand, byte byDutport);

        //JC_API JC_STATUS JcSetOffsetVco(BYTE_ byInternalBand, BYTE_ byDutport, double val);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JcSetOffsetVco(byte byInternalBand, byte byDutport, double val);

        //配置外部传感器校准(0：不使用外部， 1：使用外部，并设置外部地址）
        //JC_API BOOL_ JcSetOffsetTX_Config(int iAnalyzer, const char* Device_Info);
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool JcSetOffsetTX_Config(int iAnalyzer, string Device_Info);

        //关闭外部传感器
        //JC_API void  JcSetOffsetTX_Config_Close();
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void JcSetOffsetTX_Config_Close();

        /////////////////////////////////////////////////////
        //获取配置文件开关模块的enable
        //int JcGetSwtichEnable(int byInternalBandIndex)
        //[DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool JcGetSwtichEnable(int iBand);

        //获取底层dll版本号
        //int JcGetDllVersion(int &major, int &minor, int &build, int &revision) 
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JcGetDllVersion(ref int major, ref int minor, ref int build, ref int revision);
        //检查同步线
        [DllImport(Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern  int fnCheckTwoSignalROSC();

    }
}
