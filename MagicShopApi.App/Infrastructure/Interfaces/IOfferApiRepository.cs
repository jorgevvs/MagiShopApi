using MagicShop.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure.Interfaces
{
    public interface IOfferApiRepository
    {
        Task<IEnumerable<Offer>> GetOffers();
        Task<Offer> GetOfferById(int offerId);
        Task InsertOffer(Offer offer);
        Task UpdateOffer(Offer offer);
        Task DeleteOffer(int offerId);
    }
}
