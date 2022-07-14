using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferApiController : ControllerBase
    {
        private readonly IOfferApiRepository _offersRepository;

        public OfferApiController(IOfferApiRepository offersRepository)
        {
            _offersRepository = offersRepository;
        }
        [HttpDelete("{offerId}")]
        public async Task DeleteOffer(int offerId)
        {
            await _offersRepository.DeleteOffer(offerId);
        }
        [HttpGet("{offerId}")]
        public async Task<Offer> GetOfferById([FromRoute] int offerId)
        {
            return await _offersRepository.GetOfferById(offerId);
        }

        [HttpGet]
        public async Task<IEnumerable<Offer>> GetOffers()
        {
            return await _offersRepository.GetOffers();
        }
        [HttpPost]
        public async Task InsertOffer([FromBody] Offer offer)
        {
            await _offersRepository.InsertOffer(offer);
        }

        [HttpPut]
        public async Task UpdateOffer(Offer offer)
        {
            await _offersRepository.UpdateOffer(offer);
        }
    }
}
