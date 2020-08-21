using PointFood.Commons;
using PointFood.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Service
{
    public interface IOrderService
    {
        Task<OrderDto> Create(OrderCreateDto model);
        Task UpdateStateAttend(int id);
        Task UpdateStateReady(int id);
        Task UpdateStateCancel(int id);
        Task<OrderDto> GetById(int id);
        Task<DataCollection<OrderDto>> GetAllByClient(int clientId, int page, int take);
        Task<DataCollection<OrderDto>> GetAllByRestaurantOwners(int restaurantOwnerId, int page, int take);

        Task<DataCollection<OrderDto>> GetAllByStateAndRestaurant(int restaurantId, int stateId, int page, int take);
        Task<DataCollection<OrderDto>> GetAllByRestaurant(int restaurantId, int page, int take);
        
    }
}
