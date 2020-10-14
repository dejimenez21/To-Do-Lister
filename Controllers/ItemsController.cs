using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoLister.Models;

namespace ToDoLister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public ItemsController()
        {
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            
            await Task.Yield();

            return new List<Item> { };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            
            await Task.Yield();

            return null;
        }

        [HttpPost("")]
        public async Task<ActionResult<Item>> PostItem(Item model)
        {
            await Task.Yield();

            return null;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item model)
        {
            await Task.Yield();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItemById(int id)
        {
            
            await Task.Yield();

            return null;
        }
    }
}