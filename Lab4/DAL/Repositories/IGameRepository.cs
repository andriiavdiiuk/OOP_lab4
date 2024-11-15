using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.DAL.Models;

namespace Lab4.DAL.Repositories
{
    public interface IGameRepository
    {
        int Create(GameModel game);
        IEnumerable<GameModel> GetAll();
        GameModel Read(int id);
        void Update(GameModel game);
        void Delete(int id);
    }
}
