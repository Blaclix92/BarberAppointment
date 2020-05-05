using BarberAppointment.WebApi.Model.BarberProfiles;
using BarberAppointment.WebApi.Model.ClientProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.WebApi.DataStore
{
    public class ProfileDataStore
    {
        public static ProfileDataStore Current { get; } = new ProfileDataStore();
        public List<BarberProfile> Profiles { get; set; }
        public ProfileDataStore()
        {
            Profiles = new List<BarberProfile>()
            {
                new BarberProfile()
                {
                    Id = 1,
                    FirstName = "blba",
                    LastName= "bb",
                    MobileNumber = "66272bis",
                    UserId = 2,
                    ClientProfiles = new List<ClientProfile>()
                    {
                        new ClientProfile()
                        {
                            Id = 1,
                            FirstName = "blba",
                            LastName= "bb",
                            MobileNumber = "66272bis",
                            UserId = 1,
                        },
                            new ClientProfile()
                        {
                            Id = 2,
                            FirstName = "jonodu",
                            LastName= "lsabd",
                            MobileNumber = "66272bis",
                            UserId = 5,
                        }
                    }
                },
                new BarberProfile()
                {
                    Id = 1,
                    FirstName = "opjdpo",
                    LastName= "dpokpdokbb",
                    MobileNumber = "66272bis",
                    UserId = 7,
                    ClientProfiles = new List<ClientProfile>()
                    {
                        new ClientProfile()
                        {
                            Id = 10,
                            FirstName = "lkelwk ",
                            LastName= "wmkznnx",
                            MobileNumber = "66272bis",
                            UserId = 9,
                        },
                            new ClientProfile()
                        {
                            Id = 20,
                            FirstName = "jonodu",
                            LastName= "lsabd",
                            MobileNumber = "66272bis",
                            UserId = 50,
                        }
                    }
                }
            };
        }
    }
}
