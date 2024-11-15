using Lab4.BLL.GameAccounts;
using Lab4.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.Games
{
    public class SinglePlayerRatingGame : BaseGame
    {
        private Random rand = new Random();
        private BaseGameAccount RankedPlayer;

        public SinglePlayerRatingGame(IGameService service, BaseGameAccount rankedPlayer) : base(service)
        {
            RankedPlayer = rankedPlayer;
        }

        public override int GetGameRating()
        {
            if (Rating < 0)
            {
                Rating = rand.Next(10, 100);
            }
            return Rating;
        }
        public override int GetRatingForPlayer(BaseGameAccount player)
        {
            if (RankedPlayer == player)
            {
                return GetGameRating();
            }
            return 0;
        }
    }
}
