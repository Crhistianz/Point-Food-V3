using PointFood.Commons;
using PointFood.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Service
{
    public interface IRestaurantService
    {
        Task<RestaurantDto> Create(RestaurantCreateDto model);
        Task Update(int id, RestaurantUpdateDto model);
        Task<RestaurantDto> GetByRestaurantOwner(int restaurantOwnerId);
        Task<DataCollection<RestaurantDto>> GetAll(int page, int take);
        Task<DataCollection<RestaurantDto>> GetAllByCategory(int categoryId, int page, int take);
    }
}
