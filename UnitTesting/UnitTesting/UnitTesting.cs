using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudiePlannerBlazor.Client.DataService;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.UnitTesting
{
    [TestClass]
    public class UnitTesting
    {
        private IDataService<TaskModel> taskrepo { get; set; }
        private IDataService<AppointmentModel> appointmentrepo { get; set; }

        private Uri uri = new Uri("https://localhost:44314/");

        public TaskModel taskmodel = new TaskModel()
        {
           Id = 10,
           Name = "test",
           Notes = "test",
           Status = StudiePlannerBlazor.Shared.Models.TaskStatus.Busy,
           StartDate = DateTime.Now,
           EndDate = DateTime.Now
        };

        public AppointmentModel appointmentmodel = new AppointmentModel()
        {
            Date = DateTime.Now,
            Email = "test@hotmail.com",
            PersonalContact = true,
            Id = 11,
            TelephoneNumber = "test"
        };

        public void TaskDependencyInjection()
        {
            if (taskrepo == null)
            {
                var services = new ServiceCollection();
                services.AddHttpClient<IDataService<TaskModel>, TaskDataService>(client =>
                {
                    client.BaseAddress = uri;
                });

                var serviceprovider = services.BuildServiceProvider();
                taskrepo = serviceprovider.GetService<IDataService<TaskModel>>();
            }
        }

        public void AppointmentDependencyInjection()
        {
            if (taskrepo == null)
            {
                var services = new ServiceCollection();
                services.AddHttpClient<IDataService<AppointmentModel>, AppointmentDataService>(client =>
                {
                    client.BaseAddress = uri;
                });

                var serviceprovider = services.BuildServiceProvider();
                appointmentrepo = serviceprovider.GetService<IDataService<AppointmentModel>>();
            }
        }

        [TestMethod]
        [TestCategory("Post")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task AddTask()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            TaskDependencyInjection();
            NUnit.Framework.Assert.DoesNotThrowAsync(async () => await taskrepo.Add(taskmodel), "not added task properly");
        }

        [TestMethod]
        [TestCategory("Post")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task AddAppointment()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            AppointmentDependencyInjection();
            NUnit.Framework.Assert.DoesNotThrowAsync(async () => await appointmentrepo.Add(appointmentmodel), "not added task properly");
        }
    }
}
