// See https://aka.ms/new-console-template for more information
using Bot.StrategyPool;

internal class Program
{
    private static async Task Main(string[] args)
    {
        StrategyRegistry.ListStrategyRegistry().ForEach(i => Console.WriteLine(i));

        CancellationTokenSource tokenSource = new CancellationTokenSource();
        await StrategyRegistry.RunStrategy("Bot.StrategyPool.Strategies.NoopStrategy");
    }
}
