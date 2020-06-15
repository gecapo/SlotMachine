namespace SlotMachine.Lib
{
    public interface IInteractionService
    {
        void VisualiseReels(Symbol[][] reels);

        void VisualiseString(string options);

        decimal ReadDecimal(string message);
    }
}
