using TradeApp.Classifiers;
using TradeApp.Classifiers.Categories;
using TradeApp.Models;
using TradeApp.Utils;

namespace TradeApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Wecome to TradeApp! You can start typing the input data.");

        try
        {
            Process();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid Input format: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Processes the input data and classifies the trades.
    /// </summary>
    public static void Process()
    {
        // Read Input data
        var (referenceDate, trades) = GetInputData();

        // Set up categories
        var classifier = new TradeClassifier(referenceDate);
        classifier.AddCategory(new ExpiredCategory());
        classifier.AddCategory(new HighRiskCategory());
        classifier.AddCategory(new MediumRiskCategory());

        // Classify and Output Results
        foreach (var trade in trades)
        {
            string category = classifier.Classify(trade);
            Console.WriteLine(category);
        }
    }

    /// <summary>
    /// Reads the input data.
    /// </summary>
    /// <returns>Reference date and trade list.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static (DateTime, List<Trade>) GetInputData()
    {
        var referenceDate = Console.ReadLine().ToEngUSDateTime();
        if (referenceDate == DateTime.MinValue)
            throw new ArgumentException("Invalid reference date.");

        var hasNumberOfTrades = int.TryParse(Console.ReadLine(), out int numberOfTrades);
        if (!hasNumberOfTrades)
            throw new ArgumentException("Invalid number of trades.");

        var trades = new List<Trade>();
        for (int i = 0; i < numberOfTrades; i++)
        {
            var tradeIn = Console.ReadLine();
            if (tradeIn == null || !tradeIn.Contains(" "))
                throw new ArgumentException("Invalid trade input format.");

            string[] input = tradeIn.Split(' ');
            if (input.Length != 3)
                throw new ArgumentException("Invalid trade input format.");

            if (!double.TryParse(input[0], out double value))
                throw new ArgumentException("Invalid trade value.");

            string sector = input[1];
            if (sector != Consts.PublicSector && sector != Consts.PrivateSector)
                throw new ArgumentException("Invalid trade sector.");

            DateTime nextPaymentDate = input[2].ToEngUSDateTime();
            if (nextPaymentDate == DateTime.MinValue)
                throw new ArgumentException("Invalid trade next payment date.");

            trades.Add(new Trade(value, sector, nextPaymentDate));
        }

        return new (referenceDate, trades);
    }

}
