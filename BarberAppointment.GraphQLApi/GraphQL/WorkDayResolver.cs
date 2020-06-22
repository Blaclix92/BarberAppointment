using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.Model;
using HotChocolate;
using HotChocolate.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.GraphQL
{
    public class WorkDayResolver
    {
        private readonly IAppointmentHour _appointmentHour;

        public WorkDayResolver([Service]IAppointmentHour appointmentHour)
        {
            _appointmentHour = appointmentHour;
        }

        public IList<AppointmentHour> GetAppointmentHours(WorkDay workDay, IResolverContext ctx)
        {
            return _appointmentHour.GetAll().Where(a => a.WorkDayId == workDay.Id).ToList();
        }
    }
}
