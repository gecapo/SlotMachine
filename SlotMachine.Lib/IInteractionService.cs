namespace SlotMachine.Lib
{
    public interface IInteractionService
    {
        void HandleReelsOuput(Symbol[][] reels);
        void HandleStringOutput(string options);
        void HandleError(string message);
        int HandleNewGame();
        int HandleGameCycle();
        decimal HandleInput(string message);
    }
}
