using OxyPlot.Series;
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

namespace FuzzyOperators.Pages
{
    /// <summary>
    /// Interaction logic for ResultView.xaml
    /// </summary>
    public partial class ResultView : Page
    {
        public ResultView()
        {
            InitializeComponent();
            DataContext = App.GetApp().ResultModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.GetApp().Reset();
            App.GetMainWindow().Frame.Navigate(new SelectPlots());
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SlideText.Text = $"(p = {slider.Value})";

            var lastSeries = App.GetApp().ResultModel.PlotModel.Series.Last();

            App.GetApp().ResultModel.PlotModel.Series.Remove(lastSeries);
            App.GetApp().ResultModel.PlotModel.Series.Add(
                new FunctionSeries(App.ResultFunc(App.GetApp().FuncChosen), 0, 40, 0.1, "Result Function")
                );

            MainPlotView.InvalidatePlot(true);


        }
    }
}
