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
    [Route("restaurants")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(RestaurantCreateDto model)
        {
            await _restaurantService.Create(model);

            return Ok();
        }

        [HttpGet("restaurantowners/{restaurantOwnerId}")]
        public async Task<RestaurantDto> GetByRestaurantOwner(int restaurantOwnerId)
        {
            return await _restaurantService.GetByRestaurantOwner(restaurantOwnerId);
        }


        [HttpGet]
        public async Task<DataCollection<RestaurantDto>> GetAll(int page, int take)
        {
            return await _restaurantService.GetAll(page, take);
        }

        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult<DataCollection<RestaurantDto>>> GetByCategory(int categoryId, int page, int take)
        {
            return await _restaurantService.GetAllByCategory(categoryId, page, take);
        }
    }
}
