using System.Globalization;

namespace TradeApp.Utils;

/// <summary>
/// Aggregate of extension methods.
/// </summary>
public static class Extensions
{
    public static DateTime ToEngUSDateTime(this string? date)
    {
        if (date == null)
            return DateTime.MinValue;

        return DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        
    }   
}
