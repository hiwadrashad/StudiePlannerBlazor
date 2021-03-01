using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.DataService
{
    public interface IDataService<TModel>
    {
        //public TModel Add(TModel model);
        //public TModel Delete(int id);
        //public TModel Update(TModel model);
        //public List<TModel> GetAll();
        //public TModel GetById(int id);

        Task<TModel> Add(TModel model);
        Task Delete(int id);
        Task Update(TModel model);
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetById(int id);
    }
}
