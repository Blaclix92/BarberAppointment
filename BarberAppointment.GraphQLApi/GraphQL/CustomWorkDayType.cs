using BarberAppointment.GraphQLApi.Model;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.GraphQL
{
    public class CustomWorkDayType : ObjectType<CustomWorkDay>
    {
        protected override void Configure(IObjectTypeDescriptor<CustomWorkDay> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Date).Type<StringType>();
            descriptor.Field(a => a.BarberId).Type<StringType>();
            descriptor.Field(a => a.OffDay).Type<StringType>();
            descriptor.Field<CustomWorkDayResolver>(t => t.GetCustomAppointmentHours(default, default));
            descriptor.Field<CustomWorkDayResolver>(t => t.GetCustomAppointmentHoursNumber(default, default));
        }
    }
}
