using Microsoft.EntityFrameworkCore;
using StudiePlannerBlazor.Shared.Models;

namespace StudiePlannerBlazor.Server.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }

        public DbSet<AppointmentModel> Appointments { get; set; }
        public DbSet<CalenderModel> Calenders { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
