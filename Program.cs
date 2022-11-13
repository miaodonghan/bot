using Bot.StrategyCatalog;
using Bot.StrategyCatalog.Strategies;


internal class Program
{
    private static async Task Main(string[] args)
    {
        SeedConfigs();

        StrategyCatalog.ListStrategyRegistry().ForEach(Console.WriteLine);

        StrategyConfig strategyConfig = StrategyCatalog.GetFirstStrategyConfig();
        Strategy strategy = StrategyCatalog.GetStrategy(strategyConfig.StrategyId!);

        try
        {
            Task task = strategy.Start(StrategyCatalog.GetFirstStrategyConfig);
            await task;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            strategy.RequestCancel();
        }
    }


    private static void SeedConfigs()
    {
        using var db = new StrategyConfigContext();
        Console.WriteLine($"configs path: {db.DbPath}");
        if (db.configs.Count() == 0)
        {
            db.Add(new StrategyConfig()
            {
                AccountId = "testAccount",
                Password = "123",
                StrategyId = typeof(NoopStrategy).FullName
            });
            db.SaveChanges();
        }
    }
}
