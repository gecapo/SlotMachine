using System;
using System.Threading.Tasks;

namespace SlotMachine.Lib
{
    internal class InteractionService : IInteractionService
    {
        public decimal ReadDecimal(string message)
        {
            decimal number;
            do
            {
                VisualiseString(message);
            } while (!decimal.TryParse(Console.ReadLine(), out number));

            return number;
        }

        public void VisualiseString(string options)
        {
            Console.WriteLine(options);
        }

        /// <summary>
        /// Prints the reels to the console.
        /// </summary>
        /// <param name="reels">Symbol Jagged Array to be printed in the console.</param>
        public void VisualiseReels(Symbol[][] reels)
        {
            Console.WriteLine();
            foreach (var reel in reels)
            {
                foreach (var symbol in reel)
                {
                    //Delayed for dramatic purposes :D
                    Task.Run(async () =>
                    {
                        await Task.Delay(1000);
                        Console.Write(symbol.ToSymbolString());
                    }).Wait();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
