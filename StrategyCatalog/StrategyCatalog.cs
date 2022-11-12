using Bot.StrategyCatalog.Strategies;

namespace Bot.StrategyCatalog
{
    public class StrategyCatalog
    {
        static List<Type> myList = new List<Type>
        {
            typeof(NoopStrategy), 
            // Add additional strategy implementations.
        };

        StrategyCatalog() { }

        public static Strategy GetStrategy(string StrategyId)
        {
            Type? type = Type.GetType(StrategyId);
            _ = type ?? throw new Exception("No strategy type is found");

            Strategy? strategy = (Strategy?)Activator.CreateInstance(type);
            _ = strategy ?? throw new Exception("Failed to crate an instance of the strategy");

            return strategy;
        }

        public static List<Type> ListStrategyRegistry()
        {
            return myList;
        }
        public static StrategyConfig GetFirstStrategyConfig()
        {
            using var db = new StrategyConfigContext();
            return db.configs.First();
        }
    }
}
