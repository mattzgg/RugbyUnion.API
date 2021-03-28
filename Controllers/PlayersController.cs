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
        public async Task<IActionResult> GetAllAsync()
        {
            var psResponse = await _playerService.GetAllAsync();
            var resources = _mapper.Map<IEnumerable<Player>, IEnumerable<PlayerResource>>(psResponse.Result);
            return Ok(resources);
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
            ServiceResponse<Player> psResponse = await _playerService.AddAsync(newPlayer);
            if (!psResponse.Success)
            {
                return BadRequest(psResponse.Message);
            }
            PlayerResource newPlayerResource = _mapper.Map<Player, PlayerResource>(psResponse.Result);
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

            ServiceResponse<Player> psResponse = await _playerService.FindByIdAsync(playerId);
            if (!psResponse.Success)
            {
                return BadRequest(psResponse.Message);
            }
            Team team = psResponse.Result.Team;
            if (team == null)
            {
                return BadRequest("Player has not been signed to a team");
            }
            TeamResource teamResource = _mapper.Map<Team, TeamResource>(team);
            return Ok(teamResource);
        }
    }
}
