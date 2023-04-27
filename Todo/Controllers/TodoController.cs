using System;
using Microsoft.AspNetCore.Mvc;
using Todo.models;
using Todo.Services;

namespace Todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(int id)
        {
            var item = await _service.GetTodoItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem(TodoItem item)
        {
            await _service.CreateTodoItem(item);

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, TodoItem item)
        {
            try
            {
                await _service.UpdateTodoItem(id, item);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            try
            {
                await _service.DeleteTodoItem(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}

