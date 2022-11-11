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

        public abstract Task StrategyLogic(StrategyConfigProvider config);

        // TODO: change to config provider instead of config instance.
        [MethodImpl(MethodImplOptions.Synchronized)]
        public Task Start(StrategyConfigProvider config)
        {
            if (this.runningTask != null)
            {
                throw new Exception("Task is already running.");
            }
            this.runningTask = StrategyLogic(config);
            return this.runningTask;
        }

        public TaskStatus? GetTaskStatus()
        {
            return this.runningTask == null
                ? null
                : this.runningTask.Status;
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
