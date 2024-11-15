using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.BLL.GameAccounts;
using Lab4.BLL.Services;
namespace Lab4.BLL.Games
{
    public static class GameManager
    {
        private static Random random = new Random();
        
        public static List<int> PlayGame(List<BaseGameAccount> players, int count, IGameService service)
        {
            List<int> playedGames = new List<int>();
            for (int i = 0; i < players.Count(); i++)
            {
                for (int j = i + 1; j < players.Count(); j++)
                {
                    for (int k = 0; k < count; k++)
                    {
                        playedGames.Add(PlayRandomGame(players[i], players[j], service));
                    }
                }
            }
            return playedGames;
        }


        public static List<int> PlayGame(List<int> players, GameType gameType, int rating, IGameAccountService gameAccountService, IGameService gameService, int playerWithRating=-1)
        {
            List<int> playedGames = new List<int>();
            for (int i = 0; i < players.Count(); i++)
            {
                for (int j = i + 1; j < players.Count(); j++)
                {
                    if (playerWithRating >= 0)
                    {
                        playedGames.Add(PlayGame(gameAccountService.Get(i), gameAccountService.Get(j), gameType, rating, gameService, gameAccountService.Get(playerWithRating)));
                    }
                    else
                    {
                        playedGames.Add(PlayGame(gameAccountService.Get(i), gameAccountService.Get(j), gameType, rating, gameService));
                    }
                }
            }
            return playedGames;
        }

        public static int PlayGame(BaseGameAccount player1, BaseGameAccount player2, GameType gameType, int rating, IGameService service, BaseGameAccount playerWithRating)
        {
            BaseGame game = GameFactory.GetGame(gameType, service, playerWithRating);
            game.Rating = rating; 
            return game.Play(player1, player2);
        }
        public static int PlayGame(BaseGameAccount player1, BaseGameAccount player2, GameType gameType, int rating, IGameService service)
        {
            BaseGame game = GameFactory.GetGame(gameType, service);
            game.Rating = rating;
            return game.Play(player1, player2);
        }
        public static int PlayRandomGame(BaseGameAccount player1, BaseGameAccount player2, IGameService service)
        {
            int rand = random.Next(3);
            BaseGame game;
            switch (rand)
            {
                default:
                case 0:
                    game = GameFactory.GetGame(GameType.Standard,service);
                    break;
                case 1:
                    game = GameFactory.GetGame(GameType.Training, service);
                    break;
                case 2:
                    BaseGameAccount playerWithRating;
                    if (random.Next(2) == 0) playerWithRating = player1;
                    else playerWithRating = player2;
                    game = GameFactory.GetGame(GameType.SinglePlayerRating, service, playerWithRating);
                    break;
            }
            return game.Play(player1, player2);
        }
    }
}
