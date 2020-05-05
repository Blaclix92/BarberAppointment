using BarberAppointment.WebApi.Model.BookAppoinments;
using BarberAppointment.WebApi.Model.ClientProfiles;
using BarberAppointment.WebApi.Model.CustomWorkDays;
using BarberAppointment.WebApi.Model.WorkDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.WebApi.Model.BarberProfiles
{
    public class BarberProfile
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<WorkDay> WorkDays { get; set; } = new List<WorkDay>();
        public ICollection<CustomWorkDay> CustomWorkDays { get; set; } = new List<CustomWorkDay>();
        public ICollection<BookAppointment> BookAppoinments { get; set; } = new List<BookAppointment>();
        public ICollection<ClientProfile> ClientProfiles { get; set; } = new List<ClientProfile>();
        public int UserId { get; set; }
    }
}
