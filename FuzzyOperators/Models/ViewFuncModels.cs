using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyOperators.Models
{
    public class ViewFuncModels
    {
        public Dictionary<string, FunctionSeries> NameToFuncMapper { get; set; }
            = new Dictionary<string, FunctionSeries>()
            {
                ["Triangular"] =  new FunctionSeries(PlotModels.TriangularFunction, 0, 40, 0.1, "Triangular"),
                ["Triangular Reversed"] =  new FunctionSeries(PlotModels.TriangularReversedFunction, 0, 40, 0.1, "Triangular Reversed"),
                ["Trapezoidal"] =  new FunctionSeries(PlotModels.TrapezoidalFunction, 0, 40, 0.1, "Trapezoidal"),
                ["Trapezoidal Reversed"] =  new FunctionSeries(PlotModels.TrapezoidalReversedFunction, 0, 40, 0.1, "Trapezoidal Reversed"),
                ["Gaussian"] =  new FunctionSeries(PlotModels.GaussianFunction, 0, 40, 0.1, "Gaussian"),
                ["Gaussian Reversed"] =  new FunctionSeries(PlotModels.GaussianReversedFunction, 0, 40, 0.1, "Gaussian Reversed"),
                ["Logistic"] =  new FunctionSeries(PlotModels.LogisticFunction, 0, 40, 0.1, "Logistic"),
                ["Logistic Reversed"] =  new FunctionSeries(PlotModels.LogisticReversedFunction, 0, 40, 0.1, "Logistic Reversed")
            };
    }
}
