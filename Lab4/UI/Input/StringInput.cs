using Lab4.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI.Input
{
    public class StringInput : IInput<string>
    {
        public string Result { get; private set; } = string.Empty;
        public string _label;
        public StringInput(string label)
        {
            _label = label;
        }
        public void Action()
        {
            Console.WriteLine(_label);
            string input = Console.ReadLine()!;
            Result = input;
        }
    }
}
