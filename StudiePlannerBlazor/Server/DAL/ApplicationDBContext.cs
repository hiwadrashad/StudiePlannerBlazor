using Microsoft.EntityFrameworkCore;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Server.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<CalenderModel> CalenderModels { get; set; }
        public DbSet<TaskModel> taskModels { get; set; }
    }
}
