using TradeApp.Models;

namespace TradeApp.Classifiers.Categories.Base;

/// <summary>
/// Represents a trade category.
/// </summary>
public interface ITradeCategory
{
    string Name { get; }
    bool IsMatch(ITrade trade, DateTime referenceDate);
}

