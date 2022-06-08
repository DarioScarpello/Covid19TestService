using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Collections.Generic;
using Covid19TestService_Library.Models;
using System.Linq;
using System;

namespace Covid19TestService_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class Covid19TestServiceController : ControllerBase
    {
        static JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        static testservicescarpelloContext context = new testservicescarpelloContext();

        [HttpPost("Login/{email}")]
        public ActionResult Login(string email, string password)
        {
            var selectedUser = context.Users.Where(x => x.Email == email).FirstOrDefault();

            if (selectedUser != null) 
            {
                if (selectedUser.Password == password)
                {
                    return Ok();
                }
                return NotFound();
            }
            return NotFound();
        }

        [HttpGet("Profiles/{uid}")]
        public ActionResult<List<Profile>> GetAllProfiles(int uid) 
        {
            return Ok(context.Profile.Where(x => x.Uid == uid));
        }

        [HttpGet("PCR/{pid}")]
        public ActionResult<List<Pcr>> GetPcrById(int pid)
        {
            return Ok(context.Pcr.Where(x => x.Pid == pid));
        }

        [HttpGet("Antigen/{pid}")]
        public ActionResult<List<Antigen>> GetAntigenById(int pid)
        {
            return Ok(context.Antigen.Where(x => x.Pid == pid));
        }

        [HttpPost("Profiles")]
        public ActionResult CreateProfile(Profile profile)
        {
            var allProfiles = context.Profile;
            int nextId = allProfiles.Max(x => x.Pid);

            profile.Pid = nextId;
            context.Profile.Add(profile);
            return Ok();
        }

        [HttpDelete("Profiles/delete/{ProfileId}")]
        public ActionResult<Profile> DeleteProfileById(int ProfileId) 
        {
            var profileToDelete = context.Profile.Where(x => x.Pid == ProfileId).FirstOrDefault();

            context.Profile.Remove(profileToDelete);

            return Ok(profileToDelete);
        }

        [HttpPost("PCR/add")]
        public ActionResult<Profile> CreatePCR(int ct, DateOnly takenon, bool ispositve, int pid)
        {
            var allpcr = context.Pcr;
            int nextId = allpcr.Max(x => x.Pcrid);

            Pcr pcr = new Pcr(nextId, ct, takenon, ispositve, pid);
            context.Pcr.Add(pcr);

            return Ok(pcr);
        }

        [HttpPost("Antigen/add")]
        public ActionResult<Profile> CreateAntigen(int lines, DateOnly takenon, bool ispositive, int pid)
        {
            var allAntigen = context.Antigen;
            int nextId = allAntigen.Max(x => x.Aid);

            Antigen antigen = new Antigen(nextId, lines, takenon, ispositive, pid);
            context.Antigen.Add(antigen);

            return Ok(antigen);
        }

        [HttpPatch("Profile/edit/{ProfileId}")]
        public ActionResult PatchProfileByIdstring(int ProfileId, string firstname, string lastname, int phonenumber, int ssn, DateOnly dob, string address, string city, string country) 
        {
            var profileToEdit = context.Profile.Where(x => x.Pid == ProfileId).FirstOrDefault();

            profileToEdit.Firstname = firstname;
            profileToEdit.Lastname = lastname;
            profileToEdit.Phonenumber = phonenumber;
            profileToEdit.Ssn = ssn;
            profileToEdit.Dob = dob;
            profileToEdit.Address = address;
            profileToEdit.City = city;
            profileToEdit.Country = country;

            return Ok(profileToEdit);
        }
    }
}
