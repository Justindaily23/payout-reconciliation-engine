namespace UnitTests;
using PayoutReconciliationEngine.SharedKernel;


public class MoneyTests
{
    [Fact]
    public void Constructor_ShouldStoreKoboAmount()
    {
        // Arrange
        var money = new Money(150075);

        // Assert
        Assert.Equal(150075, money.Kobo);
    }

    [Fact]
    public void Addition_ShouldReturnSumOfKoboAmounts()
    {
        // Arrange
        var left = new Money(100000);
        var right = new Money(50050);

        // Act
        var result = left + right;

        // Assert
        Assert.Equal(150050, result.Kobo);
    }

    [Fact]
    public void Subtraction_ShouldReturnDifferenceOfKoboAmounts()
    {
        // Arrange
        var left = new Money(100000);
        var right = new Money(25000);

        // Act
        var result = left - right;

        // Assert
        Assert.Equal(75000, result.Kobo);
    }

    [Fact]
    public void Addition_ShouldThrowWhenOverflowOccurs()
    {
        // Arrange
        var left = new Money(long.MaxValue);
        var right = new Money(1);

        // Act & Assert
        Assert.Throws<OverflowException>(() => left + right );
    }

    [Fact]
    public void Subtraction_ShouldThrowWhenResultOverflows()
    {
        var left = new Money(long.MinValue);
        var right = new Money(1);

        Assert.Throws<OverflowException>(() => left - right);
    }

    [Fact]
    public void Addition_ShouldHandleMixedSigns()
    {
        // Arrange
        var positive = new Money(100000);
        var negative = new Money(-25000);

        // Act
        var result = positive + negative;

        // Assert
        Assert.Equal(75000, result.Kobo);
    }

    [Fact]
    public void Constructor_ShouldAcceptZeroKobo()
    {
        // Arrange
        var money = new Money(0);

        // Assert
        Assert.Equal(0, money.Kobo);
    }
}
