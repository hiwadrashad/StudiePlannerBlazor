using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.DataService
{
    public class TaskDataService : IDataService<TaskModel>, IUploadDataService
    {
        private readonly HttpClient _httpClient;

        public TaskDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TaskModel> Add(TaskModel model)
        {
            var modelJson = new StringContent(JsonSerializer.Serialize(model), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Task", modelJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<TaskModel>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Task/{id}");
        }

        public async Task Update(TaskModel model)
        {
            var modelJson = new StringContent(JsonSerializer.Serialize(model), System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("api/Task", modelJson);
        }

        public async Task<IEnumerable<TaskModel>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<TaskModel>>(await _httpClient.GetStreamAsync($"api/Task"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<TaskModel> GetById(int id)
        {
            return await JsonSerializer.DeserializeAsync<TaskModel>(await _httpClient.GetStreamAsync($"api/Task/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<DocumentModel> UploadFile(MultipartFormDataContent content)
        {
            var postResult = await _httpClient.PostAsync("api/Upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }

            return await JsonSerializer.DeserializeAsync<DocumentModel>(await postResult.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
