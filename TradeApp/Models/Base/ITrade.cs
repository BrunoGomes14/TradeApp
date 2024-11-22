namespace TradeApp.Models;

/// <summary>
/// Representens trade rules and properties.
/// </summary>
public interface ITrade
{
    double Value { get; }
    string ClientSector { get; }
    DateTime NextPaymentDate { get; }

}