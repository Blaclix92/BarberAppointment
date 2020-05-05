using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAppointment.WebApi.Model.WorkDays
{
    public class WorkDayForUpdateData
    {
        [Required(ErrorMessage = "You should provide a id value.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "You should provide a day value.")]
        public string Day { get; set; }
    }
}
