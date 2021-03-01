using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.DataService
{
    public class CalenderDataService /*: IDataService<CalenderModel>*/
    {
        private readonly HttpClient _httpClient;

        public CalenderDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CalenderModel> Add(CalenderModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CalenderModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CalenderModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(CalenderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
