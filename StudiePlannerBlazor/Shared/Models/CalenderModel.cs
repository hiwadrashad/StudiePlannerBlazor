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
#nullable enable
        public string? UserId { get; set; }
        //[NotMapped]
        //public List<int>? TaskId { get; set; }
#nullable disable
        //[ForeignKey("TaskId")]
        //public List<TaskModel> Tasks { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
