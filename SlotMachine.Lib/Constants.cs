using System;

namespace SlotMachine.Lib
{
    internal static class Constants
    {
        #region Apple
        /// <summary>
        /// Apple console symbol
        /// </summary>
        public const string AppleSymbol = "A";
        /// <summary>
        /// Apple console color
        /// </summary>
        public const ConsoleColor AppleColor = ConsoleColor.Red;
        /// <summary>
        /// Apple coeficent
        /// </summary>
        public const decimal AppleCoefficient = 0.4m;
        /// <summary>
        /// Apple probability percent
        /// </summary>
        public const int AppleProbabilityPercent = 45;
        /// <summary>
        /// Apple probability border
        /// </summary>
        public const int AppleProbabilityBorder = 45;
        #endregion

        #region Bananan
        /// <summary>
        /// Banana properties
        /// </summary>
        public const string BananaSymbol = "B";
        public const ConsoleColor BananaColor = ConsoleColor.Yellow;
        public const decimal BananaCoefficient = 0.6m;
        public const int BananaProbabilityPercent = 35;
        public const int BananaProbabilityBorder
            = AppleProbabilityBorder + BananaProbabilityPercent;
        #endregion

        #region PineApple
        /// <summary>
        /// Pineapple properties
        /// </summary>
        public const string PineappleSymbol = "P";
        public const ConsoleColor PineappleColor = ConsoleColor.Green;
        public const decimal PineappleCoefficient = 0.8m;
        public const int PineappleProbabilityPercent = 15;
        public const int PineappleProbabilityBorder
            = BananaProbabilityBorder + PineappleProbabilityPercent;
        #endregion

        #region Wildcard
        /// <summary>
        /// Wildcard properties
        /// </summary>
        public const string WildcardSymbol = "*";
        public const ConsoleColor WildcardColor= ConsoleColor.Cyan;
        public const decimal WildcardCoefficient = 0;
        public const int WildcardProbabilityPercent = 15;
        public const int WildcardProbabilityBorder
            = PineappleProbabilityBorder + WildcardProbabilityPercent;
        #endregion

        #region Slot Dimensions
        public const int SlotLines = 4;
        public const int SlotReels = 3;
        #endregion

        #region Generator
        /// <summary>
        /// SlotMachine generator number borders
        /// </summary>
        public const int MinGeneratedNumber = 1;
        public const int MaxGeneratedNumber = 101;
        #endregion
    }
}
