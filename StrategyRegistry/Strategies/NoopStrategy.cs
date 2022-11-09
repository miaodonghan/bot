
namespace Bot.StrategyRegistry.Strategies
{

    class NoopStrategy : IStrategy
    {
        public string Description()
        {
            return "A sample strategy that does nothing";
        }

        public string DisplayName()
        {
            return "A sample strategy that does nothing";
        }

        public async Task RunAsync(CancellationToken ct)
        {
            await Task.Delay(100);
            await Operations.RunAsync(Operations.WaitMarketOpen, ct);
        }
    }
}