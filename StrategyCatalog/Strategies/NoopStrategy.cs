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

        public override async Task StrategyLogic(StrategyConfig config)
        {
            for (; ; )
            {
                Console.WriteLine("Run with config " + config.ToString());
                await Task.Delay(TimeSpan.FromSeconds(3));
                await RunActionAsync(OperationRegistry.WaitMarketOpen);
            }
        }
    }
}
