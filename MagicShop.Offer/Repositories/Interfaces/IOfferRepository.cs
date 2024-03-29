﻿using MagicShop.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.OfferAPI.Repositories.Interfaces
{
    public interface IOfferRepository : IDisposable
    {
        Task<IEnumerable<Offer>> GetOffers();
        ActionResult<Offer> GetOfferById(int offerId);
        void InserOffer(Offer offer);
        void UpdateOffer(Offer offer);
        void DeleteOffer(int offerId);
        void Save();
        bool Exists(int offerId);
    }
}
