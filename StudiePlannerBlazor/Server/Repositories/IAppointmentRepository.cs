using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Server.Repositories
{
    public interface IAppointmentRepository
    {
        AppointmentModel Add(AppointmentModel model);
        AppointmentModel Delete(int id);
        AppointmentModel Update(AppointmentModel model);
        List<AppointmentModel> GetAll();
        AppointmentModel GetById(int id);
    }
}
