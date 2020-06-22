using BarberAppointment.GraphQLApi.Core;
using BarberAppointment.GraphQLApi.DataStore;
using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Data
{
    public class BookAppointmentRepository : IBookAppointment
    {
        private IList<BookAppointment> _bookappointments;

        public BookAppointmentRepository()
        {
            _bookappointments = CreateBookAppointments();
        }


        private static IList<BookAppointment> CreateBookAppointments()
        {
            return new List<BookAppointment>()
            {
                new BookAppointment()
                {
                    Id = 1,
                    Date = "02-04-2019",
                    Hour = "11:00 AM",
                    Cancel = 0,
                    BarberId = 2,
                    ClientId = 3
                },
                new BookAppointment()
                {
                    Id = 2,
                    Date = "10-04-2019",
                    Hour = "11:00 AM",
                    Cancel = 0,
                    BarberId = 2,
                    ClientId = 3
                },
                new BookAppointment()
                {
                    Id = 3,
                    Date = "25-04-2019",
                    Hour = "11:00 AM",
                    Cancel = 0,
                    BarberId = 2,
                    ClientId = 3
                }
            };

        }

        public BookAppointment Create(CreateBookAppointment inputBookApointment)
        {
            BookAppointment newBookAppointment = new BookAppointment() {
            Id= 99,
            BarberId = inputBookApointment.BarberId,
            Cancel = 0,
            ClientId = 1,
            Date = inputBookApointment.Date,
            Hour = inputBookApointment.Hour
            };

            _bookappointments.Add(newBookAppointment);
            return newBookAppointment;
        }

        public BookAppointment Delete(DeleteBookAppointment inputDeleteApointment)
        {
            var bookAppointmentToDelete = _bookappointments.FirstOrDefault(b => b.Id == inputDeleteApointment.Id);
            if (bookAppointmentToDelete == null) { 
                //throw new BookAppointmentNotFoundException() { BookId = inputBook.Id }; 
            }
            _bookappointments.Remove(bookAppointmentToDelete);
            return bookAppointmentToDelete;
        }

        public IQueryable<BookAppointment> GetAll()
        {
            return _bookappointments.AsQueryable(); ;
        }
    }
}
