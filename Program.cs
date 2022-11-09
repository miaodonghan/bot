// See https://aka.ms/new-console-template for more information
using Bot;

internal class Program
{
    private static async Task Main(string[] args)
    {
        StrategyRegistry.ListStrategyRegistry().ForEach(i => Console.WriteLine(i));

        CancellationTokenSource ts = new CancellationTokenSource();
        CancellationToken token = ts.Token;

        await StrategyRegistry.RunStrategy("Bot.NoopStrategy", token);

        ts.Cancel();

    }
}
