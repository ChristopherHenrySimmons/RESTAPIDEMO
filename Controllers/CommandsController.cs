using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPIDEMO.Models;

namespace RESTAPIDEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly DevelopmentUtilitiesV1Context _context;

        public CommandsController(DevelopmentUtilitiesV1Context context)
        {
            _context = context;
        }

        // GET: api/Commands
        [HttpGet]
        public async Task<CommandList> GetCommands()
        {
               CommandList returnable = new CommandList();
               returnable.commandList = await _context.Commands.ToListAsync();
               return returnable;
          }

        // GET: api/Commands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commands>> GetCommands(int id)
        {
            var commands = await _context.Commands.FindAsync(id);

            if (commands == null)
            {
                return NotFound();
            }

            return commands;
        }

        // PUT: api/Commands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommands(int id, Commands commands)
        {
            if (id != commands.Id)
            {
                return BadRequest();
            }

            _context.Entry(commands).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandsExists(id))
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

        // POST: api/Commands
        [HttpPost]
        public async Task<ActionResult<Commands>> PostCommands(Commands commands)
        {
            _context.Commands.Add(commands);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommands", new { id = commands.Id }, commands);
        }

        // DELETE: api/Commands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Commands>> DeleteCommands(int id)
        {
            var commands = await _context.Commands.FindAsync(id);
            if (commands == null)
            {
                return NotFound();
            }

            _context.Commands.Remove(commands);
            await _context.SaveChangesAsync();

            return commands;
        }

        private bool CommandsExists(int id)
        {
            return _context.Commands.Any(e => e.Id == id);
        }
    }
}
