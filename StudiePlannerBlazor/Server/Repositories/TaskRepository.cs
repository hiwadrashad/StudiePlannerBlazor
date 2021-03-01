using StudiePlannerBlazor.Server.DAL;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Server.Repositories
{
    public class TaskRepository
    {
        private readonly ApplicationDBContext _ApplicationDbContext;

        public TaskRepository(ApplicationDBContext appcontext)
        {
            _ApplicationDbContext = appcontext;
        }

        public TaskModel AddTask(TaskModel model)
        {
            var addedEntity = _ApplicationDbContext.Add(model);
            _ApplicationDbContext.SaveChanges();
            return model;
        }

        public void DeleteTask(int id)
        {
            var foundFotoModel = _ApplicationDbContext.taskModels.FirstOrDefault(p => p.Id == id);
            if (foundFotoModel == null) return;

            _ApplicationDbContext.taskModels.Remove(foundFotoModel);
            _ApplicationDbContext.SaveChanges();
        }

        public IEnumerable<TaskModel> GetAllFotoModellen()
        {
            return _ApplicationDbContext.taskModels;
        }
    }
}
