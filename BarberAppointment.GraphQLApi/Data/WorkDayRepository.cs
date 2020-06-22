using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Data
{
    public class WorkDayRepository : IWorkDay
    {
        private IList<WorkDay> _workDays;

        public WorkDayRepository()
        {
            _workDays = CreateWorkDays();
        }
        private static IList<WorkDay> CreateWorkDays()
        {
            return new List<WorkDay>()
            {
                new WorkDay
                  {
                      Id = 1,
                      Day = "Monday",
                      BarberId = 2,
                  },
                new WorkDay
                {
                    Id = 2,
                    BarberId = 2,
                    Day = "Tuesday",
                },
                new WorkDay
                {
                    Id = 3,
                    BarberId = 2,
                    Day = "Wednesday",
                }
            };
      
        }

        public WorkDay CreateWorkDay( CreateWorkDay createWorkDay)
        {
            WorkDay newWorkDay = new WorkDay()
            {
                Id = 99,
                BarberId = createWorkDay.BarberId,
                Day = createWorkDay.Day
            };

            _workDays.Add(newWorkDay);

            return newWorkDay;
        }

        public WorkDay DeleteWorkDay(DeleteWorkDay deleteWorkDay)
        {
            WorkDay workDayToDelete = _workDays.FirstOrDefault(w => w.Id == deleteWorkDay.Id);
            _workDays.Remove(workDayToDelete);

            return workDayToDelete;
        }

        public IQueryable<WorkDay> GetAll()
        {
            return _workDays.AsQueryable();
        }
    }
}
