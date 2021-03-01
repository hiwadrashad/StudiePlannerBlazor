using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.DataService
{
    public class CalenderDataService : IDataService<CalenderModel>
    {
        private readonly HttpClient _httpClient;

        public CalenderDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CalenderModel> Add(CalenderModel model)
        {
            var modelJson = new StringContent(JsonSerializer.Serialize(model), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Calender", modelJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<CalenderModel>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Calender/{id}");
        }

        public async Task Update(CalenderModel model)
        {
            var modelJson = new StringContent(JsonSerializer.Serialize(model), System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("api/Calender", modelJson);
        }

        public async Task<IEnumerable<CalenderModel>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<CalenderModel>>(await _httpClient.GetStreamAsync($"api/Calender"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<CalenderModel> GetById(int id)
        {
            return await JsonSerializer.DeserializeAsync<CalenderModel>(await _httpClient.GetStreamAsync($"api/Calender/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }); ;
        }
    }
}
