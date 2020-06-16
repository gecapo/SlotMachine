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
                if (value <= 0)
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
        protected virtual void Initialize()
        {
            var newGame = _interactionService.HandleGameOptions("Press [spacebar] for new game or any other key to exit.");

            if (newGame)
            {
                NewGame();
            }
            else
            {
                Exit();
            }
        }

        /// <summary>
        /// Start a new game
        /// </summary>
        protected virtual void NewGame()
        {
            try
            {
                Balance = _interactionService.HandleInput("Insert money?");
                while (Balance > 0)
                {
                    RunGameCycle();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _interactionService.HandleError(ex.Message);
            }
            finally
            {
                Initialize();
            }
        }


        /// <summary>
        /// Stop the game
        /// </summary>
        protected virtual void Exit()
        {
            _interactionService.HandleStringOutput($"Thank you for playing");
        }

        /// <summary>
        /// Trigger one game cycle
        /// </summary>
        protected virtual void RunGameCycle()
        {
            try
            {
                var newBet = true;
                if (Bet != 0)
                {
                    newBet = _interactionService.HandleGameOptions("Press [spacebar] to use the same bet or any other key to enter new bet.");
                }

                if (newBet)
                {
                    Bet = _interactionService.HandleInput("Enter amout of the bet.");
                }
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
