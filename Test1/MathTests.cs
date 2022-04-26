using System;
using Xunit;
using WpfApp1.Classes;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Integral_X_X_Pryamoug_Success()
        {
            //Arrange
            double upLim = 100.0;
            double downLim = 0.0;
            Func<double, double> integral = x => x * x;
            int count = 100000;
            double time;
            double expected = 333333.3333;
            //Act
            RectCalculator pryamoygolnikCalculate = new RectCalculator();
            double result = pryamoygolnikCalculate.Calculate(count, upLim, downLim, integral, out time);

            //Assert
            Assert.Equal(expected, result, 4);
        }

        [Fact]
        public void Integral_X_X_StepNegative()
        {
            //Arrange
            double upLim = 100.0;
            double downLim = 0.0;
            Func<double, double> func = x => x * x;
            int count = -10000;
            double time;
            //Act
            TrapezoidCalculator trapez = new TrapezoidCalculator();


            //Assert
            Assert.Throws<ArgumentException>(() => trapez.Calculate(count, upLim, downLim, func, out time));
        }
        [Fact]
        public void Integral_X_X_Trapezi_Success()
        {
            //Arrange
            double upLim = 100.0;
            double downLim = 0.0;
            Func<double, double> integral = x => x * x;
            int count = 100000;
            double time;
            double expected = 333333.3333;
            //Act
            TrapezoidCalculator trap = new TrapezoidCalculator();
            double result = trap.Calculate(count, upLim, downLim, integral, out time);

            //Assert
            Assert.Equal(expected, result, 4);
        }
        [Fact]
        public void Integral_X_X_Simps_Success()
        {
            //Arrange
            double upLim = 100.0;
            double downLim = 0.0;
            Func<double, double> integral = x => x * x;
            int count = 100000;
            double time;
            double expected = 333333.3333;
            //Act
            SimpsonCalculator simps = new SimpsonCalculator();
            double result = simps.Calculate(count, upLim, downLim, integral, out time);

            //Assert
            Assert.Equal(expected, result, 4);
        }
        [Fact]
        public void Integral_X_X_Gives_0()
        {
            //Arrange
            double downLim = 0.0;
            double upLim = downLim;
            Func<double, double> integral = x => x * x;
            int count = 100000;
            double time;
            double expected = 0.0;
            //Act
            RectCalculator pryam = new RectCalculator();
            double result = pryam.Calculate(count, upLim, downLim, integral, out time);

            //Assert
            Assert.Equal(expected, result, (int)0.0001);
        }
    }
    }
