using AreaCalculationLibrary.Attributes;
using AreaCalculationLibrary.Interfaces;
using System.Reflection;

namespace AreaCalculationLibrary;

public class Area
{
    private readonly Dictionary<int, IFigure> Methods;

    public Area()
    { 
        Methods = new Dictionary<int, IFigure>();
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsDefined(typeof(ParamsAttribute)));
        foreach (var t in types)
        {
            var instance = Activator.CreateInstance(t);
            var attr = Attribute.GetCustomAttribute(t, typeof(ParamsAttribute));
            if (instance != null && attr is ParamsAttribute paramsAttribute)
            {
                Methods.TryAdd(paramsAttribute.CountValue, (IFigure)instance);
            }
        }
    }

    /// <summary>
    /// Calculating the area of ​​a figure without knowing the type of the figure.
    /// </summary>
    /// <param name="values"> The values needed to calculate the area. </param>
    /// <returns> Figure area. </returns>
    /// <exception cref="ArgumentException"> If once of values less than zero. </exception>
    /// <exception cref="ArgumentOutOfRangeException"> No method for set number of parameters. </exception>
    public double Calculate(params double[]  values)
    {
        foreach (var value in values)
        {
            if (value < 0)
            {
                throw new ArgumentException("Passed value is less than zero.");
            }
        }

        var inst = Methods.GetValueOrDefault(values.Length);
        if (inst == null)
        {
            throw new ArgumentOutOfRangeException($"There is no method that takes {values.Length} parameters.");
        }
        
        var result = inst.AreaCalculate(values);
        return Math.Round(result, 3);
    }
}
