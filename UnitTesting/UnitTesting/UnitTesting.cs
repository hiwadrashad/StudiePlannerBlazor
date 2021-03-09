using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using StudiePlannerBlazor.Client.DataService;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class UnitTesting
    {
        private IDataService<TaskModel> taskrepo { get; set; }
        private IDataService<AppointmentModel> appointmentrepo { get; set; }

        private Uri uri = new Uri("https://localhost:44314/");

        public TaskModel taskmodel = new TaskModel()
        {
            Id = 123456,
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
            Id = 234567,
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

        [Test]
        [Category("Post")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task AddTask()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            TaskDependencyInjection();
            NUnit.Framework.Assert.DoesNotThrowAsync(async () => await taskrepo.Add(taskmodel), "not added task properly");
            var item = await taskrepo.GetAll();
            if (item.Contains(taskmodel))
            {
                await taskrepo.Delete(taskmodel.Id);
            }
        }

        [Test]
        [Category("Post")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task AddAppointment()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            AppointmentDependencyInjection();
            NUnit.Framework.Assert.DoesNotThrowAsync(async () => await appointmentrepo.Add(appointmentmodel), "not added appointment properly");
            var item = await appointmentrepo.GetAll();
            if (item.Contains(appointmentmodel))
            {
                await appointmentrepo.Delete(appointmentmodel.Id);
            }
        }
        [Test]
        [Category("Delete")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task DeleteTask()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            TaskDependencyInjection();
            await taskrepo.Add(taskmodel);
            NUnit.Framework.Assert.DoesNotThrowAsync(async () => await taskrepo.Delete(taskmodel.Id), "not deleted task properly");
            var item = await taskrepo.GetAll();
            if (item.Contains(taskmodel))
            {
                await taskrepo.Delete(taskmodel.Id);
            }
        }

        [Test]
        [Category("Delete")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task DeleteAppointment()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            AppointmentDependencyInjection();
            await appointmentrepo.Add(appointmentmodel);
            NUnit.Framework.Assert.DoesNotThrowAsync(async () => await appointmentrepo.Delete(appointmentmodel.Id), "not deleted appointment properly");
            var item = await appointmentrepo.GetAll();
            if (item.Contains(appointmentmodel))
            {
                await appointmentrepo.Delete(appointmentmodel.Id);
            }
        }

        [Test]
        [Category("GetAll")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetAllTasks()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            TaskDependencyInjection();
            NUnit.Framework.Assert.DoesNotThrowAsync(async () => await taskrepo.GetAll(), "Get all tasks not properly executed");
        }

        [Test]
        [Category("GetAll")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetAllAppointments()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            AppointmentDependencyInjection();
            NUnit.Framework.Assert.DoesNotThrowAsync(async () => await appointmentrepo.GetAll(), "Get all appointments not properly executed");
        }

        [Test]
        [Category("Get")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetTask()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            TaskDependencyInjection();
            await taskrepo.Add(taskmodel);
            NUnit.Framework.Assert.DoesNotThrowAsync(async () => await taskrepo.GetById(taskmodel.Id), "Not retrieved task properly");
            var item = await taskrepo.GetAll();
            if (item.Contains(taskmodel))
            {
                await taskrepo.Delete(taskmodel.Id);
            }
        }

        [Test]
        [Category("Get")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetAppointment()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            AppointmentDependencyInjection();
            await appointmentrepo.Add(appointmentmodel);
            NUnit.Framework.Assert.DoesNotThrowAsync(async () => await appointmentrepo.GetById(appointmentmodel.Id), "Not retrieved appointment properly");
            var item = await appointmentrepo.GetAll();
            if (item.Contains(appointmentmodel))
            {
                await appointmentrepo.Delete(appointmentmodel.Id);
            }
        }
    }
}