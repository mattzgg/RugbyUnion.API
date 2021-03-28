using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Domain.Services;
using RugbyUnion.API.Domain.Services.Communication;
using RugbyUnion.API.Resources;
using RugbyUnion.API.Extensions;

namespace RugbyUnion.API.Controllers
{
    [Route("/api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerService productService, IMapper mapper)
        {
            _playerService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// display a list of all the players
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PlayerResource>> GetAllAsync()
        {
            var players = await _playerService.GetAllAsync();
            var resources = _mapper.Map<IEnumerable<Player>, IEnumerable<PlayerResource>>(players);
            return resources;
        }

        /// <summary>
        /// add a new player to the system
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] SavePlayerResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            Player newPlayer = _mapper.Map<SavePlayerResource, Player>(resource);
            PlayerResponse response = await _playerService.AddAsync(newPlayer);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            PlayerResource newPlayerResource = _mapper.Map<Player, PlayerResource>(response.Player);
            return Ok(newPlayerResource);
        }

        /// <summary>
        /// allow the user to select a player and display the team that player is signed in
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet("{playerId}/team")]
        public async Task<IActionResult> GetTeamOfPlayer(int playerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            PlayerResponse response = await _playerService.FindByIdAsync(playerId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            Team team = response.Player.Team;
            if (team == null)
            {
                return BadRequest("Player has not been signed to a team");
            }
            TeamResource teamResource = _mapper.Map<Team, TeamResource>(team);
            return Ok(teamResource);
        }
    }
}
