using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
namespace GameWebApi
{
    [ApiController]
    [Route("api/players/{playerId}/items")]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IRepository _repository;
        public ItemsController(ILogger<ItemsController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        [Route("{Get}")]
        public Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            return _repository.GetItem(playerId, itemId);
        }
        [HttpGet]
        [Route("{GetAll}")]
        public Task<Item[]> GetAllitems(Guid playerId)
        {
            return _repository.GetAllItems(playerId);
        }
        [HttpPost]
        [Route("{Create}")]
        public Task<Item> CreateItem(Guid playerId, NewItem item)
        {
            Item createItem = new Item() { Id = Guid.NewGuid(), Name = item.Name };
            return _repository.CreateItem(playerId, createItem);
        }
        [HttpPost]
        [Route("{Modify}")]
        public Task<Item> UpdateItem(Guid playerId, ModifiedItem item)
        {
            return _repository.UpdateItem(playerId, item);
        }
        [HttpPost]
        [Route("{Delete}")]
        public Task<Item> DeleteItem(Guid playerId, Item item)
        {
            return _repository.DeleteItem(playerId, item);
        }
    }
}