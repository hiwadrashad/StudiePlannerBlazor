﻿using IdentityServer4.EntityFramework.Options;
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
        public DbSet<TaskModel> Tasks { get; set; }

        


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "SeedUser1",
                Email = "test1@hotmail.com",
                NormalizedEmail = "test1@hotmail.com".ToUpper(),
                UserName = "test1@hotmail.com",
                NormalizedUserName = "test1@hotmail.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "Passw0rd!"),
                EmailConfirmed = true,
            });
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "SeedUser2",
                Email = "test2@hotmail.com",
                NormalizedEmail = "test2@hotmail.com".ToUpper(),
                UserName = "test2@hotmail.com",
                NormalizedUserName = "test2@hotmail.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "Passw0rd!"),
                EmailConfirmed = true,
            });

            builder.Entity<AppointmentModel>().HasData(new AppointmentModel
            {
                Id = 1,
                Email = "Appointment1@hotmail.com",
                PersonalContact = true,
                Date = DateTime.Now.AddDays(5),
                TelephoneNumber = "0123-456789"
            });
            builder.Entity<AppointmentModel>().HasData(new AppointmentModel
            {
                Id = 2,
                Email = "Appointment2@hotmail.com",
                PersonalContact = true,
                Date = DateTime.Now.AddDays(5),
                TelephoneNumber = "1234-567890"
            });

            builder.Entity<TaskModel>().HasData(new TaskModel
            {
                Id = 1,
                ApplicationUserId = "SeedUser1",
                AppointmentId = 1,
                Name = "Work order for February",
                StartDate = DateTime.ParseExact("01/02/2021", "dd/MM/yyyy", null),
                EndDate = DateTime.ParseExact("01/03/2021", "dd/MM/yyyy", null),
                Status = Shared.Models.TaskStatus.Done,
                Notes = "geen aantekeningen"
            });
            builder.Entity<TaskModel>().HasData(new TaskModel
            {
                Id = 2,
                ApplicationUserId = "SeedUser1",
                AppointmentId = 1,
                Name = "Work order for March",
                StartDate = DateTime.ParseExact("01/03/2021", "dd/MM/yyyy", null),
                EndDate = DateTime.ParseExact("01/04/2021", "dd/MM/yyyy", null),
                Status = Shared.Models.TaskStatus.Busy,
                Notes = "geen aantekeningen"
            });
            builder.Entity<TaskModel>().HasData(new TaskModel
            {
                Id = 3,
                ApplicationUserId = "SeedUser2",
                AppointmentId = 2,
                Name = "Work Order",
                StartDate = DateTime.ParseExact("01/03/2021", "dd/MM/yyyy", null),
                EndDate = DateTime.ParseExact("01/04/2021", "dd/MM/yyyy", null),
                Status = Shared.Models.TaskStatus.Busy,
                Notes = "geen aantekeningen"
            });
        }
    }
}
