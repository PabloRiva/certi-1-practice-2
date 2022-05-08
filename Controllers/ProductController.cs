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
        

        public ProductController()
        {
          
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
           
        }



    }
}
