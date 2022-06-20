using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MagicShopApi.Contexts;
using MagicShopApi.Models;
using MagicShopApi.Repositories;
using MagicShopApi.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace MagicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : Controller
    {
        private readonly IOfferRepository _offerRepository;

        public OffersController(MagicShopContext context, IMemoryCache cache)
        {
            _offerRepository = new OfferRepository(context, cache);
        }

        // GET: api/offers
        [HttpGet]
        public Task<IEnumerable<Offer>> GetOffer()
        {
            return _offerRepository.GetOffers();
        }

        // GET: api/offers/5
        [HttpGet("{id}")]
        public ActionResult<Offer> GetOffer(int id)
        {
            return _offerRepository.GetOfferById(id);
        }

        // PUT: api/offers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffer(int id, Offer offer)
        {
            if (id != offer.Id)
            {
                return BadRequest();
            }

            _offerRepository.UpdateOffer(offer);

            try
            {
                _offerRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(id))
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

        // POST: api/offers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Offer>> PostOffer(Offer offer)
        {
            _offerRepository.InserOffer(offer);
            _offerRepository.Save();

            return CreatedAtAction("GetOffer", new { id = offer.Id }, offer);
        }

        // DELETE: api/offers/5
        [HttpDelete("{id}")]
        public ActionResult<Offer> DeleteOffer(int id)
        {
            var offer = _offerRepository.GetOfferById(id);
            if (offer == null)
            {
                return NotFound();
            }

            _offerRepository.DeleteOffer(id);
            _offerRepository.Save();

            return NoContent();
        }

        private bool OfferExists(int id)
        {
            return _offerRepository.Exists(id);
        }
    }
}
