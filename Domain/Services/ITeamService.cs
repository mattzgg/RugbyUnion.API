using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Domain.Services.Communication;

namespace RugbyUnion.API.Domain.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> FindByIdAsync(int teamId);
        Task<ServiceResponse<Team>> AddAsync(Team team);

        Task<ServiceResponse<Player>> SignAsync(int playerId, int teamId);
    }
}
