using BarberAppointment.GraphQLApi.DataStore;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.GraphQL
{
    public class BookAppointmentType : ObjectType<BookAppointment>
    {
        protected override void Configure(IObjectTypeDescriptor<BookAppointment> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.BarberId).Type<StringType>();
            descriptor.Field(a => a.ClientId).Type<StringType>();
            descriptor.Field(a => a.Date).Type<StringType>();
            descriptor.Field(a => a.Cancel).Type<StringType>();
            descriptor.Field<BookAppointmentResolver>(t => t.GetBarber(default, default));
            descriptor.Field<BookAppointmentResolver>(t => t.GetClient(default, default));
        }
    }
}
