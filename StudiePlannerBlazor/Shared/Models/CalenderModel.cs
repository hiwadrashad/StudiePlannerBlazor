using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudiePlannerBlazor.Shared.Models
{
    public class CalenderModel
    {
        [Key]
        public int CalenderId { get; set; }
        //[ForeignKey("Task")]
        //[NotMapped]
        //public List<int> TaskIds { get; set; }
        //[ForeignKey("User")]
        //public string UserId { get; set; }
        public List<TaskModel> Tasks { get; set; }

        public ApplicationUser User { get; set; }
    }
}
