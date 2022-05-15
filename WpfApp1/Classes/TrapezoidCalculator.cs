using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Classes
{
    public class TrapezoidCalculator : ICalculator
    {

        public double Calculate(int splitCount, double lowLim, double upLim, Func<double, double> integral, out double time)
        {
            time = 0;
            double h = (upLim - lowLim) / (double)splitCount; if (splitCount < 0) { throw new ArgumentException("count < 0"); }
            double sum = 0;

            for (int i = 1; i < splitCount; i++)
            {
                sum += integral(lowLim + h * i); 
            }
            sum += (integral(lowLim) + integral(upLim)) / 2;

            return h * sum;
        }
    }
    }
