using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoLister.Models;
using ToDoLister.Data;
using AutoMapper;

namespace ToDoLister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IListerRepository _repo;
        private readonly IMapper _mapper;

        public ItemsController(IListerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
        {
            var items = await _repo.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            var item = await _repo.GetItemByIdAsync(id);
            if(item != null)
                return Ok(item);
            else
                return NotFound();
        }

        [HttpPost("")]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
           _repo.CreateEntity(item);
           var saved = await _repo.SaveChangesAsync();
           return Created("api/[controller]", item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            _repo.UpdateEntity(item);
            var saved = await _repo.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItemById(int id)
        {
            var item = new Item{Id=id};
            _repo.DeleteEntity(item);
            var saved = await _repo.SaveChangesAsync();
            return Ok();
            
        }
    }
}