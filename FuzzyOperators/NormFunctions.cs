using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace FuzzyOperators
{
    public static class NormFunctions
    {
        public static double TNorm1(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return 1d / Pow(1d + Pow((Pow((1d - f1(x)) / p ,p)) + ( Pow(( 1 - f2(x) ) / p, p)), p), 1d / p);
        }

        public static double TNorm2(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return Max(0, ( 1 + p ) * ( f1(x) + f2(x) - 1 ) - ( p * f1(x) * f2(x) ));
        }

        public static double TNorm3(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return ( f1(x) * f2(x) ) / (p + (1 - p) * (f1(x) + f2(x) - (f1(x) * f2(x))));
        }

        public static double TNorm4(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return 1d / Pow((1d / (Pow(f1(x), p))) + (1d / (Pow(f2(x), p))) - 1 , 1d/p);
        }

        public static double TNorm5(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return ( f1(x) * f2(x) ) / Max(f1(x) * f2(x), p);
        }

        public static double TNorm6(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return p * Min(f1(x), f2(x)) + (1-p) * ((1d/2d) * (f1(x) + f2(x)));
        }

        public static double SNorm1(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return 1d / (1 + (Pow((Pow(f1(x) / (1 - f1(x)) ,p)) + (Pow(f2(x)/(1 - f2(x)) , p)) , 1d / p)));
        }

        public static double SNorm2(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return Min(1, f1(x) + f2(x) + (p * f1(x) + f2(x)));
        }

        public static double SNorm3(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return (f1(x) + f2(x) - (f1(x) * f2(x)) - ((1d - p) * (f1(x) * f2(x)))  ) / (1d - ((1d - p) * f1(x) * f2(x)));
        }

        public static double SNorm4(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return 1d - ((1d) / (Pow((1d / (Pow((1d - f1(x)) ,p))) + (1d / (Pow(1d - f2(x) ,p))) - 1d, 1d / p)));
        }

        public static double SNorm5(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return 1d - (( (1d - f1(x)) * (1d - f2(x))) / (Max((1d - f1(x)) * (1d - f2(x)), p)));
        }

        public static double SNorm6(double x)
        {
            var funcManager = App.GetApp().FuncManager;
            var f1 = funcManager.Function1;
            var f2 = funcManager.Function2;
            var p = App.GetApp().ResultModel.P;

            return p * Max(f1(x), f2(x)) + ((1-p) * (1d/2d) * (f1(x) + f2(x)));
        }
    }
}
