using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudiePlannerBlazor.Shared.Models
{
    public class CalenderModel
    {
        public int Id { get; set; }
        public List<TaskModel> Tasks { get; set; }    
        public IdentityUser User { get; set; }
    }
}
