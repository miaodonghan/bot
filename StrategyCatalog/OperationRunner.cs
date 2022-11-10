namespace Bot.StrategyCatalog
{

    public class OperationRunner
    {
        private CancellationToken cancellationToken;

        public OperationRunner(CancellationToken cancellationToken)
        {
            this.cancellationToken = cancellationToken;
        }


        public async Task RunAsync(Action action)
        {
            await Task.Run(action, cancellationToken);
        }
    }
}