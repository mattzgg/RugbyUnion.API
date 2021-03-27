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

        public async Task<TeamResponse> AddAsync(Team team)
        {
            try
            {
                await _teamRepository.AddAsync(team);
                await _unitOfWork.CompleteAsync();
                return new TeamResponse(team);
            }
            catch (Exception ex)
            {
                return new TeamResponse($"An error occurred when saving the team: {ex.Message}");
            }
        }

        public async Task<PlayerResponse> SignAsync(int playerId, int teamId)
        {
            Player player = await _playerRepository.FindByIdAsync(playerId);
            if (player == null)
            {
                return new PlayerResponse($"Player not found");
            }
            Team team = await _teamRepository.FindByIdAsync(teamId);
            if (team == null)
            {
                return new PlayerResponse($"Team not found");
            }
            if (player.TeamId == team.Id)
            {
                return new PlayerResponse($"Repetitive signing found");
            }
            try
            {
                player.Team = team;
                return new PlayerResponse(player);
            }
            catch (Exception ex)
            {
                return new PlayerResponse($"An error occurred when siging the player: {ex.Message}");
            }
        }
    }
}
