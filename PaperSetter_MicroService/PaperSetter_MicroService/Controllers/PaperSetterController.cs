using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaperSetter_MicroService.Models;

namespace PaperSetter_MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaperSetterController : ControllerBase
    {
        private readonly PaperSetterDbContext _context;

        public PaperSetterController(PaperSetterDbContext context)
        {
            _context = context;
        }

        // GET: api/PaperSetter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaperSetter>>> GetPaperSetter()
        {
          if (_context.PaperSetter == null)
          {
              return NotFound();
          }
            return await _context.PaperSetter.ToListAsync();
        }

        // GET: api/PaperSetter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaperSetter>> GetPaperSetter(int id)
        {
          if (_context.PaperSetter == null)
          {
              return NotFound();
          }
            var paperSetter = await _context.PaperSetter.FindAsync(id);

            if (paperSetter == null)
            {
                return NotFound();
            }

            return paperSetter;
        }

        // PUT: api/PaperSetter/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaperSetter(int id, PaperSetter paperSetter)
        {
            if (id != paperSetter.Id)
            {
                return BadRequest();
            }

            _context.Entry(paperSetter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaperSetterExists(id))
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

        // POST: api/PaperSetter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaperSetter>> PostPaperSetter(PaperSetter paperSetter)
        {
          if (_context.PaperSetter == null)
          {
              return Problem("Entity set 'PaperSetterDbContext.PaperSetter'  is null.");
          }
            _context.PaperSetter.Add(paperSetter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaperSetter", new { id = paperSetter.Id }, paperSetter);
        }

        // DELETE: api/PaperSetter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaperSetter(int id)
        {
            if (_context.PaperSetter == null)
            {
                return NotFound();
            }
            var paperSetter = await _context.PaperSetter.FindAsync(id);
            if (paperSetter == null)
            {
                return NotFound();
            }

            _context.PaperSetter.Remove(paperSetter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaperSetterExists(int id)
        {
            return (_context.PaperSetter?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
