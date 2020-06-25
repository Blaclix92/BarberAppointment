using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Data
{
    public class AppointmentHourRepository: IAppointmentHour
    {
        private IList<AppointmentHour> _appointmentHours;

        public AppointmentHourRepository()
        {
            _appointmentHours = CreateAppointmentHours();
        }

        public AppointmentHour Create(CreateAppointmentHour createAppointmentHour)
        {
            AppointmentHour newAppointmentHour = new AppointmentHour()
            {
                Id = 99,
                Hour = createAppointmentHour.Hour,
                WorkDayId = createAppointmentHour.WorkId
            };

            _appointmentHours.Add(newAppointmentHour);
            return newAppointmentHour;
        }

        public IList<AppointmentHour> CreateAppointmentHours()
        {
            return new List<AppointmentHour>()
            {
                   new AppointmentHour(){ Id= 1, Hour="11:00 AM", WorkDayId = 1},
                   new AppointmentHour(){ Id= 2, Hour="12:00 PM", WorkDayId = 1},
                   new AppointmentHour(){ Id= 3, Hour="01:00 PM", WorkDayId = 1},
                   new AppointmentHour(){ Id= 1, Hour="08:00 AM", WorkDayId = 2},
                   new AppointmentHour(){ Id= 2, Hour="10:00 AM", WorkDayId = 2},
                   new AppointmentHour(){ Id= 3, Hour="01:00 PM", WorkDayId = 2},
                   new AppointmentHour(){ Id= 1, Hour="09:00 AM", WorkDayId = 3},
                   new AppointmentHour(){ Id= 2, Hour="12:00 PM", WorkDayId = 3},
                   new AppointmentHour(){ Id= 3, Hour="03:00 PM", WorkDayId = 3}
            };
        }

        public AppointmentHour Delete(DeleteAppointmentHour deleteAppointmentHour)
        {
            AppointmentHour appointmentHourToDelete = _appointmentHours.FirstOrDefault(w => w.Id == deleteAppointmentHour.Id);
            _appointmentHours.Remove(appointmentHourToDelete);

            return appointmentHourToDelete;
        }

        public IQueryable<AppointmentHour> GetAll()
        {
            return _appointmentHours.AsQueryable(); ;
        }
    }
}
