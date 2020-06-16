using System;

namespace SlotMachine.Lib
{
    internal static class Constants
    {
        /// <summary>
        /// Apple properties
        /// </summary>
        public const string AppleSymbol = "A";
        public const ConsoleColor AppleColor = ConsoleColor.Red;
        public const decimal AppleCoefficient = 0.4m;
        public const int AppleProbabilityPercent = 45;
        public const int AppleProbabilityBorder = 45;

        public const string BananaSymbol = "B";
        public const ConsoleColor BananaColor = ConsoleColor.Yellow;
        public const decimal BananaCoefficient = 0.6m;
        public const int BananaProbabilityPercent = 35;
        public const int BananaProbabilityBorder
            = AppleProbabilityBorder + BananaProbabilityPercent;

        public const string PineappleSymbol = "P";
        public const ConsoleColor PineappleColor = ConsoleColor.Green;
        public const decimal PineappleCoefficient = 0.8m;
        public const int PineappleProbabilityPercent = 15;
        public const int PineappleProbabilityBorder
            = BananaProbabilityBorder + PineappleProbabilityPercent;

        public const string WildcardSymbol = "*";
        public const ConsoleColor WildcardColor= ConsoleColor.Cyan;
        public const decimal WildcardCoefficient = 0;
        public const int WildcardProbabilityPercent = 15;
        public const int WildcardProbabilityBorder
            = PineappleProbabilityBorder + WildcardProbabilityPercent;

        public const int SlotLines = 4;
        public const int SlotReels = 3;

        public const int MinGeneratedNumber = 1;
        public const int MaxGeneratedNumber = 101;
    }
}
