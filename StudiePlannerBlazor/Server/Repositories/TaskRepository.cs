using StudiePlannerBlazor.Server.DAL;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Server.Repositories
{
    public class TaskRepository : IRepository<TaskModel>
    {
        private readonly ApplicationDBContext _ApplicationDbContext;

        public TaskRepository(ApplicationDBContext appcontext)
        {
            _ApplicationDbContext = appcontext;
        }

        public TaskModel Add(TaskModel model)
        {
            var addedEntity = _ApplicationDbContext.Add(model);
            _ApplicationDbContext.SaveChanges();
            return model;
        }

        public TaskModel Delete(int id)
        {
            var foundModel = _ApplicationDbContext.taskModels.FirstOrDefault(p => p.Id == id);
            if (foundModel == null) return null;

            _ApplicationDbContext.taskModels.Remove(foundModel);
            _ApplicationDbContext.SaveChanges();

            return foundModel;
        }

        public TaskModel Update(TaskModel model)
        {
            var foundModel = _ApplicationDbContext.taskModels.FirstOrDefault(a => a.Id == model.Id);
            foundModel = model;
            _ApplicationDbContext.SaveChanges();
            return foundModel;
        }

        public List<TaskModel> GetAll()
        {
            return _ApplicationDbContext.taskModels.ToList();
        }

        public TaskModel GetById(int id)
        {
            return _ApplicationDbContext.taskModels.FirstOrDefault(a => a.Id == id);
        }

        
    }
}
