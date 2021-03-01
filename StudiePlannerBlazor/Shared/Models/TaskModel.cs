﻿using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TaskStatus Status { get; set; }
        public string Notes { get; set; }
        public AppointmentModel Appointment { get; set; }
        public List<string> Documents { get; set; }

    }
}
