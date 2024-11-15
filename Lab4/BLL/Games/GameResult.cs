using Lab4.BLL.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.Games
{
    public class GameResult
    {
        public int Id { get; set; }
        public BaseGameAccount Winner { get; set; }
        public BaseGameAccount Loser { get; set; }
        public int WinnerRatingChange { get; set; }
        public int WinnerRating { get; set; }
        public int LoserRating { get; set; }
        public int LoserRatingChange { get; set; }
        public int Rating { get; set; }
        public GameType Type { get; set; }

        public GameResult() { }
        public GameResult(int id, BaseGameAccount winner, BaseGameAccount loser, int winnerRatingChange, int winnerRating, int loserRating, int loserRatingChange, int rating, GameType type)
        {
            Id = id;
            Winner = winner;
            Loser = loser;
            WinnerRatingChange = winnerRatingChange;
            WinnerRating = winnerRating;
            LoserRating = loserRating;
            LoserRatingChange = loserRatingChange;
            Rating = rating;
            Type = type;
        }
    }
}
