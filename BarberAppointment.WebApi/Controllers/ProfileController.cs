using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BarberAppointment.WebApi.DataStore;
using BarberAppointment.WebApi.Model.ClientProfiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberAppointment.WebApi.Controllers
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [Route("api/client/profile")]
        [HttpGet]
        [Authorize(Roles = "client")]
        public IActionResult GetClientProfile()
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            int userId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            int barberId = 2;
            string role = claimsPrincipal.FindFirst("role").Value;
            ClientProfile profile = ProfileDataStore.Current.Profiles.FirstOrDefault(p => p.UserId == barberId).ClientProfiles.FirstOrDefault(cp => cp.UserId == userId);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("api/barber/profile")]
        [HttpGet]
        [Authorize(Roles = "barber")]
        public IActionResult GetBarberProfiles()
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            int userId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            string role = claimsPrincipal.FindFirst("role").Value;
            List<ClientProfile> profiles = ProfileDataStore.Current.Profiles.FirstOrDefault(p => p.UserId == userId).ClientProfiles.ToList();
            if (profiles == null || profiles.Count == 0)
            {
                return NotFound();
            }
            return Ok(profiles);
        }

        [Route("api/barber/profile/{id}")]
        [HttpGet]
        [Authorize(Roles = "barber")]
        public IActionResult GetBarberProfileById(int id)
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            int userId = int.Parse(claimsPrincipal.FindFirst("userId").Value);
            string role = claimsPrincipal.FindFirst("role").Value;
            ClientProfile profile = ProfileDataStore.Current.Profiles.FirstOrDefault(p => p.UserId == userId).ClientProfiles.FirstOrDefault(cp => cp.UserId == id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }
    }
}