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
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpPost("create")]
        public async Task<ActionResult> Create(OrderCreateDto order)
        {
            await _orderService.Create(order);

            return Ok();
        }

        [HttpPut("update/attend/{orderId}")]
        public async Task<ActionResult> UpdateStateAttend(int orderId)
        {
            await _orderService.UpdateStateAttend(orderId);

            return Ok();
        }

        [HttpPut("update/ready/{orderId}")]
        public async Task<ActionResult> UpdateStateReady(int orderId)
        {
            await _orderService.UpdateStateReady(orderId);

            return Ok();
        }

        [HttpPut("update/cancel/{orderId}")]
        public async Task<ActionResult> UpdateStateCancel(int orderId)
        {
            await _orderService.UpdateStateCancel(orderId);

            return Ok();
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDto>> GetById(int orderId)
        {
            return await _orderService.GetById(orderId);
        }

        [HttpGet("clients/{clientId}")]
        public async Task<ActionResult<DataCollection<OrderDto>>> GetAllByClient(int clientId, int page, int take)
        {
            return await _orderService.GetAllByClient(clientId, page, take);
        }

        [HttpGet("restaurantowners/{restaurantOwnerId}")]
        public async Task<ActionResult<DataCollection<OrderDto>>> GetAllByRestaurantOwners(int restaurantOwnerId, int page, int take)
        {
            return await _orderService.GetAllByRestaurantOwners(restaurantOwnerId, page, take);
        }

        /*
        [HttpGet("{orderId}")]
        public ActionResult<OrderDto> GetById(int orderId)
        {
            return _orderService.GetById(orderId);
        }

        [HttpGet("restaurants/{restaurantId}")]
        public ActionResult<DataCollection<OrderDto>> GetByRestaurant(int restaurantId, int page, int take)
        {
            return _orderService.GetByRestaurant(restaurantId, page, take);
        }

        [HttpGet("restaurants/{restaurantId}/states/{stateId}")]
        public ActionResult<DataCollection<OrderDto>> GetByStateAndRestaurant(int restaurantId, int stateId, int page, int take)
        {
            return _orderService.GetByStateAndRestaurant(restaurantId, stateId, page, take);
        }

        */
    }
}
