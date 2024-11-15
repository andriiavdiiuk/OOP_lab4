using Lab4.BLL.GameAccounts;
using Lab4.BLL.Services;
using Lab4.UI.Input;
using Lab4.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI
{
    public class ShowPlayerById : IControl
    {
        private readonly IInput<int> _idInput;
        private readonly IGameAccountService _accountService;
        public ShowPlayerById(IGameAccountService service)
        {
            _accountService = service;
            _idInput = new IntInput(-1,"Enter user Id:");
        }

        public void Action()
        {
            Console.Clear();
            _idInput.Action();
            int id = _idInput.Result;
            if (id < 0)
            {
                Console.Clear();
                Console.WriteLine("Invalid user Id");
            }
            else
            {
                BaseGameAccount account = _accountService.Get(id);
                Console.WriteLine(account.GetStats());
            }
           
            Console.WriteLine("Press Any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
