using BarberAppointment.GraphQLApi.Model;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.GraphQL
{
    public class CustomAppointmentHourType : ObjectType<CustomAppointmentHour>
    {
        protected override void Configure(IObjectTypeDescriptor<CustomAppointmentHour> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Hour).Type<StringType>();
            descriptor.Field(a => a.CustomWorkDayId).Type<StringType>();
            descriptor.Field(a => a.Visible).Type<StringType>();
        }
    }
}
