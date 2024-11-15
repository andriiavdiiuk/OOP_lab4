using Lab4.BLL.Games;
using Lab4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.Services
{
    public interface IGameService
    {
        int Create(GameResult game);
        GameResult Get(int id);
        IEnumerable<GameResult> GetAll();
        void Update(GameResult game);
        void Delete(int id);
    }
}
