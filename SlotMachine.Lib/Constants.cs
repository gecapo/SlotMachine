namespace SlotMachine.Lib
{
    internal static class Constants
    {
        public const string AppleSymbol = "A";
        public const decimal AppleCoefficient = 0.4m;
        public const int AppleProbabilityPercent = 45;

        public const string BananaSymbol = "B";
        public const decimal BananaCoefficient = 0.6m;
        public const int BananaProbabilityPercent = 80;

        public const string PineappleSymbol = "P";
        public const decimal PineappleCoefficient = 0.8m;
        public const int PineappleProbabilityPercent = 95;

        public const string WildcardSymbol = "*";
        public const decimal WildcardCoefficient = 0;
        public const int WildcardProbabilityPercent = 100;

        public const int SlotLines = 4;
        public const int SlotReels = 3;
    }
}
