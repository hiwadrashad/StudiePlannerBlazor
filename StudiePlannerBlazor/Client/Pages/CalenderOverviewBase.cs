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
        protected AddComponent AddComponent { get; set; }
        protected EditComponent EditComponent { get; set; }

        private Timer time;
        protected NotificationComponentStart taskstartednotification { get; set; } = new NotificationComponentStart { ShowDialog = false };
        protected NotificationComponentEnd tasksendednotification { get; set; } = new NotificationComponentEnd { ShowDialog = false };

        protected override async Task OnInitializedAsync()
        {
            time = new Timer();
            time.Elapsed += new System.Timers.ElapsedEventHandler(timerexecutioncode);
            time.Interval = 60000;
            time.Start();

            Tasks = (await TaskDataService.GetAll()).ToList();
        }

        protected void ShowMessageStart()
        {
            taskstartednotification.ShowDialog = true;
            StateHasChanged();
        }

        protected void CancelMessageStart()
        {
            taskstartednotification.ShowDialog = false;
            StateHasChanged();
        }

        protected void ShowMessageEnd()
        {
            tasksendednotification.ShowDialog = true;
            StateHasChanged();
        }

        protected void CancelMessageEnd()
        {
            tasksendednotification.ShowDialog = false;
            StateHasChanged();
        }
        private async void timerexecutioncode(object sender, EventArgs e)
        {
            var items = await TaskDataService.GetAll();
            if (items.Where(a => a.StartDate == DateTime.Now).Any())
            {
                var itemtoshow = items.Where(a => a.StartDate == DateTime.Now).FirstOrDefault();
                string texttoshow = itemtoshow.Name = " " + "has started";
                taskstartednotification.TextToShow = texttoshow;
                ShowMessageStart();
            }
            if (taskstartednotification.ShowDialog == false)
            {
                var itemtoshow = items.Where(a => a.EndDate == DateTime.Now).FirstOrDefault();
                string texttoshow = itemtoshow.Name = " " + "has ended";
                tasksendednotification.TextToShow = texttoshow;
                ShowMessageEnd();
            }
        }

        protected void AddTask()
        {
            AddComponent.Show();
        }
        protected void EditTask()
        {
            EditComponent.Show();
        }
    }
}
