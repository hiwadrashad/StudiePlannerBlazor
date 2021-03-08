using StudiePlannerBlazor.Server.Data;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudiePlannerBlazor.Server.Repositories
{
    public class CalenderRepository : IRepository<CalenderModel>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CalenderRepository(ApplicationDbContext appcontext)
        {
            _applicationDbContext = appcontext;
        }

        public CalenderModel Add(CalenderModel model)
        {
            var addedEntity = _applicationDbContext.Calenders.Add(model);
            _applicationDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public CalenderModel Delete(int id)
        {
            var foundModel = _applicationDbContext.Calenders.FirstOrDefault(a => a.CalenderId == id);
            if (foundModel == null) return null;

            _applicationDbContext.Calenders.Remove(foundModel);
            _applicationDbContext.SaveChanges();

            return foundModel;
        }

        public CalenderModel Update(CalenderModel model)
        {
            var foundModel = _applicationDbContext.Calenders.FirstOrDefault(a => a.CalenderId == model.CalenderId);
            foundModel = model;
            _applicationDbContext.SaveChanges();
            return foundModel;
        }

        public List<CalenderModel> GetAll(/*CalenderModel model, TaskModel task*/)
        {
            //List<CalenderModel> Tasks = _applicationDbContext.Tasks.ToList();
            //if (model.CalenderId == task.CalenderId)
            //{
            //    Tasks.Add(task);
            //}
            //return Tasks.ToList();
            return _applicationDbContext.Calenders.ToList();
        }

        public CalenderModel GetById(int id)
        {
            return _applicationDbContext.Calenders.FirstOrDefault(a => a.CalenderId == id);
        }
    }
}
