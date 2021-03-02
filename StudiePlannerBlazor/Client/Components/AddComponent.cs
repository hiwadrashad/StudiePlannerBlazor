using Microsoft.AspNetCore.Components;
using StudiePlannerBlazor.Client.DataService;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.Components
{
    public partial class AddComponent
    {
        public bool ShowDialog { get; set; } = true;


        public TaskModel CurrentTask { get; set; } = new TaskModel { Appointment = new AppointmentModel() { } };

        [Inject]
        public IDataService<AppointmentModel> _AppointmentDataService { get; set; }
        [Inject]
        public IDataService<CalenderModel> _CalenderDataService { get; set; }
        [Inject]
        public IDataService<TaskModel> _TaskDataService { get; set; }
        [Inject]
        public NavigationManager navmanger { get; set; }

        public async void AddTask()
        {
            await _TaskDataService.Add(CurrentTask);
            Close();
        }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }
        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {
        }
    }
}
