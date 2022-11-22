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
            return typeof(NoopStrategy).FullName!;
        }

        public override async Task StrategyLogic(StrategyConfigProvider config)
        {
            for (; ; )
            {
                Console.WriteLine("Run with config: " + JsonSerializer.Serialize(config()));
                
                // Run a cancellable operation with cancellation token.
                await Task.Run(() => Console.WriteLine("no-op"), tokenSource.Token);

                // delays 5s
                await Task.Delay(TimeSpan.FromSeconds(5), tokenSource.Token);
            }
        }

    }
}
