namespace Figures;

internal class Circle : IFigure
{
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Invalid radius value", nameof(radius));
        if (radius >= Math.Sqrt(double.MaxValue))
            throw new ArgumentException("Too big radius (must be < Math.Sqrt(double.MaxValue))", nameof(radius));
        Radius = radius;
        Area = Math.PI * Radius * Radius;
    }

    public double Radius { get; }
    public double Area { get; }
}