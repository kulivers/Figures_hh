using System;
using System.Linq;
using Xunit;

namespace Figures.Test;

public class CircleTests
{
    [Fact]
    public void FigureAreaCalculation_Correct()
    {
        var figures = new IFigure[] { new Circle(5), new Triangle(3, 4, 5) };
        var sum = figures.Sum(f => f.Area);

        Assert.Equal(114.53981633974483, sum);
    }
    
    [Fact]
    public void AreaCalculation_Correct()
    {
        var circle = new Circle(5);
        Assert.Equal(78.53981633974483, circle.Area);
    }

    [Fact]
    public void AreaCalculationInCalculator_Correct()
    {
        Assert.Equal(78.53981633974483, AreaCalculator.CircleArea(5));
    }
    
    [Fact]
    public void LowerZeroRadius_Exception()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Circle(-2));
    }
}