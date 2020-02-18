
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
    public class OfferController : Controller
    {
        private readonly OfferService _offerService;
        private readonly ILogger<OfferController> _logger;
        public OfferController(
            OfferService offerService, 
            ILogger<OfferController> logger)
        {
            this._offerService = offerService;
            this._logger = logger;
        }
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Offer>>> Get()
        {   
            var offers = await _offerService.FindAllAsync();
            return offers;
        }
    }
}