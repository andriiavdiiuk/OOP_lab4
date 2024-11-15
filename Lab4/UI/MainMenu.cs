using Lab4.BLL.Services;
using Lab4.UI.Input;
using Lab4.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI
{
    public class MainMenu : IControl
    {
        private OptionsInput _menuInput;
        private IGameService _gameService;
        private IGameAccountService _accountService;
        public MainMenu(IGameService gameService, IGameAccountService accountService)
        {
            _gameService = gameService;
            _accountService = accountService;
            _menuInput = new OptionsInput("Select an option:");
            _menuInput.AddOption(new OptionItem(new PlayGame(accountService, gameService), "Play Game"));
            _menuInput.AddOption(new OptionItem(new AllPlayers(accountService), "Show All Players"));
            _menuInput.AddOption(new OptionItem(new ShowPlayerById(accountService), "Show Player by ID"));
            _menuInput.AddOption(new OptionItem(new CreatePlayer(accountService), "Create a Player"));
            _menuInput.AddOption(new OptionItem(new ShowAllGameResults(gameService), "Show All Game Results"));
        }

        public void Action()
        {
            while (true)
            {
                _menuInput.Action();
                IControl? control = _menuInput.Result;
                if (control != null) 
                { 
                    control.Action();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input");
                }
            }
        }
    }
}
