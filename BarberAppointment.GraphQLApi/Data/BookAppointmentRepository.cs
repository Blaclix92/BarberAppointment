using BarberAppointment.GraphQLApi.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Data
{
    public class BookAppointmentRepository
    {
            private Dictionary<string, BookAppointment> _bookappointments;

            public BookAppointmentRepository()
            {
                _bookappointments = CreateBookAppointments().ToDictionary(t => t.Id.ToString());
            }

            public Dictionary<string, BookAppointment> getData()
            {
                return _bookappointments;
            } 

            private static IEnumerable<BookAppointment> CreateBookAppointments()
            {
                yield return new BookAppointment()
                {
                    Id = 1,
                    Date = "02-04-2019",
                    Hour = "11:00 AM",
                    Cancel = 0,
                    BarberId = 2,
                    ClientId = 3
                };
                yield return new BookAppointment()
                      {
                          Id = 2,
                          Date = "10-04-2019",
                          Hour = "11:00 AM",
                          Cancel = 0,
                          BarberId = 2,
                          ClientId = 3
                      };
                 yield return new BookAppointment()
                 {
                     Id = 3,
                     Date = "25-04-2019",
                     Hour = "11:00 AM",
                     Cancel = 0,
                     BarberId = 2,
                     ClientId = 3
                 };
            }
    }
}
