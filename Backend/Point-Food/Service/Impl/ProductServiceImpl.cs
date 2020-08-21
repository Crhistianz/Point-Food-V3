using AutoMapper;
using PointFood.Model;
using PointFood.Dto;
using PointFood.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PointFood.Commons;
using Microsoft.EntityFrameworkCore;

namespace PointFood.Service.Impl
{
    public class ProductServiceImpl : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> Create(ProductCreateDto model)
        {
            var restaurant = await _context.Restaurants.SingleAsync(x => x.RestaurantOwnerId == model.UserId);

            var entry = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                RestaurantId = restaurant.RestaurantId,
                ProductTypeId = model.ProductTypeId
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDto>(entry);
        }

        public async Task Update(int id, ProductUpdateDto model)
        {
            var entry = await _context.Products.SingleAsync(x => x.ProductId == id);

            entry.Name = model.Name;
            entry.Description = model.Description;
            entry.Price = model.Price;
            entry.ProductTypeId = model.ProductTypeId;

            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            _context.Remove(
                new Product
                {
                    ProductId = id
                }
                );

            await _context.SaveChangesAsync();
        }

        public async Task<ProductDto> GetById(int id)
        {
            return _mapper.Map<ProductDto>(
                await _context.Products.SingleAsync(x => x.ProductId == id)
                );
        }

        public async Task<DataCollection<ProductDto>> GetAllByRestaurantOwner(int restaurantOwnerId, int page, int take)
        {
            return _mapper.Map<DataCollection<ProductDto>>(
                await _context.Products.OrderByDescending(x => x.ProductTypeId)
                .Include(x => x.ProductType)
                .AsQueryable().Where(x => x.Restaurant.RestaurantOwner.UserId == restaurantOwnerId)
                .PagedAsync(page, take)
                );
        }

        
    }
}
