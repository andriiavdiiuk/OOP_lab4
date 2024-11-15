using Lab4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL.Repositories
{
    public class GameAccountRepository : IGameAccountRepository
    {
        private DbContext _dbContext;

        public GameAccountRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(GameAccountModel account)
        {
            account.Id = _dbContext.GameAccounts.Count;
            _dbContext.GameAccounts.Add(account);
            return account.Id;
        }

        public void Delete(int id)
        {
            _dbContext.GameAccounts[id] = null;
        }

        public IEnumerable<GameAccountModel> GetAll()
        {
           return _dbContext.GameAccounts!;
        }

        public GameAccountModel Read(int id)
        {
            return _dbContext.GameAccounts[id]!;
        }

        public void Update(GameAccountModel account)
        {
            _dbContext.GameAccounts[account.Id] = account;
        }
    }
}
