using System;
using Microsoft.Extensions.DependencyInjection;
using SlotMachine.Lib;

namespace SlotMachine.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Idea is that by simply changing the InteractionService we can change the UI of the game

            var serviceProvider = new ServiceCollection()
                .AddTransient<GameEngine>()
                .AddSingleton<IInteractionService, InteractionService>()
                .BuildServiceProvider();

            serviceProvider.GetService<GameEngine>().Run();
        }

    }
}
