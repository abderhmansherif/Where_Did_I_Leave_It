using Microsoft.AspNetCore.Mvc;
using Where_Did_I_Leave_It.Application.Abstractions.Commands;
using Where_Did_I_Leave_It.Application.Abstractions.Queries;
using Where_Did_I_Leave_It.Application.Commands.CreateItem;
using Where_Did_I_Leave_It.Application.Commands.EditItemLocation;
using Where_Did_I_Leave_It.Application.Commands.EditItemNote;
using Where_Did_I_Leave_It.Application.Commands.RemoveItem;
using Where_Did_I_Leave_It.Application.DTOs;
using Where_Did_I_Leave_It.Application.Queries.GetItem;
using Where_Did_I_Leave_It.Application.Queries.GetItemHistory;
using Where_Did_I_Leave_It.Application.Queries.GetItems;

namespace Where_Did_I_Leave_It.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public ItemController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        [Route("{ItemName:alpha}")]
        public async Task<IActionResult> Get([FromRoute] GetItemQuery query)
        {
            var item = await _queryDispatcher.DispatchAsync<GetItemQuery, ItemDTO>(query);

            if(item is null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetItemsQuery query)
        {
            var items = await _queryDispatcher.DispatchAsync<GetItemsQuery, List<ItemDTO>>(query);
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateItemCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { ItemName = command.itemName }, null);
        }

        [HttpGet]
        [Route("{itemName:alpha}/History")]
        public async Task<IActionResult> GetHistory([FromRoute] GetItemHistoryQuery query)
        {
            var itemHistory = await _queryDispatcher.DispatchAsync<GetItemHistoryQuery, List<ItemHistoryDTO>>(query);
            return Ok(itemHistory); 
        }

        [HttpPut]
        [Route("{itemName:alpha}/Location")]
        public async Task<IActionResult> Put([FromBody] EditItemLocationCommnad command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return NoContent();
        }

        [HttpPut]
        [Route("{itemName:alpha}/Note")]
        public async Task<IActionResult> Put([FromBody] EditItemNoteCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return NoContent();
        }

        [HttpDelete("{itemName:alpha}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveItemCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return NoContent();
        }


    }
}
