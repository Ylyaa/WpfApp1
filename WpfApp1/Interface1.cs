using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    interface Interface1
    {
        public double Calculate(int count, int upLn, int downLn, Func <double, double> integral);
    }
}
