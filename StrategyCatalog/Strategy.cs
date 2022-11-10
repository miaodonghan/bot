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

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Task Run()
        {
            if (this.runningTask == null)
            {
                this.runningTask = StrategyLogic();
            }
            return this.runningTask;
        }

        public TaskStatus? GetTaskStatus()
        {
            return this.runningTask == null
                ? null
                : this.runningTask.Status;
        }

        public abstract Task StrategyLogic();

        protected async Task RunActionAsync(Action action)
        {
            await executor.RunAsync(action);
        }

        public void Cancel()
        {
            tokenSource.Cancel();
        }
    }
}