﻿using BarberAppointment.GraphQLApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.GraphQLApi.Core
{
    public interface ICustomAppointmentHour
    {
        IQueryable<CustomAppointmentHour> GetAll();
        CustomAppointmentHour Create(CreateCustomAppointmentHour createCustomAppointmentHour);
        CustomAppointmentHour Delete(DeleteCustomAppointmentHour deleteCustomAppointmentHour);
    }
}
