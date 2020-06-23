using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Data
{
    public class CustomWorkDayRepository : ICustomWorkDay
    {
        private IList<CustomWorkDay> _customWorkDays;

        public CustomWorkDayRepository()
        {
            _customWorkDays = CreateWorkDays();
        }

        public CustomWorkDay Create(CreateCustomWorkDay createCustomWorkDay)
        {
            throw new NotImplementedException();
        }

        public CustomWorkDay Delete(DeleteCustomWorkDay deleteCustomWorkDay)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CustomWorkDay> GetAll()
        {
            return _customWorkDays.AsQueryable();
        }

        private IList<CustomWorkDay> CreateWorkDays()
        {
            return new List<CustomWorkDay>() 
            {
                new CustomWorkDay
                {
                    Id = 1,
                    Date = "12-02-2019",
                    OffDay = 0,
                    BarberId = 2,
                },
                new CustomWorkDay
                {
                    Id = 2,
                    Date = "25-02-2019",
                    OffDay = 0,
                    BarberId = 2,
                },
               new CustomWorkDay
                {
                    Id = 3,
                    Date = "25-03-2019",
                    OffDay = 0,
                    BarberId = 2
                }
            };
        }
    }
}
