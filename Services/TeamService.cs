using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RugbyUnion.API.Domain.Services;
using RugbyUnion.API.Domain.Services.Communication;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Domain.Repositories;

namespace RugbyUnion.API.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(ITeamRepository teamRepository, IPlayerRepository playerRepository, IUnitOfWork unitOfWork)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _teamRepository.GetAllAsync();
        }

        public async Task<Team> FindByIdAsync(int teamId)
        {
            return await _teamRepository.FindByIdAsync(teamId);
        }

        public async Task<ServiceResponse<Team>> AddAsync(Team team)
        {
            try
            {
                await _teamRepository.AddAsync(team);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse<Team>(team);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Team>($"An error occurred when saving the team: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<IEnumerable<Player>>> GetSignedPlayersAsync(int teamId)
        {
            Team team = await _teamRepository.FindByIdAsync(teamId);
            if (team == null)
            {
                return new ServiceResponse<IEnumerable<Player>>($"Team not found");
            }
            IEnumerable<Player> signedPlayers = await _playerRepository.GetSignedPlayersAsync(teamId);
            return new ServiceResponse<IEnumerable<Player>>(signedPlayers);
        }

        public async Task<ServiceResponse<Player>> SignAsync(int teamId, int playerId)
        {
            Player player = await _playerRepository.FindByIdAsync(playerId);
            if (player == null)
            {
                return new ServiceResponse<Player>($"Player not found");
            }
            Team team = await _teamRepository.FindByIdAsync(teamId);
            if (team == null)
            {
                return new ServiceResponse<Player>($"Team not found");
            }
            if (player.TeamId == team.Id)
            {
                return new ServiceResponse<Player>($"Repetitive signing found");
            }
            try
            {
                player.Team = team;
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse<Player>(player);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Player>($"An error occurred when siging the player: {ex.Message}");
            }
        }
    }
}
