namespace SlotMachine.Lib
{
    using System;
    using System.Linq;

    internal class SlotCalculator : ICalculator
    {
        /// <summary>
        /// Determins if a Symbol array (line) has winning values.
        /// </summary>
        /// <param name="line">Symbol array</param>
        /// <returns></returns>
        private bool IsWinningLine(Symbol[] line)
        {
            var uniques = line.Distinct();
            return uniques.Count() == 1 || (uniques.Count() == 2 && uniques.Contains(Symbol.Wildcard));
        }

        /// <summary>
        /// Gets the Sum of the wining lines coeficents
        /// </summary>
        /// <param name="reels">Symbol Jagged Array</param>
        /// <returns></returns>
        public decimal GetWinningCoeficent(Symbol[][] reels)
        {
            return reels.Where(IsWinningLine).SelectMany(x => x).Sum(x => x.ToCoeficent());
        }
    }
}
