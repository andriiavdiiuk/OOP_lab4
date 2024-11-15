using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public GameAccountModel Winner { get; set; }
        public GameAccountModel Loser { get; set; }
        public int WinnerRatingChange { get; set; }
        public int WinnerRating { get; set; }
        public int LoserRating { get; set; }
        public int LoserRatingChange { get; set; }
        public int Rating { get; set; }
        public string GameType;
    }
}
