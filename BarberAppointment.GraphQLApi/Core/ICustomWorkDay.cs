using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Core
{
    public interface ICustomWorkDay
    {
        IQueryable<CustomWorkDay> GetAll();
        CustomWorkDay Create(CreateCustomWorkDay createCustomWorkDay);
        CustomWorkDay Delete(DeleteCustomWorkDay deleteCustomWorkDay);
    }
}
