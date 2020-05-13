using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Model
{
    public class CustomWorkDay
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int OffDay { get; set; }
        public int BarberId { get; set; }
        public int NumberOfAppointment { get { return CustomAppointmentHour.Count(); } }
        public ICollection<CustomAppointmentHour> CustomAppointmentHour { get; set; } = new List<CustomAppointmentHour>();
    }
}
