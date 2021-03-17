using Microsoft.AspNetCore.Components;
using StudiePlannerBlazor.Client.Components;
using StudiePlannerBlazor.Client.DataService;
using StudiePlannerBlazor.Client.GeneralMethods;
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
        public IToastService toastService { get; set; }

        [Inject]
        public IDataService<TaskModel> TaskDataService { get; set; }
        public List<TaskModel> Tasks { get; set; } = new List<TaskModel> { };
        protected NotificationComponentStart Taskstartednotification { get; set; } = new NotificationComponentStart { ShowDialog = false};
        protected NotificationComponentEnd Tasksendednotification { get; set; } = new NotificationComponentEnd { ShowDialog = false };
        private static object Lock = new object();
        public static Timer time;
        public bool TimerInitialized;
        public void InitializeTimer()
        {
            lock (Lock)
            {
                time = new Timer();
                time.Elapsed += new System.Timers.ElapsedEventHandler(Timerexecutioncode);
                time.Interval = 1000;
                TimerInitialized = true;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            Tasks = (await TaskDataService.GetAll()).ToList();
            lock (Lock)
            {
                InitializeTimer();
                time.Start();
            }

            //<summary> apply list of logged in identity instead of all stored tasks / get identity running first
            //var users = await CalenderDataService.GetAll();
            //var currentuser = users.Where(a => a.User.Email == StaticResources.CurrentIdentityUser.identityUser.Email).FirstOrDefault();
            //Tasks = currentuser.Tasks;
            //<summary>
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
        private async void Timerexecutioncode(object sender, ElapsedEventArgs e)
        {
            var items = await TaskDataService.GetAll();
            var itemsabovecurrenttime = items.Where(a => a.StartDate > DateTime.Now);
            if (items.Where(a => a.StartDate > DateTime.Now).Any())
            {
                if (items.Where(a => a.StartDate < DateTime.Now.AddSeconds(1)).Any())
                {
                    ShowMessageStart();
                }
            }

            //var endingitemsabovecurrenttime = items.Where(a => a.EndDate > DateTime.Now);
            //if (items.Where(a => a.EndDate > DateTime.Now).Any())
            //{
            //    if (items.Where(a => a.EndDate < DateTime.Now.AddSeconds(1)).Any())
            //    {
            //        ShowMessageEnd();
            //    }
            //}
        }
    }
}
