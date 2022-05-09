using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Logic.Managers;

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
        }

        [HttpGet]
        public IActionResult GetCampaign()
        {
            return Ok(_campaignManager.GetCampaigns());
        }

        [HttpPost]
        public IActionResult CreateProduct(string name, string type, string description, bool enable)
        {
            Campaign createdCampaign = _campaignManager.CreateCampaign(name,type,description,enable);
            return Ok(createdCampaign);
        }

        //[HttpPut]
        //public IActionResult UpdateProduct(string name, int stock, string type, double price,int code)
        //{
        //    Campaign modifiedProduct = _productManager.UpdateProduct(name, stock, type, price,code);
        //    return Ok(modifiedProduct);
        //}

        [HttpDelete]
        public IActionResult DeleteCamapaing(string code)
        {
            List<Campaign> deletedCampaigns = _campaignManager.DeleteCampaign(code);
            return Ok(deletedCampaigns);
        }


    }
}
