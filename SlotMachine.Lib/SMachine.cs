namespace SlotMachine.Lib
{
    public abstract class SMachine
    {
        public abstract Symbol[][] Spin();
        public abstract decimal GetWinningCoeficent();
    }
}
