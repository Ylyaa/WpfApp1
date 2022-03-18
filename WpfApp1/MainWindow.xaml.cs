using Integrtals.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;
using WpfApp1.Classes;

namespace WpfApp1
{
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            DoCalculate();
        }
        private void btGraph_Click(object sender, RoutedEventArgs e)
        {
            var pm = new PlotModel()
            {
                Title = "2x - log(2x) +234"
            };
            var lineSeries = new LineSeries();

            int upLim = Convert.ToInt32(UpperLimitEditBox.Text);
            int lowLim = Convert.ToInt32(LowerLimitEditBox.Text);
            ICalculator calcultGraph = new Simpson();

            for (int i = 0; i < 1000; i++)
            {
                double time = 0;
                double result = calcultGraph.Calculate(i, upLim, lowLim, x => (2 * x) - Math.Log(2 * x) + 234, out time);
                lineSeries.Points.Add(new DataPoint(i, time));
            }

            pm.Series.Add(lineSeries);
            Graph.Model = pm;
        }
        private ICalculator GetCalculator()
        {
            return METOD.SelectedIndex switch
            {
                1 => new Trapezi(),
                2 => new Simpson(),
                0 => new Pryamoyg(),
                _ => throw new NotImplementedException(),
            };
        }

        private void DoCalculate()
        {
            int splits = Convert.ToInt32(splitCount.Text);
            int upLim = Convert.ToInt32(UpperLimitEditBox.Text);
            int lowLim = Convert.ToInt32(LowerLimitEditBox.Text);
            double time = 0;

            ICalculator calcult = GetCalculator();
            double result = calcult.Calculate(splits, upLim, lowLim, x => (2 * x) - Math.Log(2 * x) +234, out time);
            MessageBox.Show($"Результат вычислений = {result.ToString()}");
        }


    }
}
