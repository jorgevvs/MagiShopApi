using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleApiController : ControllerBase
    {
        private readonly ISaleApiRepository _salesRepository;

        public SaleApiController(ISaleApiRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }
        [HttpDelete("{saleId}")]
        public async Task DeleteSale(int saleId)
        {
            await _salesRepository.DeleteSale(saleId);
        }
        [HttpGet("{saleId}")]
        public async Task<Sale> GetSaleById([FromRoute] int saleId)
        {
            return await _salesRepository.GetSaleById(saleId);
        }

        [HttpGet]
        public async Task<IEnumerable<Sale>> GetSales()
        {
            return await _salesRepository.GetSales();
        }
        [HttpPost]
        public async Task InsertSale([FromBody] Sale sale)
        {
            await _salesRepository.InsertSale(sale);
        }

        [HttpPut]
        public async Task UpdateSale(Sale sale)
        {
            await _salesRepository.UpdateSale(sale);
        }

        [HttpPatch("match")]
        public async Task MatchSale([FromBody] PutMatchOrderWithSaleBodyRequest bodyRequest)
        {
            await _salesRepository.MatchSale(bodyRequest);
        }
    }
}
