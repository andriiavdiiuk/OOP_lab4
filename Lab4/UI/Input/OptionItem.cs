using Lab4.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI.Input
{
    public class OptionItem
    {
        public IControl Control;
        public string Description;
       
        public OptionItem(IControl control, string description)
        {
            Control = control;
            Description = description;
        }
    }
}
