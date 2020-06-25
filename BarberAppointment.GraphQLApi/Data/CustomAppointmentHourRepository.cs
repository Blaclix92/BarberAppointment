using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Data
{
    public class CustomAppointmentHourRepository : ICustomAppointmentHour
    {
        private IList<CustomAppointmentHour> _customAppointmentHours;

        public CustomAppointmentHourRepository()
        {
            _customAppointmentHours = CreateAppointmentHours();
        }

        public CustomAppointmentHour Create(CreateCustomAppointmentHour createCustomAppointmentHour)
        {
            CustomAppointmentHour newCustomAppointmentHour = new CustomAppointmentHour()
            {
                Id = 99,
                Hour = createCustomAppointmentHour.Hour,
                CustomWorkDayId = createCustomAppointmentHour.CustomWorkDayId,
                Visible = 1
            };

            _customAppointmentHours.Add(newCustomAppointmentHour);
            return newCustomAppointmentHour;
        }

        public IList<CustomAppointmentHour> CreateAppointmentHours()
        {
            return new List<CustomAppointmentHour>()
            {
                new CustomAppointmentHour(){ Id= 1, Visible=1, Hour="11:00 AM", CustomWorkDayId= 1},
                new CustomAppointmentHour(){ Id= 2, Visible=1, Hour="12:00 PM", CustomWorkDayId= 1},
                new CustomAppointmentHour(){ Id= 3, Visible=1, Hour="01:00 PM", CustomWorkDayId= 1},
                new CustomAppointmentHour(){ Id= 1, Visible=1, Hour="11:00 AM", CustomWorkDayId= 2},
                new CustomAppointmentHour(){ Id= 2, Visible=1, Hour="12:00 PM", CustomWorkDayId= 2},
                new CustomAppointmentHour(){ Id= 3, Visible=1, Hour="01:00 PM", CustomWorkDayId= 2},
                new CustomAppointmentHour(){ Id= 1, Visible=1, Hour="11:00 AM", CustomWorkDayId= 3},
                new CustomAppointmentHour(){ Id= 2, Visible=1, Hour="12:00 PM", CustomWorkDayId= 3},
                new CustomAppointmentHour(){ Id= 3, Visible=1, Hour="01:00 PM", CustomWorkDayId= 3}
            };
        }

        public CustomAppointmentHour Delete(DeleteCustomAppointmentHour deleteCustomAppointmentHour)
        {
            CustomAppointmentHour customAppointmentHourToDelete = _customAppointmentHours.FirstOrDefault(w => w.Id == deleteCustomAppointmentHour.Id);
            _customAppointmentHours.Remove(customAppointmentHourToDelete);

            return customAppointmentHourToDelete;
        }

        public IQueryable<CustomAppointmentHour> GetAll()
        {
            return _customAppointmentHours.AsQueryable();
        }
    }
}
