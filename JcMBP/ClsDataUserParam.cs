//
//用户参数类
//（用户所关心的内容）
//（将用户参数转换为运行参数）
//Write By San!
//@JointCom.com
//2014-9-3
//
using System;
using System.Collections.Generic;
using System.Text;

namespace JcMBP
{
    class ClsDataUserParam
    {
        public string addr_sen;
        public string addr_sig1;
        public string addr_sig2;
        public string addr_ana;
        public string addr_sen_ext;
        public string addr_swh;

        public Info_Band Band
        {
            get { return _band; }
            set { _band = value; }
        }
        private Info_Band _band;

        /// <summary>
        /// Mode(Freq/Time)
        /// </summary>
        public PIM_Mode Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        private PIM_Mode _mode;

        /// <summary>
        /// Power_dBm
        /// </summary>
        public float Tx_dBm
        {
            get { return _tx_dbm; }
            set { _tx_dbm = value; }
        }
        private float _tx_dbm;

        /// <summary>
        /// Pim Order(3/5/7/9)
        /// </summary>
        public PIM_Order Order
        {
            get { return _order; }
            set { _order = value; }
        }
        private PIM_Order _order;

        /// <summary>
        /// Unit(dBm/dBc)
        /// </summary>
        public PIM_Unit Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        private PIM_Unit _unit;

        /// <summary>
        /// Directions(High/Low)
        /// </summary>
        public PIM_Directions Dire
        {
            get { return _dire; }
            set { _dire = value; }
        }
        private PIM_Directions _dire;

        /// <summary>
        /// Type(Reflection/Transmission)
        /// </summary>
        public PIM_Type Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private PIM_Type _type;

        /// <summary>
        /// Limit
        /// </summary>
        public float Limit_dBm
        {
            get { return _limit_dBm; }
            set { _limit_dBm = value; }
        }
        private float _limit_dBm;

        /// <summary>
        /// （保留，未使用）是否使用时间计算点数
        /// </summary>
        public bool IsUseTimeCount
        {
            get { return _isUseTimeCount; }
            set { _isUseTimeCount = value; }
        }
        private bool _isUseTimeCount = true;

        FreqParam __FParam;

        TimeParm __TParam;

        public ClsDataUserParam()
        {
        }

        public ClsDataUserParam(Info_Band band)
        {
            this.Band = band;
        }

        /// <summary>
        /// 设置扫频参数
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="step"></param>
        public void SetFreqParam(float f1_start_mhz, float f1_end_mhz,
                                 float f2_start_mhz, float f2_end_mhz,
                                 float step1_mhz, float step2_mhz)
        {
            __FParam.F1_Start_KHz = f1_start_mhz * 1000;
            __FParam.F1_End_KHz = f1_end_mhz * 1000;
            __FParam.F2_Start_KHz = f2_start_mhz * 1000;
            __FParam.F2_End_KHz = f2_end_mhz * 1000;
            __FParam.Step1_KHz = step1_mhz * 1000;
            __FParam.Step2_KHz = step2_mhz * 1000;
        }

        /// <summary>
        /// 设置扫时参数
        /// </summary>
        /// <param name="freq_start"></param>
        /// <param name="freq_end"></param>
        /// <param name="time_seconds"></param>
        /// <param name="count"></param>
        public void SetTimeParam(float f1_mhz, float f2_mhz, int time_seconds)
        {
            __TParam.F1_KHz = f1_mhz * 1000;
            __TParam.F2_KHz = f2_mhz * 1000;
            __TParam.Time_Seconds = time_seconds;
            __TParam.Count = 0;
        }

        //阶数计算公式
        float GetFpim(PIM_Order order, float f1, float f2)
        {
            float results = 0;
            switch (order)
            {
                case PIM_Order.IM3:
                    results = 2 * f1 - f2;
                    break;
                case PIM_Order.IM5:
                    results = 3 * f1 - 2 * f2;
                    break;
                case PIM_Order.IM7:
                    results = 4 * f1 - 3 * f2;
                    break;
                case PIM_Order.IM9:
                    results = 5 * f1 - 4 * f2;
                    break;
            }

            return results;
        }

    }

    struct FreqParam
    {
        public float F1_Start_KHz;
        public float F1_End_KHz;
        public float F2_Start_KHz;
        public float F2_End_KHz;
        public float Step1_KHz;
        public float Step2_KHz;
    }

    struct TimeParm
    {
        public float F1_KHz;
        public float F2_KHz;
        public int Time_Seconds;
        public int Count;
    }
}
