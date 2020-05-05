using BarberAppointment.WebApi.Model.AppointmentHours;
using BarberAppointment.WebApi.Model.WorkDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.WebApi.DataStore
{
    public class WorkDaysDataStore
    {
        public static WorkDaysDataStore Current { get; } = new WorkDaysDataStore();
        public List<WorkDay> Days { get; set; }
        public WorkDaysDataStore()
        {
            //init dummy data
            Days = new List<WorkDay>()
            {
                new WorkDay
                {   Id=1,
                    Day ="Monday",
                    BarberId = 2,
                    AppointmentHours = new List<AppointmentHour>() {
                        new AppointmentHour(){ Id= 1, Hour="11:00 AM"},
                        new AppointmentHour(){ Id= 2, Hour="12:00 PM"},
                        new AppointmentHour(){ Id= 3, Hour="01:00 PM"}
                } },
                new WorkDay{
                    Id =2,
                    BarberId = 2,
                    Day ="Tuesday",
                AppointmentHours = new List<AppointmentHour>() {
                        new AppointmentHour(){ Id= 1, Hour="08:00 AM"},
                        new AppointmentHour(){ Id= 2, Hour="10:00 AM"},
                        new AppointmentHour(){ Id= 3, Hour="01:00 PM"}
                } },
                new WorkDay{
                    Id =3,
                    BarberId = 2,
                    Day ="Wednesday",
                AppointmentHours = new List<AppointmentHour>() {
                        new AppointmentHour(){ Id= 1, Hour="09:00 AM"},
                        new AppointmentHour(){ Id= 2, Hour="12:00 PM"},
                        new AppointmentHour(){ Id= 3, Hour="03:00 PM"}
                } },
            };
        }
    }
}
