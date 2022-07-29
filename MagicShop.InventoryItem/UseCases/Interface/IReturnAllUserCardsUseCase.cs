using MagicShop.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.InventoryItemAPI.UseCases.Interface
{
    public interface IReturnAllUserCardsUseCase
    {
        Task<IList<InventoryItem>> Execute(int userId);
    }
}
