using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwCommerce.Models;
using SwCommerce.Services;

namespace SwCommerce.Controllers
{           
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductController : Controller
    {

        private readonly ProductService _productService;
        private readonly OfferService _offerService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(
            ProductService productService,
            OfferService offerService, 
            ILogger<ProductController> logger)
        {
            this._productService = productService;
            this._offerService = offerService;
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
                product.Offer = await _offerService.FindByIdAsync(product.OfferId);
                await _productService.AddAsync(product);
                return product;
            }
            else return BadRequest(ModelState);
        }
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Product>> Put(
            [FromBody] Product product)
        {
            if(ModelState.IsValid)
            {
                product.Offer = await _offerService.FindByIdAsync(product.OfferId); 
                System.Diagnostics.Debug.WriteLine(product);   
                await _productService.UpdateAsync(product);
                return product;
            }
            else return BadRequest(ModelState);
        }
        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<Product>> Delete(
            [FromBody] Product product)
        {
            var obj = await _productService.FindByIdAsync(product.Id);
            await _productService.DeleteAsync(product.Id);
            return obj;
        }
    }
}