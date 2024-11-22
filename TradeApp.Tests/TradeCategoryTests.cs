using TradeApp.Classifiers.Categories;
using TradeApp.Tests.Mocks;
using TradeApp.Utils;

namespace TradeApp.Tests.Tests;

public class TradeCategoryTests
{
    [Fact]
    public void ExpiredCategory_ShouldMatch_IfPaymentDateIsLateByMoreThan30Days()
    {
        // Arrange
        var category = new ExpiredCategory();
        var referenceDate = new DateTime(2020, 12, 11);
        var trade = new MockTrade(0, string.Empty, new DateTime(2020, 11, 01));

        // Act
        var result = category.IsMatch(trade, referenceDate);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HighRiskCategory_ShouldMatch_IfValueGreaterThan1MAndPrivateSector()
    {
        // Arrange
        var category = new HighRiskCategory();
        var trade = new MockTrade(2_000_000, Consts.PrivateSector, DateTime.MinValue);

        // Act
        var result = category.IsMatch(trade, DateTime.Now);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void MediumRiskCategory_ShouldMatch_IfValueGreaterThan1MAndPublicSector()
    {
        // Arrange
        var category = new MediumRiskCategory();
        var trade = new MockTrade(1_500_000, Consts.PublicSector, DateTime.MinValue);

        // Act
        var result = category.IsMatch(trade, DateTime.Now);

        // Assert
        Assert.True(result);
    }
}