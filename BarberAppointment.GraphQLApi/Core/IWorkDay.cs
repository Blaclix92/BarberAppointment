using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Core
{
    public interface IWorkDay
    {
        IQueryable<WorkDay> GetAll();
        WorkDay CreateWorkDay(CreateWorkDay createWorkDay);
        WorkDay DeleteWorkDay(DeleteWorkDay deleteWorkDay);
    }
}
