using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RugbyUnion.API.Domain.Repositories;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Persistence.Contexts;

namespace RugbyUnion.API.Persistence.Repositories
{
    public class PlayerRepository : BaseRepository, IPlayerRepository
    {
        public PlayerRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Players.Include(p => p.Team).ToListAsync();
        }

        public async Task<Player> FindByIdAsync(int playerId)
        {
            return await _context.Players.Include(p => p.Team).FirstOrDefaultAsync(p => p.Id == playerId);
        }

        public async Task AddAsync(Player player)
        {
            await _context.Players.AddAsync(player);
        }
    }
}
