using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.DataService
{
    public interface IUploadDataService
    {
        Task<DocumentModel> UploadFile(MultipartFormDataContent content);
        Task DeleteFile(int id);
        Task<IEnumerable<DocumentModel>> GetAllFiles();
        Task<DocumentModel> GetFileById(int id);
    }
}
