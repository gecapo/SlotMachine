namespace SlotMachine.Lib
{
    using System.ComponentModel;

    public enum Symbol
    {
        [Description(Constants.AppleSymbol)]
        Apple = Constants.AppleProbabilityPercent,
        [Description(Constants.BananaSymbol)]
        Banana = Constants.BananaProbabilityPercent,
        [Description(Constants.PineappleSymbol)]
        Pineapple = Constants.PineappleProbabilityPercent,
        [Description(Constants.WildcardSymbol)]
        Wildcard = Constants.WildcardProbabilityPercent
    }
}
