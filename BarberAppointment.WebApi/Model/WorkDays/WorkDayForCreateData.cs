using BarberAppointment.WebApi.Model.AppointmentHours;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.WebApi.Model.WorkDays
{
    public class WorkDayForCreateData
    {
        [Required(ErrorMessage = "You should provide a day value.")]
        public string Day { get; set; }
        [Required(ErrorMessage = "You should provide a barber id value.")]
        public int BarberId { get; set; }
        [Required(ErrorMessage = "You should provide a collection of hour values.")]
        public ICollection<AppointmentHour> AppointmentHours { get; set; } = new List<AppointmentHour>();
    }
}
