using AreaCalculationLibrary.Attributes;
using AreaCalculationLibrary.Interfaces;

namespace AreaCalculationLibrary.Models;

/// <summary>
/// Class characterizing the figure - circle.
/// </summary>
[Params(3)]
internal class Triangle : IFigure
{
    double IFigure.AreaCalculate(params double[] values)
    {
        Array.Sort(values);
        if (Math.Pow(values[2], 2) == Math.Pow(values[1], 2) + Math.Pow(values[0], 2))
        {
            return (values[0] * values[1]) / 2;
        }
        else 
        {
            var p = (values[0] + values[1] + values[2]) / 2;
            return Math.Sqrt(p * (p - values[0]) * (p - values[1]) * (p - values[2]));
        }
    }
}
