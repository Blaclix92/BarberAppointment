using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.WebApi.Model.CustomAppointmentHours
{
    public class CustomAppointmentHourForCreateData
    {
        [Required]
        public int Visible { get; set; }
        [Required]
        public string Hour { get; set; }
    }
}
