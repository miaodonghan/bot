namespace Bot.StrategyRegistry
{

    interface IStrategy
    {
        Task RunAsync(CancellationToken ct);

        String DisplayName();


        String Description();
    }

}