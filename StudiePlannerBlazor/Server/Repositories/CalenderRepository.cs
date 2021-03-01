﻿using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using StudiePlannerBlazor.Server.DAL;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudiePlannerBlazor.Server.Repositories
{
    public class CalenderRepository : IRepository<CalenderModel>
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public CalenderRepository(ApplicationDBContext appcontext)
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
            var foundModel = _applicationDbContext.Calenders.FirstOrDefault(a => a.Id == id);
            if (foundModel == null) return null;

            _applicationDbContext.Calenders.Remove(foundModel);
            _applicationDbContext.SaveChanges();

            return foundModel;
        }

        public CalenderModel Update(CalenderModel model)
        {
            var foundModel = _applicationDbContext.Calenders.FirstOrDefault(a => a.Id == model.Id);
            foundModel = model;
            _applicationDbContext.SaveChanges();
            return foundModel;
        }

        public List<CalenderModel> GetAll()
        {
            return _applicationDbContext.Calenders.ToList();
        }

        public CalenderModel GetById(int id)
        {
            return _applicationDbContext.Calenders.FirstOrDefault(a => a.Id == id);
        }
    }
}
