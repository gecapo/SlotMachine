namespace SlotMachine.Lib
{
    using System;
    using System.ComponentModel;

    public static class SymbolExtensions
    {
        public static string ToSymbolString(this Symbol symbol)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])symbol
               .GetType()
               .GetField(symbol.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static decimal ToCoeficent(this Symbol symbol) => symbol switch
        {
            Symbol.Apple => Constants.AppleCoefficient,
            Symbol.Banana => Constants.BananaCoefficient,
            Symbol.Pineapple => Constants.PineappleCoefficient,
            Symbol.Wildcard => Constants.WildcardCoefficient,
            _ => throw new System.Exception("Something went really wrong."),
        };


        public static ConsoleColor ToColor(this Symbol symbol) => symbol switch
        {
            Symbol.Apple => Constants.AppleColor,
            Symbol.Banana => Constants.BananaColor,
            Symbol.Pineapple => Constants.PineappleColor,
            Symbol.Wildcard => Constants.WildcardColor,
            _ => throw new System.Exception("Something went really wrong."),
        };

    }
}
