using MagicShopApi.Contexts;
using MagicShopApi.Interfaces.Repositories;
using MagicShopApi.Models;
using MagicShopApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : Controller
    {
        private readonly ICardRepository _cardRepository;

        public CardsController(MagicShopContext context, IMemoryCache memoryCache)
        {
            this._cardRepository = new CardRepository(context, memoryCache);
        }

        // GET: api/Cards
        [HttpGet]
        public Task<IEnumerable<Card>> GetCard()
        {
            return _cardRepository.GetCards();
        }

        //// GET: api/Cards/5
        [HttpGet("{id}")]
        public ActionResult<Card> GetCard(int id)
        {
            return _cardRepository.GetCardById(id);
        }

        //// PUT: api/Cards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }

            _cardRepository.UpdateCard(card);

            try
            {
                _cardRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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
        public async Task<ActionResult<Card>> PostCard(Card card)
        {
            _cardRepository.InsertCard(card);
            _cardRepository.Save();

            return CreatedAtAction("GetCard", new { id = card.Id }, card);
        }

        //// DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public ActionResult<Card> DeleteCard(int id)
        {
            var card = _cardRepository.GetCardById(id);
            if (card == null)
            {
                return NotFound();
            }

            _cardRepository.DeleteCard(id);
            _cardRepository.Save();

            return card;
        }

        private bool CardExists(int id)
        {
            return _cardRepository.Exists(id);
        }
    }
}
