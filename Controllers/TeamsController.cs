using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Domain.Services;
using RugbyUnion.API.Resources;
using RugbyUnion.API.Extensions;


namespace RugbyUnion.API.Controllers
{

    [Route("/api/[controller]")]
    public class TeamsController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public TeamsController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        /// <summary>
        /// Return a list of all the teams
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var tsResponse = await _teamService.GetAllAsync();
            var resources = _mapper.Map<IEnumerable<Team>, IEnumerable<TeamResource>>(tsResponse.Result);
            return Ok(resources);
        }

        /// <summary>
        /// Allow the user to select a team and display all of the players signed with it.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        [HttpGet("{teamId}/signed-players")]
        public async Task<IActionResult> GetSignedPlayersAsync(int teamId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var tsResponse = await _teamService.GetSignedPlayersAsync(teamId);
            if (!tsResponse.Success)
            {
                return BadRequest(tsResponse.Message);
            }

            IEnumerable<PlayerResource> playerResources = _mapper.Map<IEnumerable<Player>, IEnumerable<PlayerResource>>(tsResponse.Result);
            return Ok(playerResources);
        }

        /// <summary>
        /// Add a new team to the system
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] SaveTeamResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var team = _mapper.Map<SaveTeamResource, Team>(resource);
            var tsResponse = await _teamService.AddAsync(team);
            if (!tsResponse.Success)
            {
                return BadRequest(tsResponse.Message);
            }

            var teamResource = _mapper.Map<Team, TeamResource>(tsResponse.Result);
            return Ok(teamResource);
        }

        [HttpPut("{teamId}/sign-player/{playerId}")]
        public async Task<IActionResult> SignAsync(int teamId, int playerId)
        {
            var tsResponse = await _teamService.SignAsync(teamId, playerId);
            if (!tsResponse.Success)
            {
                return BadRequest(tsResponse.Message);
            }

            var playerResource = _mapper.Map<Player, PlayerResource>(tsResponse.Result);
            return Ok(playerResource);
        }
    }
}
