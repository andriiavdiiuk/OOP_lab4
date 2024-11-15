using Lab4.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.BLL.Services;
using Lab4.BLL.Games;

namespace Lab4.BLL.GameAccounts
{
    public abstract class BaseGameAccount : IEquatable<BaseGameAccount>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        private int _currentRating = 100;
        public int CurrentRating
        {
            get
            {
                return _currentRating;
            }
             set
            {
                if (value < 1)
                {
                    _currentRating = 1;
                }
                else
                {
                    _currentRating = value;
                }
            }
        }
        public int GamesCount
        {
            get
            {
                return Service.GetHistory(Id).Count();
            }
        }
        public IGameAccountService Service { get; set; }

        protected virtual void OnWin() { }
        protected virtual void OnLose() { }
        public abstract int CalculateWinRating(int rating);
        public abstract int CalculateLoseRating(int rating);

        public BaseGameAccount(IGameAccountService _service, string username)
        {
            Username = username;
            Service = _service;
        }

        public int WinGame(BaseGameAccount opponent, BaseGame game)
        {
            int ratingChange = CalculateWinRating(game.GetRatingForPlayer(this));
            CurrentRating += ratingChange;
            Service.Update(this);
            OnWin();

            GameResult result = new GameResult(-1, this, opponent, ratingChange,CurrentRating, 0, 0, game.GetGameRating(), game.GetGameType());
            return opponent.LoseGame(this, game, result);
        }

        public int LoseGame(BaseGameAccount opponent, BaseGame game)
        {
            int ratingChange = CalculateLoseRating(game.GetRatingForPlayer(this));
            CurrentRating -= ratingChange;
            Service.Update(this);
            OnLose();

            GameResult result = new GameResult(-1,opponent,this,0,0,CurrentRating,-ratingChange,game.GetGameRating(),game.GetGameType());
            return opponent.WinGame(this, game, result);
        }

        private int WinGame(BaseGameAccount opponent, BaseGame game, GameResult result)
        {
            int ratingChange = CalculateWinRating(game.GetRatingForPlayer(this));
            CurrentRating += ratingChange;
            Service.Update(this);
            OnWin();

            result.Winner = this;
            result.WinnerRatingChange = ratingChange;
            result.WinnerRating = CurrentRating;
            return game.Service.Create(result);

        }

        private int LoseGame(BaseGameAccount opponent, BaseGame game, GameResult result)
        {
            int ratingChange = CalculateLoseRating(game.GetRatingForPlayer(this));
            CurrentRating -= ratingChange;
            Service.Update(this);
            OnLose();

            result.Loser = this;
            result.LoserRatingChange = -ratingChange;
            result.LoserRating = CurrentRating;
            return game.Service.Create(result);
        }

        public virtual string GetStats()
        {
            string result = $"{Username}\n";
            result += $"Account Id: {Id}\n";
            result += $"AccountType: {GetAccountType().ToString()}\n";
            result += $"Current Rating: {CurrentRating}\n";
            result += $"Games Count: {GamesCount}\n";
            result += "--------------------------------------------------------------------------------------------\n";
            result += $"|{"Opponent",-12} | {"Win/Lost",-10} | {"Game Rating",-11} | {"Rating Change",-13} | {"Id",-4}| {"Game Type",-25} |\n";
            result += "--------------------------------------------------------------------------------------------\n";
            string opponent = "";
            string winLost = "";
            int rating = 0;
            int ratingChange = 0;
            string ratingFormatted = "";
            IEnumerable<GameResult> history = Service.GetHistory(Id);
            foreach (GameResult game in history)
            {
                if (game.Winner.Username == Username)
                {
                    opponent = game.Loser.Username;
                    ratingChange = game.WinnerRatingChange;
                    rating = game.WinnerRating;
                    winLost = "Win";
                }
                else
                {
                    opponent = game.Winner.Username;
                    rating = game.LoserRating;
                    ratingChange = game.LoserRatingChange;
                    winLost = "Lost";
                }

                ratingFormatted = $"{rating,-5} ({ratingChange})";
                result += $"|{opponent,-12} | {winLost,-10} | {game.Rating,-11} | {ratingFormatted,-13} | {game.Id,-4}| {game.Type.ToString(),-25} |\n";
            };
            result += "--------------------------------------------------------------------------------------------\n";

            return result;
        }


        public AccountType GetAccountType()
        {
            Type enumType = typeof(AccountType);
            Type type = GetType();
            foreach (AccountType gameType in Enum.GetValues(enumType))
            {
                var memberInfo = enumType.GetMember(gameType.ToString());
                var attributes = memberInfo[0].GetCustomAttributes(typeof(TypeAttribute<>), false);

                if (attributes.Length > 0)
                {
                    Type? attributeType = attributes[0].GetType();
                    Type genericType = attributeType.GetGenericArguments()[0];

                    if (genericType == type)
                    {
                        return gameType;
                    }

                }
            }
            throw new InvalidOperationException($"No GameType attribute found for {type.Name}.");
        }

        public bool Equals(BaseGameAccount? obj)
        {
            if (obj == null)
                return false;

            return Username == obj.Username;
        }
        public override bool Equals(object? obj) => Equals(obj as BaseGameAccount);
        public static bool operator ==(BaseGameAccount? b1, BaseGameAccount? b2)
        {
            if ((object)b1 == null)
                return (object)b2 == null;

            return b1.Equals(b2);
        }

        public static bool operator !=(BaseGameAccount? b1, BaseGameAccount? b2)
        {
            return !(b1 == b2);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
