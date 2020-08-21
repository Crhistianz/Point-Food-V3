using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointFood.Commons;
using PointFood.Dto;
using PointFood.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Service.Impl
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollection<CategoryDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<CategoryDto>>(
             await _context.Categories
             .OrderBy(x => x.Name)
             .AsQueryable()
             .PagedAsync(page, take)
            );
        }
    }
}
