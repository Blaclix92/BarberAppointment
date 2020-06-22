using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.DataStore;
using BarberAppointment.GraphQLApi.Model;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.GraphQL
{
    public class Query
    {
        private readonly IBookAppointment _bookAppointment;
        private readonly IProfile _profile;
        private readonly IWorkDay _workDay;
        private readonly ICustomWorkDay _customWorkDay;

        public Query(IBookAppointment bookAppointment, IProfile profile, IWorkDay workDay, ICustomWorkDay customWorkDay)
        {
            _bookAppointment = bookAppointment;
            _workDay = workDay;
            _customWorkDay = customWorkDay;
            _profile = profile;
        }

        [UsePaging(SchemaType = typeof(BookAppointmentType))]
        [UseFiltering]
        public IQueryable<BookAppointment> BookAppointments=> _bookAppointment.GetAll();

        [UsePaging(SchemaType = typeof(WorkDayType))]
        [UseFiltering]
        public IQueryable<WorkDay> WorkDays => _workDay.GetAll();

        [UsePaging(SchemaType = typeof(CustomWorkDayType))]
        [UseFiltering]
        public IQueryable<CustomWorkDay> CustomWorkDays => _customWorkDay.GetAll();

        [UsePaging(SchemaType = typeof(BookAppointmentType))]
        [UseFiltering]
        public IQueryable<Profile> Profiles => _profile.GetAll();
    }
}
