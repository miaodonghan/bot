using Bot.StrategyPool;

namespace Bot.StrategyPool.Strategies
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

        public async Task RunAsync(OperationRunner runner)
        {
            await runner.RunAsync(()=> Task.Delay(100));
            await runner.RunAsync(OperationRegistry.WaitMarketOpen);
        }
    }
}