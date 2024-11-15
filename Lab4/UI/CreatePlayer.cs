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
    public class CreatePlayer : IControl
    {
        private readonly IInput<string> _usernameInput;
        private readonly IInput<AccountType?> _accountTypeInput;
        private readonly IGameAccountService _accountService;
        public CreatePlayer(IGameAccountService service)
        {
            _accountService = service;
            _accountTypeInput = new EnumTypeInput<AccountType>("Enter account type:");
            _usernameInput = new StringInput("Enter Username:");
        }
        public void Action()
        {
            Console.Clear();
            while (true)
            {
                _usernameInput.Action();
                string username = _usernameInput.Result;
                _accountTypeInput.Action();
                AccountType accountType = (AccountType)_accountTypeInput.Result;

                if (_accountService.Create(GameAccountFactory.GetAccount(accountType, _accountService, username)) >= 0)
                {
                    break;
                }
                Console.Clear();
                Console.WriteLine("Incorrect input, try again");
            }
            Console.Clear();
        }
    }
}
