using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Collections.Generic;
using Covid19TestService_Library.Models;
using System.Linq;

namespace Covid19TestService_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class Covid19TestServiceController : ControllerBase
    {
        static JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        static testservicescarpelloContext context = new testservicescarpelloContext();

        [HttpGet("Users")]
        public ActionResult<List<Users>> GetUsersForLogin(string email)
        {
            return Ok(context.Users.Where(x => x.Email == email).FirstOrDefault());
        }

        [HttpGet("Profiles")]
        public ActionResult<List<Profile>> GetAllProfiles(int uid) 
        {
            return Ok(context.Profile.Where(x => x.Uid == uid).FirstOrDefault());
        }

        [HttpGet("PCR")]
        public ActionResult<List<Pcr>> GetAllPCR(int pid)
        {
            return Ok(context.Pcr.Where(x => x.Pid == pid).FirstOrDefault());
        }

        [HttpGet("Antigen")]
        public ActionResult<List<Antigen>> GetAllantigen(int pid)
        {
            return Ok(context.Antigen.Where(x => x.Pid == pid).FirstOrDefault());
        }

        [HttpPost("Profiles/add")]
        public ActionResult<Profile> CreateProfile() 
        {
            var allProfiles = context.Profile;
            int nextId = allProfiles.Max(x => x.Uid).F
        }
    }
}
