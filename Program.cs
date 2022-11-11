// See https://aka.ms/new-console-template for more information
using Bot.StrategyCatalog;

internal class Program
{
    private static async Task Main(string[] args)
    {
        StrategyCatalog.ListStrategyRegistry().ForEach(i => Console.WriteLine(i));

        Strategy strategy = StrategyCatalog.GetStrategy("Bot.StrategyCatalog.Strategies.NoopStrategy");
        try
        {
            Task task = strategy.Start();
            await task;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally {
            strategy.Stop();
        }
    }
}
