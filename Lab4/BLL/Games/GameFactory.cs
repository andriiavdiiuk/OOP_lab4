using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.Games
{
    public static class GameFactory
    {
        public static BaseGame GetGame(GameType gameType, params object?[]? args)
        {
            Type? t = gameType.GetAttributeType();
            if (t == null)
            {
                throw new ArgumentException($"Type {gameType} is unknown", nameof(gameType));
            }
            if (!t.IsSubclassOf(typeof(BaseGame)))
            {
                throw new ArgumentException($"{gameType} is not subclass of {nameof(BaseGame)}", nameof(gameType));
            }
            return (BaseGame)Activator.CreateInstance(t, args)!;
        }
    }
}
