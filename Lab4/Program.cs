using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.DAL;
using Lab4.BLL.Services;
using Lab4.BLL.GameAccounts;
using Lab4.BLL.Games;
using Lab4.UI.Input;
using Lab4.UI;

namespace Lab4
{
    public class Program
    {
        static void Main(string[] args)
        {
            DbContext dbContext = new DbContext();
            IGameService GameService = new GameService(dbContext);
            IGameAccountService AccountService = new GameAccountService(dbContext);
            
            MainMenu mainMenu = new MainMenu(GameService, AccountService);

            mainMenu.Action();
        }
    }
}
