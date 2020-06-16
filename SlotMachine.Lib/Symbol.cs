namespace SlotMachine.Lib
{
    using System.ComponentModel;

    public enum Symbol
    {
        [Description(Constants.AppleSymbol)]
        Apple = Constants.AppleProbabilityBorder,
        [Description(Constants.BananaSymbol)]
        Banana = Constants.BananaProbabilityBorder,
        [Description(Constants.PineappleSymbol)]
        Pineapple = Constants.PineappleProbabilityBorder,
        [Description(Constants.WildcardSymbol)]
        Wildcard = Constants.WildcardProbabilityBorder
    }
}
