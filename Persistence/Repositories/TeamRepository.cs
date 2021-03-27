using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Domain.Repositories;
using RugbyUnion.API.Persistence.Contexts;

namespace RugbyUnion.API.Persistence.Repositories
{
    public class TeamRepository : BaseRepository, ITeamRepository
    {
        public TeamRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team> FindByIdAsync(int teamId)
        {
            return await _context.Teams.FindAsync(teamId);
        }

        public async Task AddAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
        }

    }
}
