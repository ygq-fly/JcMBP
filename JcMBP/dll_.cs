using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace JcMBP
{



        public class ClsJcPimDll__11
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


            public static  void HwSetBandEnable(int iBand, bool isEnable)
            {
            }


            public static  void HwSetExit()
            {

            }


            public static  bool JcGetVcoDsp(ref double vco, byte bySwitchBand)
            {
                return true;
            }


            public static  void JcGetError(byte[] msg, int max)
            {
            }



            public static  bool JcGetDeviceStatus(byte byDevice)
            {
                return true;
            }


            public static  void JcSetSig(byte byCarrier, double freq_khz, double pow_dbm)
            { }

            public static  bool JcGetSig_ExtRefStatus(byte byCarrier)
            {
                return true;
            }



            public static  int JcSetSig_Advanced(byte byCarrier, byte byBand, byte byPort,
                                                       double freq_khz, double pow_dbm,
                                                       bool isOffet, double dOffset)
            {
                return 0;
            }


            public static  double JcGetSig_CoupDsp(byte byCoup, byte byBand, byte byPort,
                                                         double freq_khz, double pow_dbm, double dExtOffset)
            {
                return 0;
            }


            public static  double JcGetSen()
            {
                return 0;
            }


            public static  double JcGetAna(double freq_khz, bool isMax)
            {
                return 0;
            }


            public static  void JcSetAna_RefLevelOffset(double offset)
            { }


            public static  bool JcSetSwitch(int iSwitchTx1, int iSwitchTx2,
                                                  int iSwitchPim, int iSwitchDet)
            {
                return true;
            }

            //------------------------------------------------扩展 API--------------------------------------------------------


            public static  void HwSetIsExtBand(bool isUse)
            { }


            public static  int HwSetExtFlag(int Build, string Flag)
            {
                return 0;
            }


            public static  int fnSetInit(string cDeviceAddr)
            {
                return 0;
            }


            public static  int fnSetExit()
            {
                return 0;
            }


            public static  int fnSetMeasBand(byte byBandIndex)
            {
                return 0;
            }

            public static  int HwSetMeasBand(byte byTx1Band, byte byTx2Band, byte byRxBand)
            {
                return 0;
            }


            public static  int fnSetImAvg(byte byAvgTime)
            {
                return 0;
            }


            public static  int fnSetDutPort(byte byPort)
            {
                return 0;
            }


            public static  int HwSetDutPort(byte tx1, byte tx2, byte byPort)
            {
                i = 0;
                return 0;
            }


            public static  int fnSetImOrder(byte byImOrder)
            {
                return 0;
            }


            public static  int fnSetTxPower(double dTxPower1, double dTxPower2,
                                                   double dPowerOffset1, double dPowerOffset2)
            {
                return 0;
            }

            public static  int fnSetTxFreqs(double dCarrierFreq1, double dCarrierFreq2, string cUnits)
            {
                return 0;
            }


            public static  int fnSetTxOn(bool bOn, byte byCarrier = 0)
            {
                return 0;
            }

          static   double i = 0;
            public static  int fnGetImResult(ref double dFreq, ref double dPimResult, string cUnits)
            {
                dFreq = 900+i;
                i+=0.1;
                dPimResult = -110;
                Thread.Sleep(100);
                return 0;
            }


            public static  void HwSetCoup(byte byCoup)
            {

            }


            public static  double HwGetCoup_Dsp(byte byCoup)
            {
                return 0;
            }


            public static  int HwGetSig_Smooth(ref double dd, byte byCarrier)
            {
                return 0;
            }


            public static  int HwSetTxFreqs(double dCarrierFreq1, double dCarrierFreq2, string cUnits)
            {
                return 0;
            }


            public static  bool FnGet_Vco()
            {
                return true;
            }


            public static  bool HwGet_Vco(ref double real_val, ref double vco_val)
            {
                return true;
            }


            public static  int HwSetImOrder(byte byImOrder, byte byImLow, byte byImLess)
            {
                return 0;
            }

            public static  int JcSetOffsetTxIncremental(byte byInternalBand, byte byDutPort, byte coup, byte setOrread, double Incremental)
            {
                return 0;
            }


            public static  int HwSetImCoefficients(byte byImCo1, byte byImCo2, byte byImLow, byte byImLess)
            {
                return 0;
            }
            //------------------------------------------------函数指针--------------------------------------------------------


            public delegate void Callback_Get_RX_Offset_Point(double offset_freq, double Offset_val);


            public delegate void Callback_Get_TX_Offset_Point(double offset_freq, double Offset_real_val, double Offset_dsp_val);
            


            public static void testcb(Callback_Get_RX_Offset_Point pHandler)
            {
                
            }


            public static int gettestval(int a, int b) { return 0; }
            //------------------------------------------------OFFSET API--------------------------------------------------------


            public static Int32 JcGetOffsetRxNum(byte byInternalBand) { return 0; }

            public static Int32 JcGetOffsetTxNum(byte byInternalBand) { return 0; }


            public static  int JcGetOffsetRx(ref double offset_val,
                                                   byte byInternalBand, byte byDutPort,
                                                   double freq_mhz) { return 0; }


            public static  int JcSetOffsetRx(byte MeasBand, byte DutPort,
                                                   double loss_db, Callback_Get_RX_Offset_Point pHandler) { return 0; }


            public static  int JcGetOffsetTx(ref double offset_val,
                                                   byte byInternalBand, byte byDutPort,
                                                   byte coup, byte real_or_dsp,
                                                   double freq_mhz, double tx_dbm) { return 0; }


            public static  int JcSetOffsetTx(byte byInternalBand, byte byDutPort,
                                                   double des_p_dbm, double loss_db, Callback_Get_TX_Offset_Point pHandler) { return 0; }


            public static int JcSetOffsetTx_Single(ref double resulte, ref double resulte_sen,
                                                          int coup,
                                                          double des_p_dbm, double des_f_mhz,
                                                          double loss_db) { return 0; }


            public static int JcGetOffsetVco(ref double offset_vco, byte byInternalBand, byte byDutport) { return 0; }


            public static int JcSetOffsetVco(byte byInternalBand, byte byDutport, double val) { return 0; }


            public static bool JcSetOffsetTX_Config(int iAnalyzer, string Device_Info) { return true; }


            public static void JcSetOffsetTX_Config_Close() {  }

           
            public static  int JcGetDllVersion(ref int major, ref int minor, ref int build, ref int revision)
            {
                revision = 400;
                return 0;
            }

            public static  int fnCheckTwoSignalROSC()
            {
                return 0;
            }

        }

    
}
