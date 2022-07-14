using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardApiController : ControllerBase
    {
        private readonly ICardApiRepository _cardsRepository;

        public CardApiController(ICardApiRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }
        [HttpDelete("{cardId}")]
        public void DeleteCard(int cardId)
        {
            _cardsRepository.DeleteCard(cardId);
        }
        [HttpGet("{cardId}")]
        public async Task<Card> GetCardById([FromRoute]int cardId)
        {
            return await _cardsRepository.GetCardById(cardId);
        }

        [HttpGet]
        public async Task<IEnumerable<Card>> GetCards()
        {
           return await _cardsRepository.GetCards();
        }
        [HttpPost]
        public void InsertCard([FromBody]Card card)
        {
            _cardsRepository.InsertCard(card);
        }

        [HttpPut]
        public void UpdateCard(Card card)
        {
            _cardsRepository.UpdateCard(card);
        }
    }
}
