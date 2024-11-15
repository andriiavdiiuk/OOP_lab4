using Lab4.BLL.GameAccounts;
using Lab4.BLL.Games;
using Lab4.BLL.Services;
using Lab4.UI.Input;
using Lab4.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI
{
    public class PlayGame : IControl
    {
        private readonly IInput<List<int>> _gamePlayersInput;
        private readonly IInput<GameType?> _gameTypeInput;
        private readonly IInput<int> _playerWithRating;
        private readonly IInput<int> _gameRatingInput;
        private readonly IGameService _gameService;
        private readonly IGameAccountService _accountService;
        public PlayGame(IGameAccountService gameAccountService ,IGameService gameService) 
        {
            _gameService = gameService;
            _accountService = gameAccountService;
            _gamePlayersInput = new GamePlayersInput();
            _gameTypeInput = new EnumTypeInput<GameType>("Enter game type:");
            _gameRatingInput= new IntInput(-1,"Enter rating:");
            _playerWithRating = new IntInput(-1,"Enter player id to play with rating");
        }
        public void Action()
        {
            Console.Clear();
            _gamePlayersInput.Action();
            _gameTypeInput.Action();
            _gameRatingInput.Action();
            List<int> playerIds = _gamePlayersInput.Result;
            GameType? gameType = _gameTypeInput.Result;
            int rating = _gameRatingInput.Result;

            if (playerIds.Count == 0 || gameType == null || rating < 0) {
                Console.WriteLine("Invalid input");
                return;
            }
            int playerWithRating = -1;
            if (gameType == GameType.SinglePlayerRating) {
                _playerWithRating.Action();
                playerWithRating = _playerWithRating.Result;
            }
            List<int> results = GameManager.PlayGame(playerIds,(GameType)gameType,rating, _accountService, _gameService, playerWithRating);

            IControl showGameResults = new ShowGameResults(_gameService,results);
            showGameResults.Action();

            Console.Clear();
        }
    }
}
