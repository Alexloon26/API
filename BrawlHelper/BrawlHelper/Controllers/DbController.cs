using Microsoft.AspNetCore.Mvc;
using BrawlHelper.Clients;
using BrawlHelper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrawlHelper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly DataBase _dataBase;
        private readonly BrawlClient _brawlClient;

        public PlayerController(DataBase dataBase, BrawlClient brawlClient)
        {
            _dataBase = dataBase;
            _brawlClient = brawlClient;
        }

    
        [HttpPost]
        public async Task<IActionResult> AddPlayer(string playerTag)
        {
            var playerData = await _brawlClient.GetPlayerInfo(playerTag);

            if (playerData == null)
            {
                return NotFound("Player not found.");
            }

            playerData.Tag = $"#{playerTag}";
            await _dataBase.InsertPlayer(playerData);
            return Ok("Player added successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayer(string playerTag)
        {
            var fullPlayerTag = $"#{playerTag}";
            var playerExists = await _dataBase.PlayerExists(fullPlayerTag);

            if (!playerExists)
            {
                return NotFound("Player not found.");
            }

            await _dataBase.DeletePlayer(fullPlayerTag);
            return Ok("Player deleted successfully.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(string playerTag)
        {
            var playerData = await _brawlClient.GetPlayerInfo(playerTag);

            if (playerData == null)
            {
                return NotFound("Player not found.");
            }

            var fullPlayerTag = $"#{playerTag}";
            var playerExists = await _dataBase.PlayerExists(fullPlayerTag);

            if (!playerExists)
            {
                return NotFound("Player not found in the database.");
            }

            playerData.Tag = fullPlayerTag;
            await _dataBase.UpdatePlayer(playerData);
            return Ok("Player data updated successfully.");
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetAllPlayers()
        {
            var players = await _dataBase.GetAllPlayers();
            return Ok(players);
        }
    }
}