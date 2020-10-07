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
        [Route("Get/{id:Guid}")]
        public async Task<Player> Get(Guid id)
        {
            return await _repository.Get(id.ToString());
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
        [Route("Delete/{id:Guid}")]
        public async Task<Player> Delete(Guid id)
        {
            return await _repository.Delete(id.ToString());
        }
        [HttpGet]
        [Route("GetAllScores")]

        public async Task<Player[]> GetAllPlayerScore()
        {
            return await _repository.GetAllPlayerScore();
        }
        [HttpGet]
        [Route("getplayerscore/{score:int}")]
        public async Task<Player> GetPlayerScore(int score)
        {
            return await _repository.GetPlayerScore(score);
        }
        [HttpGet]
        [Route("getplayername/{name}")]
        public async Task<Player> GetPlayerName(string name)
        {
            return await _repository.GetPlayerName(name);
        }
        [HttpPost]
        [Route("Update/{name,name1}")]
        public async Task<Player> UpdatePlayername(string name, string name1)
        {
            return await _repository.UpdatePlayername(name, name1);
        }
        [HttpPost]
        [Route("ban/{id:Guid}")]
        public async Task<Player> Ban(Guid id)
        {
            return await _repository.Ban(id.ToString());
        }
        [HttpPost]
        [Route("unban/{id:Guid}")]
        public async Task<Player> UnBan(Guid id)
        {
            return await _repository.UnBan(id.ToString());
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