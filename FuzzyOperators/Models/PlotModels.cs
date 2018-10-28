
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyOperators.Models
{
    using OxyPlot;
    using OxyPlot.Series;

    public class PlotModels
    {
        public PlotModels()
        {
            SelectionTriangularModel = new PlotModel { IsLegendVisible = false};
            SelectionTrapezoidalModel = new PlotModel { IsLegendVisible = false };
            SelectionLogisticModel = new PlotModel { IsLegendVisible = false };
            SelectionGaussianModel = new PlotModel { IsLegendVisible = false };
            SelectionTriangularReversedModel = new PlotModel { IsLegendVisible = false };
            SelectionTrapezoidalReversedModel = new PlotModel { IsLegendVisible = false };
            SelectionLogisticReversedModel = new PlotModel { IsLegendVisible = false };
            SelectionGaussianReversedModel = new PlotModel { IsLegendVisible = false };

            SelectionTriangularModel.Series.Add(SelectionTriangularFucntionSeries);
            SelectionTrapezoidalModel.Series.Add(SelectionTrapezoidalFunctionSeries);
            SelectionLogisticModel.Series.Add(SelectionLogisticFunctionSeries);
            SelectionGaussianModel.Series.Add(SelectionGaussianFunctionSeries);
            SelectionTriangularReversedModel.Series.Add(SelectionTriangularReversedFucntionSeries);
            SelectionTrapezoidalReversedModel.Series.Add(SelectionTrapezoidalReversedFunctionSeries);
            SelectionLogisticReversedModel.Series.Add(SelectionLogisticReversedFunctionSeries);
            SelectionGaussianReversedModel.Series.Add(SelectionGaussianReversedFunctionSeries);
        }

        // Plot Models
        public PlotModel TriangularModel { get; set; }
        public PlotModel TrapezoidalModel { get; set; }
        public PlotModel LogisticModel { get; set; }
        public PlotModel GaussianModel { get; set; }

        public PlotModel SelectionTriangularModel { get; set; }
        public PlotModel SelectionTrapezoidalModel { get; set; }
        public PlotModel SelectionLogisticModel { get; set; }
        public PlotModel SelectionGaussianModel { get; set; }
        public PlotModel SelectionTriangularReversedModel { get; set; }
        public PlotModel SelectionTrapezoidalReversedModel { get; set; }
        public PlotModel SelectionLogisticReversedModel { get; set; }
        public PlotModel SelectionGaussianReversedModel { get; set; }

        public FunctionSeries SelectionTriangularFucntionSeries { get; set; }
            = new FunctionSeries(TriangularFunction, 0, 40, 0.1);
        public FunctionSeries SelectionTriangularReversedFucntionSeries { get; set; }
            = new FunctionSeries(TriangularReversedFunction, 0, 40, 0.1);

        public FunctionSeries SelectionTrapezoidalFunctionSeries { get; set; }
            = new FunctionSeries(TrapezoidalFunction, 0, 40, 0.1);
        public FunctionSeries SelectionTrapezoidalReversedFunctionSeries { get; set; }
            = new FunctionSeries(TrapezoidalReversedFunction, 0, 40, 0.1);

        public FunctionSeries SelectionLogisticFunctionSeries { get; set; }
            = new FunctionSeries(LogisticFunction, 0, 40, 0.1);
        public FunctionSeries SelectionLogisticReversedFunctionSeries { get; set; }
            = new FunctionSeries(LogisticReversedFunction, 0, 40, 0.1);

        public FunctionSeries SelectionGaussianFunctionSeries { get; set; }
            = new FunctionSeries(GaussianFunction, 0, 40, 0.1);
        public FunctionSeries SelectionGaussianReversedFunctionSeries { get; set; }
            = new FunctionSeries(GaussianReversedFunction, 0, 40, 0.1);

        // Functions
        public static double TriangularFunction(double x)
        {
            if (x >= 10 && x < 20) return ( 0.1 * x ) - 1;
            if (x >= 20 && x < 30) return ( -0.1 * x ) + 3;
            return 0;
        }

        public static double TriangularReversedFunction(double x) => ( TriangularFunction(x) * -1 ) + 1;

        public static double TrapezoidalFunction(double x)
        {
            if (x >= 5 && x < 13) return ( ( 1 / 8f ) * x ) - ( 5 / 8f );
            if (x >= 13 && x < 27) return 1;
            if (x >= 27 && x < 35) return ( ( -1 / 8f ) * x ) + ( 35 / 8f );
            return 0;
        }

        public static double TrapezoidalReversedFunction(double x) => ( TrapezoidalFunction(x) * -1 ) + 1;

        public static double LogisticFunction(double x)
        {
            const float soorat = 1f;
            const float makhrejJomleAval = 1f;
            var makhrejJomleDovom = 100 * ( 1f / Math.Pow(Math.E, x * ( 1 / 4f )) );
            var formula = soorat / ( makhrejJomleAval + makhrejJomleDovom );

            return formula;
        }

        public static double LogisticReversedFunction(double x) => ( LogisticFunction(x) * -1 ) + 1;

        public static double GaussianFunction(double x)
        {
            double e(double j) => j;
            Func<double, double> k = e;

            var formula = Math.Pow(Math.E, ( Math.Pow(x - 20, 2) ) / ( -2f * 36 ));

            return formula;
        }

        public static double GaussianReversedFunction(double x) => ( GaussianFunction(x) * -1 ) + 1;
    }
}

