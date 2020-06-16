namespace SlotMachine.Lib
{
    using System;
    using System.Security.Cryptography;

    internal class RNGCRandom : IDisposable
    {
        /// <summary>
        /// Max border of generated number
        /// </summary>
        private const int MAX = Constants.MaxGeneratedNumber;
        /// <summary>
        /// Min border of generated number
        /// </summary>
        private const int MIN = Constants.MinGeneratedNumber;

        /// <summary>
        /// Secure random generator
        /// </summary>
        private readonly RNGCryptoServiceProvider rngc = new RNGCryptoServiceProvider();

        /// <summary>
        /// Get next random integer number betwen 1-100 including.
        /// </summary>
        /// <returns>Integer number betwen 1-100 including.</returns>
        public int Next()
        {
            return (int)Math.Floor(MIN + ((double)MAX - MIN) * NextDouble());
        }

        /// <summary>
        /// Get next random double number.
        /// </summary>
        /// <returns>Random double number.</returns>
        private double NextDouble()
        {
            var data = new byte[sizeof(uint)];
            rngc.GetBytes(data);
            return BitConverter.ToUInt32(data, 0) / (uint.MaxValue + 1.0);
        }

        /// <summary>
        /// Disposes the randomer
        /// </summary>
        public void Dispose()
        {
            rngc?.Dispose();
        }
    }
}
