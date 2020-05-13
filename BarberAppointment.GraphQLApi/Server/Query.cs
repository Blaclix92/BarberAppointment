using BarberAppointment.GraphQLApi.Data;
using BarberAppointment.GraphQLApi.DataStore;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Server
{
    public class Query
    {
        public Dictionary<string, BookAppointment> BookAppointments() => new BookAppointmentRepository().getData();
     
    }
}
