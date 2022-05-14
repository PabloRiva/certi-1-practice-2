using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Logic.Managers;
using Newtonsoft.Json;
using Serilog;

namespace practice3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private CampaignManager _campaignManager;
        public ProductController(CampaignManager productManager)
        {
            _campaignManager = productManager;
            try
            {
                _campaignManager.setCampaings(JsonConvert.DeserializeObject<List<Campaign>>(System.IO.File.ReadAllText(@"..\practice3\campaigns.txt")));
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay una DB todavia");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        [HttpGet]
        public IActionResult GetCampaign()
        {
            Log.Information("Antes de pedir Campañas");

            return Ok(_campaignManager.GetCampaigns());
        }

        [HttpPost]
        public IActionResult CreateProduct(string name, string type, string description, bool enable)
        {
            Campaign createdCampaign = _campaignManager.CreateCampaign(name,type,description,enable);
            string json = JsonConvert.SerializeObject(_campaignManager.GetCampaigns());
            System.IO.File.WriteAllText(@"..\practice3\campaigns.txt",json);

            Log.Information("Se ha creado una campaña");

            return Ok(createdCampaign);
        }

        /*[HttpPut]
        [Route("/search-partners")]
        public IActionResult UpdateProduct(string name, int stock, string type, double price,int code)
        {
            Campaign modifiedProduct = CampaignManager.Upda(name, stock, type, price,code);
            Log.Information("Campaña modificada");
            return Ok(modifiedProduct);
        }*/

        [HttpDelete]
        public IActionResult DeleteCamapaing(string code)
        {
            List<Campaign> deletedCampaigns = _campaignManager.DeleteCampaign(code);
            string json = JsonConvert.SerializeObject(_campaignManager.GetCampaigns());
            System.IO.File.WriteAllText(@"..\practice3\campaigns.txt", json);
            Log.Information("Campaña borrada");
            return Ok(deletedCampaigns);
        }


    }
}
