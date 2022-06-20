using MagicShopApi.Contexts;
using MagicShopApi.Models;
using MagicShopApi.Models.DTO;
using MagicShopApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShopApi.Repositories
{
    public class SaleRepository : ISaleRepository, IDisposable
    {
        private readonly MagicShopContext _context;
        private readonly CardRepository _cardRepository;
        private readonly UserRepository _userRepository;
        private readonly IMemoryCache _cache;

        public SaleRepository(MagicShopContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public void DeleteSale(int saleId)
        {
            Sale sale = _context.Sale.Find(saleId);
            _context.Sale.Remove(sale);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Exists(int saleId)
        {
            return _context.Sale.Any(x => x.Id == saleId);
        }

        public ActionResult<SaleDTO> GetSaleById(int saleId)
        {
            var sale = _cache.GetOrCreate("Sales_GetById_" + saleId, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(30);
                entry.SetPriority(CacheItemPriority.Low);
                System.Threading.Thread.Sleep(1000);
                return _context.Sale.Find(saleId);
            });
            return SaleToDTO(sale);
        }

        public async Task<IEnumerable<SaleDTO>> GetSales()
        {
            var sales = _cache.GetOrCreate("Sales_GetAll", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(30);
                entry.SetPriority(CacheItemPriority.Low);
                System.Threading.Thread.Sleep(1000);
                return _context.Sale.ToListAsync();
            });
            return sales.Result.Select(x => SaleToDTO(x));
        }

        public void InsertSale(SaleDTO sale)
        {
            _context.Sale.Add(DTOToSale(sale));
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateSale(SaleDTO sale)
        {
            _context.Entry(sale).State = EntityState.Modified;
        }

        public SaleDTO SaleToDTO(Sale sale)
        {
            SaleDTO dto = new SaleDTO()
            {
                Id = sale.Id,
                CardId = sale.CardId,
                UserId = sale.UserId,
                RequestedValue = sale.RequestedValue
            };
            return dto;
        }

        public Sale DTOToSale(SaleDTO dto)
        {
            Sale sale = new Sale()
            {
                UserId = dto.UserId,
                CardId = dto.CardId,
                RequestedValue = dto.RequestedValue,
                User = _userRepository.GetUserById(dto.UserId).Value,
                Card = _cardRepository.GetCardById(dto.CardId).Value
            };
            return sale;
        }
    }
}
