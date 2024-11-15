using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    public class TypeAttribute<T> : Attribute
    {
    }
}
