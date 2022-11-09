namespace Bot
{

    interface IStrategy
    {
        Task RunAsync(CancellationToken ct);

        String DisplayName();


        String Description();
    }

}