using TradeApp.Classifiers.Categories.Base;
using TradeApp.Models;
using TradeApp.Utils;

namespace TradeApp.Classifiers.Categories;

/// <summary>
/// Represents the high risk category.
/// </summary>
public class HighRiskCategory : ITradeCategory
{
    public string Name => Consts.HighRisk;

    public bool IsMatch(ITrade trade, DateTime referenceDate)
    {
        return trade.Value > 1_000_000 && trade.ClientSector == Consts.PrivateSector;
    }
}