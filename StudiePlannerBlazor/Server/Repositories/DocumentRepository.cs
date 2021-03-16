using StudiePlannerBlazor.Server.Data;
using StudiePlannerBlazor.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudiePlannerBlazor.Server.Repositories
{
    public class DocumentRepository : IRepository<DocumentModel>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DocumentRepository(ApplicationDbContext appcontext)
        {
            _applicationDbContext = appcontext;
        }

        public DocumentModel Add(DocumentModel model)
        {
            var addedEntity = _applicationDbContext.Documents.Add(model);
            _applicationDbContext.SaveChanges();
            return model;
        }

        public DocumentModel Delete(int id)
        {
            var foundModel = _applicationDbContext.Documents.FirstOrDefault(p => p.Id == id);
            if (foundModel == null) return null;

            _applicationDbContext.Documents.Remove(foundModel);
            _applicationDbContext.SaveChanges();

            return foundModel;
        }

        public DocumentModel Update(DocumentModel model)
        {
            var foundModel = _applicationDbContext.Documents.FirstOrDefault(a => a.Id == model.Id);
            foundModel = model;
            _applicationDbContext.SaveChanges();
            return foundModel;
        }

        public List<DocumentModel> GetAll()
        {
            return _applicationDbContext.Documents.ToList();
        }

        public DocumentModel GetById(int id)
        {
            return _applicationDbContext.Documents.FirstOrDefault(a => a.Id == id);
        }
    }
}
