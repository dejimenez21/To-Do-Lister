using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoLister.Models;
using ToDoLister.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using TodoLister.Dtos;
using System.Security.Claims;
using Microsoft.AspNetCore.JsonPatch;

namespace ToDoLister.Controllers
{
    [Authorize]
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
            
            var items = await _repo.GetAllItemsAsync(User.Identity.Name);
            var itemRead = items.Select(item=>_mapper.Map<ItemReadDto>(item));
            return Ok(itemRead);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            var item = await _repo.GetItemByIdAsync(id);
            if(item != null)
            {
                var itemRead = _mapper.Map<ItemReadDto>(item);
                return Ok(itemRead);
            }  
            else
                return NotFound();
        }

        [HttpPost("")]
        public async Task<ActionResult<Item>> CreateItem(ItemCreateDto itemCreate)
        {
            var item = _mapper.Map<Item>(itemCreate);
            item.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _repo.CreateItem(item);
            var saved = await _repo.SaveChangesAsync();
            var itemRead = _mapper.Map<ItemReadDto>(item);
            return Created("api/[controller]", itemRead);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ItemUpdateDto itemToUpdate)
        {
            var item = _mapper.Map<Item>(itemToUpdate);
            item.Id = id;
            _repo.UpdateItem(item);
            var saved = await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItemById(int id)
        {
            var item = new Item{Id=id};
            _repo.DeleteEntity(item);
            var saved = await _repo.SaveChangesAsync();
            return Ok();
            
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialItemUpdate(int id, JsonPatchDocument<ItemUpdateDto> patchDoc)
        {
            var itemModelFromRepo = await _repo.GetItemByIdAsync(id);
            if(itemModelFromRepo == null)
                return NotFound(new {message="El item no existe"});

            var itemToPatch = _mapper.Map<ItemUpdateDto>(itemModelFromRepo);
            patchDoc.ApplyTo(itemToPatch, ModelState);

            if(!TryValidateModel(itemToPatch))
            {
                return ValidationProblem();
            }

            _mapper.Map(itemToPatch, itemModelFromRepo);
            _repo.UpdateItem(itemModelFromRepo);
            await _repo.SaveChangesAsync();

            return NoContent();
        }

    }
}