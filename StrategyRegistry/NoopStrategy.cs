namespace Bot
{

    class NoopStrategy : IStrategy
    {
        public string Description()
        {
            return "A sample strategy that does nothing";
        }

        public string DisplayName()
        {
            return "A sample strategy that does nothing";
        }

        public async Task RunAsync()
        {
            await Task.Run(() => Console.WriteLine("This strategy does nothing"));
        }
    }
}