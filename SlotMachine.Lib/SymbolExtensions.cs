namespace SlotMachine.Lib
{
    using System.ComponentModel;

    internal static class SymbolExtensions
    {
        internal static string ToSymbolString(this Symbol symbol)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])symbol
               .GetType()
               .GetField(symbol.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        internal static decimal ToCoeficent(this Symbol symbol) => symbol switch
        {
            Symbol.Apple => Constants.AppleCoefficient,
            Symbol.Banana => Constants.BananaCoefficient,
            Symbol.Pineapple => Constants.PineappleCoefficient,
            Symbol.Wildcard => Constants.WildcardCoefficient,
            _ => throw new System.Exception("Something went really wrong."),
        };

    }
}
