using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrderMatchSaleWorker.UseCase.Interface;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderMatchSaleWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMatchOrderWithSaleUseCase _useCase;

        public Worker(ILogger<Worker> logger, IMatchOrderWithSaleUseCase useCase)
        {
            _logger = logger;
            _useCase = useCase;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(10000, stoppingToken);
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Worker running at: {time}", PegaHoraBrasilia());
                    await _useCase.Execute();
                }catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                }
                
                await Task.Delay(10000, stoppingToken);
            }
        }

        public DateTime PegaHoraBrasilia() {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo"));
         }
    }
}
