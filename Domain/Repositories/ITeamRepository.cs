using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RugbyUnion.API.Domain.Models;

namespace RugbyUnion.API.Domain.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> FindByIdAsync(int teamId);
        Task AddAsync(Team team);
    }
}
