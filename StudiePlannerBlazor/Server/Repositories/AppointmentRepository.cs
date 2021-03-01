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

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDBContext _ApplicationDbContext;

        public AppointmentRepository(ApplicationDBContext appcontext)
        {
            _ApplicationDbContext = appcontext;
        }

        public Appointment AddAppointment(Appointment model)
        {
            var addedEntity = _ApplicationDbContext.Add(model);
            _ApplicationDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteAppointment(int id)
        {
            var FoundModel = _ApplicationDbContext.Appointments.FirstOrDefault(a => a.Id == id);
            if (FoundModel == null) return;

            _ApplicationDbContext.Appointments.Remove(FoundModel);
            _ApplicationDbContext.SaveChanges();
        }

        public List<Appointment> GetAllAppointments()
        {
            return _ApplicationDbContext.Appointments.ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _ApplicationDbContext.Appointments.FirstOrDefault(a => a.Id == id);
        }

        public Appointment UpdateAppointment(Appointment model)
        {
            var foundmodel = _ApplicationDbContext.Appointments.FirstOrDefault(a => a.Id == model.Id);
            foundmodel = model;
            _ApplicationDbContext.SaveChanges();
            return foundmodel;
        }
    }
}
