using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Project
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
        [Route("{Get}")]
        public Task<Player> Get(Guid id)
        {
            return _repository.Get(id.ToString());
        }

        [HttpGet]
        [Route("{GetAll}")]
        public Task<Player[]> GetAll()
        {
            return _repository.GetAll();
        }
        [HttpPost]
        [Route("{Create}")]
        public Task<Player> Create(NewPlayer player)
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
            return _repository.Create(createPlayer);
        }
        [HttpPost]
        [Route("{Modify}")]
        public Task<Player> Modify(Guid id, Player player)
        {
            return _repository.Modify(id.ToString(), player);
        }
        [HttpPost]
        [Route("{Delete}")]
        public Task<Player> Delete(Guid id)
        {
            return _repository.Delete(id.ToString());
        }
        [HttpGet]
        [Route("{GetAllScores}")]

        public Task<Player[]> GetAllPlayerScore()
        {
            return _repository.GetAllPlayerScore();
        }
        [HttpGet]
        [Route("{Score}")]
        public Task<Player> GetPlayerScore(int score)
        {
            return _repository.GetPlayerScore(score);
        }
        [HttpGet]
        [Route("{Name}")]
        public Task<Player> GetPlayerName(string name)
        {
            return _repository.GetPlayerName(name);
        }
        [HttpGet]
        [Route("{Update}")]
        public Task<Player> UpdatePlayername(string name, string name1)
        {
            return _repository.UpdatePlayername(name, name1);
        }
        [HttpPost]
        [Route("{Ban}")]
        public Task<Player> Ban(Guid id, bool banned)
        {
            return _repository.Ban(id.ToString(), banned);
        }
        [HttpGet]
        [Route("{GetBanned}")]
        public Task<Player[]> GetBannedPlayers()
        {
            return _repository.GetBannedPlayers();
        }
        [HttpGet]
        [Route("{GetNotBanned}")]
        public Task<Player[]> GetNotBannedPlayers()
        {
            return _repository.GetNotBannedPlayers();
        }

    }
}