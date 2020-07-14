using BarberAppointment.GraphQLApi.Model;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.GraphQL
{
    public class WorkDayType: ObjectType<WorkDay>
    {
        protected override void Configure(IObjectTypeDescriptor<WorkDay> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Custom).Type<StringType>();
            descriptor.Field(a => a.Day).Type<StringType>();
            descriptor.Field(a => a.BarberId).Type<StringType>();
            descriptor.Field(a => a.Date).Type<StringType>();
            descriptor.Field(a => a.OffDay).Type<StringType>();
            descriptor.Field<WorkDayResolver>(t => t.GetAppointmentHours(default, default));
            descriptor.Field<WorkDayResolver>(t => t.GetAppointmentHoursNumber(default, default));
    }

    }
}
