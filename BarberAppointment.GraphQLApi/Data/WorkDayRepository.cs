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
                      Custom = 0,
                      Date = null,
                      OffDay = 0
                  },
                new WorkDay
                {
                    Id = 2,
                    BarberId = 2,
                    Day = "Tuesday",
                    Custom = 0,
                    Date = null,
                    OffDay = 0
                },
                new WorkDay
                {
                    Id = 3,
                    BarberId = 2,
                    Day = "Wednesday",
                    Custom = 0,
                    Date = null,
                    OffDay = 0
                },
                    new WorkDay()
                {
                    Id = 4,
                    BarberId = 2,
                    Day = null,
                    Custom = 1,
                    Date = "30-04-2019",
                    OffDay = 0
                }
            };
      
        }

        public WorkDay CreateCustomWorkDay(CreateCustomWorkDay createCustomWorkDay)
        {
            WorkDay newWorkDay = new WorkDay()
            {
                Id = 99,
                BarberId = createCustomWorkDay.BarberId,
                Day = null,
                Custom = 1,
                Date = createCustomWorkDay.Date,
                OffDay = createCustomWorkDay.OffDay
            };

            _workDays.Add(newWorkDay);

            return newWorkDay;
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
