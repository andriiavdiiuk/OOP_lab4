using Lab4.BLL.GameAccounts;
using Lab4.BLL.Games;
using Lab4.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI.Input
{
    public class EnumTypeInput<T> : IInput<T?> where T : struct, Enum
    {
        public T? Result { get; private set; } = default(T);
        private string _label;
        public EnumTypeInput(string label) 
        {
            _label = label;
        }  
        public void Action() 
        {
            Console.WriteLine(_label);
            T[] values = Enum.GetValues<T>();
            int i = 1;
            foreach (T type in values)
            {
                Console.WriteLine($"{i} - {type.ToString()}");
                i++;
            }

            string enumType = Console.ReadLine()!;

            int intType = 0;
            if (int.TryParse(enumType, out intType) && intType <= i - 1)
            { 
                Result =  values[(intType - 1) % values.Length];
            }
            else
            {
                Result = null;
            }
        }
    }
}
