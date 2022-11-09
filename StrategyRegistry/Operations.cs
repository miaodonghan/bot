namespace Bot
{


    public sealed class Operations
    {
        private Operations() { }


        static Action<string, double, double> PlaceBuyOrder = (string symbol, double quantity, double limit) =>
        {
            Console.WriteLine("buy {0} of {1} at {2}", symbol, quantity, limit);
        };
        static Action<string, double, double> PlaceSellOrder = (string symbol, double quantity, double limit) =>
        {
            Console.WriteLine("sell {0} of {1} at {2}", symbol, quantity, limit);
        };

       internal static Action WaitMarketOpen = () => { Console.WriteLine("wait for market open"); };

        static Action<TimeSpan> Delay = (TimeSpan ts) => { Console.WriteLine("delay"); };

    }
}