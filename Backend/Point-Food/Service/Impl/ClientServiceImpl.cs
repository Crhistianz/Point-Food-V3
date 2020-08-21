using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PointFood.Commons;
using PointFood.Dto;
using PointFood.Model;
using PointFood.Model.Identity;
using PointFood.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Service.Impl
{
    public class ClientServiceImpl : IClientService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientServiceImpl(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(ClientCreateDto model)
        {
            int quantityUsers = _context.Users.Count();

            var user = new Client
            {
                UserId = quantityUsers + 1,
                Email = model.Email,
                UserName = model.Email,
                Name = model.Name
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, RoleHelper.CLIENT);

            if (!result.Succeeded)
            {
                throw new Exception("No se pudo registrar el usuario.");
            }
        }
    }
}
