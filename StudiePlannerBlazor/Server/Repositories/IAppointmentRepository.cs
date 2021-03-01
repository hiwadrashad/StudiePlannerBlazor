using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Server.Repositories
{
    public interface IAppointmentRepository
    {
        Appointment AddAppointment(Appointment model);

        void DeleteAppointment(int id);

        List<Appointment> GetAllAppointments();

        Appointment GetAppointmentById(int id);

        Appointment UpdateAppointment(Appointment model);
    }
}
