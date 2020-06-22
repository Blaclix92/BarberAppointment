using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Model
{
    public class CreateAppointmentHour
    {
        public int WorkId { get; set; }
        public string Hour { get; set; }
    }
}
