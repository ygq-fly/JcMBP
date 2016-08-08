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
    public partial class TimesSweep: Form
    {
        ClsUpLoad cul;
        DataSweep ds;
        FreqSweepMid fsm;
        public static JbData[] jd;
        byte imCo1 = 2;
        byte imCo2 = 1;
        byte imLow = 0;
        byte imLess = 0;
        float _rxs;
        float _rxe;
        double f1;
        double f2;
        double f1s;
        double f1e;
        double f2s;
        double f2e;
        float rmax;
        float rmin;
        int Count = 0;
        public TimesSweep(ClsUpLoad cul, FreqSweepMid fsm)
        {
            InitializeComponent();
            this.cul = cul;
            this.fsm = fsm;
        }


    }
}
