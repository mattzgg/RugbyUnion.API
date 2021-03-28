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

        public async Task<ServiceResponse<Player>> FindByIdAsync(int playerId)
        {
            Player player = await _playerRepository.FindByIdAsync(playerId);
            return player == null ? new ServiceResponse<Player>("Player not found") : new ServiceResponse<Player>(player);
        }

        public async Task<ServiceResponse<Player>> AddAsync(Player newPlayer)
        {
            try
            {
                await _playerRepository.AddAsync(newPlayer);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse<Player>(newPlayer);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Player>($"An error occurred when adding the new player: {ex.Message}");
            }
        }
    }
}
