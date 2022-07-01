using System;
using System.Globalization;
using Xunit;
using Xunit.Abstractions;

namespace Figures.Test;

public class TriangleTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TriangleTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void AreaCalculationInCalculator_Correct()
    {
        Assert.Equal(36.0, AreaCalculator.TriangleArea(3, 4, 5));
    }

    [Fact]
    public void TriangleHasAngle90()
    {
        // Arrange
        var fst = new Triangle(3, 4, 5);
        // Assert
        Assert.True(fst.HasAngle90);
    }

    [Fact]
    public void TriangleHasntAngle90()
    {
        // Arrange
        var fst = new Triangle(3, 5, 6);
        // Assert
        Assert.False(fst.HasAngle90);
    }

    [Fact]
    public void WrongTriangleCreatingThrows_InvalidOperationException()
    {
        // act & assert
        Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 100));
    }

    [Fact]
    public void TooBigValuesInSidesArgumentException()
    {
        // act & assert
        Assert.Throws<ArgumentException>(() => new Triangle(1, Math.Sqrt(double.MaxValue), Math.Sqrt(double.MaxValue)));
    }
}