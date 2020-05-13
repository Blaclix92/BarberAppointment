using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Data
{
    public class CustomWorkDayRepository
    {
        private Dictionary<string, CustomWorkDay> _customWorkDay;

        public CustomWorkDayRepository()
        {
            _customWorkDay = CreateWorkDays().ToDictionary(t => t.Id.ToString());
        }

        public Dictionary<string, CustomWorkDay> getData()
        {
            return _customWorkDay;
        }

        private static IEnumerable<CustomWorkDay> CreateWorkDays()
        {
            yield return new CustomWorkDay
            {
                Id = 1,
                Date = "12-02-2019",
                OffDay = 0,
                BarberId = 2,
                CustomAppointmentHour = new List<CustomAppointmentHour>() {
                        new CustomAppointmentHour(){ Id= 1, Visible=1, Hour="11:00 AM"},
                        new CustomAppointmentHour(){ Id= 2, Visible=1, Hour="12:00 PM"},
                        new CustomAppointmentHour(){ Id= 3, Visible=1, Hour="01:00 PM"}
                }
            };
             yield return new CustomWorkDay
                {
                    Id = 2,
                    Date = "25-02-2019",
                    OffDay = 0,
                    BarberId = 2,
                    CustomAppointmentHour = new List<CustomAppointmentHour>() {
                        new CustomAppointmentHour(){ Id= 1, Visible=1, Hour="11:00 AM"},
                        new CustomAppointmentHour(){ Id= 2, Visible=1, Hour="12:00 PM"},
                        new CustomAppointmentHour(){ Id= 3, Visible=1, Hour="01:00 PM"}
                }
                };
               yield return new CustomWorkDay
                {
                    Id = 3,
                    Date = "25-03-2019",
                    OffDay = 0,
                    BarberId = 2,
                    CustomAppointmentHour = new List<CustomAppointmentHour>() {
                        new CustomAppointmentHour(){ Id= 1, Visible=1, Hour="11:00 AM"},
                        new CustomAppointmentHour(){ Id= 2, Visible=1, Hour="12:00 PM"},
                        new CustomAppointmentHour(){ Id= 3, Visible=1, Hour="01:00 PM"}
                }
                };
        }
    }
}
