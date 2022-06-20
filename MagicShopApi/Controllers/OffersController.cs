using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MagicShopApi.Contexts;
using MagicShopApi.Models;
using MagicShopApi.Models.DTO;

namespace MagicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly MagicShopContext _context;

        public OffersController(MagicShopContext context)
        {
            _context = context;
        }

        // GET: api/offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferDTO>>> GetOffer()
        {
            return await _context.Offer.Select(x => OfferToDTO(x)).ToListAsync();
        }

        // GET: api/offers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDTO>> GetOffer(int id)
        {
            var offer = await _context.Offer.FindAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            return OfferToDTO(offer);
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

            _context.Entry(offer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
        public async Task<ActionResult<OfferDTO>> PostOffer(Offer offerDTO)
        {
            var offer = new Offer
            {
                SaleId = offerDTO.SaleId,
                UserId = offerDTO.UserId,
                Value = offerDTO.Value
            };
            _context.Offer.Add(offer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffer", new { id = offer.Id }, offer);
        }

        // DELETE: api/offers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var offer = await _context.Offer.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            _context.Offer.Remove(offer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfferExists(int id)
        {
            return _context.Offer.Any(e => e.Id == id);
        }

        private static OfferDTO OfferToDTO(Offer offer) =>
            new OfferDTO
            {
                Id = offer.Id,
                Value = offer.Value,
                UserId = offer.UserId,
                SaleId = offer.SaleId
            };
    }
}
