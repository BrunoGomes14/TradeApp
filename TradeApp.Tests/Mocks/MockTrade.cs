using TradeApp.Models;

namespace TradeApp.Tests.Mocks;

public class MockTrade : ITrade
{
    public MockTrade(double value, string clientSector, DateTime nextPaymentDate)
    {
        Value = value;
        ClientSector = clientSector;
        NextPaymentDate = nextPaymentDate;
    }

    public double Value { get; set; }
    public string ClientSector { get; set; }
    public DateTime NextPaymentDate { get; set; }
}