using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.WebApi.Model.CustomAppointmentHours
{
    public class CustomAppointmentHour
    {
        public int Id { get; set; }
        public int Visible { get; set; }
        public string Hour { get; set; }
    }
}
