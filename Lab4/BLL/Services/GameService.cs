using Lab4.BLL.DtoMappers;
using Lab4.BLL.Games;
using Lab4.DAL;
using Lab4.DAL.Models;
using Lab4.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.Services
{
    public class GameService : IGameService
    {
        private IGameRepository _gameRepository;
        private IDtoMapper<GameModel, GameResult> _mapper;
        public GameService(DbContext dbContext)
        {
            _gameRepository = new GameRepository(dbContext);
            _mapper = new GameDtoMapper(new GameAccountDtoMapper(new GameAccountService(dbContext)));
        }

        public int Create(GameResult game)
        {
            return _gameRepository.Create(_mapper.ToModel(game));
        }

        public GameResult Get(int id)
        {
            return _mapper.FromModel(_gameRepository.Read(id));
        }

        public IEnumerable<GameResult> GetAll()
        {
            return _gameRepository.GetAll().Select(_mapper.FromModel);
        }

        public void Update(GameResult game)
        {
            _gameRepository.Update(_mapper.ToModel(game));
        }

        public void Delete(int id)
        {
            _gameRepository.Delete(id);
        }
    }
}
