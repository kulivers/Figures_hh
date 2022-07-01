namespace Figures;

public static class AreaCalculator
{
    public static double CircleArea(double radius) => new Circle(radius).Area;
    public static double TriangleArea(params double[] sides) => new Triangle(sides).Area;
}