using System;

namespace SlotMachine.Lib
{

    public class GameEngine : GEngine
    {
        protected readonly IInteractionService _interactionService;

        public GameEngine(IInteractionService interactionService)
        {
            this._slotMachine = new SlotMachine();
            _interactionService = interactionService;
        }

        /// <summary>
        /// Gets The current balance of the player
        /// </summary>
        public override decimal Balance
        {
            get => _balance;
            protected set
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
        public override decimal Bet
        {
            get => _bet;
            protected set
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
        public override Symbol[][] SpinResult { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            _interactionService.HandleNewGame();
            try
            {
                Balance = _interactionService.HandleInput("Insert money?");
                while (Balance > 0)
                {
                    HandleSpin();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _interactionService.HandleError(ex.Message);
            }

            _interactionService.HandleStringOutput($"Game Over");
        }

        /// <summary>
        /// Trigger one game cycle
        /// </summary>
        protected override void HandleSpin()
        {
            try
            {
                Bet = _interactionService.HandleInput("Enter bet.");
                Balance -= Bet;

                SpinResult = _slotMachine.Spin();
                _interactionService.HandleReelsOuput(SpinResult);

                var winnings = Bet * _slotMachine.GetWinningCoeficent();

                Balance += winnings;
                _interactionService.HandleStringOutput($"You win ${winnings}\nNew balance is ${Balance}\n");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _interactionService.HandleError(ex.Message);
            }
        }

        /// <summary>
        /// Main point entry of GameEngine
        /// </summary>
        public override void Run()
        {
            Initialize();
        }
    }
}
