using Microsoft.AspNetCore.Mvc;
using ApiChic.Model;
using System.Data.Common;

namespace ApiChic.Controllers
{
    public class PlayerController : ControllerBase
    {
        public static List<Player> players = new List<Player>()
        {
            {new Player {id = "1", Vida = 100, Item = 0, PosX = 0f, PosY = 0f} }
        };

        [HttpGet]
        [Route("Jogador")]
        public IActionResult GetPlayers()
        {
            return Ok(players);
        }

        [HttpGet]
        [Route("Jogador/{id}")]
        public IActionResult GetPlayerID(string id) {

            var player = players.FirstOrDefault(async => async.id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        [Route("Jogador")]
        public IActionResult AddPlayer([FromBody] Player newPlayer) {
          players.Add(newPlayer);
            return Ok(newPlayer);
        }

        [HttpPut]
        [Route("Jogador/{id}")]
        public IActionResult UpdatePlayer(string id, [FromBody] Player updatedPlayer) { 
          var player = players.FirstOrDefault(a => a.id == id);
            if( player == null)
            {
                return NotFound();
            }
            player.Vida = updatedPlayer.Vida;
            player.Item = updatedPlayer.Item;
            player.PosX = updatedPlayer.PosX;
            player.PosY = updatedPlayer.PosY;
            return Ok(player);
        }

        [HttpDelete]
        [Route("Jogador/{id}")]
        public IActionResult DeletePlayer(string id)
        {
            var player = players.FirstOrDefault(a =>a.id == id);
            if ( player == null)
            {
                return NotFound();
            }
            players.Remove(player);
            return Ok(player);
        }
    }
}
