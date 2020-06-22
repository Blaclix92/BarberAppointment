using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.DataStore;
using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.GraphQL
{
    public class Mutation
    {
        private readonly IBookAppointment _bookAppointmentService;

        public Mutation(IBookAppointment bookAppointmentService)
        {
            _bookAppointmentService = bookAppointmentService;
        }

        public BookAppointment CreateBook(CreateBookAppointment bookAppointment)
        {
            return _bookAppointmentService.Create(bookAppointment);
        }

        public BookAppointment DeleteBook(DeleteBookAppointment bookAppointment)
        {
            return _bookAppointmentService.Delete(bookAppointment);
        }
    }
}
