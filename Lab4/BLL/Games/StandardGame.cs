using Lab4.BLL.GameAccounts;
using Lab4.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.Games
{
    public class StandardGame : BaseGame
    {
        private Random rand = new Random();
        public StandardGame(IGameService service) : base(service)
        {

        }

        public override int GetGameRating()
        {
            return Rating;
        }

        public override int GetRatingForPlayer(BaseGameAccount player)
        {
            return Rating;
        }
    }
}
