using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BarberAppointment.WebApi.DataStore;
using BarberAppointment.WebApi.Model.CustomWorkDays;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BarberAppointment.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    public class CustomWorkDayController : ControllerBase
    {
        [Route("api/customworkdays")]
        [HttpGet]
        public IActionResult GetCustomWorkDays()
        {
            return Ok(CustomWorkDaysDataStore.Current.Days);
        }

        [Route("api/customworkdays")]
        [HttpGet("{id}", Name = "GetCustomWorkDayById")]
        [Authorize(Roles = "admin")]
        public IActionResult GetCustomWorkDayById(int id)
        {
            CustomWorkDay workDay = CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == id);
            if (workDay == null)
            {
                return NotFound();
            }
            return Ok(workDay);
        }

        [Route("api/barber/customworkdays")]
        [HttpGet("{id}", Name = "GetCustomWorkDayByIdForBarber")]
        [Authorize(Roles = "barber")]
        public IActionResult GetCustomWorkDayByIdForBarber(int id)
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            int barberId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            CustomWorkDay workDay = CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == id && wd.BarberId == barberId);
            if (workDay == null)
            {
                return NotFound();
            }
            return Ok(workDay);
        }

        [Route("api/barber/customworkdays")]
        [HttpGet("{date}", Name = "GetCustomWorkDayByDateForBarber")]
        [Authorize(Roles = "barber")]
        public IActionResult GetCustomWorkDayByDateForBarber(string date)
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            int barberId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            CustomWorkDay workDay = CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.BarberId == barberId && wd.Date == date);
            if (workDay == null)
            {
                return NotFound();
            }
            return Ok(workDay);
        }

        [Route("api/client/customworkdays")]
        [HttpGet("{date}", Name = "GetCustomWorkDayByDateForClient")]
        public IActionResult GetCustomWorkDayByDateForClient(string date)
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            int clientId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            int barberId = 2; // find barber id with client id
            CustomWorkDay workDay = CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.BarberId == barberId && wd.Date == date);
            if (workDay == null)
            {
                return NotFound();
            }
            return Ok(workDay);
        }

        [Route("api/customworkdays")]
        [HttpPost]
        public IActionResult CreateCustomWorkDay([FromBody] CustomWorkDayForCreateData data)
        {
            ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;
            string role = claimsPrincipal.FindFirst("role").Value;
            if (!role.Equals("client"))
            {
                var maxCustomWorkDayId = WorkDaysDataStore.Current.Days.Max(wd => wd.Id);
                var newCustomWorkDay = new CustomWorkDay()
                {
                    Id = ++maxCustomWorkDayId,
                    OffDay = data.OffDay,
                    Date = data.Date,
                    BarberId = data.BarberId,
                    CustomAppointmentHour = data.CustomAppointmentHour
                };
                CustomWorkDaysDataStore.Current.Days.Add(newCustomWorkDay);
                return CreatedAtRoute(role.Equals("admin") ? "GetCustomWorkDayById" : "GetCustomWorkDayByIdForBarber", new { newCustomWorkDay.Id }, newCustomWorkDay);
            }
            return Unauthorized();
        }

        [Route("api/customworkdays")]
        [HttpPut()]
        public IActionResult UpdateWorkDay([FromBody] CustomWorkDayForUpdateData data)
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            var role = claimsPrincipal.FindFirst("role").Value;
            if (!role.Equals("client"))
            {
                CustomWorkDay customworkDay = CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == data.Id);
                if (customworkDay == null)
                {
                    return NotFound();
                }
                customworkDay.OffDay = data.OffDay;
                return NoContent();
            }
            return Unauthorized();
        }

        [Route("api/customworkdays")]
        [HttpPatch("{id}")]
        public IActionResult PatchWorkDay(int id, [FromBody] JsonPatchDocument<CustomWorkDayForUpdateData> patchDoc)
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            int barberId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            string role = claimsPrincipal.FindFirst("role").Value;
            if (!role.Equals("client"))
            {
                CustomWorkDay customWorkDay = role.Equals("admin") ? CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == id) :
                CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == id && wd.BarberId == barberId);
                if (customWorkDay == null)
                {
                    return NotFound();
                }
                CustomWorkDayForUpdateData patchCustomWorkDay = new CustomWorkDayForUpdateData()
                {
                    OffDay = customWorkDay.OffDay,
                };

                patchDoc.ApplyTo(patchCustomWorkDay);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                customWorkDay.OffDay = patchCustomWorkDay.OffDay;
                return NoContent();
            }
            return Unauthorized();
        }

        [Route("api/customworkdays")]
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkDay(int id)
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            var role = claimsPrincipal.FindFirst("role").Value;
            int barberId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            if (!role.Equals("client"))
            {
                CustomWorkDay customWorkDay = role.Equals("admin") ? CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == id) :
                CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == id && wd.BarberId == barberId);
                if (customWorkDay == null)
                {
                    return NotFound();
                }
                CustomWorkDaysDataStore.Current.Days.Remove(customWorkDay);
                return NoContent();
            }
            return Unauthorized();
        }
    }
}