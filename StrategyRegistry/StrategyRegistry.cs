namespace Bot
{

    class StrategyRegistry
    {
        static List<Type> myList = new List<Type>
        { typeof(NoopStrategy),};

        StrategyRegistry()
        {
        }


        public static async Task RunStrategy(string StrategyType)
        {
            Type? type = Type.GetType(StrategyType);
            _ = type ?? throw new Exception("No strategy type is found");

            IStrategy? strategy = (IStrategy?)Activator.CreateInstance(type);
            _ = strategy ?? throw new Exception("Failed to crate an instance of the strategy");

            await strategy.RunAsync();
        }

        public static List<Type> ListStrategyRegistry()
        {
            return myList;
        }
    }


}