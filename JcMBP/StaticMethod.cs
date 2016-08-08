using System;
using System.Collections.Generic;
using System.Text;

namespace JcMBP
{
    class StaticMethod
    {
        public static double GetFreq(byte imCo1,byte imCo2,byte imLow,byte imLess,
                                     double  f1,double  f2)
        {
            double last = 0;
            int m = 0;
            int n = 0;
            if (imLow == 1)
            {
                m = imCo2;
                n = imCo1;
            }
            else
            {
                n = imCo2;
                m = imCo1;
            }
            if (imLess == 1)
                last = Math.Abs(m * f1 + n * f2);
            else
                last = Math.Abs(m * f1 - n * f2);
            return last;
        }
    }
}
