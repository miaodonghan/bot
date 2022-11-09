namespace Bot.StrategyPool
{

    public class OperationRunner
    {
        private CancellationTokenSource cancellationTokenSource;
        public OperationRunner()
        {
            this.cancellationTokenSource = new CancellationTokenSource();
        }


       public async Task RunAsync(Action action)
        {
            await Task.Run(action, cancellationTokenSource.Token);
        }

       public async void Cancel()
        {
            cancellationTokenSource.Cancel();
        }
    }
}