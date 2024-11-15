using Lab4.BLL.GameAccounts;
using Lab4.BLL.Services;
using Lab4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.DtoMappers
{
    public class GameAccountDtoMapper : IDtoMapper<GameAccountModel, BaseGameAccount>
    {
        IGameAccountService _gameAccountService;
 
        public GameAccountDtoMapper(IGameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }

        public GameAccountModel ToModel(BaseGameAccount account)
        {
            return new GameAccountModel()
            {
                Id = account.Id,
                Username = account.Username,
                CurrentRating = account.CurrentRating,
                AccountType = account.GetAccountType().ToString()
            };
        }

        public BaseGameAccount FromModel(GameAccountModel accountModel)
        {
            BaseGameAccount account = GameAccountFactory.GetAccount(Enum.Parse<AccountType>(accountModel.AccountType), _gameAccountService, accountModel.Username);
            account.Id = accountModel.Id;
            account.CurrentRating = accountModel.CurrentRating;
            account.Service = _gameAccountService;
            return account;
        }
    }
}
