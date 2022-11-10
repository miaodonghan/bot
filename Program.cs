// See https://aka.ms/new-console-template for more information
using Bot.StrategyCatalog;

internal class Program
{
    private static async Task Main(string[] args)
    {
        StrategyRegistry.ListStrategyRegistry().ForEach(i => Console.WriteLine(i));

        Strategy strategy = StrategyRegistry.GetStrategy("Bot.StrategyCatalog.Strategies.NoopStrategy");
        Task task = strategy.RunAsync();
        strategy.Cancel();
        await task;
    }
}
