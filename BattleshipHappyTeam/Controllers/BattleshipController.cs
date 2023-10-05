using BattleShipLibrary.Interface;
using BattleShipLibrary.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BattleshipHappyTeamApi.Controllers
{
    [Route("api/[controller]/game")]
    [ApiController]
    public class BattleshipController : ControllerBase
    {
        private IBattleShipProvider _battleShipProvider;
        public BattleshipController(IBattleShipProvider battleShipProvider)
        {
            _battleShipProvider = battleShipProvider;
        }

        // GET api/<BattleshipController>/5
        [HttpGet("{id}")]
        public ActionResult<GameDataModelApi> GetGameData(Guid id)
        {
            GameDataModelApi gameDataModelApi = _battleShipProvider.GetData(id);

            return Ok(gameDataModelApi);
        }

        [HttpPost]
        public ActionResult<GameDataModelApi> Create()
        {
            GameDataModelApi gameDataModelApi = _battleShipProvider.Create(10, 17);

            return Ok(gameDataModelApi);
        }

        // POST api/<BattleshipController>
        [HttpPost("{id}")]
        public ActionResult Shot(Guid id,[FromBody] ShotModelApi shot)
        {
            _battleShipProvider.MakeATurn(id, shot.X, shot.Y);
            return Ok();
        }

            
    }
}
