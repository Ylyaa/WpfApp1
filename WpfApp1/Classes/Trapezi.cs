using Integrtals.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Classes
{
    internal class Trapezi : ICalculator
    {
    
        public double Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
        {
            int N = (int)((upLim - lowLim) / splitCount);
            double area = 0;
            for (int i = 0; i < N; i++)
            {
                double currentX = lowLim + splitCount * i;
                area += CalculateFunction(currentX);
            }
            area += (CalculateFunction(lowLim) + CalculateFunction(upLim)) / 2;
            time = 0;
            return splitCount * area;
        }

        public double CalculateFunction(double x)
        {
            return 2 * x - Math.Log(2 * x) + 234;
        }
    }
}