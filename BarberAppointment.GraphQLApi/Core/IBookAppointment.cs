using BarberAppointment.GraphQLApi.DataStore;
using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Core
{
    public interface IBookAppointment
    {
        IQueryable<BookAppointment> GetAll();

        BookAppointment Create(CreateBookAppointment inputBookApointment);
        BookAppointment Delete( DeleteBookAppointment inputDeleteApointment);
    }
}
