using BarberAppointment.GraphQLApi.Model;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.GraphQL
{
    public class ProfileType: ObjectType<Profile>
    {
        protected override void Configure(IObjectTypeDescriptor<Profile> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.FirstName).Type<StringType>();
            descriptor.Field(a => a.LastName).Type<StringType>();
            descriptor.Field(a => a.MobileNumber).Type<StringType>();
            descriptor.Field(a => a.ProfileType).Type<StringType>();
        }
    }
}
