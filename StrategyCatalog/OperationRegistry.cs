using System.Threading;

namespace Bot.StrategyCatalog
{
    public sealed class OperationRegistry
    {
        private OperationRegistry() { }

        public class NoopOperation : Operation
        {
            public NoopOperation(CancellationToken cancellationToken) : base(cancellationToken)
            {
            }

            public override string getName()
            {
                return "no-op";
            }
            public override async Task RunAsync()
            {
                await Task.Run(() => Console.WriteLine("no-op"), cancellationToken);
            }
        }


        public class DelayOperation : Operation
        {
            public DelayOperation(CancellationToken cancellationToken) : base(cancellationToken)
            {
            }

            public override string getName()
            {
                return "delay 5s";
            }

            public override async Task RunAsync()
            {
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }
    }
}
