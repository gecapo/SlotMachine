using System;

namespace SlotMachine.Lib
{
    public class GameEngine
    {
        private decimal _amount;
        private readonly SlotMachine _slotMachine;
        private readonly IInteractionService _interactionService;

        public GameEngine()
        {
            _slotMachine = new SlotMachine();
            _interactionService = new InteractionService();
        }

        public void Start()
        {
            _amount = _interactionService.ReadDecimal("Insert amout?");
            while (_amount > 0)
            {
                var bet = _interactionService.ReadDecimal("Enter bet.");
                _amount -= bet;
                var spinResult = _slotMachine.Spin();
                _interactionService.VisualiseReels(spinResult);
                var winnings = bet * _slotMachine.GetWinningCoeficent();

                _interactionService.VisualiseString($"You win {winnings}");
                _amount += winnings;
                _interactionService.VisualiseString($"New balance is {_amount}");
            }
        }
    }
}
