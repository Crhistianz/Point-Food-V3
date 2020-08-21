using Microsoft.AspNetCore.Mvc;
using PointFood.Commons;
using PointFood.Dto;
using PointFood.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(ProductCreateDto model)
        {
            await _productService.Create(model);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ProductUpdateDto model)
        {
            await _productService.Update(id, model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _productService.Remove(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            return await _productService.GetById(id);
        }

        [HttpGet("restaurants/restaurantowners/{restaurantOwnerId}")]
        public async Task<ActionResult<DataCollection<ProductDto>>> GetAllByRestaurantOwner(int restaurantOwnerId, int page, int take)
        {
            return await _productService.GetAllByRestaurantOwner(restaurantOwnerId, page, take);
        }
    }
}
