using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderMatchSaleWorker.UseCase.Interface
{
    public interface IMatchOrderWithSaleUseCase
    {
        Task Execute();
    }
}
