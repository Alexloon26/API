using BrawlHelper.Models;
using BrawlHelper.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BrawlHelper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Brawl : ControllerBase
    {
        private readonly ILogger<Brawl> _logger;
        private readonly BrawlClient _client;

        public Brawl(ILogger<Brawl> logger, BrawlClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet("player/{playerId}")]
        public async Task<IActionResult> GetPlayerInfo(string playerId)
        {
            var player = await _client.GetPlayerInfo(playerId);
            return Ok(player);
        }

        [HttpGet("scrambled")]
        public async Task<IActionResult> GetScrambledBrawlerName()
        {
            var (originalName, scrambledName) = await _client.GetScrambledBrawlerNameAsync();
            return Ok(new { OriginalName = originalName, ScrambledName = scrambledName });
        }

        [HttpGet("club/{clubId}")]
        public async Task<IActionResult> GetClubInfo(string clubId)
        {
            var club = await _client.GetClubInfo(clubId);
            return Ok(club);
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _client.GetEvents();
            return Ok(events);
        }
    }
}
