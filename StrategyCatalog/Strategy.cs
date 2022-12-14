using System.Runtime.CompilerServices;

namespace Bot.StrategyCatalog
{
    public abstract class Strategy
    {
        protected CancellationTokenSource tokenSource;

        private Task? runningTask;

        public Strategy()
        {
            tokenSource = new CancellationTokenSource();
        }

        public abstract string DisplayName();

        public abstract string Description();

        public abstract string StrategyId();

        public abstract Task StrategyLogic(StrategyConfigProvider config);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Task Start(StrategyConfigProvider config)
        {
            if (runningTask != null)
            {
                throw new Exception("Task is already running.");
            }
            StrategyConfig conf = config();
            if (conf.StrategyId != GetType().FullName)
            {
                throw new InvalidOperationException(
                    string.Format("The strategy id {0} doesn't match config {1}",
                        GetType().FullName, conf.StrategyId!));
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

        public void RequestCancel()
        {
            if (runningTask != null)
            {
                tokenSource.Cancel();
            }
        }
    }
}
