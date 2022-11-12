using Bot.StrategyCatalog;
using System.Text.Json;

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

        public override string StrategyId()
        {
            return typeof(NoopStrategy).ToString();
        }

        public override async Task StrategyLogic(StrategyConfigProvider config)
        {
            for (; ; )
            {
                Console.WriteLine("Run with config: " + JsonSerializer.Serialize(config()));
                await Task.Delay(TimeSpan.FromSeconds(1));
                await RunActionAsync(() => OperationRegistry.PlaceBuyOrder("QQQ", 100.0, 1.0));
            }
        }

    }
}
