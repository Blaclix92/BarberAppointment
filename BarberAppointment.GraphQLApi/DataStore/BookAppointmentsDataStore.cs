using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.DataStore
{
    public class BookAppointmentsDataStore
    {
        public static BookAppointmentsDataStore Current { get; } = new BookAppointmentsDataStore();
        public List<BookAppointment> Appointments { get; set; }
        public BookAppointmentsDataStore()
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
