namespace Figures;

internal class Triangle : IFigure
{
    public Triangle(params double[] sides)
    {
        if (sides.Length != 3)
            throw new ArgumentException("Triangle must have three sides", nameof(sides));

        if (sides.Select(side => side >= Math.Sqrt(double.MaxValue)).Count(x=>x==true)>1)
            throw new ArgumentException("Too big values in sides", nameof(sides));
        
        Sides = sides;
        var perimeter = Sides.Aggregate((sum, x) => sum + x);

        if (!IsValid(sides, perimeter))
            throw new ArgumentException("Triangle cant exist with that sides");

        Perimeter = perimeter;
        HasAngle90 = Sides.Select((x, i) => IsHypotenuse(i)).Any(x => x);
    }

    public double[] Sides { get; }
    public bool HasAngle90 { get; }

    private bool IsHypotenuse(int sideIndex)
    {
        var cathetSquareSum = Sides
            .Where((x, i) => i != sideIndex)
            .Aggregate(0.0, (sum, x) => sum + x * x);

        return Math.Abs(Sides[sideIndex] * Sides[sideIndex] - cathetSquareSum) < double.Epsilon;
    }

    private static bool IsValid(double[] sides, double perimeter)
    {
        if (sides.Any(x => x <= 0))
            return false;

        return !sides.Any(x => x + x >= perimeter);
    }

    private double Perimeter { get; }

    public double Area
    {
        get
        {
            var semiPerimeter = Perimeter / 2;
            return Sides.Aggregate(semiPerimeter, (x, side) => x * (semiPerimeter - side));
        }
    }
}