using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        TModel Create(TModel entity);
    }
}
