using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BarberAppointment.WebApi.DataStore;
using BarberAppointment.WebApi.Model.CustomAppointmentHours;
using BarberAppointment.WebApi.Model.CustomWorkDays;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BarberAppointment.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    public class CustomAppointmentHourController : ControllerBase
    {
        [Route("api/customworkdays/{customworkdayId}/customappointmenthours")]
        [HttpGet()]
        public IActionResult GetAppointmentHours(int customworkdayId)
        {
            CustomWorkDay customworkDay = CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId);
            if (customworkDay == null)
            {
                return NotFound();
            }
            return Ok(customworkDay.CustomAppointmentHour);
        }

        [Route("api/barber/customworkdays/{customworkdayId}/customappointmenthours")]
        [HttpGet()]
        [Authorize(Roles = "barber")]
        public IActionResult GetAppointmentHoursForBarbers(int customworkdayId)
        {
            ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;
            int barberId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            List<CustomAppointmentHour> customAppointmentHours = CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId && wd.BarberId == barberId).CustomAppointmentHour.ToList();
            if (customAppointmentHours == null || customAppointmentHours.Count == 0)
            {
                return NotFound();
            }
            return Ok(customAppointmentHours);
        }

        [Route("api/client/customworkdays/{customworkdayId}/customappointmenthours")]
        [HttpGet()]
        [Authorize(Roles = "client")]
        public IActionResult GetAppointmentHoursForClients(int customworkdayId)
        {
            ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;
            int clientId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            int barberId = 2;//TODO: find barberId with clientId
            List<CustomAppointmentHour> customAppointmentHours = CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId && wd.BarberId == barberId).CustomAppointmentHour.ToList();
            if (customAppointmentHours == null || customAppointmentHours.Count == 0)
            {
                return NotFound();
            }
            return Ok(customAppointmentHours);
        }

        [Route("api/customworkdays/{customworkdayId}/customappointmenthours")]
        [HttpGet("{id}", Name = "GetCustomAppointmentHourById")]
        [Authorize(Roles = "admin")]
        public IActionResult GetCustomAppointmentHourById(int customworkdayId, int id)
        {
            CustomAppointmentHour customAppointmentHour = CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId).CustomAppointmentHour.FirstOrDefault(ah => ah.Id == id);
            if (customAppointmentHour == null)
            {
                return NotFound();
            }
            return Ok(customAppointmentHour);
        }

        [Route("api/barber/customworkdays/{customworkdayId}/customappointmenthours")]
        [HttpGet("{id}", Name = "GetCustomAppointmentHourByIdForBarber")]
        public IActionResult GetCustomAppointmentHourByIdForBarber(int customworkdayId, int id)
        {
            ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;
            int barberId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            CustomAppointmentHour customAppointmentHour = CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId && wd.BarberId == barberId).CustomAppointmentHour.FirstOrDefault(ah => ah.Id == id);
            if (customAppointmentHour == null)
            {
                return NotFound();
            }
            return Ok(customAppointmentHour);
        }

        [Route("api/client/customworkdays/{customworkdayId}/customappointmenthours")]
        [HttpGet("{id}", Name = "GetCustomAppointmentHourByIdForClient")]
        public IActionResult GetCustomAppointmentHourByIdForClient(int customworkdayId, int id)
        {
            ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;
            int clientId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            int barberId = 2;//Todo find barberId with clienrId
            CustomAppointmentHour customAppointmentHour = CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId && wd.BarberId == barberId).CustomAppointmentHour.FirstOrDefault(ah => ah.Id == id);
            if (customAppointmentHour == null)
            {
                return NotFound();
            }
            return Ok(customAppointmentHour);
        }

        [Route("api/customworkdays/{customworkdayId}/customappointmenthours")]
        [HttpPost()]
        public IActionResult CreateCustomAppointmentHour(int customworkdayId, [FromBody] CustomAppointmentHourForCreateData data)
        {
            ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;
            string role = claimsPrincipal.FindFirst("role").Value;
            int barberId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            if (!role.Equals("client"))
            {
                CustomWorkDay customWorkday = role.Equals("admin") ? CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId) :
                    CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId && wd.BarberId == barberId);
                if (customWorkday == null)
                {
                    return NotFound();
                }
                int maxCustomAppointmentHourId = CustomWorkDaysDataStore.Current.Days.SelectMany(wd => wd.CustomAppointmentHour).Max(ah => ah.Id);

                CustomAppointmentHour newCustomAppointmentHour = new CustomAppointmentHour()
                {
                    Id = ++maxCustomAppointmentHourId,
                    Visible = data.Visible,
                    Hour = data.Hour
                };
                customWorkday.CustomAppointmentHour.Add(newCustomAppointmentHour);
                return CreatedAtRoute(role.Equals("admin") ? "GetCustomAppointmentHourById" : "GetCustomAppointmentHourByIdForBarber", new { customworkdayId, id = newCustomAppointmentHour.Id }, newCustomAppointmentHour);
            }
            return Unauthorized();
        }

        [Route("api/customworkdays/{customworkdayId}/customappointmenthours")]
        [HttpPut("{id}")]
        public IActionResult UpdateAppointmentHour(int customworkdayId, int id, [FromBody] CustomAppointmentHourForUpdateData data)
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            string role = claimsPrincipal.FindFirst("role").Value;
            int barberId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            if (!role.Equals("client"))
            {
                CustomAppointmentHour customAppointmentHour = role.Equals("admin") ? CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId).CustomAppointmentHour.FirstOrDefault(ah => ah.Id == id) :
                    CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId && wd.BarberId == barberId).CustomAppointmentHour.FirstOrDefault(ah => ah.Id == id);
                if (customAppointmentHour == null)
                {
                    return NotFound();
                }
                customAppointmentHour.Hour = data.Hour;
                customAppointmentHour.Visible = data.Visible;
                return NoContent();
            }
            return Unauthorized();
        }

        [Route("api/customworkdays/{customworkdayId}/customappointmenthours")]
        [HttpPatch("{id}")]
        public IActionResult PatchAppointmentHour(int customworkdayId, int id, [FromBody] JsonPatchDocument<CustomAppointmentHourForUpdateData> patchDoc)
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            string role = claimsPrincipal.FindFirst("role").Value;
            int barberId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            if (!role.Equals("client"))
            {
                CustomAppointmentHour customAppointmentHour = role.Equals("admin") ? CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId).CustomAppointmentHour.FirstOrDefault(ah => ah.Id == id) :
                    CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId && wd.BarberId == barberId).CustomAppointmentHour.FirstOrDefault(ah => ah.Id == id);
                if (customAppointmentHour == null)
                {
                    return NotFound();
                }
                CustomAppointmentHourForUpdateData patchData = new CustomAppointmentHourForUpdateData()
                {
                    Hour = customAppointmentHour.Hour,
                    Visible = customAppointmentHour.Visible
                };

                patchDoc.ApplyTo(patchData);
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                customAppointmentHour.Hour = patchData.Hour;
                customAppointmentHour.Visible = patchData.Visible;
                return NoContent();
            }
            return Unauthorized();
        }

        [Route("api/customworkdays/{customworkdayId}/customappointmenthours")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointmentHourById(int customworkdayId, int id)
        {
            ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;
            string role = claimsPrincipal.FindFirst("role").Value;
            int barberId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            if (!role.Equals("client"))
            {
                CustomAppointmentHour customAppointmentHour = role.Equals("admin") ? CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId).CustomAppointmentHour.FirstOrDefault(ah => ah.Id == id) :
                    CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId && wd.BarberId == barberId).CustomAppointmentHour.FirstOrDefault(ah => ah.Id == id);
                if (customAppointmentHour == null)
                {
                    return NotFound();
                }
                CustomWorkDaysDataStore.Current.Days.FirstOrDefault(wd => wd.Id == customworkdayId).CustomAppointmentHour.Remove(customAppointmentHour);
                return NoContent();
            }
            return Unauthorized();
        }
    }
}