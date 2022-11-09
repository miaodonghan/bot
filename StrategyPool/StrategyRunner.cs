using System;

namespace Bot.StrategyPool
{
    public class StrategyRunner
    {
        public StrategyRunner()
        {
        }


        public async Task RunAsync(Strategy strategy) => await strategy.RunAsync();
    }
}

