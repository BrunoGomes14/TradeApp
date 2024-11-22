using TradeApp.Classifiers.Categories.Base;
using TradeApp.Models;
using TradeApp.Utils;

namespace TradeApp.Classifiers;

/// <summary>
/// Classifies a trade.
/// </summary>
public class TradeClassifier
{
    private readonly DateTime _referenceDate;
    private readonly List<ITradeCategory> _categories = new();

    public TradeClassifier(DateTime referenceDate)
    {
        _referenceDate = referenceDate;
    }

    public void AddCategory(ITradeCategory category)
    {
        _categories.Add(category);
    }

    public string Classify(ITrade trade)
    {
        foreach (var category in _categories)
        {
            if (category.IsMatch(trade, _referenceDate))
            {
                return category.Name;
            }
        }

        return Consts.DefaultRisk; 
    }
}
