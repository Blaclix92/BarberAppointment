using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Core
{
    public interface IAppointmentHour
    {
        IQueryable<AppointmentHour> GetAll();
        AppointmentHour Create(CreateAppointmentHour createAppointmentHour);
        AppointmentHour Delete(DeleteAppointmentHour deleteAppointmentHour);
    }
}
