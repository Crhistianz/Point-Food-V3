using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointFood.Commons;
using PointFood.Dto;
using PointFood.Model;
using PointFood.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Service.Impl
{
    public class RestaurantServiceImpl : IRestaurantService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RestaurantServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RestaurantDto> Create(RestaurantCreateDto model)
        {
            var entry = _mapper.Map<Restaurant>(model);

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<RestaurantDto>(entry);
        }

        public async Task Update(int id, RestaurantUpdateDto model)
        {
            var entry = await _context.Restaurants.SingleAsync(x => x.RestaurantId == id);
            entry.Name = model.Name;
            entry.Address = model.Address;
            entry.PhoneNumber = model.PhoneNumber;

            await _context.SaveChangesAsync();
        }

        public async Task<RestaurantDto> GetByRestaurantOwner(int restaurantOwnerId)
        {
            return _mapper.Map<RestaurantDto>(
                await _context.Restaurants.SingleAsync(x => x.RestaurantOwner.UserId == restaurantOwnerId)
                );
        }

        public async Task<DataCollection<RestaurantDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<RestaurantDto>>(
                await _context.Restaurants
                .Include(x => x.Products)
                .AsQueryable()
                .PagedAsync(page, take)
                );
        }

        public async Task<DataCollection<RestaurantDto>> GetAllByCategory(int categoryId, int page, int take)
        {
            var lir = _context.RestaurantCategory.AsQueryable().Where(x => x.CategoryId == categoryId).Select(x => x.RestaurantId).ToList();

            return _mapper.Map<DataCollection<RestaurantDto>>(
               await _context.Restaurants.OrderByDescending(x => x.RestaurantId)
               .Include(x => x.Products)
               .AsQueryable().Where(x => lir.Contains(x.RestaurantId))
               .PagedAsync(page, take)
               /*await _context.Restaurants
               .Find().RestaurantCategories
               .AsQueryable().Where(x => x.CategoryId == categoryId)
               .PagedAsync(page, take)*/
               );
        }

        
    }
}
