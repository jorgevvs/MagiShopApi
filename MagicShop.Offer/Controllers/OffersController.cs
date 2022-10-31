using System.Collections.Generic;
using System.Threading.Tasks;
using MagicShop.Common.Entities;
using MagicShop.OfferAPI.Contexts;
using MagicShop.OfferAPI.Repositories;
using MagicShop.OfferAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace MagicShop.OfferAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : Controller
    {
        private readonly IOfferRepository _offerRepository;

        public OffersController(OfferContext context, IMemoryCache cache)
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
        public async Task<IActionResult> PutOffer(int id, Offer offer) {
            if (id != offer.Id) {
                return BadRequest();
            }
            
            if (!OfferExists(id)) {
                return NotFound();
            }

            _offerRepository.UpdateOffer(offer);
            _offerRepository.Save();
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
