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
    public class StateServiceImpl : IStateService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StateServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DataCollection<StateDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<StateDto>>(
                await _context.States
                .AsQueryable()
                .PagedAsync(page, take)
                );
        }
    }
}
