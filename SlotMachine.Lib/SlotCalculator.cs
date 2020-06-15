namespace SlotMachine.Lib
{
    using System;
    using System.Linq;

    internal class SlotCalculator
    {
        private bool IsWinningLine(Symbol[] line)
        {
            var uniques = line.Distinct();
            return uniques.Count() == 1 || (uniques.Count() == 2 && uniques.Contains(Symbol.Wildcard));
        }

        internal decimal GetWinningCoeficent(Symbol[][] reels)
        {
            return reels.Where(IsWinningLine).SelectMany(x => x).Sum(x => x.ToCoeficent());
        }
    }
}
