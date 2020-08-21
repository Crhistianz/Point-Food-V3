using AutoMapper;
using PointFood.Commons;
using PointFood.Dto;
using PointFood.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Service.Impl
{
    public class ProductTypeServiceImpl : IProductTypeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductTypeServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollection<ProductTypeDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ProductTypeDto>>(
                await _context.ProductTypes
                .AsQueryable()
                .PagedAsync(page, take)
                );
        }
    }
}
