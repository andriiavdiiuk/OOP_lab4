using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.DAL.Models;

namespace Lab4.DAL.Repositories
{
    public interface IGameAccountRepository
    {
        int Create(GameAccountModel account);
        IEnumerable<GameAccountModel> GetAll();
        GameAccountModel Read(int id);
        void Update(GameAccountModel account);
        void Delete(int id);
    }
}
