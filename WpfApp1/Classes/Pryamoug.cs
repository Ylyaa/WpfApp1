using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WpfApp1.Classes
{
   public class Pryamoyg : ICalculator
    {
        public double Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
        {
            Stopwatch sw = new Stopwatch();
            double h = (upLim - lowLim) / splitCount;
            double sum = 0.0;

            sw.Start();
            for (int i = 1; i <= splitCount; i++)
            {
                sum += integral(lowLim + h * i - 0.5 * h);
            }

            sw.Stop();
            TimeSpan t = sw.Elapsed;

            time = 0;
            return h * sum;
        }
    }
}
