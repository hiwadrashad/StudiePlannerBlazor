using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.DataService
{
    public interface IDataService<TModel>
    {
        Task<TModel> Add(TModel model);
        Task Delete(int id);
        Task Update(TModel model);
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetById(int id);
    }
}
