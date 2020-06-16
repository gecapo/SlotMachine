namespace SlotMachine.Lib
{
    using System;
    using System.ComponentModel;

    public static class SymbolExtensions
    {
        /// <summary>
        /// Gets the symbol console representation
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static string ToSymbolString(this Symbol symbol) =>
            ((DescriptionAttribute[])symbol
               .GetType()
               .GetField(symbol.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false)
            )[0].Description;

        /// <summary>
        /// Gets the coeficent of a given symbol
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static decimal ToCoeficent(this Symbol symbol) => symbol switch
        {
            Symbol.Apple => Constants.AppleCoefficient,
            Symbol.Banana => Constants.BananaCoefficient,
            Symbol.Pineapple => Constants.PineappleCoefficient,
            Symbol.Wildcard => Constants.WildcardCoefficient,
            _ => throw new System.Exception("Something went really wrong."),
        };

        /// <summary>
        /// Gets the console color of the current symbol.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
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
