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
    public class OrderServiceImpl : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> Create(OrderCreateDto model)
        {
            var entry = _mapper.Map<Order>(model);
            entry.RegisteredAt = DateTime.Now;
            entry.StateId = StateHelper.Pendiente;

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDto>(entry);
        }

        public async Task UpdateStateAttend(int id)
        {
            var entry = await _context.Orders.SingleAsync(x => x.OrderId == id);
            entry.StateId = StateHelper.Proceso;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateStateReady(int id)
        {
            var entry = await _context.Orders.SingleAsync(x => x.OrderId == id);
            entry.StateId = StateHelper.Listo;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateStateCancel(int id)
        {
            var entry = await _context.Orders.SingleAsync(x => x.OrderId == id);
            entry.StateId = StateHelper.Cancelado;

            await _context.SaveChangesAsync();
        }

        public async Task<OrderDto> GetById(int id)
        {
            return _mapper.Map<OrderDto>(
                await _context.Orders
                .Include(x => x.Client)
                .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                .Include(x => x.Restaurant)
                .Include(x => x.State)
                .SingleAsync(x => x.OrderId == id)
                );
        }

        public async Task<DataCollection<OrderDto>> GetAllByClient(int clientId, int page, int take)
        {
            return _mapper.Map<DataCollection<OrderDto>>(
                await _context.Orders.OrderByDescending(x => x.OrderId)
                .AsQueryable()
                .Where(x => x.Client.UserId == clientId)
                .Include(x => x.Client)
                .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                .Include(x => x.Restaurant)
                .Include(x => x.State)
                .PagedAsync(page, take)
                );
        }

        public async Task<DataCollection<OrderDto>> GetAllByRestaurantOwners(int restaurantOwnerId, int page, int take)
        {
            return _mapper.Map<DataCollection<OrderDto>>(
                await _context.Orders.OrderByDescending(x => x.OrderId)
                .AsQueryable()
                .Where(x => x.Restaurant.RestaurantOwner.UserId == restaurantOwnerId)
                .Include(x => x.Client)
                .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                .Include(x => x.Restaurant)
                .Include(x => x.State)
                .PagedAsync(page, take)
                );
        }





        public async Task<DataCollection<OrderDto>> GetAllByRestaurant(int restaurantId, int page, int take)
        {
            return _mapper.Map<DataCollection<OrderDto>>(
                await _context.Orders.OrderByDescending(x => x.OrderId)
                .AsQueryable()
                .Where(x => x.RestaurantId == restaurantId)
                .PagedAsync(page, take)
                );
        }

        public async Task<DataCollection<OrderDto>> GetAllByStateAndRestaurant(int restaurantId, int stateId, int page, int take)
        {
            return _mapper.Map<DataCollection<OrderDto>>(
                await _context.Orders.OrderByDescending(x => x.OrderId)
                .AsQueryable()
                .Where(x => x.RestaurantId == restaurantId && x.StateId == stateId)
                .PagedAsync(page, take)
                );
        }

        
        /*
public OrderDto Create(OrderCreateDto model)
{
  var entry = _mapper.Map<Order>(model);
  entry.RegisteredAt = DateTime.Now;
  CalculateSubTotalDishExtra(entry.Products);
  CalculateSubtotalOrderDetail(entry.Products);
  entry.Total = entry.Products.Sum(x => x.SubTotal);
  entry.StateId = 1;

  _context.Add(entry);
  _context.SaveChanges();

  return _mapper.Map<OrderDto>(GetById(entry.OrderId));
}

public OrderDto GetById(int id)
{
  return _mapper.Map<OrderDto>(
      _context.Orders
      .Include(x => x.Client)
      .Include(x => x.Restaurant)
          //.ThenInclude(x => x.Category)
      .Include(x => x.Products)
          .ThenInclude(x => x.Extras)
              .ThenInclude(x => x.Extra)
      .Include(x => x.Products)
          .ThenInclude(x => x.Product)
      .Include(x => x.State)
      .Single(x => x.OrderId == id));
}

public void CalculateSubTotalDishExtra(IEnumerable<OrderDetail> products)
{
  foreach(var product in products)
  {
      foreach(var extra in product.Extras)
      {
          extra.SubTotal = _context.Extras.Single(x => x.ExtraId == extra.ExtraId).Price * extra.Quantity;
      }
  }
}

public void CalculateSubtotalOrderDetail(IEnumerable<OrderDetail> products)
{
  foreach(var product in products)
  {
      product.SubTotal = product.Extras.Sum(x => x.SubTotal) + _context.Products.Single(x => x.ProductId == product.ProductId).Price;        
  }
}

public DataCollection<OrderDto> GetByRestaurant(int RestaurantId, int page, int take)
{
  return _mapper.Map<DataCollection<OrderDto>>(
      _context.Orders.OrderBy(x => x.OrderId)
      .Include(x => x.Client)
      .Include(x => x.Restaurant)
          //.ThenInclude(x => x.Category)
      .Include(x => x.Products)
          .ThenInclude(x => x.Extras)
              .ThenInclude(x => x.Extra)
      .Include(x => x.Products)
          .ThenInclude(x => x.Product)
      .Include(x => x.State)
      .AsQueryable().Where(x => x.RestaurantId == RestaurantId)
      .PagedAsync(page, take)
      );
}


public void UpdateState(int id, OrderUpdateDto model)
{
  var entry = _context.Orders.Single(x => x.OrderId == id);
  entry.StateId = model.StateId;

  _context.SaveChanges();
}

public DataCollection<OrderDto> GetByStateAndRestaurant(int RestaurantId, int StateId, int page, int take)
{
  return _mapper.Map<DataCollection<OrderDto>>(
      _context.Orders.OrderBy(x => x.OrderId)
      .Include(x => x.Client)
      .Include(x => x.Restaurant)
          //.ThenInclude(x => x.Category)
      .Include(x => x.Products)
          .ThenInclude(x => x.Extras)
              .ThenInclude(x => x.Extra)
      .Include(x => x.Products)
          .ThenInclude(x => x.Product)
      .Include(x => x.State)
      .AsQueryable().Where(x => x.RestaurantId == RestaurantId && x.StateId == StateId)
      .PagedAsync(page, take)
      );
}
*/
    }
}
