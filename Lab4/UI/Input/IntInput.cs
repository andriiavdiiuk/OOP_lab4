using Lab4.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI.Input
{
    public class IntInput : IInput<int> 
    {
        public int Result { get; private set; }
        public string? _label;
        public IntInput(int defaultInt=-1, string? label=null)
        {
            Result = defaultInt;
            _label = label; 
        }
        public void Action()
        {        
            int num = -1;
            Console.WriteLine(_label);

            string? snum = Console.ReadLine();

            if (int.TryParse(snum, out num))
            {
                Result = num;
            }
        }
    }
}
