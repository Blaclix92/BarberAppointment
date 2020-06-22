using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.DataStore;
using BarberAppointment.GraphQLApi.Model;
using HotChocolate;
using HotChocolate.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.GraphQL
{
    public class BookAppointmentResolver
    {
        private readonly IProfile _profileService;

        public BookAppointmentResolver([Service]IProfile profileService)
        {
            _profileService = profileService;
        }

        public Profile GetBarber(BookAppointment bookAppointment, IResolverContext ctx)
        {
            return _profileService.GetAll().Where(p => p.Id == bookAppointment.BarberId).FirstOrDefault();
        }

        public Profile GetClient(BookAppointment bookAppointment, IResolverContext ctx)
        {
            return _profileService.GetAll().Where(p => p.Id == bookAppointment.ClientId).FirstOrDefault();
        }
    }
}
