
using TradeApp.Classifiers;
using TradeApp.Classifiers.Categories;
using TradeApp.Tests.Mocks;
using TradeApp.Utils;

namespace TradeApp.Tests;

public class TradeClassifierTests
{
    [Fact]
    public void TradeClassifier_ShouldReturnExpired_WhenTradeIsLateByMoreThan30Days()
    {
        // Arrange
        var referenceDate = new DateTime(2020, 12, 11);
        var classifier = new TradeClassifier(referenceDate);
        classifier.AddCategory(new ExpiredCategory());

        var trade = new MockTrade(0, string.Empty, new DateTime(2020, 11, 01));

        // Act
        var result = classifier.Classify(trade);

        // Assert
        Assert.Equal("EXPIRED", result);
    }

    [Fact]
    public void TradeClassifier_ShouldRespectPrecedence()
    {
        // Arrange
        var referenceDate = new DateTime(2020, 12, 11);
        var classifier = new TradeClassifier(referenceDate);
        classifier.AddCategory(new ExpiredCategory());
        classifier.AddCategory(new HighRiskCategory());

        var trade = new MockTrade(2_000_000, Consts.PrivateSector, new DateTime(2020, 11, 01));

        // Act
        var result = classifier.Classify(trade);

        // Assert
        Assert.Equal(Consts.Expired, result); // Expired takes precedence
    }

    [Fact]
    public void TradeClassifier_ShouldReturnUnknown_WhenNoCategoryMatches()
    {
        // Arrange
        var referenceDate = new DateTime(2020, 12, 11);
        var classifier = new TradeClassifier(referenceDate);

        var trade = new MockTrade(500_000, Consts.PublicSector, new DateTime(2020, 11, 01));

        // Act
        var result = classifier.Classify(trade);

        // Assert
        Assert.Equal(Consts.DefaultRisk, result);
    }
}
