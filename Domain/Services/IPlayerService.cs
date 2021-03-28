using System.Collections.Generic;
using System.Threading.Tasks;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Domain.Services.Communication;

namespace RugbyUnion.API.Domain.Services
{
    public interface IPlayerService
    {
        Task<ServiceResponse<IEnumerable<Player>>> GetAllAsync();
        Task<ServiceResponse<Player>> FindByIdAsync(int playerId);
        Task<ServiceResponse<Player>> AddAsync(Player newPlayer);
    }
}
