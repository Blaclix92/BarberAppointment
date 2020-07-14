using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Model
{
    public class CreateCustomAppointmentHour
    {
        public int Visible { get; set; }
        public string Hour { get; set; }
        public int WorkDayId { get; set; }
    }
}
