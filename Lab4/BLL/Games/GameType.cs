using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.Games
{
    public enum GameType
    {
        [TypeAttribute<StandardGame>]
        Standard,
        [TypeAttribute<TrainingGame>]
        Training,
        [TypeAttribute<SinglePlayerRatingGame>]
        SinglePlayerRating,
    }
}
