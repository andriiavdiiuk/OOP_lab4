using Lab4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL
{
    public class DbContext
    {
        public List<Models.GameAccountModel?> GameAccounts;
        public List<GameModel?> GameRecords;

        public DbContext()
        {
            GameAccounts = new List<Models.GameAccountModel?>();
            GameRecords = new List<GameModel?>();
        }
    }
}
