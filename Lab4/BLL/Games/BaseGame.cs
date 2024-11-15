using Lab4.BLL.GameAccounts;
using Lab4.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.Games
{
    public abstract class BaseGame
    {
        public int Rating = -1;

        private static Random random = new Random();
        public abstract int GetRatingForPlayer(BaseGameAccount player);
        public abstract int GetGameRating();

        public IGameService Service { get; set; }

        public BaseGame(IGameService service)
        {
            Service = service;
        }

        public virtual int Play(BaseGameAccount player1, BaseGameAccount player2)
        {
            bool player1Wins = random.Next(2) == 0;

            if (player1Wins)
            {
                return player1.WinGame(player2, this);
            }
            else
            {
                return player1.LoseGame(player2, this);
            }
        } 

        public GameType GetGameType()
        {
            Type enumType = typeof(GameType);
            Type type = GetType();
            foreach (GameType gameType in Enum.GetValues(enumType))
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
    }
}
