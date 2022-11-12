using Bot.StrategyCatalog;
using Bot.StrategyCatalog.Strategies;

internal class Program
{
    private static async Task Main(string[] args)
    {
        SeedConfigs();

        StrategyCatalog.ListStrategyRegistry().ForEach(i => Console.WriteLine(i));

        StrategyConfig strategyConfig = sqliteStrategyConfigProvider();
        Strategy strategy = StrategyCatalog.GetStrategy(strategyConfig.StrategyId!);
        
        try
        {
            Task task = strategy.Start(sqliteStrategyConfigProvider);
            await task;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            strategy.Stop();
        }
    }


    private static void SeedConfigs()
    {
        using var db = new StrategyConfigContext();
        Console.WriteLine($"configs path: {db.DbPath}.");
        if (db.configs.Count() == 0)
        {
            db.Add(new StrategyConfig()
            {
                AccountId = "testAccount",
                Password = "123",
                StrategyId = typeof(NoopStrategy).ToString()
            });
            db.SaveChanges();
        }
    }

    private static StrategyConfig sqliteStrategyConfigProvider()
    {
        using var db = new StrategyConfigContext();
        return db.configs.First();
    }
}
