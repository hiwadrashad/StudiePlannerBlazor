using Microsoft.AspNetCore.Mvc;
using StudiePlannerBlazor.Server.DAL;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudiePlannerBlazor.Server.Repositories
{

    public class AppointmentRepository : IRepository<Appointment>
    {
        private readonly ApplicationDBContext _ApplicationDbContext;

        public AppointmentRepository(ApplicationDBContext appcontext)
        {
            _ApplicationDbContext = appcontext;
        }

        public Appointment Add(Appointment model)
        {
            var addedEntity = _ApplicationDbContext.Add(model);
            _ApplicationDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Appointment Delete(int id)
        {
            var foundModel = _ApplicationDbContext.Appointments.FirstOrDefault(a => a.Id == id);
            if (foundModel == null) return null;

            _ApplicationDbContext.Appointments.Remove(foundModel);
            _ApplicationDbContext.SaveChanges();

            return foundModel;
        }

        public Appointment Update(Appointment model)
        {
            var foundModel = _ApplicationDbContext.Appointments.FirstOrDefault(a => a.Id == model.Id);
            foundModel = model;
            _ApplicationDbContext.SaveChanges();
            return foundModel;
        }

        public List<Appointment> GetAll()
        {
            return _ApplicationDbContext.Appointments.ToList();
        }

        public Appointment GetById(int id)
        {
            return _ApplicationDbContext.Appointments.FirstOrDefault(a => a.Id == id);
        }
    }
}
