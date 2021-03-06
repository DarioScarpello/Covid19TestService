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
        public ActionResult<Users> Login(string email, [FromBody]string password)
        {
            var selectedUser = context.Users.Where(x => x.Email == email).FirstOrDefault();

            if (selectedUser != null) 
            {
                if (selectedUser.Password == password)
                {
                    return Ok(selectedUser);
                }
                return NotFound();
            }
            return NotFound();
        }

        [HttpGet("Profiles/{uid}")]
        public ActionResult<List<Profile>> GetAllProfiles(int uid) 
        {
            var profiles = context.Profile.Where(x => x.Uid == uid).ToList();

            return Ok(profiles);
        }

        [HttpGet("PCR/{pid}")]
        public ActionResult<List<Pcr>> GetPcrById(int pid)
        {
            var pcrs = context.Pcr.Where(x => x.Pid == pid).ToList();

            return Ok(pcrs);
        }

        [HttpGet("Antigen/{pid}")]
        public ActionResult<List<Antigen>> GetAntigenById(int pid)
        {
            var antigens = context.Antigen.Where(x => x.Pid == pid).ToList();
            return Ok(antigens);
        }

        [HttpPost("Profiles")]
        public ActionResult<Profile> CreateProfile([FromBody]Profile profile)
        {
            var allProfiles = context.Profile;
            int nextId = allProfiles.Max(x => x.Pid);

            profile.Pid = nextId;
            context.Profile.Add(profile);

            //Save geht nicht, weil ich das Datum nicht speichern kann
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("Profiles{pid}")]
        public ActionResult<Profile> DeleteProfileById(int pid) 
        {
            var profileToDelete = context.Profile.Where(x => x.Pid == pid).FirstOrDefault();

            context.Profile.Remove(profileToDelete);
            context.SaveChanges();

            return Ok(profileToDelete);
        }

        [HttpPost("PCR/{pid}")]
        public ActionResult<Pcr> CreatePCR([FromBody] Pcr pcr, int pid)
        {
            //var allpcrwithid = context.Pcr.Where(x => x.Pid == pid);
            var allpcr = context.Pcr;
            int nextId;

            if (allpcr == null)
            {
                nextId = 1;
            }
            else
            {
                nextId = allpcr.Max(x => x.Pcrid);
            }

            pcr.Pcrid = nextId;
            context.Pcr.Add(pcr);

            return Ok(pcr);
        }

        [HttpPost("Antigen{pid}")]
        public ActionResult<Antigen> CreateAntigen([FromBody] Antigen antigen, int pid)
        {
            //var allAntigenwithId = context.Antigen.Where(x => x.Pid == pid);
            var allAntigen = context.Antigen;
            int nextId;

            if (allAntigen == null)
            {
                nextId = 1;
            }
            else
            {
                nextId = allAntigen.Max(x => x.Aid);
            }

            antigen.Aid = nextId;
            context.Antigen.Add(antigen);

            return Ok(antigen);
        }

        [HttpPatch("Profile/{pid}")]
        public ActionResult PatchProfileByIdstring(int pid,[FromBody]Profile profile) 
        {
            var profileToEdit = context.Profile.Where(x => x.Pid == pid).FirstOrDefault();

            profileToEdit.Firstname = profile.Firstname;
            profileToEdit.Lastname = profile.Lastname;
            profileToEdit.Phonenumber = profile.Phonenumber;
            profileToEdit.Ssn = profile.Ssn;
            profileToEdit.Dob = profile.Dob;
            profileToEdit.Address = profile.Address;
            profileToEdit.City = profile.City;
            profileToEdit.Country = profile.Country;
            context.SaveChanges();

            return Ok(profileToEdit);
        }
    }
}