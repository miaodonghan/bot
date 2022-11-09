// See https://aka.ms/new-console-template for more information
using Bot.StrategyPool;

internal class Program
{
    private static async Task Main(string[] args)
    {
        StrategyRegistry.ListStrategyRegistry().ForEach(i => Console.WriteLine(i));

        OperationRunner runner = new OperationRunner();
        Task t = StrategyRegistry.RunStrategy("Bot.StrategyPool.Strategies.NoopStrategy", runner);

        runner.Cancel();
        t.Wait();
    }
}
