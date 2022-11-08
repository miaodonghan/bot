// See https://aka.ms/new-console-template for more information
using Bot;


StrategyRegistry.ListStrategyRegistry().ForEach(i => Console.WriteLine(i));
await StrategyRegistry.RunStrategy("Bot.NoopStrategy");

Console.Read();
