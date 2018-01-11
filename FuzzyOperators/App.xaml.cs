using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FuzzyOperators.Models;
using OxyPlot;
using OxyPlot.Series;

namespace FuzzyOperators
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

#if !DEBUG
        App() : base()
        {
            // Splash delay
            System.Threading.Thread.Sleep(2000);
        }
#endif

        public static App GetApp() { return ( (App)Current ); }
        public static MainWindow GetMainWindow() { return ( (MainWindow)GetApp().MainWindow ); }

        public ResultViewModel ResultModel { get; set; } = new ResultViewModel();
        public FuncManager FuncManager { get; set; } = new FuncManager();
        public string FuncChosen { get; set; }

        public void Reset()
        {
            ResultModel = new ResultViewModel();
            FuncManager = new FuncManager();
        }

        public static void InitBasedOnFunc(string funcName)
        {
            if (funcName == "TNormMin")
            {
                App.GetApp().ResultModel.LatexString = @"T-Norm: \; min\left{\mu A(x), \mu B(x)\right}, \forall x \in X ";
                App.GetApp().ResultModel.TrackEnable = false;
                App.GetApp().ResultModel.TrackMin = 0;
                App.GetApp().ResultModel.TrackMax = 1;

            } else if (funcName == "TNormProduct")
            {
                App.GetApp().ResultModel.LatexString = @"T-Norm: \; \mu A(x) \mu B(x), \forall x \in X ";
                App.GetApp().ResultModel.TrackEnable = false;
                App.GetApp().ResultModel.TrackMin = 0;
                App.GetApp().ResultModel.TrackMax = 1;

            } else if (funcName == "TNorm1")
            {
                App.GetApp().ResultModel.LatexString = @"T-Norm: \; \frac{1}{1 + \sqrt[p]{({\frac{1-\mu A(x)}{p})}^p} + ({\frac{1-\mu B(x)}{p})}^p}, for\; p > 0";
                App.GetApp().ResultModel.TrackEnable = true;
                App.GetApp().ResultModel.TrackMin = 0.1;
                App.GetApp().ResultModel.TrackMax = 2.5;


            } else if (funcName == "TNorm2")
            {
                App.GetApp().ResultModel.LatexString = @"T-Norm: \; max\left{0, (1+p)(\mu A(x) + \mu B(x) - 1) - p \mu A(x)\mu B(x) \right},\; for\; p \geq -1";
                App.GetApp().ResultModel.TrackEnable = true;

                App.GetApp().ResultModel.TrackMin = -1;
                App.GetApp().ResultModel.TrackMax = 3;

            } else if (funcName == "TNorm3")
            {
                App.GetApp().ResultModel.LatexString = @"T-Norm: \; \frac{\mu A(x)\mu B(x)}{p + (1-p)(\mu A(x) + \mu B(x) - \mu A(x) \mu B(x))}, for\; p > 0";
                App.GetApp().ResultModel.TrackEnable = true;

                App.GetApp().ResultModel.TrackMin = 0.1;
                App.GetApp().ResultModel.TrackMax = 10;

            } else if (funcName == "TNorm4")
            {
                App.GetApp().ResultModel.LatexString = @"T-Norm: \; \frac{1}{\sqrt[p]{\frac{1}{(\mu A(x))^p} + \frac{1}{(\mu B(x))^p}-1 }}";
                App.GetApp().ResultModel.TrackEnable = true;

                App.GetApp().ResultModel.TrackMin = -0.5;
                App.GetApp().ResultModel.TrackMax = 40;

            } else if (funcName == "TNorm5")
            {
                App.GetApp().ResultModel.LatexString = @"T-Norm: \; \frac{\mu A(x) \mu B(x)}{max \left{\mu A(x) \mu B(x), p\right}}, for\; p \in [0, 1]";
                App.GetApp().ResultModel.TrackEnable = true;

                App.GetApp().ResultModel.TrackMin = 0;
                App.GetApp().ResultModel.TrackMax = 1;

            } else if (funcName == "TNorm6")
            {
                App.GetApp().ResultModel.LatexString = @"T-Norm: \; p \times min\left{\mu A(x), \mu B(x)\right} + (1 - p) \times \frac{1}{2}  (\mu A(x) + \mu B(x)), where\;p \in [0, 1]";
                App.GetApp().ResultModel.TrackEnable = true;
                App.GetApp().ResultModel.TrackMin = 0;
                App.GetApp().ResultModel.TrackMax = 1;

            } else if (funcName == "SNormMax")
            {
                App.GetApp().ResultModel.LatexString = @"max\left{\mu A(x), \mu B(x)\right}, \forall x \in X ";
                App.GetApp().ResultModel.TrackEnable = false;
                App.GetApp().ResultModel.TrackMin = 0;
                App.GetApp().ResultModel.TrackMax = 1;

            } else if (funcName == "SNormSummation")
            {
                App.GetApp().ResultModel.LatexString = @"\mu A(x)+ \mu B(x) - \mu A(x)\mu B(x), \forall x \in X";
                App.GetApp().ResultModel.TrackEnable = false;
                App.GetApp().ResultModel.TrackMin = 0;
                App.GetApp().ResultModel.TrackMax = 1;

            } else if (funcName == "SNorm1")
            {
                App.GetApp().ResultModel.LatexString = @"\frac{1}{1 + \sqrt[p]{({\frac{\mu A(x)}{1-\mu A(x)})}^p} + ({\frac{\mu B(x)}{1-\mu B(x)})}^p}, for\; p > 0";
                App.GetApp().ResultModel.TrackEnable = true;

                App.GetApp().ResultModel.TrackMin = 0.01;
                App.GetApp().ResultModel.TrackMax = 100;


            } else if (funcName == "SNorm2")
            {
                App.GetApp().ResultModel.LatexString = @"min\left{1, \mu A(x) + \mu B(x) + p \mu A(x)\mu B(x) \right},\; for\; p \geq 0";
                App.GetApp().ResultModel.TrackEnable = true;

                App.GetApp().ResultModel.TrackMin = 0;
                App.GetApp().ResultModel.TrackMax = 100;

            } else if (funcName == "SNorm3")
            {
                App.GetApp().ResultModel.LatexString = @"\frac{\mu A(x)+\mu B(x)-\mu A(x)\mu B(x) - (1-p)\mu A(x) \mu B(x)}{1 - (1-p)\mu A(x)\mu B(x)}, for\; p \geq 0";
                App.GetApp().ResultModel.TrackEnable = true;

                App.GetApp().ResultModel.TrackMin = 0;
                App.GetApp().ResultModel.TrackMax = 100;


            } else if (funcName == "SNorm4")
            {
                App.GetApp().ResultModel.LatexString = @"1 - \frac{1}{\sqrt[p]{\frac{1}{(1 - \mu A(x))^p} + \frac{1}{(1 - \mu B(x))^p}-1 }}";
                App.GetApp().ResultModel.TrackEnable = true;

                App.GetApp().ResultModel.TrackMin = 0;
                App.GetApp().ResultModel.TrackMax = 80;


            } else if (funcName == "SNorm5")
            {
                App.GetApp().ResultModel.LatexString = @"1 - \frac{(1 - \mu A(x)) (1 - \mu B(x))}{max \left{(1 - \mu A(x))(1 - \mu B(x)), p\right}}, for\; P \in [0, 1]";
                App.GetApp().ResultModel.TrackEnable = true;

                App.GetApp().ResultModel.TrackMin = 0.01;
                App.GetApp().ResultModel.TrackMax = 1;

            } else if (funcName == "SNorm6")
            {
                App.GetApp().ResultModel.LatexString = @"p \times max\left{\mu A(x), \mu B(x)\right} + (1 - p) \times \frac{1}{2} (\mu A(x) + \mu B(x)), where\;p \in [0, 1]";
                App.GetApp().ResultModel.TrackEnable = true;

                App.GetApp().ResultModel.TrackMin = 0;
                App.GetApp().ResultModel.TrackMax = 1;

            }
        }

        public static Func<double, double> ResultFunc(string funcName)
        {
            var funcManager = App.GetApp().FuncManager;

            var p = App.GetApp().ResultModel.P;

            var func1 = funcManager.Function1;
            var func2 = funcManager.Function2;

            if (funcName == "TNormMin")
            {

                double Func(double x) => Math.Min(func1(x), func2(x));

                return Func;

            } else if (funcName == "TNormProduct")
            {

                double Func(double x) => func1(x) * func2(x);

                return Func;

            } else if (funcName == "TNorm1")
            {

                return NormFunctions.TNorm1;

            } else if (funcName == "TNorm2")
            {

                return  NormFunctions.TNorm2;

            } else if (funcName == "TNorm3")
            {

                return NormFunctions.TNorm3;

            } else if (funcName == "TNorm4")
            {

                return NormFunctions.TNorm4;

            } else if (funcName == "TNorm5")
            {

                return NormFunctions.TNorm5;

            } else if (funcName == "TNorm6")
            {

                return NormFunctions.TNorm6;

            } else if (funcName == "SNormMax")
            {

                double Func(double x) => Math.Max(func1(x), func2(x));

                return Func;

            } else if (funcName == "SNormSummation")
            {

                double Func(double x) => func1(x) + func2(x) - ( func1(x) * func2(x) );

                return Func;

            } else if (funcName == "SNorm1")
            {

                return NormFunctions.SNorm1;


            } else if (funcName == "SNorm2")
            {

                return NormFunctions.SNorm2;

            } else if (funcName == "SNorm3")
            {

                return NormFunctions.SNorm3;

            } else if (funcName == "SNorm4")
            {

                return NormFunctions.SNorm4;

            } else if (funcName == "SNorm5")
            {

                return NormFunctions.SNorm5;

            } else if (funcName == "SNorm6")
            {

                return NormFunctions.SNorm6;

            }

            return null; 
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            // Delay Startup for Splash
            
        }
    }

    public class FuncManager
    {

        public List<string> FuncNames { get; set; } = new List<string>();

        public Func<double, double> Function1 {
            get
            {
                if (FuncNames.Count == 0) return null;
                if(FuncNames.Count >= 1)
                {
                    return TranslateNameToFunc(FuncNames[0]);
                }
                return null;
            }
        }
        public Func<double, double> Function2 {
            get
            {
                if (FuncNames.Count == 0) return null;
                if (FuncNames.Count == 1)
                {
                    return Function1;
                }
                if(FuncNames.Count == 2)
                {
                    return TranslateNameToFunc(FuncNames[1]);
                }
                return null;
            }
        }


        private Func<double, double> TranslateNameToFunc(string name)
        {
            if (name == "Gaussian") return PlotModels.GaussianFunction;
            if (name == "Gaussian Reversed") return PlotModels.GaussianReversedFunction;
            if (name == "Trapezoidal") return PlotModels.TrapezoidalFunction;
            if (name == "Trapezoidal Reversed") return PlotModels.TrapezoidalReversedFunction;
            if (name == "Triangular") return PlotModels.TriangularFunction;
            if (name == "Triangular Reversed") return PlotModels.TriangularReversedFunction;
            if (name == "Logistic") return PlotModels.LogisticFunction;
            if (name == "Logistic Reversed") return PlotModels.LogisticReversedFunction;
            return null;

        }

    }


    public class ResultViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PlotModel _plotModel = new PlotModel();
        private bool trackEnable = true;
        private string _latexString = "";
        private double _p = 0.5;
        private double _trackMin = 0;
        private double _trackMax = 1;


        public PlotModel PlotModel
        {
            get { return _plotModel; }
            set { _plotModel = value; OnPropertyChanged("PlotModel"); }
        }

        public bool TrackEnable
        {
            get { return trackEnable; }
            set { trackEnable = value; OnPropertyChanged("TrackEnable"); }
        }

        public string LatexString
        {
            get { return _latexString; }
            set { _latexString = value; OnPropertyChanged("LatexString"); }

        }

        public double P
        {
            get { return _p; }
            set { _p = value; OnPropertyChanged("P"); }

        }

        public double TrackMin
        {
            get { return _trackMin; }
            set { _trackMin = value; OnPropertyChanged("TrackMin"); }
        }

        public double TrackMax
        {
            get { return _trackMax; }
            set { _trackMax = value; OnPropertyChanged("TrackMax"); }
        }


        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
