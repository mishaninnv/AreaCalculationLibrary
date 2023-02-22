using AreaCalculationLibrary.Attributes;
using AreaCalculationLibrary.Interfaces;

namespace AreaCalculationLibrary.Models;

/// <summary>
/// Class characterizing the figure - circle.
/// </summary>
[Params(1)]
internal class Circle : IFigure
{
    double IFigure.AreaCalculate(params double[] values) => Math.PI * Math.Pow(values[0], 2);
}
