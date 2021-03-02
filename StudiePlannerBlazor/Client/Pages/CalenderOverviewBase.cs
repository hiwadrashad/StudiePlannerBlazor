using Microsoft.AspNetCore.Components;
using StudiePlannerBlazor.Client.Components;
using StudiePlannerBlazor.Client.DataService;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace StudiePlannerBlazor.Client.Pages
{
    public partial class CalenderOverviewBase : ComponentBase
    {
        [Inject]
        public IDataService<TaskModel> TaskDataService { get; set; }
        public List<TaskModel> Tasks { get; set; }
        private Timer time;
        protected NotificationComponentStart Taskstartednotification { get; set; } = new NotificationComponentStart { ShowDialog = false};
        protected NotificationComponentEnd Tasksendednotification { get; set; } = new NotificationComponentEnd { ShowDialog = false };

        protected override async Task OnInitializedAsync()
        {
            time = new Timer();
            time.Elapsed += new System.Timers.ElapsedEventHandler(Timerexecutioncode);
            time.Interval = 60000;
            time.Start();

            Tasks = (await TaskDataService.GetAll()).ToList();
            Taskstartednotification.ShowDialog = true;
        }

        protected void ShowMessageStart()
        {
            Taskstartednotification.ShowDialog = true;
            StateHasChanged();
        }

        protected void CancelMessageStart()
        {
            Taskstartednotification.ShowDialog = false;
            StateHasChanged();
        }

        protected void ShowMessageEnd()
        {
            Tasksendednotification.ShowDialog = true;
            StateHasChanged();
        }

        protected void CancelMessageEnd()
        {
            Tasksendednotification.ShowDialog = false;
            StateHasChanged();
        }
        private async void Timerexecutioncode(object sender, EventArgs e)
        {
            var items = await TaskDataService.GetAll();
            if (items.Where(a => a.StartDate == DateTime.Now).Any())
            {
                var itemtoshow = items.Where(a => a.StartDate == DateTime.Now).FirstOrDefault();
                string texttoshow = itemtoshow.Name = " " + "has started";
                Taskstartednotification.TextToShow = texttoshow;
                ShowMessageStart();
            }
            if (Taskstartednotification.ShowDialog == false)
            {
                var itemtoshow = items.Where(a => a.EndDate == DateTime.Now).FirstOrDefault();
                string texttoshow = itemtoshow.Name = " " + "has ended";
                Tasksendednotification.TextToShow = texttoshow;
                ShowMessageEnd();
            }
        }
    }
}
