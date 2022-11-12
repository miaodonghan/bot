using System.Runtime.CompilerServices;

namespace Bot.StrategyCatalog
{
    public abstract class Strategy
    {
        private CancellationTokenSource tokenSource;
        private OperationExecutor executor;

        private Task? runningTask;

        public Strategy()
        {
            tokenSource = new CancellationTokenSource();
            executor = new OperationExecutor(tokenSource.Token);
        }

        public abstract String DisplayName();

        public abstract String Description();

        public abstract String StrategyId();

        public abstract Task StrategyLogic(StrategyConfigProvider config);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Task Start(StrategyConfigProvider config)
        {
            if (runningTask != null)
            {
                throw new Exception("Task is already running.");
            }
            runningTask = StrategyLogic(config);
            return runningTask;
        }

        public TaskStatus? GetTaskStatus()
        {
            return runningTask == null
                ? null
                : runningTask.Status;
        }

        public void Stop()
        {
            tokenSource.Cancel();
        }

        protected async Task RunActionAsync(Action action)
        {
            await executor.RunAsync(action);
        }
    }
}
