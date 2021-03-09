using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudiePlannerBlazor.Shared.Models
{
    public enum TaskStatus
    {
     None,
     Busy,
     Done
    }
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AppointmentModel")]
        public int AppointmentId { get; set; }
        public AppointmentModel Appointment { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TaskStatus Status { get; set; }
        public string Notes { get; set; }
        public IEnumerable<DocumentModel> Documents { get; set; }
    }
}
