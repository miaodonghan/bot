// See https://aka.ms/new-console-template for more information
using Bot.StrategyCatalog;

internal class Program
{
    private static async Task Main(string[] args)
    {
        StrategyCatalog.ListStrategyRegistry().ForEach(i => Console.WriteLine(i));

        Strategy strategy = StrategyCatalog.GetStrategy("Bot.StrategyCatalog.Strategies.NoopStrategy");
        
        try
        {
            SeedConfigs();
  
            Task task = strategy.Start(() =>
                {
                    using var db = new StrategyConfigContext();
                    return db.configs.First();
                }
            );
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
            db.Add(new StrategyConfig() { AccountId = "testAccount", Password = "123" });
            db.SaveChanges();
        }
    }
}
