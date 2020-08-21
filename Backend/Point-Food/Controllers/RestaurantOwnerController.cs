using Microsoft.AspNetCore.Mvc;
using PointFood.Commons;
using PointFood.Dto;
using PointFood.Model;
using PointFood.Model.Identity;
using PointFood.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Controllers
{
    [ApiController]
    [Route("restaurantowners")]
    public class RestaurantOwnerController : ControllerBase
    {
        private readonly IRestaurantOwnerService _restaurantOwnerService;
        private readonly IUserService _userService;

        public RestaurantOwnerController(IRestaurantOwnerService restaurantOwnerService, IUserService userService)
        {
            _restaurantOwnerService = restaurantOwnerService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Create(RestaurantOwnerCreateDto model)
        {
            await _restaurantOwnerService.Create(model);

            return Ok();
        }
    }
}
