using MagicShopApi.Models;
using MagicShopApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShopApi.Repositories.Interfaces
{
    public interface ISaleRepository : IDisposable
    {
        Task<IEnumerable<SaleDTO>> GetSales();
        ActionResult<SaleDTO> GetSaleById(int saleId);
        void InsertSale(SaleDTO sale);
        void UpdateSale(SaleDTO sale);
        void DeleteSale(int saleId);
        void Save();
        bool Exists(int saleId);
    }
}
