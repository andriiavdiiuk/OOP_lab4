using Lab4.BLL.GameAccounts;
using Lab4.BLL.Services;
using Lab4.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI
{
    public class AllPlayers : IControl
    {
        private readonly IGameAccountService _accountService;
        public AllPlayers(IGameAccountService service) 
        {
            _accountService = service;
        }
        public void Action()
        {
            Console.Clear();
            string result = "All Players:\n";
            result += "----------------------------------------------------------------------------------\n";
            result += $"| {"Id",-4} | {"Username",-15} | {"Current Rating",-15} | {"Games Count",-12} | {"Account Type",-20} |\n";
            result += "----------------------------------------------------------------------------------\n";
            foreach (BaseGameAccount account in _accountService.GetAll())
            {
                result += $"| {account.Id,-4} | {account.Username,-15} | {account.CurrentRating,-15} | {account.GamesCount,-12} | {account.GetAccountType().ToString(),-20} |\n";
            }

            result += "----------------------------------------------------------------------------------\n";
            Console.WriteLine(result);
            Console.WriteLine("Press Any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
