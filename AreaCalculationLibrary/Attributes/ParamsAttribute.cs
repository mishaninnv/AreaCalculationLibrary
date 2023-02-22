namespace AreaCalculationLibrary.Attributes;

[AttributeUsage(AttributeTargets.Class)]
internal class ParamsAttribute : Attribute
{
    /// <summary>
    /// The number of sides to calculate the area of ​​a figure.
    /// </summary>
    internal int CountValue { get; private set; }

    /// <summary>
    /// This attribute that marks figures.
    /// </summary>
    /// <param name="countValue"> The number of sides to calculate the area of ​​a figure. </param>
    internal ParamsAttribute(int countValue)
    {
        CountValue = countValue;
    }
}
