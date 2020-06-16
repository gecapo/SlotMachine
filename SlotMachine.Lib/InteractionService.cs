using System;
using System.Threading.Tasks;
using SlotMachine.Lib;

namespace SlotMachine
{
    public class InteractionService : IInteractionService
    {
        /// <summary>
        /// Handle input from console. Should always be number.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public decimal HandleInput(string message)
        {
            decimal number;
            do
            {
                HandleStringOutput(message);
            } while (!decimal.TryParse(Console.ReadLine(), out number));

            return number;
        }

        /// <summary>
        /// Handle string visualization to the console.
        /// </summary>
        /// <param name="options"></param>
        public void HandleStringOutput(string options)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(options);
        }

        /// <summary>
        /// Hanlde the reels visualization to the console.
        /// </summary>
        /// <param name="reels">Symbol Jagged Array to be printed in the console.</param>
        public void HandleReelsOuput(Symbol[][] reels)
        {
            Console.WriteLine();
            foreach (var reel in reels)
            {
                foreach (var symbol in reel)
                {
                    //Delayed for dramatic purposes :D
                    Task.Run(async () =>
                    {
                        await Task.Delay(500);
                        Console.ForegroundColor = symbol.ToColor();
                        Console.Write(symbol.ToSymbolString());
                    }).Wait();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Handle errors visualizations to the console.
        /// </summary>
        /// <param name="message"></param>
        public void HandleError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
        }

        public bool HandleGameOptions(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            var key = Console.ReadKey();

            if (key.Key.Equals(ConsoleKey.Spacebar))
            {
                return true;
            }

            return false;
        }
    }
}
