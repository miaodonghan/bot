// See https://aka.ms/new-console-template for more information
using Bot.StrategyRegistry;

internal class Program
{
    private static async Task Main(string[] args)
    {
        StrategyRegistry.ListStrategyRegistry().ForEach(i => Console.WriteLine(i));

        CancellationTokenSource ts = new CancellationTokenSource();

        Task t = StrategyRegistry.RunStrategy("Bot.StrategyRegistry.Strategies.NoopStrategy", ts.Token);

        ts.Cancel();
        t.Wait();
    }
}
