using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Project.Controllers
{
    [ApiController]
    [Route("api/player")]
    public class PlayerController : ControllerBase
    {

        private readonly ILogger<PlayerController> _logger;
        private readonly Irepository _repository;
        public PlayerController(ILogger<PlayerController> logger, Irepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<Player> Get([FromBody] Player player)
        {
            return await _repository.Get(player);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<Player[]> GetAll()
        {
            return await _repository.GetAll();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<Player> Create([FromBody] NewPlayer player)
        {
            Player createPlayer = new Player()
            {
                Id = Guid.NewGuid().ToString(),
                Name = player.Name,
                Score = 0,
                IsBanned = false,
                CreationTime = DateTime.UtcNow,
                Level = 0
            };
            return await _repository.Create(createPlayer);
        }
        [HttpPost]
        [Route("modify")]
        public async Task<Player> Modify([FromBody] Player player)
        {
            return await _repository.Modify(player);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<Player> Delete([FromBody] Player player)
        {
            return await _repository.Delete(player);
        }
        [HttpGet]
        [Route("GetAllScores")]

        public async Task<Player[]> GetAllPlayerScore()
        {
            return await _repository.GetAllPlayerScore();
        }
        [HttpGet]
        [Route("getplayerscore")]
        public async Task<Player> GetPlayerScore([FromBody] Player player)
        {
            return await _repository.GetPlayerScore(player);
        }
        [HttpGet]
        [Route("getplayername")]
        public async Task<Player> GetPlayerName([FromBody] Player player)
        {
            return await _repository.GetPlayerName(player);
        }
        [HttpPost]
        [Route("Update")]
        public async Task<Player> UpdatePlayername([FromBody] Player player, string name1)
        {
            return await _repository.UpdatePlayername(player, name1);
        }
        [HttpPost]
        [Route("ban")]
        public async Task<Player> Ban([FromBody] Player player)
        {
            return await _repository.Ban(player);
        }
        [HttpPost]
        [Route("unban")]
        public async Task<Player> UnBan([FromBody] Player player)
        {
            return await _repository.UnBan(player);
        }
        [HttpGet]
        [Route("GetBanned")]
        public async Task<Player[]> GetBannedPlayers()
        {
            return await _repository.GetBannedPlayers();
        }
        [HttpGet]
        [Route("GetNotBanned")]
        public async Task<Player[]> GetNotBannedPlayers()
        {
            return await _repository.GetNotBannedPlayers();
        }

    }
}