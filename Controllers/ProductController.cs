using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwCommerce.Models;
using SwCommerce.Services;

namespace ApiTest.Controllers
{           
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductController : Controller
    {

        public readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            this._productService = productService;
            this._logger = logger;
        }
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get()
        {   
            var products = await _productService.FindAllAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Product> GetProduct(int Id)
        {
            Product item = await _productService.FindByIdAsync(Id);
            return item;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post(
            [FromBody] Product product)
        {
            if(ModelState.IsValid)
            {
                await _productService.AddAsync(product);
                return product;
            }
            else return BadRequest(ModelState);
        }
    }
}