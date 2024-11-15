using Lab4.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI.Input
{
    public class GamePlayersInput : IInput<List<int>>
    {
        public List<int> Result { get; private set; } = new List<int>();
        void IControl.Action()
        {
            Action();
        }
        public void Action()
        {
            List<int> playerIds = new List<int>();
            Console.WriteLine("Enter players Ids separated by comma");
            string ids = Console.ReadLine()!;
            ids.Replace(" ", "");
            int tempId = 0;
            foreach (string id in ids.Split(","))
            {
                if (int.TryParse(id, out tempId))
                {
                    playerIds.Add(tempId);
                }
            }
            Result = playerIds;
        }
    }
}
