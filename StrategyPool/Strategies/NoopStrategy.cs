using Bot.StrategyPool;

namespace Bot.StrategyPool.Strategies
{

    class NoopStrategy : Strategy
    {
        public override string Description()
        {
            return "A sample strategy that does nothing";
        }

        public override string DisplayName()
        {
            return "A sample strategy that does nothing";
        }

        public override async Task RunAsync()
        {
            await RunActionAsync(()=> Task.Delay(100));
            await RunActionAsync(OperationRegistry.WaitMarketOpen);
        }
    }
}