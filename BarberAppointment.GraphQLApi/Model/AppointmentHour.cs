using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Model
{
    public class AppointmentHour
    {
        public int Id { get; set; }
        public int Custom { get; set; }
        public string Hour { get; set; }
        public int WorkDayId { get; set; }
        public int Visible { get; set; }
    }
}
