using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Model
{
    public class WorkDay
    {
        public int Id { get; set; }
        public int Custom { get; set; }
        public string Day { get; set; }
        public int BarberId { get; set; }
        public string Date { get; set; }
        public int OffDay { get; set; }
    }
}
