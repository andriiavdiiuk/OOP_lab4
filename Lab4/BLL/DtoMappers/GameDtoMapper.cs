using Lab4.BLL.GameAccounts;
using Lab4.BLL.Games;
using Lab4.BLL.Services;
using Lab4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.DtoMappers
{
    public class GameDtoMapper : IDtoMapper<GameModel, GameResult>
    {
        private IDtoMapper<GameAccountModel, BaseGameAccount> _mapper;
        public GameDtoMapper(IDtoMapper<GameAccountModel, BaseGameAccount> mapper)
        {
            _mapper = mapper;
        }
        public GameModel ToModel(GameResult game)
        {
            return new GameModel()
            {
                Id = game.Id,
                Winner = _mapper.ToModel(game.Winner),
                Loser = _mapper.ToModel(game.Loser),
                WinnerRatingChange = game.WinnerRatingChange,
                WinnerRating = game.WinnerRating,
                LoserRatingChange = game.LoserRatingChange,
                LoserRating = game.LoserRating,
                Rating = game.Rating,
                GameType = game.Type.ToString(),
            };
        }

        public GameResult FromModel(GameModel gameModel)
        {
            return new GameResult()
            {
                Id = gameModel.Id,
                Winner = _mapper.FromModel(gameModel.Winner),
                Loser = _mapper.FromModel(gameModel.Loser),
                WinnerRatingChange = gameModel.WinnerRatingChange,
                WinnerRating = gameModel.WinnerRating,
                LoserRatingChange = gameModel.LoserRatingChange,
                LoserRating = gameModel.LoserRating,
                Rating = gameModel.Rating,
                Type = Enum.Parse<GameType>(gameModel.GameType)
            };
        }
    }
}
