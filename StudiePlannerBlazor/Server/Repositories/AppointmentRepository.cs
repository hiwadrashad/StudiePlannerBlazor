using StudiePlannerBlazor.Server.Data;
using StudiePlannerBlazor.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudiePlannerBlazor.Server.Repositories
{
    public class AppointmentRepository : IRepository<AppointmentModel>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AppointmentRepository(ApplicationDbContext appcontext)
        {
            _applicationDbContext = appcontext;
        }

        public AppointmentModel Add(AppointmentModel model)
        {
            var addedEntity = _applicationDbContext.Appointments.Add(model);
            _applicationDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public AppointmentModel Delete(int id)
        {
            var foundModel = _applicationDbContext.Appointments.FirstOrDefault(a => a.Id == id);
            if (foundModel == null) return null;

            _applicationDbContext.Appointments.Remove(foundModel);
            _applicationDbContext.SaveChanges();

            return foundModel;
        }

        public AppointmentModel Update(AppointmentModel model)
        {
            var foundModel = _applicationDbContext.Appointments.FirstOrDefault(a => a.Id == model.Id);
            foundModel = model;
            _applicationDbContext.SaveChanges();
            return foundModel;
        }

        public List<AppointmentModel> GetAll()
        {
            return _applicationDbContext.Appointments.ToList();
        }

        public AppointmentModel GetById(int id)
        {
            return _applicationDbContext.Appointments.FirstOrDefault(a => a.Id == id);
        }
    }
}
