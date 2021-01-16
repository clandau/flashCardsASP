using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlashCardsAPI.Models;

namespace FlashCardsAPI.Controllers
{
    [Route("api/FlashCards")]
    [ApiController]
    public class FlashCardsController : ControllerBase
    {
        private readonly FlashCardContext _context;

        public FlashCardsController(FlashCardContext context)
        {
            _context = context;
        }

        // GET: api/FlashCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlashCard>>> GetFlashCardItems()
        {
            return await _context.FlashCardItems.ToListAsync();
        }

        // GET: api/FlashCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlashCard>> GetFlashCard(int id)
        {
            var flashCard = await _context.FlashCardItems.FindAsync(id);

            if (flashCard == null)
            {
                return NotFound();
            }

            return flashCard;
        }

        // PUT: api/FlashCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlashCard(int id, FlashCard flashCard)
        {
            if (id != flashCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(flashCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlashCardExists(id))
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

        // POST: api/FlashCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlashCard>> PostFlashCard(FlashCard flashCard)
        {
            _context.FlashCardItems.Add(flashCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFlashCard), new { id = flashCard.Id }, flashCard);
        }

        // DELETE: api/FlashCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlashCard(int id)
        {
            var flashCard = await _context.FlashCardItems.FindAsync(id);
            if (flashCard == null)
            {
                return NotFound();
            }

            _context.FlashCardItems.Remove(flashCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlashCardExists(int id)
        {
            return _context.FlashCardItems.Any(e => e.Id == id);
        }
    }
}
