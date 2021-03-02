using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudiePlannerBlazor.Server.Models;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<AppointmentModel> Appointments { get; set; }
        public DbSet<CalenderModel> Calenders { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin>().HasKey(m => m.UserId);
            builder.Entity<IdentityUserRole>().HasKey(m => m.UserId);
            base.OnModelCreating(builder);

            builder.Entity<TaskModel>().HasData(new TaskModel
            {
                Id = 1,
                Name = "Work order for February",
                StartDate = DateTime.ParseExact("01/02/2021", "dd/MM/yyyy", null),
                EndDate = DateTime.ParseExact("01/03/2021", "dd/MM/yyyy", null),
                Status = Shared.Models.TaskStatus.Done
            });
            builder.Entity<TaskModel>().HasData(new TaskModel
            {
                Id = 2,
                Name = "Work order for March",
                StartDate = DateTime.ParseExact("01/03/2021", "dd/MM/yyyy", null),
                EndDate = DateTime.ParseExact("01/04/2021", "dd/MM/yyyy", null),
                Status = Shared.Models.TaskStatus.Busy
            });
        }
    }
}
