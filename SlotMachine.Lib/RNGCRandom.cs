namespace SlotMachine.Lib
{
    using System;
    using System.Security.Cryptography;

    internal class RNGCRandom : IDisposable
    {
        private const int MAX = 101;
        private const int MIN = 1;

        private readonly RNGCryptoServiceProvider rngc = new RNGCryptoServiceProvider();

        public int Next()
        {
            return (int)Math.Floor(MIN + ((double)MAX - MIN) * NextDouble());
        }

        private double NextDouble()
        {
            var data = new byte[sizeof(uint)];
            rngc.GetBytes(data);
            return BitConverter.ToUInt32(data, 0) / (uint.MaxValue + 1.0);
        }


        public void Dispose()
        {
            rngc?.Dispose();
        }
    }
}
