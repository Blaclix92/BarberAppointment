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
        private readonly IWorkDay _workDayService;

        public Mutation(IBookAppointment bookAppointmentService, IWorkDay workDayService)
        {
            _bookAppointmentService = bookAppointmentService;
            _workDayService = workDayService;
        }

        public BookAppointment CreateBook(CreateBookAppointment bookAppointment)
        {
            return _bookAppointmentService.Create(bookAppointment);
        }

        public BookAppointment DeleteBook(DeleteBookAppointment bookAppointment)
        {
            return _bookAppointmentService.Delete(bookAppointment);
        }

        public WorkDay CreateWorkDay(CreateWorkDay createWorkDay)
        {
            return _workDayService.CreateWorkDay(createWorkDay);
        }

        public WorkDay DeleteWorkDay(DeleteWorkDay deleteWorkDay)
        {
            return _workDayService.DeleteWorkDay(deleteWorkDay);
        } 
    }
}
