
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwCommerce.Models;
using SwCommerce.Models.ViewModel;
using SwCommerce.Services;

namespace SwCommerce.Controllers
{           
    [ApiController]
    [Route("api/[controller]")] 
    public class CartController : Controller
    {
        public CartViewModel cart = new CartViewModel();
        private readonly ILogger<CartController> _logger;
        private readonly ProductService _productService;
        public CartController(
            ProductService productService,
            ILogger<CartController> logger)
        {
            this._productService = productService;
            this._logger = logger;
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<CartViewModel>> Post(
            [FromBody] List<SaleFormatFrontEndViewModel> model)
        {   
            if(ModelState.IsValid)
            {
                if(model!= null)
                {
                    foreach(var mod in model){
                        Product product = await this._productService.FindByIdAsync(mod.ProductId);
                        cart.CartAddProduct(new SaleViewModel(mod.Amount,product));
                    }
                }
                return cart;
            }
            else return BadRequest(ModelState);
        }
    }
}