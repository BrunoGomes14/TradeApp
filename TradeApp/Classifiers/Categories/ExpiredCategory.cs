using TradeApp.Classifiers.Categories.Base;
using TradeApp.Models;
using TradeApp.Utils;

namespace TradeApp.Classifiers.Categories;

/// <summary>
/// Represents the expired category.
/// </summary>
public class ExpiredCategory : ITradeCategory
{
    public string Name => Consts.Expired;

    public bool IsMatch(ITrade trade, DateTime referenceDate)
    {
        return trade.NextPaymentDate < referenceDate;
    }
}
