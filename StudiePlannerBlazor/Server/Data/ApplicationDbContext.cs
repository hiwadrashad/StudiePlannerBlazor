using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
            //builder.Entity<IdentityUserLogin>().HasKey(m => m.UserId);
            //builder.Entity<IdentityUserRole>().HasKey(m => m.UserId);
            base.OnModelCreating(builder);

            //builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Email = "test1@hotmail.com",
            //    UserName = "test1@hotmail.com"
            //});

            //var user = new ApplicationUser
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Email = "test1@hotmail.com",
            //    UserName = "test1@hotmail.com"
            //};

            builder.Entity<CalenderModel>().HasData(new CalenderModel
            {
                CalenderId = 1,

                //Tasks = new List<TaskModel>()
                //{
                //    new TaskModel
                //    {
                //        Id = 4,
                //        Name = "Work order for February",
                //        StartDate = DateTime.ParseExact("01/02/2021", "dd/MM/yyyy", null),
                //        EndDate = DateTime.ParseExact("01/03/2021", "dd/MM/yyyy", null),
                //        Status = Shared.Models.TaskStatus.Done
                //    },
                //    new TaskModel
                //    {
                //        Id = 5,
                //        Name = "Work order for March",
                //        StartDate = DateTime.ParseExact("01/03/2021", "dd/MM/yyyy", null),
                //        EndDate = DateTime.ParseExact("01/04/2021", "dd/MM/yyyy", null),
                //        Status = Shared.Models.TaskStatus.Busy
                //    }
                //},

                //User = user

                //User = Users.FirstOrDefault(l => l.UserName == "test1@hotmail.com") as ApplicationUser

                //User = new IdentityUser { Id = Guid.NewGuid().ToString(), Email = "test@hotmail.com", UserName = "test@hotmail.com" }

            });
            builder.Entity<TaskModel>().HasData(new TaskModel
            {
                Id = 1,
                CalenderId = 1,
                Name = "Work order for February",
                StartDate = DateTime.ParseExact("01/02/2021", "dd/MM/yyyy", null),
                EndDate = DateTime.ParseExact("01/03/2021", "dd/MM/yyyy", null),
                Status = Shared.Models.TaskStatus.Done
            });
            builder.Entity<TaskModel>().HasData(new TaskModel
            {
                Id = 2,
                CalenderId = 1,
                Name = "Work order for March",
                StartDate = DateTime.ParseExact("01/03/2021", "dd/MM/yyyy", null),
                EndDate = DateTime.ParseExact("01/04/2021", "dd/MM/yyyy", null),
                Status = Shared.Models.TaskStatus.Busy
            });
        }
    }
}
