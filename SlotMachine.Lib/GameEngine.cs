using System;

namespace SlotMachine.Lib
{
    public class GameEngine
    {
        private decimal _balance;
        private decimal _bet;
        private readonly SlotMachine _slotMachine;
        private readonly IInteractionService _interactionService;

        public GameEngine(IInteractionService interactionService)
        {
            _slotMachine = new SlotMachine();
            _interactionService = interactionService;
        }

        /// <summary>
        /// Gets The current balance of the player
        /// </summary>
        public decimal Balance
        {
            get => _balance;
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                          $"{nameof(Balance)} must be positive number.");

                _balance = value;
            }
        }

        /// <summary>
        /// Gets the current bet of the player
        /// </summary>
        public decimal Bet
        {
            get => _bet;
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                          $"{nameof(Bet)} must be positive number.");

                if (_balance - value < 0)
                    throw new ArgumentOutOfRangeException(
                          $"{nameof(Bet)} cannot be more than your current Balance.");

                _bet = value;
            }
        }

        /// <summary>
        /// Gets the current Slot Machine spin result.
        /// </summary>
        public Symbol[][] SpinResult { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            try
            {
                Balance = _interactionService.ReadDecimal("Insert money?");
                while (Balance > 0)
                {
                    GameSpin();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _interactionService.VisualiseString(ex.Message);
            }

            _interactionService.VisualiseString($"Game Over");
        }

        /// <summary>
        /// Trigger one game cycle
        /// </summary>
        private void GameSpin()
        {
            try
            {
                Bet = _interactionService.ReadDecimal("Enter bet.");
                Balance -= Bet;

                SpinResult = _slotMachine.Spin();
                _interactionService.VisualiseReels(SpinResult);

                var winnings = Bet * _slotMachine.GetWinningCoeficent();

                Balance += winnings;
                _interactionService.VisualiseString($"You win ${winnings}\nNew balance is ${Balance}\n");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _interactionService.VisualiseString(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            Initialize();
        }
    }
}
