using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Model
{
    public class CreateWorkDay
    {
        public string Day { get; set; }
        public int BarberId { get; set; }
    }
}
