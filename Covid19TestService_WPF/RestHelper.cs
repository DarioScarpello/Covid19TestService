using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Covid19TestService_API.Controllers;
using Covid19TestService_Library.Models;


namespace Covid19TestService_WPF
{
    internal class RestHelper
    {
        private static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:2682/api/") };
        static JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public static async Task<bool> PostLoginAsync(string email, string password)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(password, options), Encoding.UTF8, "application/json");

            var successCode = await client.PostAsync($"Login/{email}", content);

            if (successCode.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public static async Task<List<Profile>> GetAllProfilsAsync(int uid) 
        {
            var successCode = await client.GetAsync($"Profiles/{uid}");

            if (successCode.IsSuccessStatusCode)
            {
                var allprofiles = await successCode.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Profile>>(allprofiles, options);
            }
            return null;
        }

        public static async Task<List<Pcr>> GetPcrsAsync(int pid)
        {
            var successCode = await client.GetAsync($"PCR/{pid}");

            if (successCode.IsSuccessStatusCode)
            {
                var pcrs = await successCode.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Pcr>>(pcrs, options);
            }
            return null;
        }

        public static async Task<List<Antigen>> GetAntigenAsync(int pid)
        {
            var successCode = await client.GetAsync($"Antigen/{pid}");

            if (successCode.IsSuccessStatusCode)
            {
                var antigen = await successCode.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Antigen>>(antigen, options);
            }
            return null;
        }

        public static async Task PostProfileAsync(Profile profile)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(profile, options), Encoding.UTF8, "application/json");

            await client.PostAsync("Profiles", content);
        }

        public static async Task DeleteProfileAsnyc(int pid) 
        {
            await client.DeleteAsync($"Profiles{pid}");
        }

        public static async Task PostPCRAsync(Pcr pcr)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(pcr, options), Encoding.UTF8, "application/json");

            await client.PostAsync("PCR", content);
        }

        public static async Task PostAntigensync(Antigen antigen)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(antigen, options), Encoding.UTF8, "application/json");

            await client.PostAsync("PCR", content);
        }

        public static async Task PatchProfileAsync(int pid, Profile profile) 
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(profile, options), Encoding.UTF8, "application/json");

            await client.PatchAsync($"Profile/{pid}", content);
        }
    }
}
