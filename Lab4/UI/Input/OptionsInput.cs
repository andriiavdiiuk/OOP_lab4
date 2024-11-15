using Lab4.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab4.UI.Input
{
    public class OptionsInput : IInput<IControl?>
    {
        public IControl? Result { get; private set; } = null;
        private List<OptionItem> _options;
        private readonly IInput<int> _intInput;
        public string Label;
        public OptionsInput(string label)
        {
            Label = label;
            _options = new List<OptionItem>();
            _intInput = new IntInput();
        }
        public void AddOption(OptionItem item)
        {
            _options.Add(item);
        }
        public void Action()
        {
            Console.WriteLine(Label);
            int count = 1;
            foreach (OptionItem item in _options) 
            {
                Console.WriteLine($"{count} - {item.Description}");
                count++;
            }
            _intInput.Action();
            int result =  _intInput.Result - 1;
            if (result > _options.Count)
            {
                Result = null;
            }
            else
            {
                Result = _options[result].Control;
            }
        }
    }
}
