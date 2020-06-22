using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Data
{
    public class ProfileRepository : IProfile
    {
        private IList<Profile> _profiles;

        public ProfileRepository()
        {
            _profiles = CreateProfiles();
        }

        public IList<Profile> CreateProfiles()
        {
            return new List<Profile>() 
            {
                new Profile()
                {
                    Id = 1,
                    FirstName = "Gerson",
                    LastName = "Orman",
                    MobileNumber = "78723833",
                    ProfileType = "Client"
                },
                new Profile()
                {
                    Id = 2,
                    FirstName = "Benny",
                    LastName = "Mohan",
                    MobileNumber = "78723833",
                    ProfileType = "Barber"
                },
                new Profile()
                {
                    Id = 3,
                    FirstName = "Reshma",
                    LastName = "Orman",
                    MobileNumber = "78723833",
                    ProfileType = "Client"
                },
            };

        }

        public IQueryable<Profile> GetAll()
        {
            return _profiles.AsQueryable();
        }
    }
}
