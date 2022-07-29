using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderMatchSaleWorker.Repositories;
using OrderMatchSaleWorker.Repositories.Interfaces;
using OrderMatchSaleWorker.UseCase;
using OrderMatchSaleWorker.UseCase.Interface;


namespace OrderMatchSaleWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<IOrderRepository, OrderRepository>();
                    services.AddTransient<ISaleRepository, SaleRepository>();
                    services.AddTransient<IInventoryItemRepository, InventoryItemRepository>();
                    services.AddTransient<IMatchOrderWithSaleUseCase, MatchOrderWithSaleUseCase>();
                });
    }
}
