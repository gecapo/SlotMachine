namespace SlotMachine.Lib
{
    using System;

    internal class SlotMachine : SMachine
    {
        protected readonly ICalculator _slotCalculator = new SlotCalculator();
        protected Symbol[][] _currentSpinResult;

        /// <summary>
        /// Produces random spin result.
        /// </summary>
        /// <returns></returns>
        public override Symbol[][] Spin()
        {
            this._currentSpinResult = NewSpinResult();
            using (var random = new RNGCRandom())
            {
                for (int line = 0; line < _currentSpinResult.Length; line++)
                {
                    for (int reel = 0; reel < _currentSpinResult[line].Length; reel++)
                    {
                        _currentSpinResult[line][reel] = GetSymbol(random.Next());
                    }
                }
            }

            return _currentSpinResult;
        }

        /// <summary>
        /// Gets the winning coeficent of the current spin result
        /// </summary>
        /// <returns></returns>
        public override decimal GetWinningCoeficent() =>
            _slotCalculator.GetWinningCoeficent(_currentSpinResult);

        /// <summary>
        /// Gets symbol depending on the number provided
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private Symbol GetSymbol(int number)
        {
            return number switch
            {
                _ when number <= (int)Symbol.Apple => Symbol.Apple,
                _ when number <= (int)Symbol.Banana => Symbol.Banana,
                _ when number <= (int)Symbol.Pineapple => Symbol.Pineapple,
                _ when number <= (int)Symbol.Wildcard => Symbol.Wildcard,
                _ => throw new ArgumentOutOfRangeException("Couldn't get symbol.")
            };

        }

        /// <summary>
        /// Clears curent spin result
        /// </summary>
        /// <returns></returns>
        private Symbol[][] NewSpinResult()
        {
            var result = new Symbol[Constants.SlotLines][];
            for (int row = 0; row < result.Length; row++)
            {
                result[row] = new Symbol[Constants.SlotReels];
            }

            return result;
        }
    }
}
