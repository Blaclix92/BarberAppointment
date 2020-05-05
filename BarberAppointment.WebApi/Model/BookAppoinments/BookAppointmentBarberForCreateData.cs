using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.WebApi.Model.BookAppoinments
{
    public class BookAppointmentBarberForCreateData
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public string Hour { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}
