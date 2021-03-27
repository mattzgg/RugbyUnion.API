using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Domain.Services;
using RugbyUnion.API.Domain.Services.Communication;
using RugbyUnion.API.Domain.Repositories;

namespace RugbyUnion.API.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        private readonly IUnitOfWork _unitOfWork;

        public PlayerService(IPlayerRepository productRepository, IUnitOfWork unitOfWork)
        {
            _playerRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _playerRepository.GetAllAsync();
        }

        public async Task<PlayerResponse> FindByIdAsync(int playerId)
        {
            Player player = await _playerRepository.FindByIdAsync(playerId);
            return player == null ? new PlayerResponse("Player not found") : new PlayerResponse(player);
        }

        public async Task<PlayerResponse> AddAsync(Player newPlayer)
        {
            try
            {
                await _playerRepository.AddAsync(newPlayer);
                await _unitOfWork.CompleteAsync();
                return new PlayerResponse(newPlayer);
            }
            catch (Exception ex)
            {
                return new PlayerResponse($"An error occurred when adding the new player: {ex.Message}");
            }
        }
    }
}
