using Lab4.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL.Repositories
{
    class GameRepository : IGameRepository
    {
        private DbContext _dbContext;
        public GameRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private static List<GameModel> GameHistory = new List<GameModel>();

        public int Create(GameModel game)
        {
            game.Id = _dbContext.GameRecords.Count;
            _dbContext.GameRecords.Add(game);
            return game.Id;
        }

        public void Delete(int id)
        {
            _dbContext.GameRecords[id] = null;
        }

        public GameModel Read(int id)
        {
            return _dbContext.GameRecords[id]!;
        }

        public void Update(GameModel game)
        {
            _dbContext.GameRecords[game.Id] = game;
        }

        public IEnumerable<GameModel> GetAll()
        {
            return _dbContext.GameRecords!;
        }
    }
}
