using BarberAppointment.GraphQLApi.Model;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.GraphQL
{
    public class AppointmentHourType : ObjectType<AppointmentHour>
    {
        protected override void Configure(IObjectTypeDescriptor<AppointmentHour> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Custom).Type<StringType>();
            descriptor.Field(a => a.WorkDayId).Type<StringType>();
            descriptor.Field(a => a.Hour).Type<StringType>();
            descriptor.Field(a => a.Visible).Type<StringType>();
        }
    }
}
