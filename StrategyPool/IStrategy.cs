namespace Bot.StrategyPool
{

    interface IStrategy
    {
        Task RunAsync(OperationRunner runner);

        String DisplayName();


        String Description();
    }

}