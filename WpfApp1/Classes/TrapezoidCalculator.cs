using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WpfApp1.Classes
{
    public class TrapezoidCalculator : ICalculator
    {

        public double Calculate(int splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
        {
            if (splitCount <= 0)
            {
                throw new ArgumentException();
            }
            Stopwatch stopWatch = new Stopwatch();
            
            double h = (upLim - lowLim) / (double)splitCount; 
            double sum = 0;
            stopWatch.Start();
            for (int i = 1; i < splitCount; i++)
            {
                sum += integral(lowLim + h * i); 
            }
            sum += (integral(lowLim) + integral(upLim)) / 2;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            time = ts.TotalMilliseconds;

            return h * sum;
        }
    }
    }