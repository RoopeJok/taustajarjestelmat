using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
namespace GameWebApi
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly IRepository _repository;
        public PlayersController(ILogger<PlayersController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        [Route("{Get}")]
        public Task<Player> Get(Guid id)
        {
            return _repository.Get(id);
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
            Player createPlayer = new Player() { Id = Guid.NewGuid(), Name = player.Name }
            return _repository.Create(createPlayer);
        }
        [HttpPost]
        [Route("{Modify}")]
        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            return _repository.Modify(id, player);
        }
        [HttpPost]
        [Route("{Delete}")]
        public Task<Player> Delete(Guid id)
        {
            return _repository.Delete(id);
        }
    }
}