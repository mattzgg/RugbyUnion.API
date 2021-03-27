using System.Collections.Generic;
using System.Threading.Tasks;
using RugbyUnion.API.Domain.Models;

namespace RugbyUnion.API.Domain.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllAsync();

        Task<Player> FindByIdAsync(int playerId);

        Task AddAsync(Player player);
    }
}
