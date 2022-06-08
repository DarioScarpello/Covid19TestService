﻿using Microsoft.AspNetCore.Http;
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
        public ActionResult<Profile> CreateProfile(Profile profile)
        {
            var allProfiles = context.Profile;
            int nextId = allProfiles.Max(x => x.Pid);

            profile.Pid = nextId;
            context.Profile.Add(profile);
            return Ok();
        }

        [HttpDelete("Profiles{profileId}")]
        public ActionResult<Profile> DeleteProfileById(int profileId) 
        {
            var profileToDelete = context.Profile.Where(x => x.Pid == profileId).FirstOrDefault();

            context.Profile.Remove(profileToDelete);

            return Ok(profileToDelete);
        }

        [HttpPost("PCR/add")]
        public ActionResult<Pcr> CreatePCR(Pcr pcr)
        {
            var allpcr = context.Pcr;
            int nextId = allpcr.Max(x => x.Pcrid);

            pcr.Pcrid = nextId;
            context.Pcr.Add(pcr);

            return Ok(pcr);
        }

        [HttpPost("Antigen/add")]
        public ActionResult<Antigen> CreateAntigen(Antigen antigen)
        {
            var allAntigen = context.Antigen;
            int nextId = allAntigen.Max(x => x.Aid);

            antigen.Aid = nextId;
            context.Antigen.Add(antigen);

            return Ok(antigen);
        }

        [HttpPatch("Profile/{profileId}")]
        public ActionResult PatchProfileByIdstring(int profileId, Profile profile) 
        {
            var profileToEdit = context.Profile.Where(x => x.Pid == profileId).FirstOrDefault();

            profileToEdit.Firstname = profile.Firstname;
            profileToEdit.Lastname = profile.Lastname;
            profileToEdit.Phonenumber = profile.Phonenumber;
            profileToEdit.Ssn = profile.Ssn;
            profileToEdit.Dob = profile.Dob;
            profileToEdit.Address = profile.Address;
            profileToEdit.City = profile.City;
            profileToEdit.Country = profile.Country;

            return Ok(profileToEdit);
        }
    }
}
