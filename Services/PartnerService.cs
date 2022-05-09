using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace Services
{
    public class PartnerService
    {
        private IConfiguration _configuration;
        public PartnerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Partner> GetPartner()
        {
            string addressURL = _configuration.GetSection("adressURL").Value;
            
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(addressURL);

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
