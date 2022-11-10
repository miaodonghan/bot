namespace Bot.StrategyCatalog
{

    public class OperationExecutor
    {
        private CancellationToken cancellationToken;

        public OperationExecutor(CancellationToken cancellationToken)
        {
            this.cancellationToken = cancellationToken;
        }


        public async Task RunAsync(Action action)
        {
            await Task.Run(action, cancellationToken);
        }
    }
}