using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo.Models;

namespace todo.Controllers
{
    [Route("api/todoItems")]
    [ApiController]
    public class todoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public todoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/todoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<todoItem>>> GetTodoItems()
        {
            return await _context.todoItems.ToListAsync();
        }

        // GET: api/todoItems/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<todoItem>> GettodoItem(long id)
        {
            var todoItem = await _context.todoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/todoItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttodoItem(long id, todoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!todoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
        // DELETE: api/todoItems/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<todoItem>> DeletetodoItem(long id)
        {
            var todoItem = await _context.todoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.todoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }

        private bool todoItemExists(long id)
        {
            return _context.todoItems.Any(e => e.Id == id);
        }
    }
}
