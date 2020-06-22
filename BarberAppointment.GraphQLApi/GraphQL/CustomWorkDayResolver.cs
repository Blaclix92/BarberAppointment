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
    public class CustomWorkDayResolver
    {
        private readonly ICustomAppointmentHour _customAppointmentHour;

        public CustomWorkDayResolver([Service]ICustomAppointmentHour customAppointmentHour )
        {
            _customAppointmentHour = customAppointmentHour;
        }

        public IList<CustomAppointmentHour> GetCustomAppointmentHours(CustomWorkDay customWorkDay, IResolverContext ctx)
        {
            return _customAppointmentHour.GetAll().Where(a => a.CustomWorkDayId == customWorkDay.Id).ToList();
        }

        public int GetCustomAppointmentHoursNumber(CustomWorkDay customWorkDay, IResolverContext ctx)
        {
            return _customAppointmentHour.GetAll().Where(a => a.CustomWorkDayId == customWorkDay.Id).Count();
        }
    }
}
