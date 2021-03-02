using Microsoft.AspNetCore.Components;
using StudiePlannerBlazor.Client.DataService;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.Pages
{
    public partial class CalenderOverviewBase : ComponentBase
    {
        [Inject]
        public IDataService<TaskModel> TaskDataService { get; set; }
        public List<TaskModel> Tasks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Tasks = (await TaskDataService.GetAll()).ToList();
        }
    }
}
