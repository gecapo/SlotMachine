namespace SlotMachine.Lib
{
    public interface IInteractionService
    {
        void HandleReelsOuput(Symbol[][] reels);
        void HandleStringOutput(string options);
        void HandleError(string message);
        bool HandleGameOptions(string message);
        decimal HandleInput(string message);
    }
}
