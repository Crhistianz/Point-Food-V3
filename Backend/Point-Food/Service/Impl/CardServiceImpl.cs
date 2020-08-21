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
    public class CardServiceImpl : ICardService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CardServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CardDto> Create(CardCreateDto model)
        {
            var entry = _mapper.Map<Card>(model);

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<CardDto>(entry);
        }

        public async Task Update(int id, CardUpdateDto model)
        {
            var entry = await _context.Cards.SingleAsync(x => x.CardId == id);
            entry.Number = model.Number;

            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            _context.Remove(
                new Card
                {
                    CardId = id
                });
            await _context.SaveChangesAsync();
        }

        public async Task<DataCollection<CardDto>> GetAllByClient(string clientId, int page, int take)
        {
            return _mapper.Map<DataCollection<CardDto>>(
                await _context.Cards
                .AsQueryable()
                .Where(x => x.ClientId == clientId)
                .PagedAsync(page, take)
                );
        }
    }
}
