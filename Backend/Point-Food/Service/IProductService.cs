using PointFood.Commons;
using PointFood.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Service
{
    public interface IProductService
    {
        Task<ProductDto> Create(ProductCreateDto model);
        Task Update(int id, ProductUpdateDto model);
        Task Remove(int id);
        Task<ProductDto> GetById(int id);
        Task<DataCollection<ProductDto>> GetAllByRestaurantOwner(int restaurantOwnerId, int page, int take);
    }
}
