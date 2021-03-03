using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Components;
using StudiePlannerBlazor.Client.DataService;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.Pages
{
    public partial class AddTask
    {
        [Inject]
        public IDataService<TaskModel> TaskDataService { get; set; }
        [Inject]
        public IDataService<AppointmentModel> AppointmentDataService { get; set; }
        [Inject]
        public IDataService<CalenderModel> CalenderDataService { get; set; }
        [Inject]
        public NavigationManager NavManager { get; set; }
        public TaskModel model { get; set; } = new TaskModel { Appointment = new AppointmentModel { } };

    }
}
