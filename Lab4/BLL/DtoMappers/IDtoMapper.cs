using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.DtoMappers
{
    public interface IDtoMapper<TModel, TDestination>
    {
        TModel ToModel(TDestination obj);
        TDestination FromModel(TModel obj);
    }
}
