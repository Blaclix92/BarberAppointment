using BarberAppointment.WebApi.Model.BookAppoinments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.WebApi.DataStore
{
    public class BookAppointmentDataStore
    {
        public static BookAppointmentDataStore Current { get; } = new BookAppointmentDataStore();
        public List<BookAppointment> Appointments { get; set; }
        public BookAppointmentDataStore()
        {
            //init dummy data
            Appointments = new List<BookAppointment>()
            {
                new BookAppointment()
                {
                    Id = 1,
                    Date = "02-04-2019",
                    Hour = "11:00 AM",
                    Cancel= 0,
                    BarberId = 2,
                    ClientId = 3
                },
                  new BookAppointment()
                {
                    Id = 2,
                    Date = "10-04-2019",
                    Hour = "11:00 AM",
                    Cancel= 0,
                    BarberId = 2,
                    ClientId = 3
                },  new BookAppointment()
                {
                    Id = 3,
                    Date = "25-04-2019",
                    Hour = "11:00 AM",
                    Cancel= 0,
                    BarberId = 2,
                    ClientId = 3
                },
            };
        }
    }
}
