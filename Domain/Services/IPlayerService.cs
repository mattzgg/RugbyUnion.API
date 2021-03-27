using System.Collections.Generic;
using System.Threading.Tasks;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Domain.Services.Communication;

namespace RugbyUnion.API.Domain.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAllAsync();
        Task<PlayerResponse> FindByIdAsync(int playerId);
        Task<PlayerResponse> AddAsync(Player newPlayer);
    }
}
