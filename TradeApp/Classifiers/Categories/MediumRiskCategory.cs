using TradeApp.Classifiers.Categories.Base;
using TradeApp.Models;
using TradeApp.Utils;

namespace TradeApp.Classifiers.Categories;

/// <summary>
/// Represents the medium risk category.
/// </summary>
public class MediumRiskCategory : ITradeCategory
{
    public string Name => Consts.MediumRisk;

    public bool IsMatch(ITrade trade, DateTime referenceDate)
    {
        return trade.Value > 1_000_000 && trade.ClientSector == Consts.PublicSector;
    }
}