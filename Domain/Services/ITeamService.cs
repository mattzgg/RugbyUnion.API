using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Domain.Services.Communication;

namespace RugbyUnion.API.Domain.Services
{
    public interface ITeamService
    {
        Task<ServiceResponse<IEnumerable<Team>>> GetAllAsync();
        Task<ServiceResponse<Team>> FindByIdAsync(int teamId);
        Task<ServiceResponse<Team>> AddAsync(Team team);
        Task<ServiceResponse<IEnumerable<Player>>> GetSignedPlayersAsync(int teamId);
        Task<ServiceResponse<Player>> SignAsync(int teamId, int playerId);
    }
}
