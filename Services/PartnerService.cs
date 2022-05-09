using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace Services
{
    public class PartnersService
    {
        public async Task<Partner> GetPartner()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://random-data-api.com/api/restaurant/random_restaurant").Result;

            Partner partner;
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                partner = JsonConvert.DeserializeObject<Partner>(responseData);
            }
            else
            {
                partner = new Partner();
            }
            return partner;
        }
    }
}
