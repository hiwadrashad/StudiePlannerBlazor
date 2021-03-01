using System;
using System.Collections.Generic;
using System.Text;

namespace StudiePlannerBlazor.Shared.Models
{
    public class Appointment
    {
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public bool PersonalContact { get; set; }
        public DateTime Date { get; set; }
    }
}
