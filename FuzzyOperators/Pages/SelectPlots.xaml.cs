using FuzzyOperators.Controls;
using FuzzyOperators.Models;
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
    /// Interaction logic for SelectPlots.xaml
    /// </summary>
    public partial class SelectPlots : Page
    {

        HashSet<CheckBox> selectedCheckboxes = new HashSet<CheckBox>();

        PlotModels plotModels = new PlotModels();
        public SelectPlots()
        {
            InitializeComponent();

            tri.FuncName =  "Triangular";
            triRev.FuncName =  "Triangular Reversed";
            trap.FuncName =  "Trapezoidal";
            trapRev.FuncName = "Trapezoidal Reversed";
            guass.FuncName =  "Gaussian";
            guassRev.FuncName =  "Gaussian Reversed";
            log.FuncName = "Logistic";
            logRev.FuncName =  "Logistic Reversed";

            tri.CheckBox.Checked += CheckBox_Checked;
            triRev.CheckBox.Checked += CheckBox_Checked;
            trap.CheckBox.Checked += CheckBox_Checked;
            trapRev.CheckBox.Checked += CheckBox_Checked;
            guass.CheckBox.Checked += CheckBox_Checked;
            guassRev.CheckBox.Checked += CheckBox_Checked;
            log.CheckBox.Checked += CheckBox_Checked;
            logRev.CheckBox.Checked += CheckBox_Checked;

            tri.CheckBox.Unchecked += CheckBox_Unchecked;
            triRev.CheckBox.Unchecked += CheckBox_Unchecked;
            trap.CheckBox.Unchecked += CheckBox_Unchecked;
            trapRev.CheckBox.Unchecked += CheckBox_Unchecked;
            guass.CheckBox.Unchecked += CheckBox_Unchecked;
            guassRev.CheckBox.Unchecked += CheckBox_Unchecked;
            log.CheckBox.Unchecked += CheckBox_Unchecked;
            logRev.CheckBox.Unchecked += CheckBox_Unchecked;

        }

        ViewFuncModels vM = new ViewFuncModels();

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            selectedCheckboxes.Add(checkBox);
            
            if (selectedCheckboxes.Count > 2)
            {
                checkBox.IsChecked = false;
            } else
            {
                var plotFuncName = (string)checkBox.Tag;
                App.GetApp().ResultModel.PlotModel.Series.Add(vM.NameToFuncMapper[plotFuncName]);
                App.GetApp().FuncManager.FuncNames.Add(plotFuncName);
            }


        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            selectedCheckboxes.Remove(checkBox);
            var plotFuncName = (string)checkBox.Tag;
            try
            {
                App.GetApp().ResultModel.PlotModel.Series.Remove(vM.NameToFuncMapper[plotFuncName]);
                App.GetApp().FuncManager.FuncNames.Remove(plotFuncName);

            } catch { }
        }

        private void Tri_Loaded(object sender, RoutedEventArgs e)
        {
            tri.PlotModel = plotModels.SelectionTriangularModel;
        }

        private void TriRev_Loaded(object sender, RoutedEventArgs e)
        {
            triRev.PlotModel = plotModels.SelectionTriangularReversedModel;
        }

        private void Trap_Loaded(object sender, RoutedEventArgs e)
        {
            trap.PlotModel = plotModels.SelectionTrapezoidalModel;
        }

        private void TrapRev_Loaded(object sender, RoutedEventArgs e)
        {
            trapRev.PlotModel = plotModels.SelectionTrapezoidalReversedModel;
        }

        private void Log_Loaded(object sender, RoutedEventArgs e)
        {
            log.PlotModel = plotModels.SelectionLogisticModel;
        }

        private void LogRev_Loaded(object sender, RoutedEventArgs e)
        {
            logRev.PlotModel = plotModels.SelectionLogisticReversedModel;
        }

        private void Guass_Loaded(object sender, RoutedEventArgs e)
        {
            guass.PlotModel = plotModels.SelectionGaussianModel;
        }

        private void GuassRev_Loaded(object sender, RoutedEventArgs e)
        {
            guassRev.PlotModel = plotModels.SelectionGaussianReversedModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.GetApp().FuncManager.FuncNames.Count > 0)
            {
                ( (MainWindow)( App.Current.MainWindow ) ).Frame.Navigate(new SelectOperator());
            } else
            {
                MessageBox.Show("لطفا حداقل یک نمودار را انتخاب کنید");
            }
        }
    }
}
