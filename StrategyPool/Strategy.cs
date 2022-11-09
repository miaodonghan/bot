namespace Bot.StrategyPool
{

    public abstract class Strategy
    {
        CancellationTokenSource tokenSource;
        OperationRunner runner;

        public Strategy()
        {
            tokenSource = new CancellationTokenSource();
            runner = new OperationRunner(tokenSource.Token);
        }

        public abstract String DisplayName();

        public abstract String Description();

        public abstract Task RunAsync();

        protected async Task RunActionAsync(Action action)
        {
            await runner.RunAsync(action);
        }

        protected void Cancel()
        {
            tokenSource.Cancel();
        }
    }
}