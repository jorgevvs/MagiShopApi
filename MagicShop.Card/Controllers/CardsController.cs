using MagicShop.CardAPI.Contexts;
using MagicShop.CardAPI.Repositories;
using MagicShop.CardAPI.Repositories.Interfaces;
using MagicShop.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.CardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : Controller
    {
        private readonly ICardRepository _cardRepository;

        public CardsController(CardContext context, IMemoryCache memoryCache)
        {
            this._cardRepository = new CardRepository(context, memoryCache);
        }

        // GET: api/Cards
        [HttpGet]
        public Task<IEnumerable<Card>> GetAllCards()
        {
            return _cardRepository.GetAll();
        }

        //// GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            return await _cardRepository.GetById(id);
        }

        //// PUT: api/Cards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard([FromRoute]int id, [FromBody]Card card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }

            await _cardRepository.Update(card);

            try
            {
                await _cardRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id).Result)
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

        //// POST: api/Cards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard([FromBody]Card card)
        {
            await _cardRepository.Insert(card);
            await _cardRepository.Save();

            return CreatedAtAction("GetCard", new { id = card.Id }, card);
        }

        //// DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Card>> DeleteCard(int id)
        {
            var card = await _cardRepository.GetById(id);
            if (card == null)
            {
                return NotFound();
            }

            await _cardRepository.Delete(id);
            await _cardRepository.Save();

            return card;
        }

        private async Task<bool> CardExists(int id)
        {
            return await _cardRepository.Exists(id);
        }
    }
}
