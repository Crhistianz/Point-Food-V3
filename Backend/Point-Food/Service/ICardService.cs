using PointFood.Commons;
using PointFood.Dto;
using System.Threading.Tasks;

namespace PointFood.Service
{
    public interface ICardService
    {
        Task<CardDto> Create(CardCreateDto model);
        Task Update(int id, CardUpdateDto model);
        Task Remove(int id);
        Task<DataCollection<CardDto>> GetAllByClient(string clientId, int page, int take);
    }
}
