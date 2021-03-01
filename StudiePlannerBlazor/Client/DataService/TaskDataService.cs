using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.DataService
{
    public class TaskDataService : IDataService<TaskModel>
    {
        private readonly HttpClient _httpClient;

        public TaskDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TaskModel> Add(TaskModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TaskModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(TaskModel model)
        {
            throw new NotImplementedException();
        }
    }
}
