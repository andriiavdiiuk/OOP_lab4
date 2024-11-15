using Lab4.BLL.Games;
using Lab4.BLL.Services;
using Lab4.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI
{
    class ShowGameResults : IControl
    {
        private readonly IGameService _gameService;
        private readonly List<int> _gameIds;

        public ShowGameResults(IGameService service,List<int> gameIds)
        {
            _gameIds = gameIds;
            _gameService = service;
        }

        public void Action()
        {
            string result = "Results:\n";
            result += "-----------------------------------------------------------------------------------------------------------------------\n";
            result += $"|{"Winner",-12} | {"Loser",-12} | {"Rating",-6} | {"Winner Rating Change",-20} | {"Loser Rating Change",-20} | {"Id",-4} | {"Game Type",-24} |\n";
            result += "-----------------------------------------------------------------------------------------------------------------------\n";
            string winnerRating = "";
            string loserRating = "";
            GameResult game;
            foreach (int id in _gameIds)
            {
                game = _gameService.Get(id);
                winnerRating = $"{game.WinnerRating,-3} ({game.WinnerRatingChange})";
                loserRating = $"{game.LoserRating,-3} ({game.LoserRatingChange})";
                result += $"|{game.Winner.Username,-12} | {game.Loser.Username,-12} | {game.Rating,-6} | {winnerRating,-20} | {loserRating,-20} | {game.Id,-4} | {game.Type,-24} |\n";
            };
            result += "-----------------------------------------------------------------------------------------------------------------------\n";

            Console.WriteLine(result);

            Console.WriteLine("Press Any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
