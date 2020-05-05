using BarberAppointment.WebApi.Model.AppointmentHours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.WebApi.Model.WorkDays
{
    public class WorkDay
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public int BarberId { get; set; }
        public int NumberOfAppointmentHours { get { return AppointmentHours.Count; } }
        public ICollection<AppointmentHour> AppointmentHours { get; set; } = new List<AppointmentHour>();
    }
}
