using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    interface ICalculator
    {
      public double Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time);

    }
}
