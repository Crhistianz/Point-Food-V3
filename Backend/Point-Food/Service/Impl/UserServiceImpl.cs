using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointFood.Commons;
using PointFood.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using PointFood.Dto;
using System.Threading.Tasks;

namespace PointFood.Service.Impl
{
    public class UserServiceImpl : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserServiceImpl(
            ApplicationDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollection<ApplicationUserDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ApplicationUserDto>>(
                await _context.Users.OrderByDescending(x => x.Name)
                                    .Include(x => x.UserRoles)
                                    .ThenInclude(x => x.Role)
                                    .AsQueryable()
                                    .PagedAsync(page, take)
                );
        }
    }
}
