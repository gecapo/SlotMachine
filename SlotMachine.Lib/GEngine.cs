namespace SlotMachine.Lib
{
    public abstract class GEngine
    {
        protected decimal _balance;
        protected decimal _bet;
        protected SMachine _slotMachine { get; set; }

        protected GEngine() { }

        public abstract decimal Balance { get; protected set; }
        public abstract decimal Bet { get; protected set; }
        public abstract Symbol[][] SpinResult { get; protected set; }

        public abstract void Run();
    }
}
