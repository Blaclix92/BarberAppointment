using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Model
{
    public class CreateBookAppointment
    {
        public string Date { get; set; }
        public string Hour { get; set; }
        public int BarberId { get; set; }
        public int ClientId { get; set; }
    }
}
