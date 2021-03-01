using StudiePlannerBlazor.Server.DAL;
using StudiePlannerBlazor.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudiePlannerBlazor.Server.Repositories
{
    public class TaskRepository : IRepository<TaskModel>
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public TaskRepository(ApplicationDBContext appcontext)
        {
            _applicationDbContext = appcontext;
        }

        public TaskModel Add(TaskModel model)
        {
            var addedEntity = _applicationDbContext.Tasks.Add(model);
            _applicationDbContext.SaveChanges();
            return model;
        }

        public TaskModel Delete(int id)
        {
            var foundModel = _applicationDbContext.Tasks.FirstOrDefault(p => p.Id == id);
            if (foundModel == null) return null;

            _applicationDbContext.Tasks.Remove(foundModel);
            _applicationDbContext.SaveChanges();

            return foundModel;
        }

        public TaskModel Update(TaskModel model)
        {
            var foundModel = _applicationDbContext.Tasks.FirstOrDefault(a => a.Id == model.Id);
            foundModel = model;
            _applicationDbContext.SaveChanges();
            return foundModel;
        }

        public List<TaskModel> GetAll()
        {
            return _applicationDbContext.Tasks.ToList();
        }

        public TaskModel GetById(int id)
        {
            return _applicationDbContext.Tasks.FirstOrDefault(a => a.Id == id);
        }
    }
}
