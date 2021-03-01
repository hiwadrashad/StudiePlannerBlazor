using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.DataService
{
    public class AppointmentDataService : IDataService<AppointmentModel>
    {
        private readonly HttpClient _httpClient;

        public AppointmentDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public AppointmentModel Add(AppointmentModel model)
        {
            throw new NotImplementedException();
        }

        public AppointmentModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AppointmentModel Update(AppointmentModel model)
        {
            throw new NotImplementedException();
        }

        public List<AppointmentModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AppointmentModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
