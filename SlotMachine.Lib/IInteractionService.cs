namespace SlotMachine.Lib
{
    internal interface IInteractionService
    {
        void VisualiseReels(Symbol[][] reels);

        void VisualiseString(string options);

        decimal ReadDecimal(string message);
    }
}
