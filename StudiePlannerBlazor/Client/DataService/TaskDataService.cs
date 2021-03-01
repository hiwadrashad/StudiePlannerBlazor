using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.DataService
{
    public class TaskDataService /*: IDataService<TaskModel>*/
    {
        private readonly HttpClient _httpClient;

        public TaskDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public TaskModel Add(TaskModel model)
        {
            throw new NotImplementedException();
        }

        public TaskModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaskModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TaskModel Update(TaskModel model)
        {
            throw new NotImplementedException();
        }
    }
}
