using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = RoleHelper.RESTAURANTOWNER)]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService
        )
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollection<ApplicationUserDto>>> GetAll(int page, int take)
        {
            return await _userService.GetAll(page, take);
        }
    }
}
