using Lab4.DAL.Repositories;
using Lab4.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.DAL.Models;
using Lab4.BLL.DtoMappers;
using Lab4.BLL.GameAccounts;
using Lab4.BLL.Games;

namespace Lab4.BLL.Services
{
    public class GameAccountService : IGameAccountService
    {
        private IGameRepository _gameRepository;
        private IGameAccountRepository _gameAccountRepository;
        private IDtoMapper<GameAccountModel, BaseGameAccount> _accountMapper;
        private IDtoMapper<GameModel, GameResult> _gameMapper;
        public GameAccountService(DbContext dbContext)
        {
            _gameAccountRepository = new GameAccountRepository(dbContext);
            _gameRepository = new GameRepository(dbContext);
            _accountMapper = new GameAccountDtoMapper(this);
            _gameMapper = new GameDtoMapper(_accountMapper);
        }

        public int Create(BaseGameAccount account)
        {
            return _gameAccountRepository.Create(_accountMapper.ToModel(account));
        }
        public BaseGameAccount Get(int id)
        {
            return _accountMapper.FromModel(_gameAccountRepository.Read(id));
        }
        public IEnumerable<BaseGameAccount> GetAll()
        {
            return _gameAccountRepository.GetAll().Select(_accountMapper.FromModel);
        }
        public void Update(BaseGameAccount account)
        {
            _gameAccountRepository.Update(_accountMapper.ToModel(account));
        }
        public void Delete(int id)
        {
            _gameAccountRepository.Delete(id);
        }

        public IEnumerable<GameResult> GetHistory(int Id)
        {
            return _gameRepository.GetAll()
                .Select(_gameMapper.FromModel)
                .Where(g => g.Winner.Id == Id || g.Loser.Id == Id);
        }
    }
}
