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
    /// Interaction logic for SelectOperator.xaml
    /// </summary>
    public partial class SelectOperator : Page
    {
        public SelectOperator()
        {
            InitializeComponent();
        }

        public Func<double, double> ResultFunc { get; set; }
        private string funcChosen = "";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.GetApp().FuncChosen = funcChosen;
            App.InitBasedOnFunc(funcChosen);
            App.GetApp().ResultModel.PlotModel.Series.Add(new FunctionSeries(ResultFunc, 0, 40, 0.1, "Result Function"));
            App.GetMainWindow().Frame.Navigate(new ResultView());
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radio = (RadioButton)sender;
            string tagData = (string)(radio.Tag) ?? "TNormMin";

            funcChosen = tagData;
            ResultFunc = App.ResultFunc(tagData);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            defaultCheck.IsChecked = true;
        }
    }
}
