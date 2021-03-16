using Microsoft.AspNetCore.Components;
using StudiePlannerBlazor.Client.GeneralMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.Pages
{
    public partial class BlazoredToast
    {
        [CascadingParameter]
        private BlazoredToasts ToastContainer { get; set; }
        [Parameter]
        public Guid ToastId { get; set; }
        [Parameter]
        public ToastSettings ToastSettings { get; set; }

        private void Close()
        {
            ToastContainer.RemoveToast(ToastId);
        }
    }
}
