namespace AreaCalculationLibrary.Interfaces;

/// <summary>
/// Interface characterizing the figures.
/// </summary>
internal interface IFigure
{
    /// <summary>
    /// Calculating figure area.
    /// </summary>
    /// <param name="values"> The values needed to calculate the area. </param>
    /// <returns> Figure area. </returns>
    internal double AreaCalculate(params double[] values);
}
