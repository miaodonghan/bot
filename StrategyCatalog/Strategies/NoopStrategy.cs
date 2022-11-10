using Bot.StrategyCatalog;

namespace Bot.StrategyCatalog.Strategies
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

        public override async Task StrategyLogic()
        {
            await RunActionAsync(() => Task.Delay(100));
            await RunActionAsync(OperationRegistry.WaitMarketOpen);
        }
    }
}