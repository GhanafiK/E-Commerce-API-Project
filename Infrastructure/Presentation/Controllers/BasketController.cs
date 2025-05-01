using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransfareObjects.BasketModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController(IServiceManager _serviceManager):ControllerBase
    {
        // Get Basket
        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket(string id)
        {
            var Basket=await _serviceManager.BasketService.GetBasketAsync(id);
            return Ok(Basket);
        }

        // Create Or Update Basket
        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket(BasketDto basket)
        {
             var Basket=await _serviceManager.BasketService.CreateOrUpdateBasketAsync(basket);
            return Ok(Basket); 
        }

        //Delete Basket
        [HttpDelete("{key}")]
        public async Task<ActionResult<bool>> DeleteBasket(string key)
        {
            var Result=await _serviceManager.BasketService.DeleteBasketAsync(key);
            return Ok(Result);
        }
    }
}
