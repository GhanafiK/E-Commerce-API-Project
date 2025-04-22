using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DataTransfareObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController(IServiceManager _serviceManager):ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts([FromQuery] ProductQueryParams queryParams)
        {
            var Products = await _serviceManager.ProductServices.GetAllProductsAsync(queryParams);
            return Ok(Products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var Product=await _serviceManager.ProductServices.GetProductByIdAsync(id);  
            return Ok(Product);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetAllBrands()
        {
            var Brands=await _serviceManager.ProductServices.GetAllBrandsAsync();
            return Ok(Brands);
        }


        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDTO>>> GetAllTpes()
        {
            var Types=await _serviceManager.ProductServices.GetAllTypesAsync();
            return Ok(Types);
        }

    }
}
