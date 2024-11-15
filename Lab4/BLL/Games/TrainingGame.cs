using Lab4.BLL.GameAccounts;
using Lab4.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.Games
{
    public class TrainingGame : BaseGame
    {
        public TrainingGame(IGameService service) : base(service)
        {
        }

        public override int GetGameRating()
        {
            return 0;
        }
        public override int GetRatingForPlayer(BaseGameAccount player)
        {
            return GetGameRating();
        }
    }
}
