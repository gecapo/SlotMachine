using System;
using SlotMachine.Lib;

namespace SlotMachine.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameEngine();
            game.Start();
        }
    }
}
