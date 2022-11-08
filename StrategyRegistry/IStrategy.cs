using Microsoft.Extensions.Localization;

namespace Bot
{

    interface IStrategy
    {
        Task RunAsync();

        String DisplayName();


        String Description();
    }

}