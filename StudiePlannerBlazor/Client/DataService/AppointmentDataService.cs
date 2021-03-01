using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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

        public async Task<AppointmentModel> Add(AppointmentModel model)
        {
            var modelJson = new StringContent(JsonSerializer.Serialize(model), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Appointment", modelJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<AppointmentModel>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Appointment/{id}");
        }

        public async  Task Update(AppointmentModel model)
        {
            var modelJson = new StringContent(JsonSerializer.Serialize(model), System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("api/Appointment", modelJson);
        }

        public async  Task<IEnumerable<AppointmentModel>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<AppointmentModel>>(await _httpClient.GetStreamAsync($"api/Appointment"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<AppointmentModel> GetById(int id)
        {
            return await JsonSerializer.DeserializeAsync<AppointmentModel>(await _httpClient.GetStreamAsync($"api/Appointment/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }); ;
        }
    }
}
