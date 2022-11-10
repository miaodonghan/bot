using Bot.StrategyCatalog.Strategies;

namespace Bot.StrategyCatalog
{
    internal class StrategyRegistry
    {
        static List<Type> myList = new List<Type> { typeof(Bot.StrategyCatalog.Strategies.NoopStrategy), };

        StrategyRegistry()
        {
        }


        public static Strategy GetStrategy(string StrategyType)
        {
            Type? type = Type.GetType(StrategyType);
            _ = type ?? throw new Exception("No strategy type is found");

            Strategy? strategy = (Strategy?)Activator.CreateInstance(type);
            _ = strategy ?? throw new Exception("Failed to crate an instance of the strategy");

            return strategy;
        }

        public static List<Type> ListStrategyRegistry()
        {
            return myList;
        }
    }
}
