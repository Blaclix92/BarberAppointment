using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.WebApi.Model.CustomWorkDays
{
    public class CustomWorkDayForUpdateData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OffDay { get; set; }
    }
}
