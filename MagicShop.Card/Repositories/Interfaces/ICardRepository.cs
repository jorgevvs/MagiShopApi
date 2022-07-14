using MagicShop.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.CardAPI.Repositories.Interfaces
{
    public interface ICardRepository : IBaseRepository<Card>,IDisposable
    {
        Task<bool> Exists(int id);
    }
}
