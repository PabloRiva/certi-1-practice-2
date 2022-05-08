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

        private ProductManager _productManager;
        public ProductController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productManager.GetProducts());
        }

        [HttpPost]
        public IActionResult CreateProduct(string name, int stock, string type, double price)
        {
            Product createdProduct = _productManager.CreateProduct(name, stock, type, price);
            return Ok(createdProduct);
        }



    }
}
